/// <reference path="GenericAjax.js" />

var CALDAY = $('#drpCALDAY').val() == "-1" || null ? "" : $('#drpCALDAY').val();
var COMPCODE = $('#drpComp').val() == "-1" || null ? "" : $('#drpComp').val();
var SALESORG = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
var DISTR = $('#drpDistr').val() == "-1" || null ? "" : $('#drpDistr').val();
var DIV = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
var CUSTOMER = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
var MATERIAL = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
var count = 0
var CompleteData = [];
var loadedRows = 0;
function hideLoader() {
    count++;
    //console.log(count);
    if (count > 6) {
        $("#divLoader").hide();
        count = 0;
    }
}
$(document).ready(function () {

    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });
    $("#btnn").click(function () {

        
        DataLoad(true);
        $("#divLoader").hide();

    });
    $("#divLoader").show();
    BindDropDownCALDAY('GetCALDAY', '', '', '', '', '', '', '');
    BindDropDownCOMPCODE('GetComp', '', '', '', '', '', '', '');
    BindDropDownSALESORG('GetSalesOrg', '', '', '', '', '', '', '');
    BindDropDownDISTR('GetDistr', '', '', '', '', '', '', '');
    BindDropDownDIV('GetDiv', '', '', '', '', '', '', '');
    BindDropDownCUSTOMER('GetCustomer', '', '', '', '', '', '', '');
    BindDropDownMATERIAL('GetMaterial', '', '', '', '', '', '', '');



    var table = $('#secondarySalesList').DataTable({
        scrollY: 500,
        scrollCollapse: true,
        scroller: true});
    //DataLoad();


    $('#drpCALDAY').change(function () {
        CALDAY = $('#drpCALDAY').val() == "-1" || null ? "" : $('#drpCALDAY').val();
        newCalday = CALDAY + "";
        COMPCODE = $('#drpComp').val() == "-1" || null ? "" : $('#drpComp').val();
        newComp = COMPCODE + "";
        SALESORG = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newSales = SALESORG + "";
        DISTR = $('#drpDistr').val() == "-1" || null ? "" : $('#drpDistr').val();
        newdistr = DISTR + "";
        DIV = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = DIV + "";
        CUSTOMER = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
        newcustomer = "0000" + CUSTOMER + ""
        MATERIAL = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
        newMAterial = "0000000000" + MATERIAL + "";

        DataLoad();
        //BindDropDownCALDAY('GetCALDAY', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownCOMPCODE('GetComp', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownSALESORG('GetSalesOrg', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownDISTR('GetDistr', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownDIV('GetDiv', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownCUSTOMER('GetCustomer', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownMATERIAL('GetMaterial', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
    });
    $('#drpComp').change(function () {
        CALDAY = $('#drpCALDAY').val() == "-1" || null ? "" : $('#drpCALDAY').val();
        newCalday = CALDAY + "";
        COMPCODE = $('#drpComp').val() == "-1" || null ? "" : $('#drpComp').val();
        newComp = COMPCODE + "";
        SALESORG = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newSales = SALESORG + "";
        DISTR = $('#drpDistr').val() == "-1" || null ? "" : $('#drpDistr').val();
        newdistr = DISTR + "";
        DIV = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = DIV + "";
        CUSTOMER = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
        newcustomer = "0000" + CUSTOMER + ""
        MATERIAL = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
        newMAterial = "0000000000" + MATERIAL + "";
        DataLoad();
        BindDropDownCALDAY('GetCALDAY', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        //BindDropDownCOMPCODE('GetComp', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownSALESORG('GetSalesOrg', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownDISTR('GetDistr', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownDIV('GetDiv', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownCUSTOMER('GetCustomer', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownMATERIAL('GetMaterial', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
    });
    $('#drpSalesOrg').change(function () {
        CALDAY = $('#drpCALDAY').val() == "-1" || null ? "" : $('#drpCALDAY').val();
        newCalday = CALDAY + "";
        COMPCODE = $('#drpComp').val() == "-1" || null ? "" : $('#drpComp').val();
        newComp = COMPCODE + "";
        SALESORG = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newSales = SALESORG + "";
        DISTR = $('#drpDistr').val() == "-1" || null ? "" : $('#drpDistr').val();
        newdistr = DISTR + "";
        DIV = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = DIV + "";
        CUSTOMER = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
        newcustomer = "0000" + CUSTOMER + ""
        MATERIAL = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
        newMAterial = "0000000000" + MATERIAL + "";
        DataLoad();
        BindDropDownCALDAY('GetCALDAY', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownCOMPCODE('GetComp', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        //BindDropDownSALESORG('GetSalesOrg', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownDISTR('GetDistr', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownDIV('GetDiv', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownCUSTOMER('GetCustomer', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownMATERIAL('GetMaterial', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
    });
    $('#drpDistr').change(function () {
        CALDAY = $('#drpCALDAY').val() == "-1" || null ? "" : $('#drpCALDAY').val();
        newCalday = CALDAY + "";
        COMPCODE = $('#drpComp').val() == "-1" || null ? "" : $('#drpComp').val();
        newComp = COMPCODE + "";
        SALESORG = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newSales = SALESORG + "";
        DISTR = $('#drpDistr').val() == "-1" || null ? "" : $('#drpDistr').val();
        newdistr = DISTR + "";
        DIV = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = DIV + "";
        CUSTOMER = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
        newcustomer = "0000" + CUSTOMER + ""
        MATERIAL = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
        newMAterial = "0000000000" + MATERIAL + "";
        DataLoad();
        BindDropDownCALDAY('GetCALDAY', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownCOMPCODE('GetComp', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownSALESORG('GetSalesOrg', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        //BindDropDownDISTR('GetDistr', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownDIV('GetDiv', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownCUSTOMER('GetCustomer', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownMATERIAL('GetMaterial', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
    });
    $('#drpDiv').change(function () {
        CALDAY = $('#drpCALDAY').val() == "-1" || null ? "" : $('#drpCALDAY').val();
        newCalday = CALDAY + "";
        COMPCODE = $('#drpComp').val() == "-1" || null ? "" : $('#drpComp').val();
        newComp = COMPCODE + "";
        SALESORG = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newSales = SALESORG + "";
        DISTR = $('#drpDistr').val() == "-1" || null ? "" : $('#drpDistr').val();
        newdistr = DISTR + "";
        DIV = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = DIV + "";
        CUSTOMER = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
        newcustomer = "0000" + CUSTOMER + ""
        MATERIAL = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
        newMAterial = "0000000000" + MATERIAL + "";
        DataLoad();
        BindDropDownCALDAY('GetCALDAY', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownCOMPCODE('GetComp', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownSALESORG('GetSalesOrg', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownDISTR('GetDistr', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        //BindDropDownDIV('GetDiv', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownCUSTOMER('GetCustomer', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownMATERIAL('GetMaterial', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
    });
    $('#drpCustomer').change(function () {
        CALDAY = $('#drpCALDAY').val() == "-1" || null ? "" : $('#drpCALDAY').val();
        newCalday = CALDAY + "";
        COMPCODE = $('#drpComp').val() == "-1" || null ? "" : $('#drpComp').val();
        newComp = COMPCODE + "";
        SALESORG = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newSales = SALESORG + "";
        DISTR = $('#drpDistr').val() == "-1" || null ? "" : $('#drpDistr').val();
        newdistr = DISTR + "";
        DIV = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = DIV + "";
        CUSTOMER = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
        newcustomer = "0000" + CUSTOMER + ""
        MATERIAL = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
        newMAterial = "0000000000" + MATERIAL + "";
        DataLoad();
        BindDropDownCALDAY('GetCALDAY', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownCOMPCODE('GetComp', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownSALESORG('GetSalesOrg', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownDISTR('GetDistr', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownDIV('GetDiv', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        //BindDropDownCUSTOMER('GetCustomer', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownMATERIAL('GetMaterial', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
    });
    $('#drpMaterial').change(function () {
        CALDAY = $('#drpCALDAY').val() == "-1" || null ? "" : $('#drpCALDAY').val();
        newCalday = CALDAY + "";
        COMPCODE = $('#drpComp').val() == "-1" || null ? "" : $('#drpComp').val();
        newComp = COMPCODE + "";
        SALESORG = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newSales = SALESORG + "";
        DISTR = $('#drpDistr').val() == "-1" || null ? "" : $('#drpDistr').val();
        newdistr = DISTR + "";
        DIV = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = DIV + "";
        CUSTOMER = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
        newcustomer = "0000" + CUSTOMER + ""
        MATERIAL = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
        newMAterial = "0000000000" + MATERIAL + "";
        DataLoad();
        BindDropDownCALDAY('GetCALDAY', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownCOMPCODE('GetComp', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownSALESORG('GetSalesOrg', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownDISTR('GetDistr', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownDIV('GetDiv', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        BindDropDownCUSTOMER('GetCustomer', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
        //BindDropDownMATERIAL('GetMaterial', newCalday, newComp, newSales, newdistr, newDiv, newcustomer, newMAterial);
    });

    //DataLoad();


});
function DataLoad(forExcel = false) {
    $('#secondarySalesList').dataTable().fnDestroy();

    CALDAY = $('#drpCALDAY').val() == "-1" || null ? "" : $('#drpCALDAY').val();
    newCalday = CALDAY + "";
    COMPCODE = $('#drpComp').val() == "-1" || null ? "" : $('#drpComp').val();
    newComp = COMPCODE + "";
    SALESORG = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
    newSales = SALESORG + "";
    DISTR = $('#drpDistr').val() == "-1" || null ? "" : $('#drpDistr').val();
    newdistr = DISTR + "";
    DIV = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
    newDiv = DIV + "";
    CUSTOMER = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
    newcustomer = "0000" + CUSTOMER + ""
    MATERIAL = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
    // newMAterial = "0000000000" + MATERIAL + "";
    newMAterial =  MATERIAL;
    if (forExcel == false) {

        $("#secondarySalesList").DataTable({
            "processing": false, // for show progress bar
            "serverSide": true, // for process server side
            "ajax": {
                "url": "gridViewPaging?CALDAY=" + newCalday + "&Comp=" + newComp + "&salesorg=" + newSales + "&distr=" + newdistr + "&div=" + newDiv + "&customer=" + newcustomer + "&material=" + newMAterial,
                "type": "POST"
            },
            "scrollX": true,
            "columns": [
                { "data": "CalendarDay", "class": "CalendarDay", "name": "CalendarDay", "autoWidth": true },
                { "data": "Company", "class": "Company", "name": "Company", "autoWidth": true },
                { "data": "SalesOrganization", "class": "SalesOrganization", "name": "SalesOrganization", "autoWidth": true },
                { "data": "Division", "class": "Division", "name": "Division", "autoWidth": true },

                { "data": "CustomerSoldToParty", "class": "CustomerSoldToParty", "name": "CustomerSoldToParty", "autoWidth": true },
                { "data": "Name1", "class": "Name1", "name": "Name1", "autoWidth": true },
                { "data": "CustomerName2", "class": "CustomerName2", "name": "CustomerName2", "autoWidth": true },
                { "data": "RegionDescription", "class": "RegionDescription", "name": "RegionDescription", "autoWidth": true },
                { "data": "AreaDescription", "class": "AreaDescription", "name": "AreaDescription", "autoWidth": true },
                { "data": "TerritoryDescription", "class": "TerritoryDescription", "name": "TerritoryDescription", "autoWidth": true },
                { "data": "TownDescription", "class": "TownDescription", "name": "TownDescription", "autoWidth": true },

                { "data": "Material", "class": "Material", "name": "Material", "autoWidth": true },
                { "data": "Description", "class": "Description", "name": "Description", "autoWidth": true },
                { "data": "MatPricingGrpDescription", "class": "MatPricingGrpDescription", "name": "MatPricingGrpDescription", "autoWidth": true },
                { "data": "MaterialGroup1_Description", "class": "MaterialGroup1_Description", "name": "MaterialGroup1_Description", "autoWidth": true },
                { "data": "MaterialGroup2_Description", "class": "MaterialGroup2_Description", "name": "MaterialGroup2_Description", "autoWidth": true },
                { "data": "MaterialGroup3_Description", "class": "MaterialGroup3_Description", "name": "MaterialGroup3_Description", "autoWidth": true },
                { "data": "MaterialGroup4_Description", "class": "MaterialGroup4_Description", "name": "MaterialGroup4_Description", "autoWidth": true },
                { "data": "MaterialGroup5_Description", "class": "MaterialGroup5_Description", "name": "MaterialGroup5_Description", "autoWidth": true },
                { "data": "MaterialGroupdescription", "class": "MaterialGroupdescription", "name": "MaterialGroupdescription", "autoWidth": true },


                { "data": "UOM", "class": "UOM", "name": "UOM", "autoWidth": true, "visible": true },


                { "data": "DistributionChannel", "class": "DistributionChannel", "name": "DistributionChannel", "autoWidth": true },
                { "data": "Quantity", "class": "dt-right", "name": "Quantity", "autoWidth": true },
                //{
                //    "defaultContent": "<button id='click'>Update!</button>"
                //}

            ],

        });
        return;

    }
    $.ajax({
        type: "POST",
        url: "gridView",
        data: {
            CALDAY: newCalday,
            Comp: newComp,
            salesorg: newSales,
            distr: newdistr,
            div: newDiv,
            customer: newcustomer,
            material: newMAterial
        },
        beforeSend: function () {

            setTimeout(function () {
                $("#divLoader").show();
            }, 1);
            // please note i have added a delay of 1 millisecond with js timeout function which runs almost same as code with no delay.
        },
        complete: function (data) {
            //$("#divLoader").hide();
            //here i write success code
        },
        datatype: "json",
        //traditional: true,

        success: function (data) {
            CompleteData = data;
            //if (data.length > 100)
            //    data = data.slice(loadedRows, 100);
            $("#secondarySalesList").DataTable({
                "processing": false, // for show progress bar
                "serverSide": false, // for process server side
                //"filter": true, // this is for disable filter (search box)
                "orderMulti": false, // for disable multiple column at once
                "data": data ,
                "drawCallback": function (json) {
                    $("#divLoader").show();

                    var a = document.createElement('a');
                    var data_type = 'data:application/vnd.ms-excel';
                    var table = $('#secondarySalesList');
                    $('#secondarySalesList').dataTable().fnDestroy();
                    // var Header = table.find('th');
                    var table_html = '<table><thead><tr><th>Calendar Month</th><th>Company</th><th>Sales Organization</th><th>Division</th><th>Customer (Sold-To Party)</th><th>Customer Name</th><th>Customer Name2</th><th>RegionDescription</th><th>AreaDescription</th><th>TerritoryDescription</th><th>TownDescription</th><th>Material</th><th>Material Description</th><th>MatPricingGrpDescription</th><th>MaterialGroup1_Description</th><th>MaterialGroup2_Description</th><th>MaterialGroup3_Description</th><th>MaterialGroup4_Description</th><th>MaterialGroup5_Description</th><th>MaterialGroupdescription</th><th>UOM</th><th>Distribution Channel</th><th>Quantity</th></tr></thead></table>';
                    table_html = table_html + table[0].outerHTML.replace(/ /g, '%20');
                    a.href = data_type + ', ' + table_html;
                    a.download = 'secondarySalesListMaster.xls';
                    a.click();
                    $("#divLoader").hide();
                    setTimeout( DataLoad, 1500);
                },  
                "columns": [
         { "data": "CalendarDay", "class": "CalendarDay", "name": "CalendarDay", "autoWidth": true },
         { "data": "Company", "class": "Company", "name": "Company", "autoWidth": true },
         { "data": "SalesOrganization", "class": "SalesOrganization", "name": "SalesOrganization", "autoWidth": true },
         { "data": "Division", "class": "Division", "name": "Division", "autoWidth": true },

       { "data": "CustomerSoldToParty", "class": "CustomerSoldToParty", "name": "CustomerSoldToParty", "autoWidth": true },
       { "data": "Name1", "class": "Name1", "name": "Name1", "autoWidth": true },
            { "data": "CustomerName2", "class": "CustomerName2", "name": "CustomerName2", "autoWidth": true },
             { "data": "RegionDescription", "class": "RegionDescription", "name": "RegionDescription", "autoWidth": true },
             { "data": "AreaDescription", "class": "AreaDescription", "name": "AreaDescription", "autoWidth": true },
             { "data": "TerritoryDescription", "class": "TerritoryDescription", "name": "TerritoryDescription", "autoWidth": true },
             { "data": "TownDescription", "class": "TownDescription", "name": "TownDescription", "autoWidth": true },

           { "data": "Material", "class": "Material", "name": "Material", "autoWidth": true },
             { "data": "Description", "class": "Description", "name": "Description", "autoWidth": true },
            { "data": "MatPricingGrpDescription", "class": "MatPricingGrpDescription", "name": "MatPricingGrpDescription", "autoWidth": true },
             { "data": "MaterialGroup1_Description", "class": "MaterialGroup1_Description", "name": "MaterialGroup1_Description", "autoWidth": true },
             { "data": "MaterialGroup2_Description", "class": "MaterialGroup2_Description", "name": "MaterialGroup2_Description", "autoWidth": true },
             { "data": "MaterialGroup3_Description", "class": "MaterialGroup3_Description", "name": "MaterialGroup3_Description", "autoWidth": true },
             { "data": "MaterialGroup4_Description", "class": "MaterialGroup4_Description", "name": "MaterialGroup4_Description", "autoWidth": true },
             { "data": "MaterialGroup5_Description", "class": "MaterialGroup5_Description", "name": "MaterialGroup5_Description", "autoWidth": true },
             { "data": "MaterialGroupdescription", "class": "MaterialGroupdescription", "name": "MaterialGroupdescription", "autoWidth": true },


         { "data": "UOM", "class": "UOM", "name": "UOM", "autoWidth": true, "visible": true },


                         { "data": "DistributionChannel", "class": "DistributionChannel", "name": "DistributionChannel", "autoWidth": true },
{ "data": "Quantity", "class": "dt-right", "name": "Quantity", "autoWidth": true },
          //{
           //    "defaultContent": "<button id='click'>Update!</button>"
           //}

                ],

            });
            
        }


    });



}


    function BindDropDownCALDAY(url, CALDAY, COMPCODE, SALESORG, DISTR, DIV, CUSTOMER, MATERIAL) {
        if (CALDAY == '' || CALDAY == 'null' || CALDAY == null) {
            Common.Ajax('GET', url, { CALDAY, COMPCODE, SALESORG, DISTR, DIV, CUSTOMER, MATERIAL }, 'json', BindDropDownCALDAYHandler);
        } else {
            hideLoader();
        }
    }
    function BindDropDownCALDAYHandler(response) {
        //var res = response.data.unique();
        //var res = $.unique(response);
        var outputArray = [];
        var s = '';
        for (var i = 0; i < response.length; i++) {

            if ((jQuery.inArray(response[i], outputArray)) == -1) {
                s += '<option value="' + response[i].CalendarDay + '">' + response[i].CalendarDay + '</option>';
            }
        }

        $("#drpCALDAY").html(s);
        $("#drpCALDAY").multiselect({
            columns: 1,
            placeholder: 'CALDAY',
            search: true,
            searchOptions: {
                'default': 'Search'
            },
            selectAll: true
        });
        $("#drpCALDAY").multiselect("reload");

        //column.data().unique().sort().each(function (d, j) {
        //    select.append('<option value="' + d + '">' + d + '</option>')

        hideLoader();
    }
    function BindDropDownCOMPCODE(url, CALDAY, COMPCODE, SALESORG, DISTR, DIV, CUSTOMER, MATERIAL) {
        if(COMPCODE =='' || COMPCODE =='null' || COMPCODE ==null )
        {
            Common.Ajax('GET', url, { name, CALDAY, COMPCODE, SALESORG, DISTR, DIV, CUSTOMER, MATERIAL }, 'json', BindDropDownCOMPCODEHandler);
        } else {
            hideLoader();
        }
    }
    function BindDropDownCOMPCODEHandler(response) {
        //var res = response.data.unique();
        //var res = $.unique(response);
        var outputArray = [];
        var s = '';
        for (var i = 0; i < response.length; i++) {

            if ((jQuery.inArray(response[i], outputArray)) == -1) {
                s += '<option value="' + response[i].Company + '">' + response[i].Company + '</option>';
            }
        }

        $("#drpComp").html(s);
        $("#drpComp").multiselect({
            columns: 1,
            placeholder: 'Company Code',
            search: true,
            searchOptions: {
                'default': 'Search'
            },
            selectAll: true
        });
        $("#drpComp").multiselect("reload");

        //column.data().unique().sort().each(function (d, j) {
        //    select.append('<option value="' + d + '">' + d + '</option>')

        hideLoader();
    }

    function BindDropDownSALESORG(url, CALDAY, COMPCODE, SALESORG, DISTR, DIV, CUSTOMER, MATERIAL) {
        if (SALESORG == '' || SALESORG == 'null' || SALESORG == null)
        { 
            Common.Ajax('GET', url, { name, CALDAY, COMPCODE, SALESORG, DISTR, DIV, CUSTOMER, MATERIAL }, 'json', BindDropDownSALESORGHandler);
        } else {
            hideLoader();
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

        hideLoader();
    }
    function BindDropDownDISTR(url, CALDAY, COMPCODE, SALESORG, DISTR, DIV, CUSTOMER, MATERIAL) {
        if(DISTR == '' || DISTR == 'null' || DISTR == null)
        {
            Common.Ajax('GET', url, { CALDAY, COMPCODE, SALESORG, DISTR, DIV, CUSTOMER, MATERIAL }, 'json', BindDropDownDSITRGHandler);
        } else {
            hideLoader();
        }
    }
    function BindDropDownDSITRGHandler(response) {
        //var res = response.data.unique();
        //var res = $.unique(response);
        var outputArray = [];
        var s = '';
        for (var i = 0; i < response.length; i++) {

            if ((jQuery.inArray(response[i], outputArray)) == -1) {
                s += '<option value="' + response[i].DistributionChannel + '">' + response[i].DistributionChannel + '</option>';
            }
        }


        $("#drpDistr").html(s);
        $("#drpDistr").multiselect({
            columns: 1,
            placeholder: 'Distritution',
            search: true,
            searchOptions: {
                'default': 'Search'
            },
            selectAll: true
        });
        $("#drpDistr").multiselect("reload");
        //column.data().unique().sort().each(function (d, j) {
        //    select.append('<option value="' + d + '">' + d + '</option>')

        hideLoader();
    }

    function BindDropDownDIV(url, CALDAY, COMPCODE, SALESORG, DISTR, DIV, CUSTOMER, MATERIAL) {
        if (DIV == '' || DIV == 'null' || DIV == null)
        { 
            Common.Ajax('GET', url, { CALDAY, COMPCODE, SALESORG, DISTR, DIV, CUSTOMER, MATERIAL }, 'json', BindDropDownDivHandler);
        } else {
            hideLoader();
        }
    }
    function BindDropDownDivHandler(response) {
        //var res = response.data.unique();
        //var res = $.unique(response);
        var outputArray = [];
        var s = '';
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

        hideLoader();
    }
    function BindDropDownCUSTOMER(url, CALDAY, COMPCODE, SALESORG, DISTR, DIV, CUSTOMER, MATERIAL) {
        if (CUSTOMER == '' || CUSTOMER == '0000null' || CUSTOMER == null)
        { 
            Common.Ajax('GET', url, { name, CALDAY, COMPCODE, SALESORG, DISTR, DIV, CUSTOMER, MATERIAL }, 'json', BindDropDownCUSTOMERHandler);
        } else {
            hideLoader();
        }
    }
    function BindDropDownCUSTOMERHandler(response) {
        //var res = response.data.unique();
        //var res = $.unique(response);
        var outputArray = [];
        var s = '';
        for (var i = 0; i < response.length; i++) {

            if ((jQuery.inArray(response[i], outputArray)) == -1) {
                s += '<option value="' + response[i].CustomerSoldToParty + '">' + response[i].Description + '</option>';
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
        //column.data().unique().sort().each(function (d, j) {
        //    select.append('<option value="' + d + '">' + d + '</option>')

        hideLoader();
    }
    function BindDropDownMATERIAL(url, CALDAY, COMPCODE, SALESORG, DISTR, DIV, CUSTOMER, MATERIAL) {
        if (MATERIAL == '' || MATERIAL == '0000000000null' || MATERIAL == null)
        { 
            Common.Ajax('GET', url, { name, CALDAY, COMPCODE, SALESORG, DISTR, DIV, CUSTOMER, MATERIAL }, 'json', BindDropDownMATERIALHandler);
        } else {
            hideLoader();
        }
    }
    function BindDropDownMATERIALHandler(response) {
        //var res = response.data.unique();
        //var res = $.unique(response);
        var outputArray = [];
        var s = '';
        for (var i = 0; i < response.length; i++) {

            if ((jQuery.inArray(response[i], outputArray)) == -1) {
                s += '<option value="' + response[i].Material + '">' + response[i].Description + '</option>';
            }
        }


        $("#drpMaterial").html(s);
        $("#drpMaterial").multiselect({
            columns: 1,
            placeholder: 'Material',
            search: true,
            searchOptions: {
                'default': 'Search'
            },
            selectAll: true
        });
        $("#drpMaterial").multiselect("reload");
        //column.data().unique().sort().each(function (d, j) {
        //    select.append('<option value="' + d + '">' + d + '</option>')

        hideLoader();
    }


    //function Refresh(url) {
    //    Common.Ajax('POST', url, 'json', successRoleUpdateHandler);
    //}