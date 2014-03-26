
//get the focused input control
//This is being recorded to check that whether the user is still at the same control which fired 
//the request of have moved if user has moved to different control then autocomplete is set to close
var focusedId;
$(":input").focus(function () {
    focusedId = this.id;
});

//This method can bind Search Auto complete in a screen
//We have to provide the target field, model, url 
//We also have to provide an array which will record all the requests and invalidates requests which are made after selection
//This is being done as most of the times when user searches result comes after a while and many requests are queued
//For using this method we have to include the script file in view like 
//<script src="@Url.Content("~/Scripts/AutocompleteSearch.js")" type="text/javascript"></script>
//and we have to initialize some variables like
//var urlAddressFindName = '@Url.Action("FindAddressName", "Search")';
//var addressNameSearchRequests = [];
//and finally bind method with control auto complete
//AddressSearchAutoComplete("ReceiverSearch", "#ReceiverSearch", "#SenderSearch", "BookingReceiverViewModel_AddressEditViewModel", addressNameSearchRequests, urlAddressFindName);
//we have to supply viewmodel name for Autocomplete to fill in appropriate values in proper fields in the view
function SearchAutoComplete(fieldId, fieldName, removeAutocompleteFromField, modelName, nameSearchRequests, urlAddressFindName) {

    if (modelName.length > 0) {
        modelName = modelName + "_";
    };

    $(fieldName).autocomplete({
        source: function (request, response) {
            nameSearchRequests.push($.ajax({
                url: urlAddressFindName,
                type: "POST",
                dataType: "json",
                scroll: true,
                data: { name: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            AddressId: item.AddressId,
                            AddressName: item.AddressName,
                            AddressLine1: item.AddressLine1,
                            AddressLine2: item.AddressLine2,
                            SuburbPostCodeId: item.SuburbPostCodeId,
                            SuburbCity: item.SuburbCity,
                            PostCode: item.PostCode,
                            StateProvinceId: item.StateProvinceId,
                            StateProvinceCode: item.StateProvinceCode,
                            StateProvinceName: item.StateProvinceName,
                            CountryId: item.CountryId,
                            CountryName: item.CountryName,
                            CompanyName: item.CompanyName,
                            ContactName: item.ContactName,
                            ContactEmail: item.ContactEmail,
                            ContactPhone: item.ContactPhone,
                            value: item.AddressName + ', ' + item.CompanyName + ', ' + item.ContactName + ', ' + item.AddressLine1 + ', ' + item.AddressLine2 + item.SuburbCity + ', ' + item.StateProvinceCode + ', ' + item.PostCode
                        }
                    }));
                }
            }))
        },
        select: function (e, ui) {
            //Populate all Address attributes
            $("#" + modelName + "AddressId").val(ui.item.AddressId);
            $("#" + modelName + "CompanyName").val(ui.item.CompanyName);
            $("#" + modelName + "AddressLine1").val(ui.item.AddressLine1);
            $("#" + modelName + "AddressLine2").val(ui.item.AddressLine2);
            $("#" + modelName + "Suburb").val(ui.item.SuburbCity);
            $("#" + modelName + "PostCode").val(ui.item.PostCode);
            $("#" + modelName + "StateProvinceId").val(ui.item.StateProvinceId);
            $("#" + modelName + "ContactName").val(ui.item.ContactName);
            $("#" + modelName + "ContactEmail").val(ui.item.ContactEmail);
            $("#" + modelName + "ContactPhone").val(ui.item.ContactPhone);
            $("#" + modelName + "SuburbPostCodeId").val(ui.item.SuburbPostCodeId);
            $("form").validate().element("#" + modelName + "CompanyName");
            $("form").validate().element("#" + modelName + "AddressLine1");
            $("form").validate().element("#" + modelName + "Suburb");
            $("form").validate().element("#" + modelName + "PostCode");
            $("form").validate().element("#" + modelName + "StateProvinceId");
            $("form").validate().element("#" + modelName + "ContactName");
            $("form").validate().element("#" + modelName + "ContactPhone");
            $("form").validate().element("#" + modelName + "SuburbPostCodeId");

            ui.item.value = '';
            $(fieldName).val('');

            for (var i = 0; i < nameSearchRequests.length; i++) nameSearchRequests[i].abort();
            return false;
        },
        minLength: 3,
        selectFirst: true,
        open: function () {
            if (focusedId != fieldId) {
                $(fieldName).autocomplete('close');
            } else {
                $(removeAutocompleteFromField).autocomplete('close');
                var position = $(fieldName).position(),
                    left = position.left, top = position.top;
                var myWidth = $(fieldName).width();
                $(".ui-autocomplete").css({
                    left: left - myWidth - 210,
                    top: top + "-800px"
                });
            }


        }
    }
      );
}