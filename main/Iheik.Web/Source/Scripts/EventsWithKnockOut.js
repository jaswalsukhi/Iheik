
//@model Priority_Portal.Web.ViewModels.UserRolesViewModel
//<div class="row">
//    <div class="span12">
//        <h3>@Model.PageViewModel.PageName</h3>
//        @Html.Raw(@Model.PageViewModel.HtmlContent)
//    </div>
//</div>
//<div class="row">
//    <div class="span12">
//        <div class="form-horizontal">
//            <div class="control-group">
//                <div class="control-label">
//                    @Html.LabelFor(model => model.MembershipProviderId)
//                </div>
//                <div class="controls">
//                    @Html.TextBoxFor(model => model.MembershipProviderId, new { @class = "input-xxlarge uneditable-input" })
//                </div>
//            </div>
//            <div class="control-group">
//                <div class="control-label">
//                    @Html.LabelFor(model => model.UserName)
//                </div>
//                <div class="controls">
//                    @Html.TextBoxFor(model => model.UserName, new { @class = "input-large uneditable-input" })
//                </div>
//            </div>
//            <div class="control-group">
//                <div class="control-label">
//                    @Html.LabelFor(model => model.FullName)
//                </div>
//                <div class="controls">
//                    @Html.TextBoxFor(model => model.FullName, new { @class = "input-large uneditable-input" })
//                </div>
//            </div>
//        </div>
//    </div>
//</div>
//<div class="row">
//    <div class="span12">
//        @using (Html.BeginForm("UserRoles", "Admin", FormMethod.Post))
//{ 
//    @Html.AntiForgeryToken()
                        
//    <div class="row">
//        <div class="span3">
//            @Html.LabelFor(model => model.SystemRoles)
//            <select multiple="multiple" height="5" data-bind="options:systemRoles, selectedOptions:selectedSystemRoles">
//            </select>
//        </div>
//        <div class="span2">
//            <br />
//            <br />
//            <button data-bind="click: addUserRole, enable: selectedSystemRoles().length > 0">
//                Add</button>
//            <button data-bind="click: removeUserRole, enable: selectedUserRoles().length > 0">
//                Remove</button>
//        </div>
//        <div class="span3">
//            @Html.LabelFor(model => model.UserRoles)
//            <select multiple="multiple" height="5" data-bind="options:userRoles, selectedOptions:selectedUserRoles">
//            </select>
//        </div>
//    </div>  
            
            
//    <div class="well">
//        <div class="row">
//            <div class="span1 offset7">
//                <button type="submit" class="btn">
//                    Save</button>
//            </div>
//            <div class="span1">
//                @Html.ActionLink("Cancel", "AdministerUser", "Admin", new { id = Model.MembershipProviderId }, new { @class = "btn" })
//            </div>
//        </div>
//    </div>     
//}
//</div>
//</div>
//<script type="text/javascript"> 
//    var initialData = @Html.Raw(Json.Encode(Model));
//</script>
//<script src="@Url.Content("~/Scripts/knockout-2.2.0.debug.js")" type="text/javascript"></script>
//<script src="@Url.Content("~/Scripts/json2.js")" type="text/javascript"></script>
//<script src="@Url.Content("~/Scripts/Toll-UserRoles.js")" type="text/javascript"></script>

var viewModel = {

    membershipProviderId: initialData.MembershipProviderId,
    userName: initialData.UserName,
    fullName: initialData.FullName,

    systemRoles: this.initialData.SystemRoles,

    userRoles: ko.observableArray(this.initialData.UserRoles),

    selectedSystemRoles: ko.observableArray([]),
    selectedUserRoles: ko.observableArray([]),

    addUserRole: function () {
        for (var i = 0; i < this.selectedSystemRoles().length; i++) {

            var item = this.selectedSystemRoles()[i];

            if (this.userRoles.indexOf(item) < 0) { // Prevent duplicates
                this.userRoles.push(item);
            }
        }

        this.selectedSystemRoles([]); // Clear System Role selected
    },

    removeUserRole: function () {
        this.userRoles.removeAll(this.selectedUserRoles());

        this.selectedUserRoles([]); // Clear User Role selection
    },

    save: function () {
        var token = $('input[name=__RequestVerificationToken]').val();
        ko.utils.postJson(location.href, { model: ko.toJS(viewModel) }, { params: { __RequestVerificationToken: token } });
    }
};

ko.applyBindings(viewModel);

$("form").validate({ submitHandler: function () { viewModel.save() } });