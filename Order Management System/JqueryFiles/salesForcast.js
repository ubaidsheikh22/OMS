/// <reference path="GenericAjax.js" />

var CALDAY = $('#drpCALDAY').val() == "-1" || null ? "" : $('#drpCALDAY').val();
var Company = $('#drpCompany').val() == "-1" || null ? "" : $('#drpCompany').val();
var Salesorg = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
var dISTR = $('#drpdISTR').val() == "-1" || null ? "" : $('#drpdISTR').val();
var Div = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
var Plant = $('#drpPlant').val() == "-1" || null ? "" : $('#drpPlant').val();
var Customer = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
var Material = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
var ZDOC_CATG = $('#drpZDOC_CATG').val() == "-1" || null ? "" : $('#drpZDOC_CATG').val();
var ZBPCACC = $('#drpZBPCACC').val() == "-1" || null ? "" : $('#drpZBPCACC').val();
var ZBPCVERS = $('#drpZBPCVERS').val() == "-1" || null ? "" : $('#drpZBPCVERS').val();
var Quantity = $('#drpQuantity').val() == "-1" || null ? "" : $('#drpQuantity').val();

$(document).ready(function () {

    $('#drpCALDAY').hide();

    BindDropDownCALDAY('GetCalDay', '', '', '', '', '', '', '', '', ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
    BindDropDownCompany('GetComp', '', '', '', '', '', '', '', '', ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
    BindDropDownSalesOrg('GetSales', '', '', '', '', '', '', '', '', ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
    BindDropDownDistr('getDistr', '', '', '', '', '', '', '', '', ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
    BindDropDownDivision('getDivision', '', '', '', '', '', '', '', '', ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
    BindDropDownPlant('getPlant', '', '', '', '', '', '', '', '', ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
    BindDropDownCustomer('getCustomer', '', '', '', '', '', '', '', '', ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
    BindDropDownMaterial('getMaterial', '', '', '', '', '', '', '', '', ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);



    var table = $('#HSDList');
   
    setTimeout(function () { DataLoad(); }, 5000);

    $('#drpCALDAY').change(function () {
        CALDAY = $('#drpCALDAY').val() == "-1" || null ? "" : $('#drpCALDAY').val();
        newCALDAY = CALDAY + "";
        Company = $('#drpCompany').val() == "-1" || null ? "" : $('#drpCompany').val();
        newComp = Company + "";
        Salesorg = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newSales = Salesorg + "";
        dISTR = $('#drpdISTR').val() == "-1" || null ? "" : $('#drpdISTR').val();
        newDistr = dISTR + "";
        Div = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = Div + "";
        Plant = $('#drpPlant').val() == "-1" || null ? "" : $('#drpPlant').val();
        newPlant = Plant + "";
        Customer = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
        newcustomer = Customer + "";
        Material = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
        newMAterial = Material + "";
        var ZDOC_CATG = $('#drpZDOC_CATG').val() == "-1" || null ? "" : $('#drpZDOC_CATG').val();
        var ZBPCACC = $('#drpZBPCACC').val() == "-1" || null ? "" : $('#drpZBPCACC').val();
        var ZBPCVERS = $('#drpZBPCVERS').val() == "-1" || null ? "" : $('#drpZBPCVERS').val();
        var Quantity = $('#drpQuantity').val() == "-1" || null ? "" : $('#drpQuantity').val();
        DataLoad();
        BindDropDownCompany('GetComp', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownSalesOrg('GetSales', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownDistr('getDistr', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownDivision('getDivision', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownPlant('getPlant', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownCustomer('getCustomer', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownMaterial('getMaterial', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
    });
    $('#drpCompany').change(function () {
        CALDAY = $('#drpCALDAY').val() == "-1" || null ? "" : $('#drpCALDAY').val();
        newCALDAY = CALDAY + "";
        Company = $('#drpCompany').val() == "-1" || null ? "" : $('#drpCompany').val();
        newComp = Company + "";
        Salesorg = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newSales = Salesorg + "";
        dISTR = $('#drpdISTR').val() == "-1" || null ? "" : $('#drpdISTR').val();
        newDistr = dISTR + "";
        Div = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = Div + "";
        Plant = $('#drpPlant').val() == "-1" || null ? "" : $('#drpPlant').val();
        newPlant = Plant + "";
        Customer = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
        newcustomer = Customer + "";
        Material = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
        newMAterial = Material + "";
        var ZDOC_CATG = $('#drpZDOC_CATG').val() == "-1" || null ? "" : $('#drpZDOC_CATG').val();
        var ZBPCACC = $('#drpZBPCACC').val() == "-1" || null ? "" : $('#drpZBPCACC').val();
        var ZBPCVERS = $('#drpZBPCVERS').val() == "-1" || null ? "" : $('#drpZBPCVERS').val();
        var Quantity = $('#drpQuantity').val() == "-1" || null ? "" : $('#drpQuantity').val();
        DataLoad();
        BindDropDownCALDAY('GetCalDay', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownSalesOrg('GetSales', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownDistr('getDistr', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownDivision('getDivision', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownPlant('getPlant', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownCustomer('getCustomer', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownMaterial('getMaterial', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
    });
    $('#drpSalesOrg').change(function () {
        CALDAY = $('#drpCALDAY').val() == "-1" || null ? "" : $('#drpCALDAY').val();
        newCALDAY = CALDAY + "";
        Company = $('#drpCompany').val() == "-1" || null ? "" : $('#drpCompany').val();
        newComp = Company + "";
        Salesorg = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newSales = Salesorg + "";
        dISTR = $('#drpdISTR').val() == "-1" || null ? "" : $('#drpdISTR').val();
        newDistr = dISTR + "";
        Div = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = Div + "";
        Plant = $('#drpPlant').val() == "-1" || null ? "" : $('#drpPlant').val();
        newPlant = Plant + "";
        Customer = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
        newcustomer = Customer + "";
        Material = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
        newMAterial = Material + "";
        var ZDOC_CATG = $('#drpZDOC_CATG').val() == "-1" || null ? "" : $('#drpZDOC_CATG').val();
        var ZBPCACC = $('#drpZBPCACC').val() == "-1" || null ? "" : $('#drpZBPCACC').val();
        var ZBPCVERS = $('#drpZBPCVERS').val() == "-1" || null ? "" : $('#drpZBPCVERS').val();
        var Quantity = $('#drpQuantity').val() == "-1" || null ? "" : $('#drpQuantity').val();
        DataLoad();
        BindDropDownCALDAY('GetCalDay', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownCompany('GetComp', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownDistr('getDistr', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownDivision('getDivision', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownPlant('getPlant', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownCustomer('getCustomer', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownMaterial('getMaterial', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
    });
    $('#drpdISTR').change(function () {
        CALDAY = $('#drpCALDAY').val() == "-1" || null ? "" : $('#drpCALDAY').val();
        newCALDAY = CALDAY + "";
        Company = $('#drpCompany').val() == "-1" || null ? "" : $('#drpCompany').val();
        newComp = Company + "";
        Salesorg = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newSales = Salesorg + "";
        dISTR = $('#drpdISTR').val() == "-1" || null ? "" : $('#drpdISTR').val();
        newDistr = dISTR + "";
        Div = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = Div + "";
        Plant = $('#drpPlant').val() == "-1" || null ? "" : $('#drpPlant').val();
        newPlant = Plant + "";
        Customer = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
        newcustomer = Customer + "";
        Material = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
        newMAterial = Material + "";
        var ZDOC_CATG = $('#drpZDOC_CATG').val() == "-1" || null ? "" : $('#drpZDOC_CATG').val();
        var ZBPCACC = $('#drpZBPCACC').val() == "-1" || null ? "" : $('#drpZBPCACC').val();
        var ZBPCVERS = $('#drpZBPCVERS').val() == "-1" || null ? "" : $('#drpZBPCVERS').val();
        var Quantity = $('#drpQuantity').val() == "-1" || null ? "" : $('#drpQuantity').val();
        DataLoad();
        BindDropDownCALDAY('GetCalDay', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownCompany('GetComp', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownSalesOrg('GetSales', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownDivision('getDivision', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownPlant('getPlant', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownCustomer('getCustomer', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownMaterial('getMaterial', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
    });
    $('#drpDiv').change(function () {
        CALDAY = $('#drpCALDAY').val() == "-1" || null ? "" : $('#drpCALDAY').val();
        newCALDAY = CALDAY + "";
        Company = $('#drpCompany').val() == "-1" || null ? "" : $('#drpCompany').val();
        newComp = Company + "";
        Salesorg = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newSales = Salesorg + "";
        dISTR = $('#drpdISTR').val() == "-1" || null ? "" : $('#drpdISTR').val();
        newDistr = dISTR + "";
        Div = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = Div + "";
        Plant = $('#drpPlant').val() == "-1" || null ? "" : $('#drpPlant').val();
        newPlant = Plant + "";
        Customer = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
        newcustomer = Customer + "";
        Material = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
        newMAterial = Material + "";
        var ZDOC_CATG = $('#drpZDOC_CATG').val() == "-1" || null ? "" : $('#drpZDOC_CATG').val();
        var ZBPCACC = $('#drpZBPCACC').val() == "-1" || null ? "" : $('#drpZBPCACC').val();
        var ZBPCVERS = $('#drpZBPCVERS').val() == "-1" || null ? "" : $('#drpZBPCVERS').val();
        var Quantity = $('#drpQuantity').val() == "-1" || null ? "" : $('#drpQuantity').val();
        DataLoad();
        BindDropDownCALDAY('GetCalDay', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownCompany('GetComp', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownSalesOrg('GetSales', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownDistr('getDistr', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownPlant('getPlant', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownCustomer('getCustomer', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownMaterial('getMaterial', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
    });
    $('#drpPlant').change(function () {
        CALDAY = $('#drpCALDAY').val() == "-1" || null ? "" : $('#drpCALDAY').val();
        newCALDAY = CALDAY + "";
        Company = $('#drpCompany').val() == "-1" || null ? "" : $('#drpCompany').val();
        newComp = Company + "";
        Salesorg = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newSales = Salesorg + "";
        dISTR = $('#drpdISTR').val() == "-1" || null ? "" : $('#drpdISTR').val();
        newDistr = dISTR + "";
        Div = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = Div + "";
        Plant = $('#drpPlant').val() == "-1" || null ? "" : $('#drpPlant').val();
        newPlant = Plant + "";
        Customer = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
        newcustomer = Customer + "";
        Material = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
        newMAterial = Material + "";
        var ZDOC_CATG = $('#drpZDOC_CATG').val() == "-1" || null ? "" : $('#drpZDOC_CATG').val();
        var ZBPCACC = $('#drpZBPCACC').val() == "-1" || null ? "" : $('#drpZBPCACC').val();
        var ZBPCVERS = $('#drpZBPCVERS').val() == "-1" || null ? "" : $('#drpZBPCVERS').val();
        var Quantity = $('#drpQuantity').val() == "-1" || null ? "" : $('#drpQuantity').val();
        DataLoad();
        BindDropDownCALDAY('GetCalDay', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownCompany('GetComp', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownSalesOrg('GetSales', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownDistr('getDistr', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownDivision('getDivision', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        //BindDropDownPlant('getPlant', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownCustomer('getCustomer', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownMaterial('getMaterial', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
    });
    $('#drpCustomer').change(function () {
        CALDAY = $('#drpCALDAY').val() == "-1" || null ? "" : $('#drpCALDAY').val();
        newCALDAY = CALDAY + "";
        Company = $('#drpCompany').val() == "-1" || null ? "" : $('#drpCompany').val();
        newComp = Company + "";
        Salesorg = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newSales = Salesorg + "";
        dISTR = $('#drpdISTR').val() == "-1" || null ? "" : $('#drpdISTR').val();
        newDistr = dISTR + "";
        Div = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = Div + "";
        Plant = $('#drpPlant').val() == "-1" || null ? "" : $('#drpPlant').val();
        newPlant = Plant + "";
        Customer = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
        newcustomer = Customer + "";
        Material = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
        newMAterial = Material + "";
        var ZDOC_CATG = $('#drpZDOC_CATG').val() == "-1" || null ? "" : $('#drpZDOC_CATG').val();
        var ZBPCACC = $('#drpZBPCACC').val() == "-1" || null ? "" : $('#drpZBPCACC').val();
        var ZBPCVERS = $('#drpZBPCVERS').val() == "-1" || null ? "" : $('#drpZBPCVERS').val();
        var Quantity = $('#drpQuantity').val() == "-1" || null ? "" : $('#drpQuantity').val();
        DataLoad();
        BindDropDownCALDAY('GetCalDay', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownCompany('GetComp', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownSalesOrg('GetSales', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownDistr('getDistr', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownDivision('getDivision', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownPlant('getPlant', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownMaterial('getMaterial', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
    });
    $('#drpMaterial').change(function () {
        CALDAY = $('#drpCALDAY').val() == "-1" || null ? "" : $('#drpCALDAY').val();
        newCALDAY = CALDAY + "";
        Company = $('#drpCompany').val() == "-1" || null ? "" : $('#drpCompany').val();
        newComp = Company + "";
        Salesorg = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
        newSales = Salesorg + "";
        dISTR = $('#drpdISTR').val() == "-1" || null ? "" : $('#drpdISTR').val();
        newDistr = dISTR + "";
        Div = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
        newDiv = Div + "";
        Plant = $('#drpPlant').val() == "-1" || null ? "" : $('#drpPlant').val();
        newPlant = Plant + "";
        Customer = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
        newcustomer = Customer + "";
        Material = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
        newMAterial = Material + "";
        var ZDOC_CATG = $('#drpZDOC_CATG').val() == "-1" || null ? "" : $('#drpZDOC_CATG').val();
        var ZBPCACC = $('#drpZBPCACC').val() == "-1" || null ? "" : $('#drpZBPCACC').val();
        var ZBPCVERS = $('#drpZBPCVERS').val() == "-1" || null ? "" : $('#drpZBPCVERS').val();
        var Quantity = $('#drpQuantity').val() == "-1" || null ? "" : $('#drpQuantity').val();
        DataLoad();
        BindDropDownCALDAY('GetCalDay', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownCompany('GetComp', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownSalesOrg('GetSales', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownDistr('getDistr', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownDivision('getDivision', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownPlant('getPlant', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
        BindDropDownCustomer('getCustomer', newCALDAY, newComp, newSales, newDistr, newDiv, newPlant, newcustomer, newMAterial, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity);
    });

   
    $("#btnn").click(function () {

        $("#divLoader").show();

        var a = document.createElement('a');
        var data_type = 'data:application/vnd.ms-excel';
        //var table = $('#HSDList');
        //$('#HSDList').dataTable().fnDestroy();
        var table_html = table.find('th');
        table_html = table_html + table[0].outerHTML.replace(/ /g, '%20');
        a.href = data_type + ', ' + table_html;

        a.download = 'salesForcast.xls';
        a.click();
        DataLoad();
        $("#divLoader").hide();

    });

    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });


});


function DataLoad() {
    $("#divLoader").show();
    $('#HSDList').dataTable().fnDestroy();

    //Gets the latest CALDAY
    currentCALDAY = $('#drpCALDAY option')[$('#drpCALDAY option').length - 1].value;

    CALDAY = $('#drpCALDAY').val() == "-1" || currentCALDAY ? "" : $('#drpCALDAY').val();
    newCALDAY = CALDAY + "";
    Company = $('#drpCompany').val() == "-1" || null ? "" : $('#drpCompany').val();
    newComp = Company + "";
    Salesorg = $('#drpSalesOrg').val() == "-1" || null ? "" : $('#drpSalesOrg').val();
    newSales = Salesorg + "";
    dISTR = $('#drpdISTR').val() == "-1" || null ? "" : $('#drpdISTR').val();
    newDistr = dISTR + "";
    Div = $('#drpDiv').val() == "-1" || null ? "" : $('#drpDiv').val();
    newDiv = Div + "";
    Plant = $('#drpPlant').val() == "-1" || null ? "" : $('#drpPlant').val();
    newPlant = Plant + "";
    Customer = $('#drpCustomer').val() == "-1" || null ? "" : $('#drpCustomer').val();
    newcustomer = Customer + "";
    Material = $('#drpMaterial').val() == "-1" || null ? "" : $('#drpMaterial').val();
    newMAterial = Material + "";
    var ZDOC_CATG = $('#drpZDOC_CATG').val() == "-1" || null ? "" : $('#drpZDOC_CATG').val();
    var ZBPCACC = $('#drpZBPCACC').val() == "-1" || null ? "" : $('#drpZBPCACC').val();
    var ZBPCVERS = $('#drpZBPCVERS').val() == "-1" || null ? "" : $('#drpZBPCVERS').val();
    var Quantity = $('#drpQuantity').val() == "-1" || null ? "" : $('#drpQuantity').val();

   
    $.ajax({
        type: "POST",
        url: "gridView",
        data: {
            CALDAY: newCALDAY,
            company: newComp,
            sales: newSales,
            distr: newDistr,
            div: newDiv,
            plant: newPlant,
            customer: newcustomer,
            material: newMAterial,
            ZDOC_CATG: ZDOC_CATG,
            ZBPCACC: ZBPCACC,
            ZBPCVERS: ZBPCVERS,
            qty: Quantity
        },

        datatype: "json",
        "scrollX": true,

        success: function (data) {
            $("#HSDList").DataTable({
                "processing": false, // for show progress bar
                "serverSide": false, // for process server side
                "filter": true, // this is for disable filter (search box)
                "orderMulti": false, // for disable multiple column at once
                "bInfo": true, //Dont display info e.g. "Showing 1 to 4 of 4 entries"
                "paging": false,//Dont want paging                
                "bPaginate": false,//Dont want paging  
                "data": data,
                "dataSrc": "",
                "deferRender": false,
                rowReorder: true,

                "columns": [
                    { "data": "CalendarDay", "class": "CalendarDay", "name": "CalendarDay", "autoWidth": true },
                    { "data": "Company", "class": "Company", "name": "Company", "autoWidth": true },
                    { "data": "SalesOrganization", "class": "SalesOrganization", "name": "SalesOrganization", "autoWidth": true },
                    { "data": "Division", "class": "Division", "name": "Division", "autoWidth": true },
                    { "data": "Plant", "class": "Plant", "name": "Plant", "autoWidth": true },
                    { "data": "CustomerSoldToParty", "class": "CustomerSoldToParty", "name": "CustomerSoldToParty", "autoWidth": true },
                    { "data": "Payer", "class": "Payer", "name": "Payer", "autoWidth": true },
                    { "data": "CustomerName", "class": "CustomerName", "name": "CustomerName", "autoWidth": true },
                    { "data": "Name2", "class": "Name2", "name": "Name2", "autoWidth": true },
                    { "data": "RegionDescription", "class": "RegionDescription", "name": "RegionDescription", "autoWidth": true },
                    { "data": "AreaDescription", "class": "AreaDescription", "name": "AreaDescription", "autoWidth": true },
                    { "data": "TerritoryDescription", "class": "TerritoryDescription", "name": "TerritoryDescription", "autoWidth": true },
                    { "data": "TownDescription", "class": "TownDescription", "name": "TownDescription", "autoWidth": true },
                    { "data": "Material", "class": "Material", "name": "Material", "autoWidth": true },
                    { "data": "MaterialDescription", "class": "MaterialDescription", "name": "MaterialDescription", "autoWidth": true },
                    { "data": "Quantity", "class": "dt-right", "name": "Quantity", "autoWidth": true },
                    { "data": "ZDOC_CATG", "class": "ZDOC_CATG", "name": "ZDOC_CATG", "autoWidth": true },
                    { "data": "ZBPCACC", "class": "ZBPCACC", "name": "ZBPCACC", "autoWidth": true },
                    { "data": "ZBPCVERS", "class": "ZBPCVERS", "name": "ZBPCVERS", "autoWidth": true },
                    { "data": "GrWtKg", "class": "GrWtKg", "name": "GrWtKg", "autoWidth": true },
                    { "data": "GRNetKg", "class": "GRNetKg", "name": "GRNetKg", "autoWidth": true },
                    { "data": "DistributionChannel", "class": "DistributionChannel", "name": "DistributionChannel", "autoWidth": true },
                ],
                footerCallback: function (tfoot, data, start, end, display) {
                    var api = this.api();
                    $(api.column(15).footer()).html(
                        api.column(15).data().reduce(function (a, b) {
                            return parseInt(a) + parseInt(b);
                        }, 0),
                        $(tfoot).find('th').eq(14).html("Total Quantity")

                    );
                },

            });
            $("#divLoader").hide();

        }





    });




}







function BindDropDownCALDAY(url, CALDAY, Company, Salesorg, dISTR, Div, Plant, Customer, Material, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity) {
    if (CALDAY == '' || CALDAY == 'null' || CALDAY == null) {
        Common.Ajax('GET', url, { CALDAY, Company, Salesorg, dISTR, Div, Plant, Customer, Material, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity }, 'json', BindDropDownCALDAYHandler);
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

    //column.data().unique().sort().each(function (d, j) {
    //    select.append('<option value="' + d + '">' + d + '</option>')


}

function BindDropDownCompany(url, CALDAY, Company, Salesorg, dISTR, Div, Plant, Customer, Material, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity) {
    if (Company == '' || Company == 'null' || Company == null) {
        Common.Ajax('GET', url, { CALDAY, Company, Salesorg, dISTR, Div, Plant, Customer, Material, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity }, 'json', BindDropDownCompanyHandler);
    }
}
function BindDropDownCompanyHandler(response) {
    var s = '';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Company + '">' + response[i].Company + '</option>';
    }
    $("#drpCompany").html(s);
    $("#drpCompany").multiselect({
        columns: 1,
        placeholder: 'Company',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#drpCompany").multiselect("reload");
}

function BindDropDownSalesOrg(url, CALDAY, Company, Salesorg, dISTR, Div, Plant, Customer, Material, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity) {
    if (Salesorg == '' || Salesorg == 'null' || Salesorg == null) {
        Common.Ajax('GET', url, { url, CALDAY, Company, Salesorg, dISTR, Div, Plant, Customer, Material, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity }, 'json', BindDropDownSalesOrgHandler);
    }
}
function BindDropDownSalesOrgHandler(response) {
    var s = '';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].SalesOrganization + '">' + response[i].SalesOrganization + '</option>';
    }
    $("#drpSalesOrg").html(s);
    $("#drpSalesOrg").multiselect({
        columns: 1,
        placeholder: 'SalesOrg',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#drpSalesOrg").multiselect("reload");
}

function BindDropDownDistr(url, CALDAY, Company, Salesorg, dISTR, Div, Plant, Customer, Material, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity) {

    if (dISTR == '' || dISTR == 'null' || dISTR == null) {
        Common.Ajax('GET', url, { CALDAY, Company, Salesorg, dISTR, Div, Plant, Customer, Material, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity }, 'json', BindDropDownDistrHandler);
    }
}
function BindDropDownDistrHandler(response) {
    var s = '';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].DistributionChannel + '">' + response[i].DistributionChannel + '</option>';
    }
    $("#drpdISTR").html(s);
    $("#drpdISTR").multiselect({
        columns: 1,
        placeholder: 'Distribution',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#drpdISTR").multiselect("reload");
}

function BindDropDownDivision(url, CALDAY, Company, Salesorg, dISTR, Div, Plant, Customer, Material, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity) {

    if (Div == '' || Div == 'null' || Div == null) {
        Common.Ajax('GET', url, { CALDAY, Company, Salesorg, dISTR, Div, Plant, Customer, Material, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity }, 'json', BindDropDownDivivsionHandler);
    }
}
function BindDropDownDivivsionHandler(response) {
    var s = '';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Division + '">' + response[i].Division + '</option>';
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

function BindDropDownPlant(url, CALDAY, Company, Salesorg, dISTR, Div, Plant, Customer, Material, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity) {
    if (Plant == '' || Plant == 'null' || Plant == null) {
        Common.Ajax('GET', url, { CALDAY, Company, Salesorg, dISTR, Div, Plant, Customer, Material, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity }, 'json', BindDropDownPlantHandler);
    }
}
function BindDropDownPlantHandler(response) {
    var s = '';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Plant + '">' + response[i].Plant + '</option>';
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

function BindDropDownCustomer(url, CALDAY, Company, Salesorg, dISTR, Div, Plant, Customer, Material, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity) {
    if (Customer == '' || Customer == 'null' || Customer == null) {
        Common.Ajax('GET', url, { CALDAY, Company, Salesorg, dISTR, Div, Plant, Customer, Material, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity }, 'json', BindDropDownCustomerHandler);
    }
}
function BindDropDownCustomerHandler(response) {
    var s = '';
    for (var i = 0; i < response.length; i++) {
        if (response[i].Name1 == '') continue;

        var CustomerName = isNaN(parseInt(response[i].CustomerCode)) ? response[i].ZDOC_CATG : response[i].ZDOC_CATG + ' (' + parseInt(response[i].CustomerCode) + ')';
        s += '<option value="' + response[i].CustomerCode + '">' + CustomerName + ' </option>';
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

function BindDropDownMaterial(url, CALDAY, Company, Salesorg, dISTR, Div, Plant, Customer, Material, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity) {
    if (Material == '' || Material == 'null' || Material == null) {
        Common.Ajax('GET', url, { CALDAY, Company, Salesorg, dISTR, Div, Plant, Customer, Material, ZDOC_CATG, ZBPCACC, ZBPCVERS, Quantity }, 'json', BindDropDownMaterialHandler);
    }
}
function BindDropDownMaterialHandler(response) {
    var s = '';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].MaterialCode + '">' + response[i].ZDOC_CATG + ' (' + response[i].MaterialCode.substring(10) + ')</option>';
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
}
