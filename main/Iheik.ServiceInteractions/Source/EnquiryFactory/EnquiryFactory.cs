using System;
using System.Collections.Generic;
using Castle.Core.Logging;
using Iheik.ServiceInteractions.ServiceContracts.EnquiryType;
using Iheik.ServiceInteractions.Pocos;
using Iheik.ServiceInteractions.Constants;
using Iheik.ServiceInteractions.Extensions;
using Iheik.ServiceInteractions.Enums;
using Iheik.Utilities;
using Iheik.Utilities.Helpers;
using Iheik.ServiceInteractions.Proxies;

namespace Iheik.ServiceInteractions.EnquiryFactory
{
    /// <summary>
    /// EnquiryFactory class handles the sending the Enquiry to either Siebel or Email to customer services.
    /// </summary>
    public class EnquiryFactory : IDisposable
    {
        private bool _disposed = false;
        private ILogger _logger = NullLogger.Instance;

        public ILogger Logger
        {
            get { return _logger; }
            set { _logger = value; }
        }

        private IEnumerable<IntegrationSystemConfigurationPoco> SystemConfigs { get; set; }
        private string EnquiryEndPoint { get; set; }
        private string EnquiryUserId { get; set; }
        private string EnquiryPassword { get; set; }
        private int EnquiryTimeout { get; set; }
        private string EnquiryMethod { get; set; }

        public EnquiryFactory(ILogger logger, IEnumerable<IntegrationSystemConfigurationPoco> systemConfigs)
        {
            Logger = logger;
            SystemConfigs = systemConfigs;

            // set the configs
            EnquiryEndPoint = SystemConfigs.GetValue(InfrastructureConstants.SiebelCustomerEnquiryEndpoint);
            EnquiryUserId = SystemConfigs.GetValue(InfrastructureConstants.SiebelCustomerEnquiryUserId);
            EnquiryPassword = SystemConfigs.GetValue(InfrastructureConstants.SiebelCustomerEnquiryPassword);
            EnquiryTimeout = Int32.Parse(SystemConfigs.GetValue(InfrastructureConstants.SiebelCustomerEnquiryTimeout));
            EnquiryMethod = SystemConfigs.GetValue(InfrastructureConstants.SiebelCustomerEnquiryMethod);

            Logger.DebugFormat("EnquiryFactory created with configuration values EnquiryEndPoint: {0}; EnquiryUserId: {1}; EnquiryPassword: {2}; EnquiryTimeout: {3}; EnquiryMethod: {4}.", EnquiryEndPoint, EnquiryUserId, EnquiryPassword, EnquiryTimeout, EnquiryMethod);
        }

        #region IDisposable

        ~EnquiryFactory()
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
                SystemConfigs = null;
                Logger = NullLogger.Instance;
            }

            _disposed = true;
        }

        #endregion

        /// <summary>
        /// Creates the enquiry for customer.
        /// </summary>
        /// <param name="integrationEnquiry">The integration enquiry.</param>
        /// <returns>EnquiryResult object.</returns>
        public EnquiryResult CreateEnquiryForCustomer(IntegrationEnquiry integrationEnquiry)
        {
            Logger.InfoFormat("EnquiryFactory.CreateEnquiryForCustomer executing, with params integrationEnquiry, object contains: {0}.", integrationEnquiry.ToString());

            EnquiryResult enquiryResult = null;

            // check for you manual email process engaged
            if (EnquiryMethod.Equals("XML", StringComparison.OrdinalIgnoreCase))
            {
                EnquiryRequest enquiryRequest = BuildSiebelEnquiryRequest(integrationEnquiry);
                EnquiryResponse enquiryResponse = null;

                var xmlPacket = SerializationHelper.ConvertToXml(enquiryRequest);
                Logger.InfoFormat("EnquiryFactory.CreateEnquiryForCustomer executing XML{0}.", xmlPacket);
                try
                {
                    // call enquiry method via the channel factory
                    using (var proxy = new EnquiryProxy(EnquiryEndPoint, EnquiryTimeout))
                    {
                        enquiryResponse = proxy.Enquiry(enquiryRequest);
                    }
                }
                catch (Exception ex)
                {
                    // log error
                    Logger.Error("EnquiryFactory.CreateEnquiryForCustomer threw an exception.", ex);
                }

                enquiryResult = ProcessResponse(enquiryResponse);
            }
            else
            {
                enquiryResult = new EnquiryResult
                {
                    EnquiryNumber = string.Empty,
                    ResultStatus = ResultStatus.EmailRequired  // nothing to do Domain will email
                };
            }

            return enquiryResult;
        }

        /// <summary>
        /// Processes the response.
        /// </summary>
        /// <param name="enquiryResponse">The enquiry response.</param>
        /// <returns>EnquiryResult object populated from the web service response.</returns>
        private EnquiryResult ProcessResponse(EnquiryResponse enquiryResponse)
        {
            Logger.Debug("EnquiryFactory.ProcessResponse executing.");

            EnquiryResult enquiryResult = new EnquiryResult();

            if (enquiryResponse != null)
            {
                if (!string.IsNullOrEmpty(enquiryResponse.EnquiryNumber))
                {
                    enquiryResult.ResultStatus = ResultStatus.Success;
                    enquiryResult.EnquiryNumber = enquiryResponse.EnquiryNumber.Replace("Your enquiry reference is:", "").Trim();
                }
                else
                {
                    string returnedError = "UNDEFINED";
                    string errorDescription = "UNDEFINED";

                    if (enquiryResponse.Error != null)
                    {
                        returnedError = enquiryResponse.Error;
                        errorDescription = enquiryResponse.ErrorDescription ?? "UNDEFINED";
                    }

                    enquiryResult.ResultStatus = ResultStatus.Error;
                    enquiryResult.Errors = new List<string> { returnedError, errorDescription };

                    Logger.ErrorFormat("EnquiryFactory.ProcessResponse failed with Error: {0}; ErrorDescription: {1}.", returnedError, errorDescription);
                }
            }
            else
            {
                string returnedError = "UNDEFINED";
                string errorDescription = "UNDEFINED";

                if (enquiryResponse.Error != null)
                {
                    returnedError = enquiryResponse.Error;
                    errorDescription = enquiryResponse.ErrorDescription ?? "UNDEFINED";
                }

                enquiryResult.ResultStatus = ResultStatus.Error;
                enquiryResult.Errors = new List<string> { returnedError, errorDescription };

                // log the error
                Logger.ErrorFormat("EnquiryFactory.ProcessResponse failed with Error: {0}; ErrorDescription: {1}.", returnedError, errorDescription);
            }

            return enquiryResult;
        }

        /// <summary>
        /// Builds the Siebel enquiry request.
        /// </summary>
        /// <param name="integrationEnquiry">The integration enquiry.</param>
        /// <returns>EnquiryRequest contract object for web service call.</returns>
        private EnquiryRequest BuildSiebelEnquiryRequest(IntegrationEnquiry integrationEnquiry)
        {
            Logger.DebugFormat("EnquiryFactory.BuildSiebelEnquiryRequest executing, with params integrationEnquiry, object contains: {0}.", integrationEnquiry.ToString());

            // long-hand copy over properties from the Integration DTO
            var enquiry = new Enquiry
            {
                EnquiryType = integrationEnquiry.EnquiryType,
                ProductService = integrationEnquiry.ProductService,
                EnquiryAbout = integrationEnquiry.EnquiryAbout,
                BookingId = integrationEnquiry.BookingId.Replace("PRIO:", "").Replace("FAST:", ""),
                Connote = integrationEnquiry.Connote,
                CollectionDate = DateHelper.FormatForSiebelDateAndTime(integrationEnquiry.CollectionDate),
                TATLNumber = integrationEnquiry.TATLNumber,
                EnquiryNumber = integrationEnquiry.EnquiryNumber,
                CustomerReference1 = integrationEnquiry.CustomerReference1,
                CustomerReference2 = integrationEnquiry.CustomerReference2,
                EnquiryMessage = integrationEnquiry.EnquiryMessage,
                ExistingCustomer = integrationEnquiry.ExistingCustomer,
                AccountId = integrationEnquiry.AccountId,
                CompanyName = integrationEnquiry.CompanyName,
                ContactFirstName = integrationEnquiry.ContactFirstName,
                ContactLastName = integrationEnquiry.ContactLastName,
                ContactNumber = integrationEnquiry.ContactNumber,
                ContactEmailAddress = integrationEnquiry.ContactEmailAddress,
                Country = integrationEnquiry.Country,
                State = integrationEnquiry.State,
                TownCity = integrationEnquiry.TownCity,
                LocalityProvince = integrationEnquiry.LocalityProvince,
                Locality = integrationEnquiry.Locality,
                ROWCountry = integrationEnquiry.ROWCountry,
            };

            // build the request for the web service call
            var enquiryRequest = new EnquiryRequest
            {
                Enquiry = enquiry,
            };

            return enquiryRequest;
        }

    }
}
