using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iheik.ServiceInteractions.Constants
{
    internal static class InfrastructureConstants
    {
        // Integration Constants 
        internal const string HPPortalSender = "HP Portal";
        internal const string TollCustomerServices = "TollCustomerServices";
        internal const string TollPriorityReceiver = "TollOnline";
        internal const string TollFastReceiver = "RockHopper";
        internal const string DocumentType = "TollPickupRequest";
        internal const string TollFastDocumentType = "Booking Request";
        internal const string TollFastBusinessName = "HP ADHOC";

        // Nick; this is crap
        internal const string SiebelCustomerEnquiryEndpoint = "SiebelCustomerEnquiryEndpoint";
        internal const string SiebelCustomerEnquiryUserId = "SiebelCustomerEnquiryUserId";
        internal const string SiebelCustomerEnquiryPassword = "SiebelCustomerEnquiryPassword";
        internal const string SiebelCustomerEnquiryTimeout = "SiebelCustomerEnquiryTimeout";
        internal const string SiebelCustomerEnquiryMethod = "SiebelCustomerEnquiryMethod";
        internal const string SiebelCustomerEnquiryEmail = "SiebelCustomerEnquiryEmail";

        internal const string TollFastBookingEndpoint = "TollFastBookingEndpoint";
        internal const string TollFastBookingUserId = "TollFastBookingUserId";
        internal const string TollFastBookingPassword = "TollFastBookingPassword";
        internal const string TollFastBookingTimeout = "TollFastBookingTimeout";
        internal const string TollFastBookingMethod = "TollFastBookingMethod";
        internal const string TollFastBookingEmail = "TollFastBookingEmail";
        internal const string TollFastItemDimensionMethod = "TollFastItemDimensionMethod";

        internal const string TollPriorityBookingEndpoint = "TollPriorityBookingEndpoint";
        internal const string TollPriorityBookingUserId = "TollPriorityBookingUserId";
        internal const string TollPriorityBookingPassword = "TollPriorityBookingPassword";
        internal const string TollPriorityBookingTimeout = "TollPriorityBookingTimeout";
        internal const string TollPriorityBookingMethod = "TollPriorityBookingMethod";
        internal const string TollPriorityBookingEmail = "TollPriorityBookingEmail";
        internal const string TollPriorityItemDimensionMethod = "TollPriorityItemDimensionMethod";

        internal const string ReportServerTargetURL = "ReportServerTargetURL";
        internal const string ReportUserDomain = "ReportUserDomain";
        internal const string ReportUser = "ReportUser";
        internal const string ReportUserPassword = "ReportUserPassword";
        internal const string ReportConnoteFolder = "ReportConnoteFolder";
        internal const string ReportThermalConnoteFolder = "ReportThermalConnoteFolder";
        internal const string ReportManifestFolder = "ReportManifestFolder";
        internal const string ReportTimeout = "ReportTimeout";

        // Toll Fast Account Codes
        //Sukhbir, change this to be driven by data
        //for PPS
        internal const string TollFastAccount_PPS_NSW_Newcastle = "HPPPSAN";
        internal const string TollFastAccount_PPS_NSW = "HPPPSA";
        internal const string TollFastAccount_PPS_SA_NT = "HPPPSA";
        internal const string TollFastAccount_PPS_WA = "HPPPSA";
        internal const string TollFastAccount_PPS_QLD = "HPPPSA";
        internal const string TollFastAccount_PPS_ACT = "HPPPSA";
        internal const string TollFastAccount_PPS_VIC_TAS = "HPPPSA";

        //for EG
        internal const string TollFastAccount_EG_NSW_Newcastle = "HPEGAN";
        internal const string TollFastAccount_EG_NSW = "HPEGA";
        internal const string TollFastAccount_EG_SA_NT = "HPEGA";
        internal const string TollFastAccount_EG_WA = "HPEGA";
        internal const string TollFastAccount_EG_QLD = "HPEGA";
        internal const string TollFastAccount_EG_ACT = "HPEGA";
        internal const string TollFastAccount_EG_VIC_TAS = "HPEGA";


        //for IPG
        internal const string TollFastAccount_IPG_NSW_Newcastle = "";
        internal const string TollFastAccount_IPG_NSW = "HPIPGA";
        internal const string TollFastAccount_IPG_SA_NT = "HPIPGA";
        internal const string TollFastAccount_IPG_WA = "HPIPGA";
        internal const string TollFastAccount_IPG_QLD = "HPIPGA";
        internal const string TollFastAccount_IPG_ACT = "HPIPGA";
        internal const string TollFastAccount_IPG_VIC_TAS = "HPIPGA";
        // Product code
        internal const string TollFastProductCodes = "HP ADHoc";

    }
}
