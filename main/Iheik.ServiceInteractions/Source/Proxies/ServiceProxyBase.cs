using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Iheik.Utilities.Extensions;

namespace Iheik.ServiceInteractions.Proxies
{
    public abstract class ServiceProxyBase<T> : IDisposable where T : class
    {
        // properties
        private readonly string _serviceEndPointUri;
        private readonly int _timeoutInSeconds;
        private readonly string _serviceUserName;
        private readonly string _servicePassword;
        private readonly object _sync = new object();
        private IChannelFactory<T> _channelFactory;
        private T _channel;
        private bool _disposed = false;
        

        protected ServiceProxyBase(string serviceEndPointUri, int timeoutInSeconds, string userName = "", string password = "")
        {
            _serviceEndPointUri = serviceEndPointUri;
            _timeoutInSeconds = timeoutInSeconds;
            _serviceUserName = userName;
            _servicePassword = password;
        }

        #region IDisposable

        ~ServiceProxyBase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposedManaged)
        {
            if (_disposed)
            {
                return;
            }

            if (disposedManaged)
            {
                lock (_sync)
                {
                    CloseChannel();

                    if (_channelFactory != null)
                    {
                        ((IDisposable)_channelFactory).Dispose();
                    }

                    _channel = null;
                    _channelFactory = null;
                }
            }

            _disposed = true;
        }

        #endregion

        /// <summary>
        /// Gets the channel.
        /// </summary>
        protected T Channel
        {
            get
            {
                Initialise();

                return _channel;
            }
        }

        /// <summary>
        /// Closes the channel.
        /// </summary>
        protected void CloseChannel()
        {
            if (_channel != null)
            {
                ((ICommunicationObject)_channel).Close();
            }
        }

        /// <summary>
        /// Initialises this instance.
        /// </summary>
        private void Initialise()
        {
            lock (_sync)
            {
                if (_channel != null)
                {
                    return;
                }

                // certificate setup
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(OnValidationCallback);

                // binding setup
                var binding = new BasicHttpBinding();

                if (_serviceEndPointUri.Contains("https:", StringComparison.OrdinalIgnoreCase))
                {
                    binding.Security.Mode = BasicHttpSecurityMode.Transport;
                }

                // Nick; binding override needs to be added
                _channelFactory = new ChannelFactory<T>(binding);

                // check for username and password
                if (!string.IsNullOrEmpty(_serviceUserName) && !string.IsNullOrEmpty(_servicePassword))
                {
                    // find and remove default endpoint behavior 
                    var defaultCredentials = ((ChannelFactory)_channelFactory).Endpoint.Behaviors.Find<ClientCredentials>();
                    ((ChannelFactory)_channelFactory).Endpoint.Behaviors.Remove(defaultCredentials);

                    // instantiate your credentials
                    var loginCredentials = new ClientCredentials();
                    loginCredentials.UserName.UserName = _serviceUserName;
                    loginCredentials.UserName.Password = _servicePassword;

                    // set that as new endpoint behavior on factory
                    ((ChannelFactory)_channelFactory).Endpoint.Behaviors.Add(loginCredentials);
                }

                _channel = _channelFactory.CreateChannel(new EndpointAddress(_serviceEndPointUri));

                ((IContextChannel)_channel).OperationTimeout = new TimeSpan(0, 0, _timeoutInSeconds);
            }
        }


        private static bool OnValidationCallback(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

    }
}
