$(document).ready(function () {
    //setToday();

    $('#redirect').click(function () {
        window.location.href = "/dashboard/dashboard";
    });

    $.ajax({
        type: "GET",
        url: "/OrderStatus/GetCustName",
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
        //if ($('#StartDate').val() == "") {
        //    alert("Please select a date!");
        //    return;
        //}

        $('#divLoader').fadeIn();

        $("#OrderStatus").DataTable().destroy();
        var table = $("#OrderStatus").DataTable({
         
            "ajax": {
                "url": "GetOrdersStatus?Customer=" + $('#drpCustomerName').val(),
                "type": "GET",
                "datatype": "application/json",
                "processing": true, // for show progress bar
                "serverSide": true, // for process server side
                "filter": true, // this is for disable filter (search box)
                "orderMulti": true, // for disable multiple column at once
                "dataSrc": "",
            },
            "columns": [
                { "data": "OrderRefrenceNumber", "class": "OrderRefrenceNumber", "name": "OrderRefrenceNumber", "autoWidth": true },
                { "data": "Customer", "class": "Customer", "name": "Customer", "autoWidth": true },
                { "data": "SalesOrganization", "class": "SalesOrganization", "name": "SalesOrganization", "autoWidth": true },
                { "data": "division", "class": "division", "name": "division", "autowidth": true },
                { "data": "FirmOrder", "class": "FirmOrder", "name": "FirmOrder", "autoWidth": true },
                { "data": "Calday", "class": "Calday", "name": "Calday", "autoWidth": true },
               
                { "data": "IsPushed", "class": "IsPushed", "name": "IsPushed", "autoWidth": true },
            



            ]

        });
        $('#divLoader').fadeOut();
    });
});

//function pad(str, max) {
//    str = str.toString();
//    return str.length < max ? pad("0" + str, max) : str;
//}

//function setToday() {
//    var dd = new Date();
//    var today = dd.getFullYear() + '-' + pad(dd.getMonth() + 1, 2) + '-' + pad(dd.getDate(), 2);
//    $('#StartDate').val(today);
//}