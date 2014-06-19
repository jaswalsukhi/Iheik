//main page will be like this
//<div class="panel-body scrollable">
//    <div id="locationResults" class="">
//        @{
//            Html.RenderPartial("_PickupLocations", Model.SearchedPickupLocationsViewModel);
//}
//                </div>
//            </div>

//the show page will be like this
//@using System.Configuration
//@using CardLeft.Domain.Enums
//@using CardLeft.Web.ViewModels
//@model SearchedPickupLocationsViewModel


//<link href="@Url.Content("~/Content/css/ExpandCollaspeDiv.css")" rel="stylesheet" type="text/css" />
//<div id="toggle form-group">
//    <ul id="myUl" class="noPadding noLeftPadding">

//        @if (Model != null)
//{
//    if (Model.PickupLocations.Any())
//    {
//        foreach (CollectionLocationViewModel location in Model.PickupLocations)
//        {
//    <li class="myLi">
//        @if (Model.PickupLocationType == PickupLocationType.NewsAgent)
//        {
//            <label>
//                <input type="radio" name="pickupLocationRadio" id='@location.PickupLocationId'  onclick=" return SelectPickupLocation(@location.PickupLocationId); " /></label>
//        }
//    else if (Model.PickupLocationType == PickupLocationType.Depot)
//        {
//            <input id="availableDepot" value="@location.PickupLocationId" type="hidden"/>
//            }
//        <label class="field-Description">@location.Name, @location.Suburb</label>
//    </li>
//    <div class="col-lg-offset-1 col-md-offset-1 col-sm-offset-1 text-Description">
//        @location.AddressLine1
//        <br />
//        @if (!string.IsNullOrEmpty(location.AddressLine2))
//        {
//            @location.AddressLine2
//            <br />
//            }
//        @location.Suburb
//        @location.StateProvinceCode
//        @location.Postcode
//        @if (!string.IsNullOrEmpty(location.OpenHours))
//        {
//            <br />
//            <div class="clearfix top-buffer"></div>
//            @location.OpenHours
//        }
//        @if (!string.IsNullOrEmpty(location.Notes))
//        {
//            <br />
//            <div class="clearfix top-buffer"></div>
//            @location.Notes
//        }
//        @Html.Hidden(location.PickupLocationId.ToString(""))

//    </div>

//    }
//}
//else
//{
//                if (Model.PickupLocationType == PickupLocationType.Depot)
//{
//    <li class="alert-user myJuLi pull-left" id="noDataFound">Please note there are no Toll Priority depots in this area.
                    
//        Please contact our Call centre on @ConfigurationManager.AppSettings["TollPriorityPhoneNumber"] if you would like to collect your parcel from the closest Toll Priority agent or to arrange for a redelivery.
//    </li>
//        }
//else if (Model.PickupLocationType == PickupLocationType.NewsAgent)
//{
//    <li class="alert-user myJuLi pull-left" id="noDataFound">The postcode location selected does not have an Alternate Delivery Point within 50km; please select an alternative delivery option.
//    </li>
//}
//}

//}
//else
//{
//    //  

            
//    <li class="alert-user myJuLi pull-left" id="noDataFound">Please note there are no Toll Priority depots / Alternate Delivery Points in this area.
//            <br />
//        Please contact our Call centre on @ConfigurationManager.AppSettings["TollPriorityPhoneNumber"] if you would like to collect your parcelfrom the closest Toll Priority agent or to arrange for a redelivery.
//    </li>
            

//        }
//</ul>
//</div>
//<script src="@Url.Content("~/Scripts/CardLeft-PickupLocationsSearchResult.js")" type="text/javascript"></script>
//<script src="@Url.Content("~/Scripts/jquery.ezmark.min.js")" type="text/javascript"></script>
//<script>

//    $('input').ezMark();
//</script>

//<script>

//    function SelectPickupLocation(item) {
//        var itemSelect = item;
//        $("#SelectedPickupLocation").val(itemSelect);
//        $('#btnPickupLocationSubmit').removeAttr('disabled');
//        var name = '#' + item;
//        $(name).trigger('change'); 
//    }
//</script>

//script on show partial will be like
$(document).ready(function () {
    if (locationTypeIsADP == "False") {
        $("#SelectedPickupLocation").val($('#availableDepot').val());
        $('#btnPickupLocationSubmit').removeAttr('disabled');
        $('.myLi').removeClass('isTollADP');
        $('.myLi').next("div").stop('true', 'true').slideToggle("slow");
    } else {
        $('.myLi').addClass('isTollADP');
        $('#btnPickupLocationSubmit').attr('disabled', 'disabled');

    }
    $("li").click(function () {
        if (locationTypeIsADP == "True") {
            $(this).toggleClass("active");

            $(this).next("div").stop('true', 'true').slideToggle("slow");
        }

    });


});
