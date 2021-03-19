$(document).ready(function () {
    setToday();

    $('#redirect').click(function () {
        window.location.href = "/dashboard/dashboard";
    });

    $.ajax({
        type: "GET",
        url: "/SaleOrderLog/GetCustName",
        data: "{}",
        success: function (data) {
            var s = '<option value="-1">Please Select Customer</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].Customer + '">' + data[i].Name1 + ' (' + data[i].Customer + ')' + '</option>';
            }
            $("#drpCustomerName").html(s);
        }
    });

    //GetLogs
    $('#btnRetrieve').click(function () {
        //if ($('#drpCustomerName').val() == '-1') {
        //    alert("Please select a customer!");
        //    return;
        //}
        if ($('#StartDate').val() == "") {
            alert("Please select a date!");
            return;
        }

        $('#divLoader').fadeIn();

        $("#list").DataTable().destroy();
        var table = $("#list").DataTable({
            //('.display').$("#SafetyList").DataTable({
            "ajax": {
                "url": "GetLogs?Customer=" + $('#drpCustomerName').val() + "&Date=" + $('#StartDate').val(),
                "type": "GET",
                "datatype": "application/json",
                "processing": true, // for show progress bar
                "serverSide": true, // for process server side
                "filter": true, // this is for disable filter (search box)
                "orderMulti": true, // for disable multiple column at once
                "dataSrc": "",
            },
            "columns": [
                { "data": "OrderReferenceNumber", "class": "OrderReferenceNumber", "name": "OrderReferenceNumber", "autoWidth": true },
                { "data": "Customer", "class": "Customer", "name": "Customer", "autoWidth": true },
                { "data": "SalesOrganization", "class": "SalesOrganization", "name": "SalesOrganization", "autoWidth": true },
                { "data": "Division", "class": "Division", "name": "Division", "autoWidth": true },
                { "data": "Type", "class": "Type", "name": "Type", "autoWidth": true },
                { "data": "ID", "class": "ID", "name": "ID", "autoWidth": true },
                { "data": "Number", "class": "Number", "name": "Number", "autoWidth": true },
                { "data": "Message", "class": "Message", "name": "Message", "autoWidth": true },
                { "data": "Message_V1", "class": "Message_V1", "name": "Message_V1", "autoWidth": true },
                { "data": "Message_V2", "class": "Message_V2", "name": "Message_V2", "autoWidth": true },
                { "data": "Message_V3", "class": "Message_V3", "name": "Message_V3", "autoWidth": true },
                { "data": "Message_V4", "class": "Message_V4", "name": "Message_V4", "autoWidth": true },
                { "data": "Parameter", "class": "Parameter", "name": "Parameter", "autoWidth": true },
                { "data": "Row", "class": "Row", "name": "Row", "autoWidth": true },
                { "data": "System", "class": "System", "name": "System", "autoWidth": true },
                { "data": "LoggedAt", "class": "LoggedAt", "name": "LoggedAt", "autoWidth": true },



            ]

        });
        $('#divLoader').fadeOut();
    });
});

function pad(str, max) {
    str = str.toString();
    return str.length < max ? pad("0" + str, max) : str;
}

function setToday() {
    var dd = new Date();
    var today = dd.getFullYear() + '-' + pad(dd.getMonth() + 1, 2) + '-' + pad(dd.getDate(), 2);
    $('#StartDate').val(today);
}