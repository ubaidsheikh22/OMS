/// <reference path="GenericAjax.js" /> 


var Material = $('#Material').val() == "-1" || null ? "" : $('#Material').val();
var salesOrg = $('#salesOrg').val() == "-1" || null ? "" : $('#salesOrg').val();
var RegionCode = $('#RegionCode').val() == "-1" || null ? "" : $('#RegionCode').val();
var AreaCode = $('#AreaCode').val() == "-1" || null ? "" : $('#AreaCode').val();
var TerritoryCode = $('#TerritoryCode').val() == "-1" || null ? "" : $('#TerritoryCode').val();
var TownCode = $('#TownCode').val() == "-1" || null ? "" : $('#TownCode').val();
var Customer = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
var Division = $('#drpDivision').val() == "-1" || null ? "" : $('#drpDivision').val();

$(document).ready(function () {


    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });

    $('#Refresh').click(function () {
        Refresh('returnValue');
    });

    $('#btnn').on('click', function () {

        $("#divLoader").show();

        var a = document.createElement('a');
        var data_type = 'data:application/vnd.ms-excel';
        var table = $('#endStockList');
        $('#endStockList').dataTable().fnDestroy();
        // var Header = table.find('th');
        var table_html = '<table><thead><tr><th>Customer Code</th><th>Customer Name</th><th>Name 2</th><th>Sales Organization</th><th>Division</th><th>Category</th><th>Region Code</th><th>Region Description</th><th>Area Code</th><th>Area Description</th><th>Territory Code</th><th>Territory Description</th><th>Town Code</th><th>Town Description</th><th>Delivering Plant</th><th>Delivering Plant</th><th>Distribution Channel</th></tr></thead></table>';
        table_html = table_html + table[0].outerHTML.replace(/ /g, '%20');
        a.href = data_type + ', ' + table_html;
        a.download = 'EndStock Master.xls';
        a.click();
        $("#divLoader").hide();
        // window.open('data:application/vnd.ms-excel,' + encodeURIComponent(table[0].outerHTML));
    });


    //var table = $('#endStockList').DataTable();
    DataLoad();
    //AllDataDataLoad();

    $('#Material').change(function () {
        DataLoad();
    });

    $('#salesOrg').change(function () {
        DataLoad();
    });

    $('#RegionCode').change(function () {
        DataLoad();
    });

    $('#AreaCode').change(function () {
        DataLoad();
    });

    $('#TerritoryCode').change(function () {
        DataLoad();
    });

    $('#TownCode').change(function () {
        DataLoad();
    });

    $('#drpCustomer').change(function () {
        DataLoad();
    });

    $('#drpDivision').change(function () {
        DataLoad();
    });

    $("#btnn").click(function () {

        $("#divLoader").show();

        var a = document.createElement('a');
        var data_type = 'data:application/vnd.ms-excel';
        var table = $('#endStockList');
        $('#endStockList').dataTable().fnDestroy();
        // var Header = table.find('th');
        var table_html = '<table><thead><tr><th>Calendar Month</th><th>Division</th><th>Customer (Sold-To Party)</th><th>Customer Name</th><th>Customer Name2</th><th>RegionDescription</th><th>AreaDescription</th><th>TerritoryDescription</th><th>TownDescription</th><th>Material</th><th>Material Description</th><th>MatPricingGrpDescription</th><th>MaterialGroup1_Description</th><th>MaterialGroup2_Description</th><th>MaterialGroup3_Description</th><th>MaterialGroup4_Description</th><th>MaterialGroup5_Description</th><th>MaterialGroupdescription</th><th>Company</th><th>Sales Organization</th><th>Distribution Channel</th><th>Basic Unit of Measure</th><th>Closing Quantity in Basic Unit of Measure</th></tr></thead></table>';
        table_html = table_html + table[0].outerHTML.replace(/ /g, '%20');
        a.href = data_type + ', ' + table_html;
        a.download = 'Customer Master.xls';
        a.click();
        $("#divLoader").hide();
    });



});
function AllDataDataLoad() {

    var table = $("#endStockList").DataTable({
        data: AllData,

        dom: 'Bfrtip',
        buttons: [{
            extend: 'excelHtml5',
        }],

        columnDefs: [
            {
                targets: 0,
                sortable: false
            },
        ],
        columnDefs: [
            {
                targets: 1,
                sortable: false
            },
        ],
        order: [[1, 2, 3, 4, 5, 6, 7, 8, "asc"]],

        "columnDefs": [
            { "orderable": false, "targets": "_all" }
        ],
        "scrollX": true,
        rowReorder: true,

        "columns": [
            { "data": "CalendarDay", "class": "CalendarDay", "name": "CalendarDay", "autoWidth": true },

            { "data": "Division", "class": "Division", "name": "Division", "autoWidth": true },
            { "data": "CustomerSoldToParty", "class": "CustomerSoldToParty", "name": "CustomerSoldToParty", "autoWidth": true },
            { "data": "CustomerName", "class": "CustomerName", "name": "CustomerName", "autoWidth": true },
            { "data": "CustomerName2", "class": "CustomerName2", "name": "CustomerName2", "autoWidth": true },
            { "data": "RegionDescription", "class": "RegionDescription", "name": "RegionDescription", "autoWidth": true },
            { "data": "AreaDescription", "class": "AreaDescription", "name": "AreaDescription", "autoWidth": true },
            { "data": "TerritoryDescription", "class": "TerritoryDescription", "name": "TerritoryDescription", "autoWidth": true },
            { "data": "TownDescription", "class": "TownDescription", "name": "TownDescription", "autoWidth": true },
            { "data": "Material", "class": "Material", "name": "Material", "autoWidth": true },
            { "data": "MaterialDescription", "class": "MaterialDescription", "name": "MaterialDescription", "autoWidth": true },
            { "data": "MatPricingGrpDescription", "class": "MatPricingGrpDescription", "name": "MatPricingGrpDescription", "autoWidth": true },
            { "data": "MaterialGroup1_Description", "class": "MaterialGroup1_Description", "name": "MaterialGroup1_Description", "autoWidth": true },
            { "data": "MaterialGroup2_Description", "class": "MaterialGroup2_Description", "name": "MaterialGroup2_Description", "autoWidth": true },
            { "data": "MaterialGroup3_Description", "class": "MaterialGroup3_Description", "name": "MaterialGroup3_Description", "autoWidth": true },
            { "data": "MaterialGroup4_Description", "class": "MaterialGroup4_Description", "name": "MaterialGroup4_Description", "autoWidth": true },
            { "data": "MaterialGroup5_Description", "class": "MaterialGroup5_Description", "name": "MaterialGroup5_Description", "autoWidth": true },
            { "data": "MaterialGroupdescription", "class": "MaterialGroupdescription", "name": "MaterialGroupdescription", "autoWidth": true },
            { "data": "Company", "class": "Company", "name": "Company", "autoWidth": true },
            { "data": "SalesOrganization", "class": "SalesOrganization", "name": "SalesOrganization", "autoWidth": true },
            { "data": "DistributionChannel", "class": "DistributionChannel", "name": "DistributionChannel", "autoWidth": true },
            { "data": "UOM", "class": "UOM", "name": "UOM", "autoWidth": true, "visible": false },
            { "data": "ClosingQuantity", "class": "dt-right", "name": "ClosingQuantity", "autoWidth": true },
        ],

        footerCallback: function (tfoot, data, start, end, display) {
            var api = this.api();
            $(api.column(22).footer()).html(
                api.column(22).data().reduce(function (a, b) {
                    return a + b;
                }, 0),
                $(tfoot).find('th').eq(20).html("Total Closing Quantity")

            );
        },
    });

}
function DataLoad() {
    $('#endStockList').dataTable().fnDestroy();

    $("#divLoader").fadeIn();

    Material = $('#Material').val() == "-1" || null ? "" : $('#Material').val();
    newMaterial = Material + "";
    salesorg = $('#salesOrg').val() == "-1" || null ? "" : $('#salesOrg').val();
    newsalesorg = salesorg + "";

    RegionCode = $('#RegionCode').val() == "-1" || null ? "" : $('#RegionCode').val();
    newRegionCode = RegionCode + "";
    AreaCode = $('#AreaCode').val() == "-1" || null ? "" : $('#AreaCode').val();
    newAreaCode = AreaCode + "";
    TerritoryCode = $('#TerritoryCode').val() == "-1" || null || $('#TerritoryCode').val() == undefined ? "" : $('#TerritoryCode').val();
    newTerritoryCode = TerritoryCode + "";
    TownCode = $('#TownCode').val() == "-1" || null ? "" : $('#TownCode').val();
    newTownCode = TownCode + "";
    Customer = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
    newCustomer = Customer + "";
    Division = $('#drpDivision').val() == "-1" || null ? "" : $('#drpDivision').val();
    newDivision = Division + "";
    var table = $("#endStockList").DataTable({

        //dom: 'Bfrtip',
        //buttons: [{
        //    extend: 'excelHtml5', 
        //}],
        "processing": false, // for show progress bar
        "serverSide": true,
        "ajax": {
            "url": "gridViewPaging?Material=" + newMaterial + "&salesOrg=" + newsalesorg + "&RegionCode=" + newRegionCode + "&AreaCode=" + newAreaCode
                + "&TerritoryCode=" + newTerritoryCode + "&TownCode=" + newTownCode + "&customer=" + newCustomer + "&division=" + newDivision,
            "type": "POST"
        },
        columnDefs: [
            {
                targets: 0,
                sortable: false
            },
        ],
        columnDefs: [
            {
                targets: 1,
                sortable: false
            },
        ],
        order: [[1, 2, 3, 4, 5, 6, 7, 8, "asc"]],

        "columnDefs": [
            { "orderable": false, "targets": "_all" }
        ],
        //"scrollY": 200,
        "scrollX": true,
        //rowReorder: true,

        "columns": [
            { "data": "CalendarDay", "class": "CalendarDay", "name": "CalendarDay", "autoWidth": true },

            { "data": "Division", "class": "Division", "name": "Division", "autoWidth": true },
            { "data": "CustomerSoldToParty", "class": "CustomerSoldToParty", "name": "CustomerSoldToParty", "autoWidth": true },
            { "data": "CustomerName", "class": "CustomerName", "name": "CustomerName", "autoWidth": true },
            { "data": "CustomerName2", "class": "CustomerName2", "name": "CustomerName2", "autoWidth": true },
            { "data": "RegionDescription", "class": "RegionDescription", "name": "RegionDescription", "autoWidth": true },
            { "data": "AreaDescription", "class": "AreaDescription", "name": "AreaDescription", "autoWidth": true },
            { "data": "TerritoryDescription", "class": "TerritoryDescription", "name": "TerritoryDescription", "autoWidth": true },
            { "data": "TownDescription", "class": "TownDescription", "name": "TownDescription", "autoWidth": true },


            { "data": "Material", "class": "Material", "name": "Material", "autoWidth": true },
            { "data": "MaterialDescription", "class": "MaterialDescription", "name": "MaterialDescription", "autoWidth": true },
            { "data": "MatPricingGrpDescription", "class": "MatPricingGrpDescription", "name": "MatPricingGrpDescription", "autoWidth": true },
            { "data": "MaterialGroup1_Description", "class": "MaterialGroup1_Description", "name": "MaterialGroup1_Description", "autoWidth": true },
            { "data": "MaterialGroup2_Description", "class": "MaterialGroup2_Description", "name": "MaterialGroup2_Description", "autoWidth": true },
            { "data": "MaterialGroup3_Description", "class": "MaterialGroup3_Description", "name": "MaterialGroup3_Description", "autoWidth": true },
            { "data": "MaterialGroup4_Description", "class": "MaterialGroup4_Description", "name": "MaterialGroup4_Description", "autoWidth": true },
            { "data": "MaterialGroup5_Description", "class": "MaterialGroup5_Description", "name": "MaterialGroup5_Description", "autoWidth": true },
            { "data": "MaterialGroupdescription", "class": "MaterialGroupdescription", "name": "MaterialGroupdescription", "autoWidth": true },


            { "data": "Company", "class": "Company", "name": "Company", "autoWidth": true },
            { "data": "SalesOrganization", "class": "SalesOrganization", "name": "SalesOrganization", "autoWidth": true },
            { "data": "DistributionChannel", "class": "DistributionChannel", "name": "DistributionChannel", "autoWidth": true },
            //{ "data": "ZDOC_CATG", "class": "ZDOC_CATG", "name": "ZDOC_CATG", "autoWidth": true },
            { "data": "UOM", "class": "UOM", "name": "UOM", "autoWidth": true, "visible": false },
            { "data": "ClosingQuantity", "class": "dt-right", "name": "ClosingQuantity", "autoWidth": true },


        ],

        footerCallback: function (tfoot, data, start, end, display) {
            var api = this.api();
            $(api.column(22).footer()).html(
                api.column(22).data().reduce(function (a, b) {
                    return a + b;
                }, 0),
                $(tfoot).find('th').eq(20).html("Total Closing Quantity")

            );
        },
    });      //"orderMulti": false, // for disable multiple column at once   

    BindDropDown(newMaterial, newsalesorg, newRegionCode, newAreaCode, newTerritoryCode, newTownCode, newCustomer, newDivision);

    $("#divLoader").fadeOut();
};



function BindDropDown(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division) {
    var url = "getAllDDL";
    Common.Ajax('GET', url, { Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division }, 'json', BindDropDownHandler);
}
function BindDropDownHandler(response) {
    ddlData = response;


    Material = $('#Material').val() == "-1" || null ? "" : $('#Material').val();
    newMaterial = "0000000000" + Material + "";
    salesOrg = $('#salesOrg').val() == "-1" || null ? "" : $('#salesOrg').val();
    newOrg = salesOrg + "";
    RegionCode = $('#RegionCode').val() == "-1" || null ? "" : $('#RegionCode').val();
    newRegionCode = RegionCode + "";
    AreaCode = $('#AreaCode').val() == "-1" || null ? "" : $('#AreaCode').val();
    newAreaCode = AreaCode + "";
    TerritoryCode = $('#TerritoryCode').val() == "-1" || null ? "" : $('#TerritoryCode').val();
    newTerritoryCode = TerritoryCode + "";
    TownCode = $('#TownCode').val() == "-1" || null ? "" : $('#TownCode').val();
    newTownCode = TownCode + "";
    Customer = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
    newCustomer = Customer + "";
    Division = $('#drpDivision').val() == "-1" || null ? "" : $('#drpDivision').val();
    newDivision = Division + "";
    //setTimeout(function () {
    BindDropDownMaterial('GetMaterial', newMaterial, newOrg, newRegionCode, newAreaCode, newTerritoryCode, newTownCode);
    BindDropDownSALESORG('GetSalesOrg', newMaterial, newOrg, newRegionCode, newAreaCode, newTerritoryCode, newTownCode, newCustomer, newDivision);
    BindDropDownRegion('GetRegion', newMaterial, newOrg, newRegionCode, newAreaCode, newTerritoryCode, newTownCode, newCustomer, newDivision);
    BindDropDownArea('GetArea', newMaterial, newOrg, newRegionCode, newAreaCode, newTerritoryCode, newTownCode, newCustomer, newDivision);
    BindDropDownTerritory('GetTerritory', newMaterial, newOrg, newRegionCode, newAreaCode, newTerritoryCode, newTownCode, newCustomer, newDivision);
    BindDropDownTown('GetTown', newMaterial, newOrg, newRegionCode, newAreaCode, newTerritoryCode, newTownCode, newCustomer, newDivision);
    BindDropDownCustomer('GetCustomer', newMaterial, newOrg, newRegionCode, newAreaCode, newTerritoryCode, newTownCode, newCustomer, newDivision);
    BindDropDownDivision('GetDivision', newMaterial, newOrg, newRegionCode, newAreaCode, newTerritoryCode, newTownCode, newCustomer, newDivision);
    //},7000);
}
function BindDropDownMaterial(url, Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division) {

    if (Material == "" || Material == "null" || Material.includes("null")) {
        if (ddlData.Material == undefined)
            Common.Ajax('GET', url, { Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division }, 'json', BindDropDownMaterialHandler);
        else {
            BindDropDownMaterialHandler(ddlData.Material);
        }
    }
}
function BindDropDownMaterialHandler(response) {
    //var res = response.data.unique();
    //var res = $.unique(response);
    var outputArray = [];
    var s = ''
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].Material + '">' + response[i].Description + ' (' + response[i].Material + ') </option>';
            //s += '<option value="' + response[i].Material + '">' + response[i].Description +  response[i].Material +'</option>';
        }
    }
    $("#Material").html(s);
    $("#Material").multiselect({
        columns: 1,
        placeholder: 'Material',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#Material").multiselect("reload");

    //column.data().unique().sort().each(function (d, j) {
    //    select.append('<option value="' + d + '">' + d + '</option>')
}


function BindDropDownSALESORG(url, Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division) {
    if (salesOrg == "" || salesOrg == "null") {
        if (ddlData.salesOrg == undefined)
            Common.Ajax('GET', url, { Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division }, 'json', BindDropDownSALESORGHandler);
        else {
            BindDropDownSALESORGHandler(ddlData.salesOrg);
        }

    }

}
function BindDropDownSALESORGHandler(response) {
    //var res = response.data.unique();
    //var res = $.unique(response);
    var outputArray = [];
    var s = '';
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].SalesOrganization + '">' + response[i].SalesOrganization + '</option>';
        }
    }


    $("#salesOrg").html(s);
    $("#salesOrg").multiselect({
        columns: 1,
        placeholder: 'sales Org',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#salesOrg").multiselect("reload");
    //column.data().unique().sort().each(function (d, j) {
    //    select.append('<option value="' + d + '">' + d + '</option>')
}
function BindDropDownRegion(url, Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division) {
    if (RegionCode == "" || RegionCode == "null") {
        if (ddlData.RegionCode == undefined)
            Common.Ajax('GET', url, { Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division }, 'json', BindDropDownRegionHandler);
        else {
            BindDropDownRegionHandler(ddlData.RegionCode);
        }

    }
}
function BindDropDownRegionHandler(response) {
    //var res = response.data.unique();
    //var res = $.unique(response);
    var outputArray = [];
    var s = '';
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].RegionCode + '">' + response[i].RegionDescription + '</option>';
        }
    }


    $("#RegionCode").html(s);
    $("#RegionCode").multiselect({
        columns: 1,
        placeholder: 'Region Code',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#RegionCode").multiselect("reload");
}
function BindDropDownArea(url, Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division) {
    if (AreaCode == "" || AreaCode == "null") {
        if (ddlData.AreaCode == undefined)
            Common.Ajax('GET', url, { Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division }, 'json', BindDropDownAreaHandler);
        else {
            BindDropDownAreaHandler(ddlData.AreaCode);
        }

    }
}
function BindDropDownAreaHandler(response) {

    var outputArray = [];
    var s = '';
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].AreaCode + '">' + response[i].AreaDescription + '</option>';
        }
    }


    $("#AreaCode").html(s);
    $("#AreaCode").multiselect({
        columns: 1,
        placeholder: 'Area Code',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#AreaCode").multiselect("reload");

}

function BindDropDownTerritory(url, Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division) {
    if (TerritoryCode == "" || TerritoryCode == "null") {
        if (ddlData.TerritoryCode == undefined)
            Common.Ajax('GET', url, { Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division }, 'json', BindDropDownTerritoryHandler);
        else {
            BindDropDownTerritoryHandler(ddlData.TerritoryCode);
        }

    }
}
function BindDropDownTerritoryHandler(response) {

    var outputArray = [];
    var s = '';
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].TerritoryCode + '">' + response[i].TerritoryDescription + '</option>';
        }
    }

    $("#TerritoryCode").html(s);
    $("#TerritoryCode").multiselect({
        columns: 1,
        placeholder: 'Territory Code',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#TerritoryCode").multiselect("reload");
}

function BindDropDownTown(url, Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division) {
    if (TownCode == "" || TownCode == "null") {
        if (ddlData.TownCode == undefined)
            Common.Ajax('GET', url, { Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division }, 'json', BindDropDownTownHandler);
        else {
            BindDropDownTownHandler(ddlData.TownCode);
        }

    }
}
function BindDropDownTownHandler(response) {

    var outputArray = [];
    var s = '';
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].TownCode + '">' + response[i].TownDescription + '</option>';
        }
    }

    $("#TownCode").html(s);
    $("#TownCode").multiselect({
        columns: 1,
        placeholder: 'Town Code',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#TownCode").multiselect("reload");
}
function BindDropDownCustomer(url, Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division) {
    if (Customer == "" || Customer == "null") {
        if (ddlData.Customer == undefined)
            Common.Ajax('GET', url, { Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division }, 'json', BindDropDownCustomerHandler);
        else {
            BindDropDownCustomerHandler(ddlData.Customer);
        }
    }
}
function BindDropDownCustomerHandler(response) {
    var outputArray = [];
    var s = '';
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            var CustomerName = isNaN(parseInt(response[i].AreaCode)) ? response[i].CustomerName : response[i].CustomerName + ' (' + parseInt(response[i].AreaCode) + ')';
            s += '<option value="' + response[i].AreaCode + '">' + CustomerName + '</option>';
        }
    }


    $("#drpCustomer").html(s);
    $("#drpCustomer").multiselect({
        columns: 1,
        placeholder: 'Customer',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#drpCustomer").multiselect("reload");
}

function BindDropDownDivision(url, Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division) {
    if (division == "" || division == "null") {
        if (ddlData.division == undefined)
            Common.Ajax('GET', url, { Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division }, 'json', BindDropDownDivisionHandler);
        else {
            BindDropDownDivisionHandler(ddlData.division);
        }
    }
}
function BindDropDownDivisionHandler(response) {
    var outputArray = [];
    var s = '';//'<option value="-1">Division</option>';
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].Division + '">' + response[i].Division + '</option>';
        }
    }

    $("#drpDivision").html(s);
    $("#drpDivision").multiselect({
        columns: 1,
        placeholder: 'Division',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#drpDivision").multiselect("reload");
}

function Refresh(url) {
    Common.Ajax('POST', url, 'json', successRoleUpdateHandler);
}