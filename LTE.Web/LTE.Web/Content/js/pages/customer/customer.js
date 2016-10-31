
$(document).ready(function () {
    //$(document).ajaxStart(function (event) {
    //    $("#ajax-loading").show();
    //});

    //$(document).ajaxComplete(function (evnt) {
    //    $("#ajax-loading").hide(3000);
    //});


    GetCustomerList(1);
    $("".concat("#SearchEmail,", "#SearchFristName,", "#SearchLastName")).keydown(function (event) {
        if (event.keyCode === 13) {
            GetCustomerList(1);
        }
    });

    $("#searchForm").submit(function (event) {
        GetCustomerList(1);
        event.preventDefault();
    });


});


function GetCustomerList(page) {
    var searchData = $("#searchForm").serializeObject();
    searchData.Page = page;
    $.ajax({
        type: "POST",
        url: lte.Urls.GetCustomerListUrl,
        data: searchData,
        dataType: "html",
        beforeSend: function () {
            ShowAjaxLoading("ajax-loading", "customers-grid");
        },
        success: function (response) {
            $("#customers-grid").html(response);
            HideAjaxLoading("ajax-loading");
        }
    });
}

function ShowAjaxLoading(overlayId, idOfDivToOverlay) {
    var pos = $("#" + idOfDivToOverlay).offset();
    var width = $("#" + idOfDivToOverlay).width();
    var height = $("#" + idOfDivToOverlay).height();

    $("#" + overlayId).css({
        "width": width + "px",
        "height": height + "px",
        "left": pos.left + "px",
        "top": pos.top + "px"
    });

    $("#" + overlayId).show();
    $("#" + overlayId).animate({ opacity: 0.3 }, 1);
}

function HideAjaxLoading(overlayId) {
    $("#" + overlayId).animate({ opacity: "hide" }, 500);
    //$("#" + overlayId).hide(2000);
}