//The following script can help show a grid with
//
//@model Priority_Portal.Web.ViewModels.JobHistoryViewModel
//<div class="row">
//    <div class="span8">
//        <h3>@Model.PageViewModel.PageName</h3>
//        @if (!string.IsNullOrEmpty(Model.PageViewModel.HtmlContent))
//        { 
//            <div class="alert">
//                <button type="button" class="close" data-dismiss="alert">
//                    ×</button>
//                <strong>@Html.Raw(@Model.PageViewModel.HtmlContent)</strong>
//            </div>
//        }
//<div class="pull-left">
//    @Html.Partial("_UserEntityContext",Model.UserEntityContextViewModel)
//</div>
//</div>
//<div class="span4">
//    @Html.Partial("_TrackConnotes")
//</div>
//</div>
//<div class="row">
//    <div class="span4">
//        <div class="form-inline">
//            @Html.RadioButtonFor(model => model.AllJobs, false, new { id = "radioMyJobs" })
//            <label for="radioMyJobs">
//                My Jobs</label>
//            @Html.RadioButtonFor(model => model.AllJobs, true, new { id = "radioAllJobs" })
//            <label for="radioAllJobs">
//                All Jobs</label>
//        </div>
//        <br />
//        <div class="form-inline">
//            <a data-bind='click: ShowToday' id="Today" class='btn'>Today</a> <a data-bind='click: ShowLastWeek'
//                id="LastWeek" class='btn'>Last Week</a> <a data-bind='click: ShowLastMonth' id="LastMonth"
//                    class='btn'>Last Month</a>
//        </div>
//    </div>
//    <div class="span4">
//        <div class="form-horizontal">
//            <div class="control-group">
//                <div class="control-label">
//                    @Html.LabelFor(model => model.ReferenceSearch)
//                </div>
//                <div class="controls">
//                    @Html.TextBoxFor(model => model.ReferenceSearch, new { @class = "input-large", @id = "referenceSearch", @title = "Search Connotes, Consignment, Item references & case numbers", @placeholder = "Connote, Reference or Case No." })
//                </div>
//            </div>
//            <div class="control-group">
//                <div class="control-label">
//                    @Html.LabelFor(model => model.OtherSearch)
//                </div>
//                <div class="controls">
//                    @Html.TextBoxFor(model => model.OtherSearch, new { @class = "input-large", @id = "otherSearch", @title = "Search Addresses, Company names & Contact persons", @placeholder = "Address, Company or Contact" })
//                </div>
//            </div>
//        </div>
//    </div>
//    <div class="span3">
//        <div class="form-horizontal">
//            <div class="control-group">
//                <div class="control-label">
//                    @Html.LabelFor(model => model.SearchDateFrom)
//                </div>
//                <div class="controls">
//                    @Html.EditorFor(model => model.SearchDateFrom)
//                </div>
//            </div>
//            <div class="control-group">
//                <div class="control-label">
//                    @Html.LabelFor(model => model.SearchDateTo)
//                </div>
//                <div class="controls">
//                    @Html.EditorFor(model => model.SearchDateTo)
//                </div>
//            </div>
//        </div>
//    </div>
//    <div class="">
//        <a data-bind="click: ValidateAndSearch" id="SearchBtn" class="btn">Search</a>
//    </div>
//</div>
//<div class="row">
//    <div id="busyProgress" align="center">
//        <img id="Busy" src="@Url.Content("~/Content/img/ajax-loader.gif")" alt="" />
//    </div>
//    <div class="span12">
//        <div>
//            Number of Jobs matching search criteria: <span data-bind='text: list().length'></span>
//        </div>
//        <span data-bind='visible: list().length == 0'>
//            <h5>
//                There are no jobs for the current criteria.</h5>
//            <br />
//        </span>
//    </div>
//</div>
//<div class="row">
//    <div class="span12">
//        <table data-bind='visible: list().length != 0' class="table table-hover">
//            <thead>
//                <tr>
//                    <th>
//                    </th>
//                    <th>
//                    </th>
//                    <th>
//                        <div data-bind='click: sortByCustomerEntityName'  class="">
//                            Division</div>
//                    </th>
//                    <th>
//                        <div data-bind='click: sortByConnote' class="">
//                            Connote</div>
//                    </th>
//                    <th>
//                        <div data-bind='click: sortByInitiator' class="">
//                            Initiator</div>
//                    </th>
//                    <th>
//                        <div data-bind='click: sortBySenderCompany' class="">
//                            Sender Company</div>
//                    </th>
//                    <th>
//                        Sender Address
//                    </th>
//                    <th>
//                        <div data-bind='click: sortByReceiverCompany' class="">
//                            Receiver Company</div>
//                    </th>
//                    <th>
//                        Receiver Address
//                    </th>
//                    <th>
//                        <div data-bind='click: sortByPickupDate' class="">
//                            Pickup Date</div>
//                    </th>
//                    <th>
//                        <div data-bind='click: sortByService' class="">
//                            Service</div>
//                    </th>
//                    <th>
//                        Last Event
//                    </th>
//                </tr>
//            </thead>
//            <tbody data-bind="foreach: pagedList()">
//                <tr>
//                    <td>
//                        <a data-bind="attr: { href: JobDetailLink }">View</a>
//                    </td>
//                    <td>
//                        <a data-bind="attr: { href: EnquiryLink }">Enquire</a>
//                    </td>
//                    <td>
//                        <span data-bind="text: CustomerEntityName"></span>
//                    </td>
//                    <td>
//                        <span data-bind="text: ConsignmentNumber"></span>
//                    </td>
//                    <td>
//                        <span data-bind="text: InitiatorName"></span>
//                    </td>
//                    <td>
//                        <span data-bind="text: SenderCompanyName"></span>
//                    </td>
//                    <td>
//                        <span data-bind="text: SenderAddress"></span>
//                    </td>
//                    <td>
//                        <span data-bind="text: ReceiverCompanyName"></span>
//                    </td>
//                    <td>
//                        <span data-bind="text: ReceiverAddress"></span>
//                    </td>
//                    <td>
//                        <span data-bind="dateString: PickupDate"></span>
//                    </td>
//                    <td>
//                        <span data-bind="text: Service"></span>
//                    </td>
//                    <td>
//                        <span data-bind="text: TrackingEventInformation"></span>
//                    </td>
//                </tr>
//            </tbody>
//        </table>
//    </div>
//</div>
//<div class="row">
//    <div class="span12">
//        <div class="pagination pagination-left">
//            <ul>
//                <li data-bind="css: { disabled: pageIndex() === 0 }"><a href="#" data-bind="click: previousPage">
//                    <<</a></li></ul>
//            <ul data-bind="foreach: allPages().slice($root.paginationStart(), $root.paginationEnd())">
//                <li data-bind="css: { active: $data.pageNumber === ($root.pageIndex() + 1) }"><a
//                    href="#" data-bind="text: $data.pageNumber, click: function() { $root.moveToPage($data.pageNumber-1); }">
//                </a></li>
//            </ul>
//            <ul>
//                <li data-bind="css: { disabled: pageIndex() === maxPageIndex() }"><a href="#" data-bind="click: nextPage">
//                    >></a></li></ul>
//        </div>
//    </div>
//</div>
//<script type="text/javascript" defer="defer"> 
//                // variables in here for scripts
//    var initialData = @Html.Raw(Json.Encode(Model));
//    var rowsPerPage = @ViewBag.PageRowCount;
//</script>
//<script src="@Url.Content("~/Scripts/jquery.tmpl.js")" type="text/javascript"></script>
//<script src="@Url.Content("~/Scripts/knockout-2.2.0.debug.js")" type="text/javascript"></script>
//<script src="@Url.Content("~/Scripts/knockout.mapping-2.0.0.debug.js")" type="text/javascript"></script>
//<script src="@Url.Content("~/Scripts/json2.js")" type="text/javascript"></script>
//<script src="@Url.Content("~/Scripts/bootstrap-datepicker.js")" type="text/javascript"></script>
//<script src="@Url.Content("~/Scripts/bootstrap-tooltip.js")" type="text/javascript"></script>
//<script src="@Url.Content("~/Scripts/Toll-JobHistory.js")" type="text/javascript" defer="defer"></script>
//<script type="text/javascript">
//    $(document).ready(function () {
//        $('#Busy').hide();

//        $('#referenceSearch').tooltip({
//            'selector': '',
//            'placement': 'top'
//            });

//        $('#otherSearch').tooltip({
//            'selector': '',
//            'placement': 'bottom'
//            });
//            });

//function showProgress() {
//    var pb = document.getElementById("busyProgress");
//    pb.innerHTML = '<img src="@Url.Content("~/Content/img/ajax-loader.gif")" />';
//    pb.style.display = '';
//};
    
//</script>

//
//
//public class JobHistoryViewModel : BaseViewModel
//{
//    public bool AllJobs { get; set; }

//    [DataType(DataType.Date)]
//    [Display(Name = "Date From:")]
//    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
//    public DateTime SearchDateFrom { get; set; }

//    [DataType(DataType.Date)]
//    [Display(Name = "To:")]
//    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
//    public DateTime SearchDateTo { get; set; }

//    [Display(Name = "Reference Search:")]
//    [PlaceHolder("Connote, Reference or Case No.")]
//    public string ReferenceSearch { get; set; }

//    [Display(Name = "Address Search:")]
//    [PlaceHolder("Address, Company or Contact")]
//    public string OtherSearch { get; set; }

//    public IEnumerable<JobHistorySearchResultViewModel> MatchingJobs { get; set; }

//    public UserEntityContextViewModel UserEntityContextViewModel { get; set; }
//}

$('#SearchDateFrom').datepicker({ format: 'dd/mm/yyyy', startDate: '-60d', autoclose: true });
$('#SearchDateTo').datepicker({ format: 'dd/mm/yyyy', autoclose: true });
Number.prototype.padLeft = function (base, chr) {
    var len = (String(base || 10).length - String(this).length) + 1;
    return len > 0 ? new Array(len).join(chr || '0') + this : this;
};

ko.bindingHandlers.dateString = {
    update: function (element, valueAccessor, allBindingsAccessor) {
        var value = valueAccessor(), allBindings = allBindingsAccessor();

        var valueUnwrapped = ko.utils.unwrapObservable(value);
        var d = "";
        if (valueUnwrapped) {
            valueUnwrapped = valueUnwrapped.replace("Date", "").replace("(", "").replace(")", "").replace("/", "").replace("/", "");
            var dateUnwrapped = new Date(parseInt(valueUnwrapped));

            if (dateUnwrapped > new Date(1900, 00, 01)) {
                d = [dateUnwrapped.getDate().padLeft(), (dateUnwrapped.getMonth() + 1).padLeft(), dateUnwrapped.getFullYear()].join('/');
            }
            else {
                d = "";
            }
        }
        $(element).text(d);
    }
};

var sortSeq = "asc";

var viewModel = {

    list: ko.observableArray(this.initialData.MatchingJobs),

    pageSize: ko.observable(this.rowsPerPage),

    pageIndex: ko.observable(0),

    previousPage: function () {
        if (this.pageIndex() > 0) {
            this.pageIndex(this.pageIndex() - 1);
        }
    },

    nextPage: function () {
        if (this.pageIndex() < this.maxPageIndex()) {
            this.pageIndex(this.pageIndex() + 1);
        }
    },

    moveToPage: function (index) {
        this.pageIndex(index);
    },

    sortByConnote: function () {
        if (this.sortSeq == "asc") {
            this.list.sort(function (a, b) {
                return a.ConsignmentNumber < b.ConsignmentNumber ? -1 : 1;
            });
            this.sortSeq = "desc";
        } else {
            this.list.sort(function (a, b) {
                return b.ConsignmentNumber < a.ConsignmentNumber ? -1 : 1;
            });
            this.sortSeq = "asc";
        }
    },
    sortByInitiator: function () {
        if (this.sortSeq == "asc") {
            this.list.sort(function (a, b) {
                return a.InitiatorName < b.InitiatorName ? -1 : 1;
            });
            this.sortSeq = "desc";
        } else {
            this.list.sort(function (a, b) {
                return b.InitiatorName < a.InitiatorName ? -1 : 1;
            });
            this.sortSeq = "asc";
        }
    },
    sortBySenderCompany: function () {
        if (this.sortSeq == "asc") {
            this.list.sort(function (a, b) {
                return a.SenderCompanyName < b.SenderCompanyName ? -1 : 1;
            });
            this.sortSeq = "desc";
        } else {
            this.list.sort(function (a, b) {
                return b.SenderCompanyName < a.SenderCompanyName ? -1 : 1;
            });
            this.sortSeq = "asc";
        }
    },

    sortByReceiverCompany: function () {
        if (this.sortSeq == "asc") {
            this.list.sort(function (a, b) {
                return a.ReceiverCompanyName < b.ReceiverCompanyName ? -1 : 1;
            });
            this.sortSeq = "desc";
        } else {
            this.list.sort(function (a, b) {
                return b.ReceiverCompanyName < a.ReceiverCompanyName ? -1 : 1;
            });
            this.sortSeq = "asc";
        }
    },

    sortByPickupDate: function () {
        if (this.sortSeq == "asc") {
            this.list.sort(function (a, b) {
                return a.PickupDate < b.PickupDate ? -1 : 1;
            });
            this.sortSeq = "desc";
        } else {
            this.list.sort(function (a, b) {
                return b.PickupDate < a.PickupDate ? -1 : 1;
            });
            this.sortSeq = "asc";
        }
    },

    sortByService: function () {
        if (this.sortSeq == "asc") {
            this.list.sort(function (a, b) {
                return a.Service < b.Service ? -1 : 1;
            });
            this.sortSeq = "desc";
        } else {
            this.list.sort(function (a, b) {
                return b.Service < a.Service ? -1 : 1;
            });
            this.sortSeq = "asc";
        }
    },
    sortByCustomerEntityName: function () {
        if (this.sortSeq == "asc") {
            this.list.sort(function (a, b) {
                return a.CustomerEntityName < b.CustomerEntityName ? -1 : 1;
            });
            this.sortSeq = "desc";
        } else {
            this.list.sort(function (a, b) {
                return b.CustomerEntityName < a.CustomerEntityName ? -1 : 1;
            });
            this.sortSeq = "asc";
        }
    },
    search: function () {
        var pickupFrom = $('#SearchDateFrom').val();
        var pickupTo = $('#SearchDateTo').val();
        var customerEntityId = $('#CustomerEntityId').val();
        var searchParams = {
            allJobs: document.getElementById('radioAllJobs').checked,
            referenceSearch: document.getElementById('referenceSearch').value,
            otherSearch: document.getElementById('otherSearch').value,
            searchFromDate: pickupFrom,
            searchToDate: pickupTo,
            customerEntityId: customerEntityId
        };

        ko.utils.postJson(location.href, { model: searchParams });

        showProgress();
    }
};

viewModel.pagedList = ko.dependentObservable(function () {
    var size = viewModel.pageSize();
    var start = viewModel.pageIndex() * size;
    return viewModel.list.slice(start, start + size);
});

viewModel.maxPageIndex = ko.dependentObservable(function () {
    return Math.ceil(viewModel.list().length / viewModel.pageSize()) - 1;
});

viewModel.allPages = ko.dependentObservable(function () {
    var pages = [];
    for (i = 0; i <= viewModel.maxPageIndex() ; i++) {
        pages.push({ pageNumber: (i + 1) });
    }
    return pages;
});

viewModel.paginationStart = ko.computed(function () {
    var last = viewModel.maxPageIndex() + 1;

    if (last <= 10) {
        return 0;
    }
    else {
        var current = viewModel.pageIndex() + 1;
        if (current <= 6) {
            return 0;
        }
        else {
            if ((last - current) <= 6) {
                return last - 10;
            }
            else {
                return current - 6;
            }
        }
    }
}, this);

viewModel.paginationEnd = ko.computed(function () {
    var last = viewModel.maxPageIndex() + 1;

    if (last <= 10) {
        return last;
    } else {
        var current = viewModel.pageIndex() + 1;
        if (current <= 6) {
            return 10;
        }
        else {
            if ((last - current) <= 6) {
                return last;
            }
            else {
                return current + 4;
            }
        }
    }
}, this);

function LoadSetup() {
    var fullDate = new Date();
    var onlyDateForToday = fullDate.getDate() + '/' + (fullDate.getMonth() + 1) + '/' + fullDate.getFullYear();
    $('#SearchDateTo').val(onlyDateForToday);
    $('#SearchDateTo').datepicker('hide');
    fullDate.setDate(fullDate.getDate() - 1);
    var onlyDateForYesterday = fullDate.getDate() + '/' + (fullDate.getMonth() + 1) + '/' + fullDate.getFullYear();
    $('#SearchDateFrom').val(onlyDateForYesterday);
    $('#SearchDateFrom').datepicker('hide');
    $('#Busy').hide();
};

function ValidateAndSearch() {
    if (document.getElementById('SearchDateFrom').value == '' || document.getElementById('SearchDateTo').value == '') {
        bootbox.alert("Job 'From' and 'To' dates must be supplied.");
        return false;
    }

    var fromDate = document.getElementById('SearchDateFrom').value.split("/");
    var pickupFrom = new Date(fromDate[2], fromDate[1] - 1, fromDate[0]);

    var toDate = document.getElementById('SearchDateTo').value.split("/");
    var pickupTo = new Date(toDate[2], toDate[1] - 1, toDate[0]);

    if (pickupFrom > pickupTo) {
        bootbox.alert("Job 'To' date must be greater than the 'From' date.");
        return false;
    }

    var diff = (pickupTo - pickupFrom);
    if ((diff / 1000 / 60 / 60 / 24) > 60) {
        bootbox.alert("Job 'From' and 'To' dates must be within a 60 day range of each other.");
        return false;
    }

    viewModel.search();

    return true;
};

function ShowToday() {
    LoadSetup();
    ValidateAndSearch();
};

function ShowLastWeek() {
    var fullDate = new Date();
    var onlyDateForToday = fullDate.getDate() + '/' + (fullDate.getMonth() + 1) + '/' + fullDate.getFullYear();
    $('#SearchDateTo').val(onlyDateForToday);
    $('#SearchDateTo').datepicker('hide');
    fullDate.setDate(fullDate.getDate() - 7);
    var onlyDateForYesterday = fullDate.getDate() + '/' + (fullDate.getMonth() + 1) + '/' + fullDate.getFullYear();
    $('#SearchDateFrom').val(onlyDateForYesterday);
    $('#SearchDateFrom').datepicker('hide');
    ValidateAndSearch();
};

function ShowLastMonth() {
    var fullDate = new Date();
    var onlyDateForToday = fullDate.getDate() + '/' + (fullDate.getMonth() + 1) + '/' + fullDate.getFullYear();
    $('#SearchDateTo').val(onlyDateForToday);
    $('#SearchDateTo').datepicker('hide');
    fullDate.setDate(fullDate.getDate() - 30);
    var onlyDateForYesterday = fullDate.getDate() + '/' + (fullDate.getMonth() + 1) + '/' + fullDate.getFullYear();
    $('#SearchDateFrom').val(onlyDateForYesterday);
    $('#SearchDateFrom').datepicker('hide');
    ValidateAndSearch();
};

function ShowJobsForSelectedCustomerEntity() {
    ValidateAndSearch();
}

$('#CustomerEntityId').change(ShowJobsForSelectedCustomerEntity);

ko.applyBindings(viewModel);

$('#CustomerEntityId').val(this.initialData.CustomerEntityId);