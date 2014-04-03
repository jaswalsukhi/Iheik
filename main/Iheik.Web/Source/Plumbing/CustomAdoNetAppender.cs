using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net.Appender;
using System.Configuration;

namespace Iheik.Plumbing
{
    /// <summary>
    /// This class will enable Logger to use existing connecting string rather than creating one more
    /// http://kenny-bu.blogspot.com.au/2011/03/using-connection-string-name-with.html
    /// config will look like
    /// <log4net>
    //    <root>
    //        <level value="DEBUG" />
    //        <appender-ref ref="ADONetAppender" />
    //    </root>
    //    <appender name="ADONetAppender" type="log4net.Appender.ADONetAppender">
    //        <bufferSize value="10" />
    //        <connectionType value="System.Data.SqlClient.SqlConnection, System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
    //        <commandType value="StoredProcedure" />
    //        <commandText value="dbo.[usp_InsertApplicationLog]" />
    //        <parameter>
    //            <parameterName value="@Thread"/>
    //            <dbType value="String"/>
    //            <size value="255"/>
    //            <layout type="log4net.Layout.PatternLayout">
    //                <conversionPattern value="%thread"/>
    //            </layout>
    //        </parameter>
    //        <parameter>
    //            <parameterName value="@Level"/>
    //            <dbType value="String"/>
    //            <size value="50"/>
    //            <layout type="log4net.Layout.PatternLayout">
    //                <conversionPattern value="%level"/>
    //            </layout>
    //        </parameter>
    //        <parameter>
    //            <parameterName value="@Logger"/>
    //            <dbType value="String"/>
    //            <size value="255"/>
    //            <layout type="log4net.Layout.PatternLayout">
    //                <conversionPattern value="%logger"/>
    //            </layout>
    //        </parameter>
    //        <parameter>
    //            <parameterName value="@Message"/>
    //            <dbType value="String"/>
    //            <size value="4000"/>
    //            <layout type="log4net.Layout.PatternLayout">
    //                <conversionPattern value="%message"/>
    //            </layout>
    //        </parameter>
    //        <parameter>
    //            <parameterName value="@Exception"/>
    //            <dbType value="String"/>
    //            <size value="2000"/>
    //            <layout type="log4net.Layout.ExceptionLayout"/>
    //        </parameter>
    //    </appender>
    //</log4net>
    /// 
    /// 
    /// 
    /// 
    /// ApplicationLog table can be created by using
    /// /****** Object:  Table [dbo].[ApplicationLog]    Script Date: 03/26/2014 11:20:36 ******/
    //SET ANSI_NULLS ON
    //GO

    //SET QUOTED_IDENTIFIER ON
    //GO

    //SET ANSI_PADDING ON
    //GO

    //CREATE TABLE [dbo].[ApplicationLog](
    //    [ApplicationLogId] [int] IDENTITY(0,1) NOT NULL,
    //    [EntryDate] [datetime] NOT NULL,
    //    [Thread] [varchar](255) NOT NULL,
    //    [LogLevel] [varchar](50) NOT NULL,
    //    [Logger] [varchar](255) NOT NULL,
    //    [LogMessage] [varchar](4000) NOT NULL,
    //    [Exception] [varchar](2000) NULL,
    //PRIMARY KEY CLUSTERED 
    //(
    //    [ApplicationLogId] ASC
    //)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
    //) ON [PRIMARY]

    //GO

    //SET ANSI_PADDING OFF
    //GO

    //ALTER TABLE [dbo].[ApplicationLog] ADD  CONSTRAINT [DEF_ApplicationLog_EntryDate]  DEFAULT (getdate()) FOR [EntryDate]
    //GO



    /// </summary>
    public class CustomAdoNetAppender : AdoNetAppender
    {

        public string ConnectionStringName
        {
            set { ConnectionString = ConfigurationManager.ConnectionStrings[value].ToString(); }
        }

    }
}