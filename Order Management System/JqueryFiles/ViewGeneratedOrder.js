

/// <reference path="GenericAjax.js" />
var tableMain;
var groupData = null;
$(document).ready(function () {

    dataload();
    $('#drpCustomerName').change(function () {
        name = $('#drpCustomerName').val() == "-1" || null ? "" : $('#drpCustomerName').val();
        salesorg = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newsalesorg = salesorg + "";
        div = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = div + "";
        category = $('#drpCategory').val() == "-1" || null ? "" : $('#drpCategory').val();
        newCat = category + "";
        region = $('#drpRegion').val() == "-1" || null ? "" : $('#drpRegion').val();
        newregion = region + "";
        area = $('#drpArea').val() == "-1" || null ? "" : $('#drpArea').val();
        newArea = area + "";
        territory = $('#drpTerritory').val() == "-1" || null ? "" : $('#drpTerritory').val();
        newsterr = territory + "";
        town = $('#drpTown').val() == "-1" || null ? "" : $('#drpTown').val();
        newtown = town + "";
        plant = $('#drpPlant').val() == "-1" || null ? "" : $('#drpPlant').val();
        newplant = plant + "";
        dataload();
        BindDropDownsalesorg('/customer/GetSalesOrg', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowndivision('/customer/GetDivision', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowncategory('/customer/GetCategory', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownregion('/customer/GetRegion', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownarea('/customer/GetArea', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownterritory('/customer/GetTerritory', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowntown('/customer/GetTown', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownplant('/customer/GetPlant', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
    });
    $('#drpSalesOrg').change(function () {
        name = $('#drpCustomerName').val() == "-1" || null ? "" : $('#drpCustomerName').val();
        salesorg = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newsalesorg = salesorg + "";
        div = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = div + "";
        category = $('#drpCategory').val() == "-1" || null ? "" : $('#drpCategory').val();
        newCat = category + "";
        region = $('#drpRegion').val() == "-1" || null ? "" : $('#drpRegion').val();
        newregion = region + "";
        area = $('#drpArea').val() == "-1" || null ? "" : $('#drpArea').val();
        newArea = area + "";
        territory = $('#drpTerritory').val() == "-1" || null ? "" : $('#drpTerritory').val();
        newsterr = territory + "";
        town = $('#drpTown').val() == "-1" || null ? "" : $('#drpTown').val();
        newtown = town + "";
        plant = $('#drpPlant').val() == "-1" || null ? "" : $('#drpPlant').val();
        newplant = plant + "";
        dataload();

        BindDropDownNAme('/customer/GetCustomerName', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowndivision('/customer/GetDivision', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowncategory('/customer/GetCategory', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownregion('/customer/GetRegion', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownarea('/customer/GetArea', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownterritory('/customer/GetTerritory', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowntown('/customer/GetTown', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownplant('/customer/GetPlant', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
    });
    $('#drpDiv').change(function () {
        name = $('#drpCustomerName').val() == "-1" || null ? "" : $('#drpCustomerName').val();
        salesorg = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newsalesorg = salesorg + "";
        div = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = div + "";
        category = $('#drpCategory').val() == "-1" || null ? "" : $('#drpCategory').val();
        newCat = category + "";
        region = $('#drpRegion').val() == "-1" || null ? "" : $('#drpRegion').val();
        newregion = region + "";
        area = $('#drpArea').val() == "-1" || null ? "" : $('#drpArea').val();
        newArea = area + "";
        territory = $('#drpTerritory').val() == "-1" || null ? "" : $('#drpTerritory').val();
        newsterr = territory + "";
        town = $('#drpTown').val() == "-1" || null ? "" : $('#drpTown').val();
        newtown = town + "";
        plant = $('#drpPlant').val() == "-1" || null ? "" : $('#drpPlant').val();
        newplant = plant + "";
        dataload();

        BindDropDownNAme('/customer/GetCustomerName', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownsalesorg('/customer/GetSalesOrg', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowncategory('/customer/GetCategory', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownregion('/customer/GetRegion', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownarea('/customer/GetArea', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownterritory('/customer/GetTerritory', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowntown('/customer/GetTown', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownplant('/customer/GetPlant', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
    });
    $('#drpCategory').change(function () {
        name = $('#drpCustomerName').val() == "-1" || null ? "" : $('#drpCustomerName').val();
        salesorg = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newsalesorg = salesorg + "";
        div = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = div + "";
        category = $('#drpCategory').val() == "-1" || null ? "" : $('#drpCategory').val();
        newCat = category + "";
        region = $('#drpRegion').val() == "-1" || null ? "" : $('#drpRegion').val();
        newregion = region + "";
        area = $('#drpArea').val() == "-1" || null ? "" : $('#drpArea').val();
        newArea = area + "";
        territory = $('#drpTerritory').val() == "-1" || null ? "" : $('#drpTerritory').val();
        newsterr = territory + "";
        town = $('#drpTown').val() == "-1" || null ? "" : $('#drpTown').val();
        newtown = town + "";
        plant = $('#drpPlant').val() == "-1" || null ? "" : $('#drpPlant').val();
        newplant = plant + "";
        dataload();

        BindDropDownNAme('/customer/GetCustomerName', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownsalesorg('/customer/GetSalesOrg', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowndivision('/customer/GetDivision', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownregion('/customer/GetRegion', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownarea('/customer/GetArea', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownterritory('/customer/GetTerritory', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowntown('/customer/GetTown', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownplant('/customer/GetPlant', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
    });
    $('#drpRegion').change(function () {
        name = $('#drpCustomerName').val() == "-1" || null ? "" : $('#drpCustomerName').val();
        salesorg = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newsalesorg = salesorg + "";
        div = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = div + "";
        category = $('#drpCategory').val() == "-1" || null ? "" : $('#drpCategory').val();
        newCat = category + "";
        region = $('#drpRegion').val() == "-1" || null ? "" : $('#drpRegion').val();
        newregion = region + "";
        area = $('#drpArea').val() == "-1" || null ? "" : $('#drpArea').val();
        newArea = area + "";
        territory = $('#drpTerritory').val() == "-1" || null ? "" : $('#drpTerritory').val();
        newsterr = territory + "";
        town = $('#drpTown').val() == "-1" || null ? "" : $('#drpTown').val();
        newtown = town + "";
        plant = $('#drpPlant').val() == "-1" || null ? "" : $('#drpPlant').val();
        newplant = plant + "";
        dataload();

        BindDropDownNAme('/customer/GetCustomerName', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownsalesorg('/customer/GetSalesOrg', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowndivision('/customer/GetDivision', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowncategory('/customer/GetCategory', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownarea('/customer/GetArea', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownterritory('/customer/GetTerritory', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowntown('/customer/GetTown', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownplant('/customer/GetPlant', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
    });
    $('#drpArea').change(function () {
        name = $('#drpCustomerName').val() == "-1" || null ? "" : $('#drpCustomerName').val();
        salesorg = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newsalesorg = salesorg + "";
        div = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = div + "";
        category = $('#drpCategory').val() == "-1" || null ? "" : $('#drpCategory').val();
        newCat = category + "";
        region = $('#drpRegion').val() == "-1" || null ? "" : $('#drpRegion').val();
        newregion = region + "";
        area = $('#drpArea').val() == "-1" || null ? "" : $('#drpArea').val();
        newArea = area + "";
        territory = $('#drpTerritory').val() == "-1" || null ? "" : $('#drpTerritory').val();
        newsterr = territory + "";
        town = $('#drpTown').val() == "-1" || null ? "" : $('#drpTown').val();
        newtown = town + "";
        plant = $('#drpPlant').val() == "-1" || null ? "" : $('#drpPlant').val();
        newplant = plant + "";
        dataload();

        BindDropDownNAme('/customer/GetCustomerName', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownsalesorg('/customer/GetSalesOrg', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowndivision('/customer/GetDivision', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowncategory('/customer/GetCategory', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownregion('/customer/GetRegion', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownterritory('/customer/GetTerritory', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowntown('/customer/GetTown', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownplant('/customer/GetPlant', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
    });
    $('#drpTerritory').change(function () {
        name = $('#drpCustomerName').val() == "-1" || null ? "" : $('#drpCustomerName').val();
        salesorg = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newsalesorg = salesorg + "";
        div = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = div + "";
        category = $('#drpCategory').val() == "-1" || null ? "" : $('#drpCategory').val();
        newCat = category + "";
        region = $('#drpRegion').val() == "-1" || null ? "" : $('#drpRegion').val();
        newregion = region + "";
        area = $('#drpArea').val() == "-1" || null ? "" : $('#drpArea').val();
        newArea = area + "";
        territory = $('#drpTerritory').val() == "-1" || null ? "" : $('#drpTerritory').val();
        newsterr = territory + "";
        town = $('#drpTown').val() == "-1" || null ? "" : $('#drpTown').val();
        newtown = town + "";
        plant = $('#drpPlant').val() == "-1" || null ? "" : $('#drpPlant').val();
        newplant = plant + "";
        dataload();

        BindDropDownNAme('/customer/GetCustomerName', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownsalesorg('/customer/GetSalesOrg', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowndivision('/customer/GetDivision', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowncategory('/customer/GetCategory', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownregion('/customer/GetRegion', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownarea('/customer/GetArea', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowntown('/customer/GetTown', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownplant('/customer/GetPlant', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
    });
    $('#drpTown').change(function () {
        name = $('#drpCustomerName').val() == "-1" || null ? "" : $('#drpCustomerName').val();
        salesorg = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newsalesorg = salesorg + "";
        div = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = div + "";
        category = $('#drpCategory').val() == "-1" || null ? "" : $('#drpCategory').val();
        newCat = category + "";
        region = $('#drpRegion').val() == "-1" || null ? "" : $('#drpRegion').val();
        newregion = region + "";
        area = $('#drpArea').val() == "-1" || null ? "" : $('#drpArea').val();
        newArea = area + "";
        territory = $('#drpTerritory').val() == "-1" || null ? "" : $('#drpTerritory').val();
        newsterr = territory + "";
        town = $('#drpTown').val() == "-1" || null ? "" : $('#drpTown').val();
        newtown = town + "";
        plant = $('#drpPlant').val() == "-1" || null ? "" : $('#drpPlant').val();
        newplant = plant + "";
        dataload();

        BindDropDownNAme('/customer/GetCustomerName', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownsalesorg('/customer/GetSalesOrg', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowndivision('/customer/GetDivision', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowncategory('/customer/GetCategory', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownregion('/customer/GetRegion', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownarea('/customer/GetArea', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownterritory('/customer/GetTerritory', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownplant('/customer/GetPlant', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
    });
    $('#drpPlant').change(function () {
        name = $('#drpCustomerName').val() == "-1" || null ? "" : $('#drpCustomerName').val();
        salesorg = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newsalesorg = salesorg + "";
        div = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = div + "";
        category = $('#drpCategory').val() == "-1" || null ? "" : $('#drpCategory').val();
        newCat = category + "";
        region = $('#drpRegion').val() == "-1" || null ? "" : $('#drpRegion').val();
        newregion = region + "";
        area = $('#drpArea').val() == "-1" || null ? "" : $('#drpArea').val();
        newArea = area + "";
        territory = $('#drpTerritory').val() == "-1" || null ? "" : $('#drpTerritory').val();
        newsterr = territory + "";
        town = $('#drpTown').val() == "-1" || null ? "" : $('#drpTown').val();
        newtown = town + "";
        plant = $('#drpPlant').val() == "-1" || null ? "" : $('#drpPlant').val();
        newplant = plant + "";
        dataload();

        BindDropDownNAme('/customer/GetCustomerName', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownsalesorg('/customer/GetSalesOrg', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowndivision('/customer/GetDivision', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowncategory('/customer/GetCategory', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownregion('/customer/GetRegion', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownarea('/customer/GetArea', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownterritory('/customer/GetTerritory', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowntown('/customer/GetTown', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
    });


    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });

    //BindDropDownCustomer('Customer', '');

    BindDropDownNAme('/customer/GetCustomerName', '', '', '', '', '', '', '', '', '');
    BindDropDownsalesorg('/customer/GetSalesOrg', '', '', '', '', '', '', '', '', '');
    BindDropDowndivision('/customer/GetDivision', '', '', '', '', '', '', '', '', '');
    BindDropDowncategory('/customer/GetCategory', '', '', '', '', '', '', '', '', '');
    BindDropDownregion('/customer/GetRegion', '', '', '', '', '', '', '', '', '');
    BindDropDownarea('/customer/GetArea', '', '', '', '', '', '', '', '', '');
    BindDropDownterritory('/customer/GetTerritory', '', '', '', '', '', '', '', '', '');
    BindDropDowntown('/customer/GetTown', '', '', '', '', '', '', '', '', '');
    BindDropDownplant('/customer/GetPlant', '', '', '', '', '', '', '', '', '');


    clickable();
    $("#list").on('load', '.OrderRefrenceNumber', function () {
        //$("#GetAllMaterialRecords").dataTable().fnDestroy();
        var calculated_total_sum = 0;

        $("#list #OrderRefrenceNumber").each(function () {
            var get_textbox_value = $(this).val();
            if ($.isNumeric(get_textbox_value)) {
                calculated_total_sum += parseFloat(get_textbox_value);
            }
        });
        $("#total_sum_Order").html(calculated_total_sum);

        //$("#GetAllMaterialRecords").DataTable();
    });
});
var table = null;

function findGroupData(c, so, div, m) {
    return $.grep(groupData, function (item) {
        return item.CUSTOMER == c;//&& item.SALESORG == so && item.DIVISION == div && item.MATERIAL == m;
    });
}

function showGroupData(c, so, div, m) {
    var a = findGroupData(String(c), String(so), String(div), String(m));
    $("#ViewList tbody").empty();
    var total = 0;
    var total2 = 0;

    for (i = 0; i < a.length; i++) {
        v = a[i];
        var sorg = (v.SALESORG == 1000) ? "EBM" : "CFL";
        var division = (v.DIVISION == 10) ? "Biscuit" : "Cake";
        $("#listt").append("<tr><td>" + v.CUSTOMER + "</td><td>" + sorg + "</td><td>" + division + "</td><td>" + v.materialDesc + "</td><td>" + v.Order_Qty + "</td><td>" + v.MaterialTotalValues + "</td></tr>");
        total += Number(v.Order_Qty);
        total2 += Number(v.MaterialTotalValues);
    }
    $("#listtfoot").html("<tr><th colspan=4>Total Order</th><th>" + total + "</th><th>" + total2 + "</th></tr>");

    $("#largeModal").modal();
}

function dataload() {
    //var table = $('#drpRegion').change(function () {
    $('#OrderList').dataTable().fnDestroy();
    var region = $('#drpRegion').val();
    var drpSalesOrg = $('#drpSalesOrg').val();
    var drpDiv = $('#drpDiv').val();
    var drpArea = $('#drpArea').val();
    var drpTerritory = $('#drpTerritory').val();
    var drpTown = $('#drpTown').val();
    var drpPlant = $('#drpPlant').val();
    var Customer = $('#drpCustomerName').val();
    var newCustomer = (Customer == null) ? "" : Customer + "";
    region = (region == null) ? "" : region + "";
    drpSalesOrg = (drpSalesOrg == null) ? "" : drpSalesOrg + "";
    drpDiv = (drpDiv == null) ? "" : drpDiv + "";
    drpArea = (drpArea == null) ? "" : drpArea + "";
    drpTerritory = (drpTerritory == null) ? "" : drpTerritory + "";
    drpTown = (drpTown == null) ? "" : drpTown + "";
    drpPlant = (drpPlant == null) ? "" : drpPlant + "";
    // $('#drpRefrenceCode').DataTable().ajax.reload();

    //if (('#drpCustomer').val() == -1)
    //{
    //    orderID = -1;
    //}


    $.ajax({
        type: "POST",
        url: "GridView",
        //data: { RegionCode: orderID },
        data: {
            customer: newCustomer,
            salesorg: drpSalesOrg,
            division: drpDiv,
            region: region,
            area: drpArea,
            territory: drpTerritory,
            town: drpTown,
            plant: drpPlant

        },
        datatype: "json",
        //traditional: true,
        //beforeSend: function () {

        //    setTimeout(function () {
        //        $("#divLoader").show();
        //    }, 1);
        //    // please note i have added a delay of 1 millisecond with js timeout function which runs almost same as code with no delay.
        //},
        //complete: function (data) {
        //    $("#divLoader").hide();
        //    //here i write success code
        //},
        success: function (data) {
            groupData = data.groupdata;
            $('#OrderList').dataTable().fnDestroy();
            table = $("#OrderList").DataTable({
                "processing": false, // for show progress bar
                "serverSide": false, // for process server side
                "filter": true, // this is for disable filter (search box)
                "orderMulti": false, // for disable multiple column at once
                "data": data.emp,
                "dataSrc": "",
                'order': [[1, 'asc']],
                //"deferRender": true,
                "columns": [
                    //{ "data": "distinctValue", "name": "distinctValue" },
                    { "data": "CALDAY", "class": "CALDAY", "name": "CALDAY", "autoWidth": true, "visible": false },
                   //   { "data": "COMP_CODE", "class": "COMP_CODE", "name": "COMP_CODE", "autoWidth": true },
                    { "data": "Order_Ref", "class": "Order_Ref", "name": "Order_Ref", "autoWidth": true },
                    { "data": "SALESORG", "class": "SALESORG", "name": "SALESORG", "autoWidth": true },
                    {
                        //"data": "CUSTOMER",
                        "class": "CUSTOMER", "name": "CUSTOMER", "autoWidth": true,
                        "render": function (data, type, full, meta) {
                            //console.log(data);
                            return "<a href='javascript:showGroupData(" + full.CUSTOMER + "," + full.SALESORG + "," + full.DIVISION + "," + full.MaterialGroup + ");' >" + full.CUSTOMER + "</a>";
                        }
                    },
                    { "data": "customerName", "class": "BPCTOTPAGE", "name": "BPCTOTPAGE", "autoWidth": true },
                     { "data": "RegionDescription", "class": "RegionDescription", "name": "RegionDescription", "autoWidth": true },
                        { "data": "AreaDescription", "class": "AreaDescription", "name": "AreaDescription", "autoWidth": true },
                          { "data": "TerritoryDescription", "class": "TerritoryDescription", "name": "TerritoryDescription", "autoWidth": true },
                            { "data": "TownDescription", "class": "TownDescription", "name": "TownDescription", "autoWidth": true },
                    { "data": "MATERIAL", "class": "MATERIAL", "name": "MATERIAL", "autoWidth": true },
                    { "data": "Description", "class": "DIVISION", "name": "DIVISION", "autoWidth": true },
                    { "data": "Order_Qty", "class": "Order_Qty", "name": "Order_Qty", "autoWidth": true },
                    { "data": "UnitPrice", "class": "UnitPrice", "name": "UnitPrice", "autoWidth": true },
                    { "data": "MaterialTotalValues", "class": "MaterialTotalValues", "name": "MaterialTotalValues", "autoWidth": true },
                    { "data": "weekNumber", "class": "weekNumber", "name": "weekNumber", "autoWidth": true },
                    { "data": "DIVISION", "class": "DIVISION", "name": "DIVISION", "autoWidth": true, "visible": false },
                    { "data": "MaterialGroup", "class": "MaterialGroup", "name": "MaterialGroup", "autoWidth": true, "visible": true },
                    { "data": "MaterialGroupdescription", "class": "MaterialGroupdescription", "name": "MaterialGroupdescription", "autoWidth": true, "visible": true },

                      { "data": "DistributorClosingStock", "class": "DistributorClosingStock", "name": "DistributorClosingStock", "autoWidth": true },
                        { "data": "SafetyStock", "class": "SafetyStock", "name": "SafetyStock", "autoWidth": true },
                          { "data": "RSFQTY", "class": "RSFQTY", "name": "RSFQTY", "autoWidth": true },
                          { "data": "SKUMapping", "class": "SKUMapping", "name": "SKUMapping", "autoWidth": true },
                          { "data": "MaxDay", "class": "MaxDay", "name": "MaxDay", "autoWidth": true, },
                          { "data": "DISTR_CHAN", "class": "DISTR_CHAN", "name": "DISTR_CHAN", "autoWidth": true, "visible": false },
                                          {
                                              "defaultContent": "<button id='click' class='btn btn-primary m-t-6 waves-effect'>View</button>"
                                              //mRender: function (data, type, row) {
                                              //    //return '<a href="#" class="table-edit" data-id="Id" onclick="Edit(' + row.Role_ID + ')">EDIT</a> / <a href="#" class="editor_remove" onclick="Delete(' + row.Id + ')">Delete</a>'
                                              //    //return '<a href="#" class="table-edit" data-id="Id" data-toggle="modal" data-target="addevent" onclick="EditRoles(' + row.Role_ID + ')">EDIT</a> / <a href="#" class="editor_remove" onclick="Delete(' + row.Id + ')">Delete</a>'
                                              //    return "<input type='button' ID='EditButton1' class='btn btn-round zmdi zmdi-edit EditButton' onclick='EditRoles(" + row.Role_ID + ")' data-toggle='modal' data-target='#addevent'/>"
                                              //}


                                          }
                ],
                'columnDefs': [
                    {
                        'targets': 0,
                        'checkboxes': {
                            'selectRow': true
                        }
                    }
                ],
                'select': {
                    'style': 'multi'
                },
                footerCallback: function (tfoot, data, start, end, display) {

                    var api = this.api();
                    $(api.column(11).footer()).html('Total Proposed Order = ' +
                        api.column(11).data().reduce(function (a, b) {
                            return parseInt(a) + parseInt(b);
                        }, 0)
                         );
                    $(api.column(12).footer()).html('Total Unit Price = ' +
                       api.column(12).data().reduce(function (a, b) {
                           return parseInt(a) + parseInt(b);
                       }, 0)
                     );
                    $(api.column(13).footer()).html('Total Amount = ' +
                     api.column(13).data().reduce(function (a, b) {
                         return parseInt(a) + parseInt(b);
                     }, 0)
                   );
                    setTimeout(function () {
                        $("#OrderList tbody TR").each(function (i, v) {
                            two = $(v).find("td:eq(20)").text();

                            //three = $(v).find("td:eq(3)").html();
                            if (parseInt(two) >= 48) {
                                console.log(two);
                                $(v).css("background-color", "yellow");
                            }
                        });
                    }, 500);
                    //$(api.column(5).footer()).html('total Special Quantity= ' +
                    //                api.column(5).data().reduce(function (a, b) {
                    //                    return a + b;
                    //                }, 0)
                    //              );

                },

            });

        }




    });



}

function clickable() {
    $('#OrderList tbody').on('click', 'button', function () {


        var data = table.row($(this).parents("tr")).data();
        var Customer = $(this).closest("tr").find(".CUSTOMER").text();




        $("#largeModal1").modal();
        $.ajax({
            type: "POST",
            url: "/GenerateOrder/GetFrequency",
            //data: { RegionCode: orderID },
            data: {
                customer: Customer,
            },
            datatype: "json",

            success: function (data) {
                groupData = data.groupdata;
                $('#list').dataTable().fnDestroy();
                table = $("#list").DataTable({
                    "processing": false, // for show progress bar
                    "serverSide": false, // for process server side
                    "filter": true, // this is for disable filter (search box)
                    "orderMulti": false, // for disable multiple column at once
                    "data": data,
                    "dataSrc": "",
                    'order': [[1, 'asc']],
                    //"deferRender": true,
                    "columns": [
               { "data": "OrderRefrenceNumber", "class": "OrderRefrenceNumber", "name": "OrderRefrenceNumber", "autoWidth": true },
                { "data": "CALDAY", "class": "CALDAY", "name": "CALDAY", "autoWidth": true, "visible": false },
                { "data": "Material", "class": "Material", "name": "Material", "autoWidth": true },
                { "data": "Description", "class": "Description", "name": "Description", "autoWidth": true },
                //{ "data": "UnitPrice", "class": "UnitPrice", "name": "UnitPrice", "autoWidth": true },
                //{ "data": "Quantity", "class": "Quantity", "name": "Quantity", "autoWidth": true },
                { "data": "WeeklyQuantity", "class": "WeeklyQuantity", "name": "WeeklyQuantity", "autoWidth": true },
                //{ "data": "FirmOrder", "class": "FirmOrder", "name": "FirmOrder", "autoWidth": true },
                { "data": "Monday", "class": "Monday", "name": "Monday", "autoWidth": true },
                { "data": "Tuesday", "class": "Tuesday", "name": "Tuesday", "autoWidth": true },
                { "data": "Wednesday", "class": "Wednesday", "name": "Wednesday", "autoWidth": true },
                { "data": "Thursday", "class": "Thursday", "name": "Thursday", "autoWidth": true },
                { "data": "Friday", "class": "Friday", "name": "Friday", "autoWidth": true },
                { "data": "Saturday", "class": "Saturday", "name": "Saturday", "autoWidth": true },
                { "data": "Sunday", "class": "Sunday", "name": "Sunday", "autoWidth": true },
                { "data": "UnitPrice", "class": "UnitPrice", "name": "UnitPrice", "autoWidth": true },
                { "data": "TotalValue", "class": "TotalValue", "name": "TotalValue", "autoWidth": true },
                //{
                //    "render": function (data, type, row) {

                //        $('#txtOverallUplift').change(function () {
                //            var uplift = $('#txtOverallUplift').val();
                //            return Math.round(row.WeeklyQuantity * uplift) / 100;

                //        });

                //    }
                //}
                  //{
                  //    "defaultContent": "<button id='click'>Update!</button>"
                  //}


                    ],

                    footerCallback: function (tfoot, data, start, end, display) {
                        var api = this.api();

                        //       $(api.column(0).footer()).html('Total Suggested Order = ' +
                        //api.column(0).data().reduce(function (a, b) {
                        //    return a + b;
                        //}, 0)

                        //       );

                        $(api.column(4).footer()).html('Total Suggested Order = ' +
                     api.column(4).data().reduce(function (a, b) {
                         return a + b;
                     }, 0)

                            );
                        $(api.column(5).footer()).html('Total Monday = ' +
                         api.column(5).data().reduce(function (a, b) {
                             return a + b;
                         }, 0)
                         );
                        $(api.column(6).footer()).html('Total Tuesday = ' +
                       api.column(6).data().reduce(function (a, b) {
                           return a + b;
                       }, 0)
                       );
                        $(api.column(7).footer()).html('Total Wednesday = ' +
                       api.column(7).data().reduce(function (a, b) {
                           return a + b;
                       }, 0)
                       );
                        $(api.column(8).footer()).html('Total Thursday = ' +
                       api.column(8).data().reduce(function (a, b) {
                           return a + b;
                       }, 0)
                       );
                        $(api.column(9).footer()).html('Total Friday = ' +
                       api.column(9).data().reduce(function (a, b) {
                           return a + b;
                       }, 0)
                       );
                        $(api.column(10).footer()).html('Total Saturday = ' +
                    api.column(10).data().reduce(function (a, b) {
                        return a + b;
                    }, 0)
                    );
                        $(api.column(11).footer()).html('Total Sunday = ' +
              api.column(11).data().reduce(function (a, b) {
                  return a + b;
              }, 0)
              );
                        $(api.column(12).footer()).html('Total Unit Price Rs = ' +
            api.column(12).data().reduce(function (a, b) {
                return a + b;
            }, 0)
            );

                        $(api.column(13).footer()).html('Total Amount Rs = ' +
   api.column(13).data().reduce(function (a, b) {
       return a + b;
   }, 0)
   );

                    },


                });
                $("#list").dataTable().fnDestroy();
            }




        });

    });
}




function saveData(url) {
    //$('#OrderList').dataTable().fnDestroy();
    //var OrderListModal = new Array();
    //$("#OrderList TBODY TR").each(function () {
    //    var row = $(this);
    //    var OrderModel = {};
    //    // OrderModel.CALDAY = row.find("TD").eq(0).html();;
    //    //rderModel.COMP_CODE = row.find("TD").eq(1).html();
    //    //OrderModel.DISTR_CHAN = row.find("TD").eq(2).html();
    //    OrderModel.SALESORG = row.find("TD").eq(0).html();
    //    OrderModel.CUSTOMER = row.find("TD").eq(1).html();
    //    OrderModel.MATERIAL = row.find("TD").eq(2).html();
    //    //OrderModel.BPCTOTPAGE = row.find("TD").eq(6).html();
    //    //OrderModel.DIVISION = row.find("TD").eq(7).html();
    //    OrderModel.Order_Qty = row.find("TD").eq(3).html();

    //    OrderListModal.push(OrderModel);


    //});
    //var dataToPost = JSON.stringify(OrderListModal);
    //console.log(dataToPost);
    //var dataToPost = '{Rele_Desc: "' + $("#txtReleDesc").val() + '" }';
    Common.Ajax('POST', url, '', 'json', successRoleCreateHandler);
    //$('#OrderList').dataTable();
}

function saveConfirmData(url) {
    $('#OrderList').dataTable().fnDestroy();
    //table.fnDestroy();
    var OrderListModal = new Array();
    $("#OrderList TBODY TR").each(function () {
        var row = $(this);
        if (row.find("input[type=checkbox]:checked").length == 0) {
            return;
        }
        
        var OrderModel = {};
        OrderModel.CALDAY = row.find("TD").eq(1).html();
        //OrderModel.CALDAY = "2020-02-26";
        //rderModel.COMP_CODE = row.find("TD").eq(1).html();
        OrderModel.Order_Ref = row.find("TD").eq(2).html();
        OrderModel.SALESORG = row.find("TD").eq(3).html();
        OrderModel.CUSTOMER = row.find("TD").eq(4).find("a").html();

        OrderModel.MATERIAL = row.find("TD").eq(10).html();
        //OrderModel.BPCTOTPAGE = row.find("TD").eq(6).html();

        OrderModel.Order_Qty = row.find("TD").eq(12).html();
        OrderModel.MaterialTotalValues = row.find("TD").eq(14).html();

        OrderModel.weekNumber = row.find("TD").eq(15).html();
        OrderModel.DIVISION = row.find("TD").eq(16).html();
        OrderModel.DISTR_CHAN = row.find("TD").eq(24).html();
        OrderListModal.push(OrderModel);


    });
    var dataToPost = JSON.stringify(OrderListModal);
    console.log(dataToPost);
    // var dataToPost = '{Rele_Desc: "' + $("#txtReleDesc").val() + '" }';
    Common.Ajax('POST', url, dataToPost, 'json', successRoleCreateHandlerORder);

}


function successRoleCreateHandler(response) {






    if (response == '1') {
        //tableMain.DataTable().ajax.reload();

        $('#successAlert').show('fade');

        setTimeout(function () {
            $('#successAlert').hide('fade');
        }, 5000);

        dataload();
    }
    if (response == '-1') {
        $('#warningAlert').show('fade');

        setTimeout(function () {
            $('#warningAlert').hide('fade');
        }, 5000);
    }
}

function successRoleCreateHandlerORder(response) {

    //$('#OrderList').DataTable().ajax.reload();
    //$('#OrderList').dataTable({ 'order': [[1, 'asc']]});
    dataload();
    if (response == '1') {
        $('#successAlert').show('fade');

        setTimeout(function () {
            $('#successAlert').hide('fade');
        }, 5000);
    }
    if (response == '-1') {
        $('#warningAlert').show('fade');

        setTimeout(function () {
            $('#warningAlert').hide('fade');
        }, 5000);
    }
}



//function BindDropDownCustomer(url, region) {
//    //if (material == "" || material == "null" || material == null)
//    Common.Ajax('GET', url, { region }, 'json', BindDropDownCustomerHandler);
//}
//function BindDropDownCustomerHandler(response) {
//    //var res = response.data.unique();
//    //var res = $.unique(response);
//    var outputArray = [];
//    var s = '';//<option value="-1">Material</option>';
//    for (var i = 0; i < response.length; i++) {

//        //if ((jQuery.inArray(response[i], outputArray)) == -1) {
//        s += '<option value="' + response[i].CUSTOMER + '">' + response[i].customerName + '</option>';
//        //}
//    }


//    $("#drpCustomerName").html(s);
//    $("#drpCustomerName").multiselect({
//        columns: 1,
//        placeholder: 'Customer',
//        search: true,
//        searchOptions: {
//            'default': 'Search'
//        },
//        selectAll: true
//    });
//    $("#drpCustomerName").multiselect("reload");
//    $('#divLoader').hide();
//    //column.data().unique().sort().each(function (d, j) {
//    //    select.append('<option value="' + d + '">' + d + '</option>')


//}





function BindDropDownNAme(url, name, salesorg, div, category, region, area, territory, town, plant) {
    if (name == '' || name == 'null' || name == null)
        Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownNameHandler);
}
function BindDropDownNameHandler(response) {
    //var res = response.data.unique();
    //var res = $.unique(response);
    var outputArray = [];
    var s = '';//'<option value="-1">Name</option>';
    for (var i = 0; i < response.length; i++) {
        if (response[i].Name1 == '') continue;

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            var CustomerName = isNaN(parseInt(response[i].Customer)) ? response[i].Name1 : response[i].Name1 + ' (' + parseInt(response[i].Customer) + ')';
            s += '<option value="' + response[i].Customer + '">' + CustomerName + '</option>';
        }
    }


    $("#drpCustomerName").html(s);
    $('#drpCustomerName').multiselect({
        columns: 1,
        placeholder: 'Customer',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#drpCustomerName").multiselect("reload");
    //column.data().unique().sort().each(function (d, j) {
    //    select.append('<option value="' + d + '">' + d + '</option>')


}
function BindDropDownsalesorg(url, name, salesorg, div, category, region, area, territory, town, plant) {
    if (salesorg == '' || salesorg == 'null' || salesorg == null)

        Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownSalesHandler);
}
function BindDropDownSalesHandler(response) {
    //var res = response.data.unique();
    //var res = $.unique(response);
    var outputArray = [];
    //var s = '<option value="-1">Sales Org</option>';
    var s = '';//<option value="-1">Sales Org</option>';
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].SalesOrganization + '">' + response[i].SalesOrganization + '</option>';
        }
    }


    $("#drpSalesOrg").html(s);
    $("#drpSalesOrg").multiselect({
        columns: 1,
        placeholder: 'Sales Org',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#drpSalesOrg").multiselect("reload");
    //column.data().unique().sort().each(function (d, j) {
    //    select.append('<option value="' + d + '">' + d + '</option>')


}
function BindDropDowndivision(url, name, salesorg, div, category, region, area, territory, town, plant) {
    if (div == '' || div == 'null' || div == null)

        Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownDivHandler);
}
function BindDropDownDivHandler(response) {
    //var res = response.data.unique();
    //var res = $.unique(response);
    var outputArray = [];
    var s = '';//<option value="-1">Division</option>';
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].Division + '">' + response[i].Division + '</option>';
        }
    }


    $("#drpDiv").html(s);
    $("#drpDiv").multiselect({
        columns: 1,
        placeholder: 'Division',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#drpDiv").multiselect("reload");
    //column.data().unique().sort().each(function (d, j) {
    //    select.append('<option value="' + d + '">' + d + '</option>')


}
function BindDropDowncategory(url, name, salesorg, div, category, region, area, territory, town, plant) {
    if (category == '' || category == 'null' || category == null)

        Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownCategoryHandler);
}
function BindDropDownCategoryHandler(response) {
    //var res = response.data.unique();
    //var res = $.unique(response);
    var outputArray = [];
    var s = '';//<option value="-1">Package Name</option>';
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].packageName + '">' + response[i].packageName + '</option>';
        }
    }


    $("#drpCategory").html(s);
    $("#drpCategory").multiselect({
        columns: 1,
        placeholder: 'Package Name',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#drpCategory").multiselect("reload");
    //column.data().unique().sort().each(function (d, j) {
    //    select.append('<option value="' + d + '">' + d + '</option>')


}
function BindDropDownregion(url, name, salesorg, div, category, region, area, territory, town, plant) {
    if (region == '' || region == 'null' || region == null)

        Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownRegionHandler);
}
function BindDropDownRegionHandler(response) {
    //var res = response.data.unique();
    //var res = $.unique(response);
    var outputArray = [];
    var s = '';//<option value="-1">Region</option>';
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].RegionCode + '">' + response[i].RegionDescription + '</option>';
        }
    }


    $("#drpRegion").html(s);
    $("#drpRegion").multiselect({
        columns: 1,
        placeholder: 'Region',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#drpRegion").multiselect("reload");
    //column.data().unique().sort().each(function (d, j) {
    //    select.append('<option value="' + d + '">' + d + '</option>')


}
function BindDropDownarea(url, name, salesorg, div, category, region, area, territory, town, plant) {

    if (area == '' || area == 'null' || area == null)
        Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownAreaHandler);
}
function BindDropDownAreaHandler(response) {
    //var res = response.data.unique();
    //var res = $.unique(response);
    var outputArray = [];
    var s = '';//<option value="-1">Area</option>';
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].AreaCode + '">' + response[i].AreaDescription + '</option>';
        }
    }


    $("#drpArea").html(s);
    $("#drpArea").multiselect({
        columns: 1,
        placeholder: 'Area',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });

    $("#drpArea").multiselect("reload");
    //column.data().unique().sort().each(function (d, j) {
    //    select.append('<option value="' + d + '">' + d + '</option>')


}
function BindDropDownterritory(url, name, salesorg, div, category, region, area, territory, town, plant) {
    if (territory == '' || territory == 'null' || territory == null)

        Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownTerritoryHandler);
}
function BindDropDownTerritoryHandler(response) {
    //var res = response.data.unique();
    //var res = $.unique(response);
    var outputArray = [];
    var s = '';//<option value="-1">Territory</option>';
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].TerritoryCode + '">' + response[i].TerritoryDescription + '</option>';
        }
    }


    $("#drpTerritory").html(s);
    $("#drpTerritory").multiselect({
        columns: 1,
        placeholder: 'Territory',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#drpTerritory").multiselect("reload");
    //column.data().unique().sort().each(function (d, j) {
    //    select.append('<option value="' + d + '">' + d + '</option>')


}
function BindDropDowntown(url, name, salesorg, div, category, region, area, territory, town, plant) {
    if (town == '' || town == 'null' || town == null)

        Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownTownHandler);
}
function BindDropDownTownHandler(response) {
    //var res = response.data.unique();
    //var res = $.unique(response);
    var outputArray = [];
    var s = '';//<option value="-1">Town</option>';
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].TownCode + '">' + response[i].TownDescription + '</option>';
        }
    }


    $("#drpTown").html(s);
    $("#drpTown").multiselect({
        columns: 1,
        placeholder: 'Town',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#drpTown").multiselect("reload");
    //column.data().unique().sort().each(function (d, j) {
    //    select.append('<option value="' + d + '">' + d + '</option>')


}
function BindDropDownplant(url, name, salesorg, div, category, region, area, territory, town, plant) {
    if (plant == '' || plant == 'null' || plant == null)

        Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownPlantHandler);
}
function BindDropDownPlantHandler(response) {
    //var res = response.data.unique();
    //var res = $.unique(response);
    var outputArray = [];
    var s = '';//<option value="-1">Plant</option>';
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].TownCode + '">' + response[i].DeliveringPlant + '</option>';
        }
    }


    $("#drpPlant").html(s);
    $("#drpPlant").multiselect({
        columns: 1,
        placeholder: 'Plant',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#drpPlant").multiselect("reload");


}