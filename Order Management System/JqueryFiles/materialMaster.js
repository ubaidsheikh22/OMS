/// <reference path="GenericAjax.js" />



var MATERIAL = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
var SALESORG = $('#drpsalesOrg').val() == "-1" || null ? "" : $('#drpsalesOrg').val();
var PGD = $('#drpPGD').val() == "-1" || null ? "" : $('#drpPGD').val();

var DIVISION = $('#drpDivision').val() == "-1" || null ? "" : $('#drpDivision').val();



$(document).ready(function () {

    AllDataDataLoad();
    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });
    //DataLoad();
    $('#Refresh').click(function () {
        refresh('');

    });
    $('#btnn').on('click', function () {
        $("#divLoader").show();
        var a = document.createElement('a');
        var data_type = 'data:application/vnd.ms-excel';
        var table = $('#MaterialList');
        $('#MaterialList').dataTable().fnDestroy();
        var table_html = '<table><thead><tr><th>Material</th><th>Sales Organization</th><th>Division</th><th>Material Group</th><th>Description</th><th>Material Pricing Group Description</th><th>Material Group 1 Description</th><th>Material Group 2 Description</th><th>Material Group 3 Description</th><th>Material Group 4 Description</th><th>Material Group Description</th><th>Material Type Descripiton</th><th>Material pricing group</th><th>Material Type</th><th>Distribution Channel</th><th>Unit Price</th></tr></thead></table>';
        table_html = table_html + table[0].outerHTML.replace(/ /g, '%20');
        a.href = data_type + ', ' + table_html;
        a.download = 'Material Master.xls';
        a.click();
        $("#divLoader").hide();
       
    });
  
    $('#btnn').on('click', function () {
        $("#divLoader").show();
        var a = document.createElement('a');
        var data_type = 'data:application/vnd.ms-excel';
        var table = $('#MaterialList');
        $('#MaterialList').dataTable().fnDestroy();
        // var Header = table.find('th');
        var table_html = '<table> <thead><tr><th>Contract Number</th><th>Requestor Name</th><th>Requesting Office/District</th><th>Requested Date</th><th>Contract Status</th><th>Estimated Contract Cost</th><th>Contract Type</th><th>Receivable/Payable</th><th>Contractors</th><th>SP Numbers</th><th>Material Group Description</th><th>Material Type Descripiton</th><th>Material pricing group</th><th>Material Type</th><th>Distribution Channel</th><th>Unit Price</th></tr></thead></table>';
        table_html = table_html + table[0].outerHTML.replace(/ /g, '%20');
        a.href = data_type + ', ' + table_html;
        a.download = 'data.xls';
        a.click();
        $("#divLoader").hide();
       
    });

    BindDropDownMATERIAL('getMaterial', '', '', '', '', '', '', '', '', '');
    BindDropDownSALESORG('getSALESORG', '', '', '', '', '', '', '', '');
    BindDropDownPGD('getPGD', '', '', '', '', '', '', '', '');
    BindDropDownDivision('getDivision', '', '', '', '', '', '', '', '');

    $('#drpMaterial').change(function () {
       
        DataLoad();
     });
    $('#drpsalesOrg').change(function () {       
        DataLoad();
       });
    $('#drpPGD').change(function () {      
        DataLoad();
        });
  
    $('#drpDivision').change(function () {
      
        DataLoad();
       });



    $("#btnn").click(function () {

        $("#divLoader").show();

        var a = document.createElement('a');
        var data_type = 'data:application/vnd.ms-excel';
        var table = $('#MaterialList');
        $('#MaterialList').dataTable().fnDestroy();
        // var Header = table.find('th');
        var table_html = '<table><thead><tr><th>Material</th><th>Sales Organization</th><th>Division</th><th>Material Group</th><th>Description</th><th>Material Pricing Group Description</th><th>Material Group 1 Description</th><th>Material Group 2 Description</th><th>Material Group 3 Description</th><th>Material Group 4 Description</th><th>Material Group Description</th><th>Material Type Descripiton</th><th>Material pricing group</th><th>Material Type</th><th>Distribution Channel</th><th>Unit Price</th></tr></thead></table>';
        table_html = table_html + table[0].outerHTML.replace(/ /g, '%20');
        a.href = data_type + ', ' + table_html;
        a.download = 'Customer Master.xls';
        a.click();
        $("#divLoader").hide();
    });




});


function AllDataDataLoad() {
    if (true) {
       
        $("#MaterialList").DataTable({
            "processing": false, // for show progress bar
            "serverSide": false, // for process server side
            "filter": true, // this is for disable filter (search box)
            "orderMulti": false, // for disable multiple column at once
            "data": AllData,
            "dataSrc": "",
            "deferRender": false,
            //"scrollY": 200,
            "scrollX": true,
            rowReorder: true,

            "columns": [
                { "data": "Material", "name": "Material", "class": "Material", "autoWidth": true },
                { "data": "SalesOrganization", "class": "SalesOrganization", "name": "SalesOrganization", "autoWidth": true },
                { "data": "Division", "class": "Division", "name": "Division", "autoWidth": true },
                { "data": "MaterialGroup", "class": "MaterialGroup", "name": "MaterialGroup", "autoWidth": true },
                { "data": "Description", "class": "Description", "name": "Description", "autoWidth": true },
                { "data": "MatPricingGrpDescription", "class": "MatPricingGrpDescription", "name": "MatPricingGrpDescription", "autoWidth": true },
                { "data": "MaterialGroup1_Description", "class": "MaterialGroup1_Description", "name": "MaterialGroup1_Description", "autoWidth": true },
                { "data": "MaterialGroup2_Description", "class": "MaterialGroup2_Description", "name": "MaterialGroup2_Description", "autoWidth": true },
                { "data": "MaterialGroup3_Description", "class": "MaterialGroup3_Description", "name": "MaterialGroup3_Description", "autoWidth": true },
                { "data": "MaterialGroup4_Description", "class": "MaterialGroup4_Description", "name": "MaterialGroup4_Description", "autoWidth": true },
                { "data": "MaterialGroupdescription", "class": "MaterialGroupdescription", "name": "MaterialGroupdescription", "autoWidth": true },
                { "data": "MaterialTypeDescripiton", "class": "MaterialTypeDescripiton", "name": "MaterialTypeDescripiton", "autoWidth": true },
                { "data": "Materialpricinggrp", "class": "Materialpricinggrp", "name": "Materialpricinggrp", "autoWidth": true },
                { "data": "MaterialType", "class": "MaterialType", "name": "MaterialType", "autoWidth": true },
                { "data": "DistributionChannel", "class": "DistributionChannel", "name": "DistributionChannel", "autoWidth": true },

                { "data": "unitPrice", "class": "unitPrice", "name": "unitPrice", "autoWidth": true },


            ]

        });
        setTimeout(1000, $('#divLoader').hide());
    }

}

function DataLoad() {
 $('#MaterialList').dataTable().fnDestroy();


    var MATERIAL = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
    newmaterial = MATERIAL + "";
    var SALESORG = $('#drpsalesOrg').val() == "-1" || null ? "" : $('#drpsalesOrg').val();
    newSales = SALESORG + "";
    var PGD = $('#drpPGD').val() == "-1" || null ? "" : $('#drpPGD').val();
    newPGD = PGD + "";
    var DIVISION = $('#drpDivision').val() == "-1" || null ? "" : $('#drpDivision').val();
    newDivision = DIVISION + "";
    BindDropDown("", newmaterial, newSales, newPGD, newDivision);
    $.ajax({
        type: "POST",
        url: "gridView",
        data: {
            material: newmaterial,
            sales: newSales,
            PGD: newPGD,
            Division: newDivision


        },
        beforeSend: function () {

            setTimeout(function () {
               
            }, 1);
            // please note i have added a delay of 1 millisecond with js timeout function which runs almost same as code with no delay.
        },
        complete: function (data) {
            $("#divLoader").hide();
            //here i write success code
        },
        dom: 'Bfrtip',
        buttons: [{
            extend: 'excel',
            autoFilter: true,
            //sheetName: 'Exported data'
        }],
        datatype: "json",
        //traditional: true,

        success: function (data) {
            //console.log(data);
            $("#MaterialList").DataTable({
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
                    { "data": "Material", "name": "Material", "class": "Material", "autoWidth": true },
                    { "data": "SalesOrganization", "class": "SalesOrganization", "name": "SalesOrganization", "autoWidth": true },

                    { "data": "Division", "class": "Division", "name": "Division", "autoWidth": true },

                    { "data": "MaterialGroup", "class": "MaterialGroup", "name": "MaterialGroup", "autoWidth": true },

                    { "data": "Description", "class": "Description", "name": "Description", "autoWidth": true },
                    { "data": "MatPricingGrpDescription", "class": "MatPricingGrpDescription", "name": "MatPricingGrpDescription", "autoWidth": true },
                    { "data": "MaterialGroup1_Description", "class": "MaterialGroup1_Description", "name": "MaterialGroup1_Description", "autoWidth": true },
                    { "data": "MaterialGroup2_Description", "class": "MaterialGroup2_Description", "name": "MaterialGroup2_Description", "autoWidth": true },
                    { "data": "MaterialGroup3_Description", "class": "MaterialGroup3_Description", "name": "MaterialGroup3_Description", "autoWidth": true },
                    { "data": "MaterialGroup4_Description", "class": "MaterialGroup4_Description", "name": "MaterialGroup4_Description", "autoWidth": true },
                    { "data": "MaterialGroupdescription", "class": "MaterialGroupdescription", "name": "MaterialGroupdescription", "autoWidth": true },
                    { "data": "MaterialTypeDescripiton", "class": "MaterialTypeDescripiton", "name": "MaterialTypeDescripiton", "autoWidth": true },
                    { "data": "Materialpricinggrp", "class": "Materialpricinggrp", "name": "Materialpricinggrp", "autoWidth": true },
                    { "data": "MaterialType", "class": "MaterialType", "name": "MaterialType", "autoWidth": true },
                    { "data": "DistributionChannel", "class": "DistributionChannel", "name": "DistributionChannel", "autoWidth": true },

                    { "data": "unitPrice", "class": "unitPrice", "name": "unitPrice", "autoWidth": true },


                ]

            });
            setTimeout(1000, $('#divLoader').hide());
        }


    });



}


function BindDropDown(material, sales, PGD, group1, group2, group3, group4, group5, division) {
    var url = "getAllDDL";
    Common.Ajax('GET', url, { material, sales, PGD, group1, group2, group3, group4, group5, division }, 'json', BindDropDownHandler);
}
function BindDropDownHandler(response) {
    ddlData = response;


    var MATERIAL = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
    newmaterial = MATERIAL + "";
    var SALESORG = $('#drpsalesOrg').val() == "-1" || null ? "" : $('#drpsalesOrg').val();
    newSales = SALESORG + "";
    var PGD = $('#drpPGD').val() == "-1" || null ? "" : $('#drpPGD').val();
    newPGD = PGD + "";
    var DIVISION = $('#drpDivision').val() == "-1" || null ? "" : $('#drpDivision').val();
    newDivision = DIVISION + "";


    BindDropDownMATERIAL('getMaterial', newmaterial, newSales, newPGD);
    BindDropDownSALESORG('getSALESORG', newmaterial, newSales, newPGD, newDivision);
    BindDropDownPGD('getPGD', newmaterial, newSales, newPGD, newDivision);
    BindDropDownDivision('getDivision', newmaterial, newSales, newPGD, newDivision);
}



function BindDropDownMATERIAL(url, material, sales, PGD, division) {
    if (material == "" || material == "null" || material == null) {
        if (ddlData.material == undefined)
            Common.Ajax('GET', url, { material, sales, PGD, division }, 'json', BindDropDownMATERIALHandler);
        else {
            BindDropDownMATERIALHandler(ddlData.material);
        }
    }
}
function BindDropDownMATERIALHandler(response) {

    ddlData.material == response;
    var outputArray = [];
    var s = '';//<option value="-1">Material</option>';
    for (var i = 0; i < response.length; i++) {

        //if ((jQuery.inArray(response[i], outputArray)) == -1) {
        s += '<option value="' + response[i].Material + '">' + response[i].Description + ' (' + response[i].Material + ') </option>';
        //}
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
    $('#divLoader').hide();
 }
function BindDropDownSALESORG(url, material, sales, PGD, division) {
    if (sales == "" || sales == "null" || sales == null) {
        if (ddlData.sales == undefined)
            Common.Ajax('GET', url, { material, sales, PGD, division }, 'json', BindDropDownSalesOrgHandler);
        else {
            BindDropDownSalesOrgHandler(ddlData.sales);
        }
    }
}
function BindDropDownSalesOrgHandler(response) {
  
    ddlData.sales == response;
    var outputArray = [];
    var s = '';//<option value="-1">SALES ORGANIZATION</option>';
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].SalesOrganization + '">' + response[i].SalesOrganization + '</option>';
        }
    }


    $("#drpsalesOrg").html(s);
    $("#drpsalesOrg").multiselect({
        columns: 1,
        placeholder: 'SALES ORGANIZATION',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#drpsalesOrg").multiselect("reload");
    $('#divLoader').hide();
   
}
function BindDropDownPGD(url, material, sales, PGD, division) {
    if (PGD == "" || PGD == "null" || PGD == null) {
        if (ddlData.PGD == undefined)
            Common.Ajax('GET', url, { material, sales, PGD, division }, 'json', BindDropDownPGDHandler);
        else {
            BindDropDownPGDHandler(ddlData.PGD);
        }
    }
}
function BindDropDownPGDHandler(response) {
    
    ddlData.PGD == response;
    var outputArray = [];
    var s = '';//<option value="-1">Material Pricing Group Description</option>';
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].MatPricingGrpDescription + '">' + response[i].MatPricingGrpDescription + '</option>';
        }
    }


    $("#drpPGD").html(s);
    $("#drpPGD").multiselect({
        columns: 1,
        placeholder: 'Material Pricing Group Description',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#drpPGD").multiselect("reload");
    $('#divLoader').hide();
    }

function BindDropDownDivision(url, material, sales, PGD, division) {
    if (division == "" || division == "null" || division == null) {
        if (ddlData.division == undefined)
            Common.Ajax('GET', url, { material, sales, PGD, division }, 'json', BindDropDownDivisionHandler);
        else {
            BindDropDownDivisionHandler(ddlData.division);
        }
    }
}
function BindDropDownDivisionHandler(response) {
    ddlData.division == response;
    var outputArray = [];
    var s = '';//<option value="-1">Material Pricing Group 5</option>';
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
    $('#divLoader').hide();
   
}

function refresh(url) {
    $('#imm').val('');
    $('#MaterialList').DataTable().ajax.reload();

    $('#imm')
        .find('option')
        .remove()
        .end()
        .append('<option value=""></option>')
        .val('')
        ;
}