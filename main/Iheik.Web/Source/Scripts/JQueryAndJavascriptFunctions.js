//how to disable
//$('#PickupFromOther').attr('disabled', 'disabled');
//loading cascading drop downs using jquery by hitting an action exposed by controller
//$("#CustomerEntityId").change(function () {
//    $.get(urlGroupings + $("#CustomerEntityId").val(), function (groupings) {
//        var ddlSelectedGrouping = $("#CustomerServiceGroupingId");

//        // clear all previous options 
//        $("#CustomerServiceGroupingId > option").remove();

//        // populate the groupings 
//        for (i = 0; i < groupings.length; i++) {
//            ddlSelectedGrouping.append($("<option />").val(groupings[i].Value == '' ? -1 : groupings[i].Value).text(groupings[i].Text));
//        }

//        // clear all previous options from service type and product as well
//        $("#CustomerServicesId > option:gt(0)").remove();
//        $("#TollProductId > option:gt(0)").remove();
//    });
//});
//$("#CustomerServiceGroupingId").change(function () {
//    $.get(urlServices + "?id=" + $("#CustomerServiceGroupingId").val() + "&selectedCustomerEntityId=" + $("#CustomerEntityId").val(), function (services) {
//        var ddlSelectedService = $("#CustomerServicesId");

//        // clear all previous options 
//        $("#CustomerServicesId > option").remove();

//        // populate the services 
//        for (i = 0; i < services.length; i++) {
//            ddlSelectedService.append($("<option />").val(services[i].Value == '' ? -1 : services[i].Value).text(services[i].Text));
//        }
//        // clear all previous options from product as well
//        $("#TollProductId > option:gt(0)").remove();
//    });
//});


//$("#CustomerServicesId").change(function () {
//    $.get(urlProducts + $("#CustomerServicesId").val(), function (products) {
//        var ddlSelectedProduct = $("#TollProductId");

//        // clear all previous options 
//        $("#TollProductId > option").remove();
//        // populate the products 
//        for (i = 0; i < products.length; i++) {
//            ddlSelectedProduct.append($("<option />").val(products[i].Value == '' ? -1 : products[i].Value).text(products[i].Text));
//        }
//    });
//});
//we need to set target in main page like
//<script type="text/javascript">
//    var urlGroupings = '@Url.Action("GetCustomerServiceGrouping", "Booking")' + '/';
//var urlServices = '@Url.Action("GetServicesForServiceGroup", "Booking")' + '/';
//var urlProducts = '@Url.Action("GetProductsForService", "Booking")' + '/';
//</script>