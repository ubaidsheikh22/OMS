
$(document).ready(function () {

    $('#redirect').click(function () {
        window.location.href = "/dashboard/dashboard";
    });

    $('#btnRetrieve').click(function () {
        getUnConfirmedOrderData();
    });

});

function getUnConfirmedOrderData() {

    var drpCustomer = $('#drpCustomer :selected').val();
    var drpRegion = $('#drpRegion :selected').val();
    var drpBrand = $('#drpBrand :selected').val();
    var drpSKU = $('#drpSKU :selected').val();



    var drpSalesOrg = $('#drpSalesOrg :selected').val();
    var drpArea = $('#drpArea :selected').val();
    var drpTown = $('#drpTown :selected').val();
    var drpTerritory = $('#drpTerritory :selected').val();

    var drpPlant = $('#drpPlant :selected').val();
    var drpMatGrp1 = $('#drpMatGrp1 :selected').val();
    var drpMatGrp2 = $('#drpMatGrp2 :selected').val();
    var drpMatGrp3 = $('#drpMatGrp3 :selected').val();
    var drpMatGrp4 = $('#drpMatGrp4 :selected').val();



    if ($('#StartDate').val() != "") {
        StartDate = $('#StartDate').val();
    }
    else {
        StartDate = "";
    }
    if ($('#EndDate').val() != "") {
        EndDate = $('#EndDate').val();
    }
    else {
        EndDate = "";
    }


    UnConfirmedOrderTable

    $("#UnConfirmedOrderTable").DataTable().destroy();
    var table = $("#UnConfirmedOrderTable").DataTable({
        dom: 'Bfrtip',
        buttons: [
            'excel', 'csv','print',
        ],
        "ajax": {
            "url": "ReportUnConfirmedOrder",
            "type": "GET",
            "data": {
                    Customer: drpCustomer, Region: drpRegion, Brand: drpBrand, SKU: drpSKU, SalesOrg: drpSalesOrg,
                    Area: drpArea, Town: drpTown, Territory: drpTerritory, Plant: drpPlant, MatGrp1: drpMatGrp1,
                    MatGrp2: drpMatGrp2, MatGrp3: drpMatGrp3, MatGrp4: drpMatGrp4, StartDate: StartDate, EndDate: EndDate
                     },
            "datatype": "application/json",
            "processing": true, // for show progress bar
            "serverSide": true, // for process server side
            "filter": true, // this is for disable filter (search box)
            "orderMulti": true, // for disable multiple column at once
            "dataSrc": "",
        },

        "columns": [
            //{ "data": "orderID", "class": "orderID", "name": "orderID", "autoWidth": true },
            { "data": "Order_Ref", "class": "Order_Ref", "name": "Order_Ref", "autoWidth": true },
            { "data": "CALDAY", "class": "CALDAY", "name": "CALDAY", "autoWidth": true },
            { "data": "Description", "class": "Description", "name": "Description", "autoWidth": true },
            { "data": "SALESORG", "class": "SALESORG", "name": "SALESORG", "autoWidth": true },
            { "data": "DISTR_CHAN", "class": "DISTR_CHAN", "name": "DISTR_CHAN", "autoWidth": true },
            { "data": "DIVISION", "class": "DIVISION", "name": "DIVISION", "autoWidth": true },
            { "data": "customerName", "class": "customerName", "name": "customerName", "autoWidth": true },
            { "data": "QTY", "class": "QTY", "name": "QTY", "autoWidth": true },
            { "data": "weekNumber", "class": "weekNumber", "name": "weekNumber", "autoWidth": true },
            { "data": "UnitPrice", "class": "UnitPrice", "name": "UnitPrice", "autoWidth": true },
            //{ "data": "SKUMapping", "class": "SKUMapping", "name": "SKUMapping", "autoWidth": true },
        ],

    });
}



