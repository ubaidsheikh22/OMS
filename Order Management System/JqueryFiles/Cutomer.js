/// <reference path="GenericAjax.js" />

var name = $('#drpCustomerName').val() == "-1" || undefined ? "" : $('#drpCustomerName').val();
var salesorg = $('#drpSalesOrg').val() == "-1" || undefined ? "" : $('#drpSalesOrg').val();
var div = $('#drpDiv').val() == "-1" || undefined ? "" : $('#drpDiv').val();
var category = $('#drpCategory').val() == "-1" || undefined ? "" : $('#drpCategory').val();
var region = $('#drpRegion').val() == "-1" || undefined ? "" : $('#drpRegion').val();
var area = $('#drpArea').val() == "-1" || undefined ? "" : $('#drpArea').val();
var territory = $('#drpTerritory').val() == "-1" || undefined ? "" : $('#drpTerritory').val();
var town = $('#drpTown').val() == "-1" || undefined ? "" : $('#drpTown').val();
var plant = $('#drpPlant').val() == "-1" || undefined ? "" : $('#drpPlant').val();

$(document).ready(function () {

    BindDropDownNAme('GetCustomerName', '', '', '', '', '', '', '', '', '');
    BindDropDownsalesorg('GetSalesOrg', '', '', '', '', '', '', '', '', '');
    BindDropDowndivision('GetDivision', '', '', '', '', '', '', '', '', '');
    BindDropDowncategory('GetCategory', '', '', '', '', '', '', '', '', '');
    BindDropDownregion('GetRegion', '', '', '', '', '', '', '', '', '');
    BindDropDownarea('GetArea', '', '', '', '', '', '', '', '', '');
    BindDropDownterritory('GetTerritory', '', '', '', '', '', '', '', '', '');
    BindDropDowntown('GetTown', '', '', '', '', '', '', '', '', '');
    BindDropDownplant('GetPlant', '', '', '', '', '', '', '', '', '');

    var table = $('#CustomerList').DataTable();
    DataLoad();

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
        DataLoad();
        BindDropDownsalesorg('GetSalesOrg', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowndivision('GetDivision', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowncategory('GetCategory', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownregion('GetRegion', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownarea('GetArea', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownterritory('GetTerritory', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowntown('GetTown', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownplant('GetPlant', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
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
        DataLoad();

        BindDropDownNAme('GetCustomerName', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowndivision('GetDivision', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowncategory('GetCategory', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownregion('GetRegion', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownarea('GetArea', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownterritory('GetTerritory', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowntown('GetTown', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownplant('GetPlant', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
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
        DataLoad();

        BindDropDownNAme('GetCustomerName', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownsalesorg('GetSalesOrg', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowncategory('GetCategory', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownregion('GetRegion', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownarea('GetArea', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownterritory('GetTerritory', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowntown('GetTown', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownplant('GetPlant', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
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
        DataLoad();

        BindDropDownNAme('GetCustomerName', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownsalesorg('GetSalesOrg', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowndivision('GetDivision', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownregion('GetRegion', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownarea('GetArea', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownterritory('GetTerritory', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowntown('GetTown', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownplant('GetPlant', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
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
        DataLoad();

        BindDropDownNAme('GetCustomerName', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownsalesorg('GetSalesOrg', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowndivision('GetDivision', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowncategory('GetCategory', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownarea('GetArea', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownterritory('GetTerritory', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowntown('GetTown', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownplant('GetPlant', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
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
        DataLoad();

        BindDropDownNAme('GetCustomerName', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownsalesorg('GetSalesOrg', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowndivision('GetDivision', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowncategory('GetCategory', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownregion('GetRegion', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownterritory('GetTerritory', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowntown('GetTown', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownplant('GetPlant', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
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
        DataLoad();

        BindDropDownNAme('GetCustomerName', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownsalesorg('GetSalesOrg', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowndivision('GetDivision', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowncategory('GetCategory', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownregion('GetRegion', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownarea('GetArea', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowntown('GetTown', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownplant('GetPlant', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
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
        DataLoad();

        BindDropDownNAme('GetCustomerName', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownsalesorg('GetSalesOrg', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowndivision('GetDivision', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowncategory('GetCategory', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownregion('GetRegion', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownarea('GetArea', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownterritory('GetTerritory', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownplant('GetPlant', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
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
        DataLoad();

        BindDropDownNAme('GetCustomerName', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownsalesorg('GetSalesOrg', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowndivision('GetDivision', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowncategory('GetCategory', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownregion('GetRegion', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownarea('GetArea', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDownterritory('GetTerritory', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
        BindDropDowntown('GetTown', name, newsalesorg, newDiv, newCat, newregion, newArea, newsterr, newtown, newplant);
    });


    $("#btnn").click(function () {

        $("#divLoader").show();

        var a = document.createElement('a');
        var data_type = 'data:application/vnd.ms-excel';
        var table = $('#CustomerList');
        $('#CustomerList').dataTable().fnDestroy();
        // var Header = table.find('th');
        var table_html = '<table><thead><tr><th>Customer Code</th><th>Customer Name</th><th>Name 2</th><th>Sales Organization</th><th>Division</th><th>Category</th><th>Region Code</th><th>Region Description</th><th>Area Code</th><th>Area Description</th><th>Territory Code</th><th>Territory Description</th><th>Town Code</th><th>Town Description</th><th>Delivering Plant</th><th>Delivering Plant</th></tr></thead></table>';
        table_html = table_html + table[0].outerHTML.replace(/ /g, '%20');
        a.href = data_type + ', ' + table_html;
        a.download = 'Customer Master.xls';
        a.click();
        $("#divLoader").hide();
        DataLoad();
    });




    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });
});



function DataLoad() {
    $('#CustomerList').dataTable().fnDestroy();


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


    $.ajax({
        type: "POST",
        url: "GetAllCustomerRecords",
        data: {
            name: name,
            sales: newsalesorg,
            div: newDiv,
            category: newCat,
            region: newregion,
            area: newArea,
            territory: newsterr,
            town: newtown,
            plant: newplant

        },
        beforeSend: function () {

            //setTimeout(function () {
            $("#divLoader").show();
            //}, 1);
            // please note i have added a delay of 1 millisecond with js timeout function which runs almost same as code with no delay.
        },
        complete: function (data) {
            $("#divLoader").hide();
            //here i write success code
        },

        datatype: "json",
        //traditional: true,

        success: function (data) {
            //console.log(data);
            $("#CustomerList").DataTable({
                "processing": false, // for show progress bar
                "serverSide": false, // for process server side
                "filter": true, // this is for disable filter (search box)
                "orderMulti": false, // for disable multiple column at once
                "data": data,
                "dataSrc": "",
                "deferRender": false,
                //"scrollY": 200,
                "scrollX": true,
                rowReorder: true,

                "columns": [

                    { "data": "Customer", "name": "Customer", "class": "Customer", "autoWidth": true },
                    { "data": "Name1", "class": "Name1", "name": "Name1", "autoWidth": true },
                    { "data": "Name2", "class": "Name2", "name": "Name2", "autoWidth": true },
                    { "data": "SalesOrganization", "class": "SalesOrganization", "name": "SalesOrganization", "autoWidth": true },

                    { "data": "Division", "class": "Division", "name": "Division", "autoWidth": true },
                    { "data": "packageName", "class": "packageName", "name": "packageName", "autoWidth": true },
                    { "data": "RegionCode", "class": "RegionCode", "name": "RegionCode", "autoWidth": true },
                    { "data": "RegionDescription", "class": "RegionDescription", "name": "RegionDescription", "autoWidth": true },
                    { "data": "AreaCode", "class": "AreaCode", "name": "AreaCode", "autoWidth": true },
                    { "data": "AreaDescription", "class": "AreaDescription", "name": "AreaDescription", "autoWidth": true },
                    { "data": "TerritoryCode", "class": "TerritoryCode", "name": "TerritoryCode", "autoWidth": true },
                    { "data": "TerritoryDescription", "class": "TerritoryDescription", "name": "TerritoryDescription", "autoWidth": true },
                    { "data": "TownCode", "class": "TownCode", "name": "TownCode", "autoWidth": true },
                    { "data": "TownDescription", "class": "TownDescription", "name": "TownDescription", "autoWidth": true },
                    { "data": "DeliveringPlant", "class": "DeliveringPlant", "name": "DeliveringPlant", "autoWidth": true },
                    { "data": "PlantDescription", "class": "PlantDescription", "name": "PlantDescription", "autoWidth": true },

                    //{ "data": "DistributionChannel", "class": "DistributionChannel", "name": "DistributionChannel", "autoWidth": true },
                ]
            });
        }
    });
}

function successUserCreateHandler(response) {

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

function BindDropDownNAme(url, name, salesorg, div, category, region, area, territory, town, plant) {
    if (name == '' || name == 'null' || name == null)
        Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownNameHandler);
}
function BindDropDownNameHandler(response) {
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

}
function BindDropDownsalesorg(url, name, salesorg, div, category, region, area, territory, town, plant) {
    if (salesorg == '' || salesorg == 'null' || salesorg == null)

        Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownSalesHandler);
}
function BindDropDownSalesHandler(response) {
    var outputArray = [];
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
}

function BindDropDowndivision(url, name, salesorg, div, category, region, area, territory, town, plant) {
    if (div == '' || div == 'null' || div == null)
        Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownDivHandler);
}

function BindDropDownDivHandler(response) {
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
}

function BindDropDowncategory(url, name, salesorg, div, category, region, area, territory, town, plant) {
    if (category == '' || category == 'null' || category == null)
        Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownCategoryHandler);
}

function BindDropDownCategoryHandler(response) {
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
        placeholder: 'Customer Category',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#drpCategory").multiselect("reload");
}

function BindDropDownregion(url, name, salesorg, div, category, region, area, territory, town, plant) {
    if (region == '' || region == 'null' || region == null)
        Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownRegionHandler);
}

function BindDropDownRegionHandler(response) {
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
}

function BindDropDownarea(url, name, salesorg, div, category, region, area, territory, town, plant) {
    if (area == '' || area == 'null' || area == null)
        Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownAreaHandler);
}

function BindDropDownAreaHandler(response) {
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
}
function BindDropDownterritory(url, name, salesorg, div, category, region, area, territory, town, plant) {
    if (territory == '' || territory == 'null' || territory == null)

        Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownTerritoryHandler);
}
function BindDropDownTerritoryHandler(response) {
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
}

function BindDropDowntown(url, name, salesorg, div, category, region, area, territory, town, plant) {
    if (town == '' || town == 'null' || town == null)
        Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownTownHandler);
}

function BindDropDownTownHandler(response) {
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
}

function BindDropDownplant(url, name, salesorg, div, category, region, area, territory, town, plant) {
    if (plant == '' || plant == 'null' || plant == null)
        Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownPlantHandler);
}

function BindDropDownPlantHandler(response) {
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