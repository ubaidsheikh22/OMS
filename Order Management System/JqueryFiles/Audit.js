/// <reference path="GenericAjax.js" /> 
var LogType = $('#LogType').val() == "-1" || null ? "" : $('#LogType').val();
var LogName = $('#LogName').val() == "-1" || null ? "" : $('#LogName').val();
var LogScreen = $('#LogScreen').val() == "-1" || null ? "" : $('#LogScreen').val();
var StartDate = $('#StartDate').val() == "-1" || null ? "" : $('#StartDate').val();
var EndDate = $('#EndDate').val() == "-1" || null ? "" : $('#EndDate').val();
$(document).ready(function () {


    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });
    $('#LogType').change(function () {//Material
        getGrid();
    });

    $('#LogName').change(function () {//salesOrg
        getGrid();
    });

    $('#LogScreen').change(function () {//RegionCode
        getGrid();
    });

    $('#StartDate').change(function () {//AreaCode
        getGrid();
    });

    $('#EndDate').change(function () {//TerritoryCode
        getGrid();
    });

});

BindDropDownType('GetLogDropdown', 1);
BindDropDownName('GetLogDropdown', 2);
BindDropDownScreen('GetLogDropdown', 3);


function BindDropDownType(url, index) {
    Common.Ajax('GET', 'GetLogDropdown', { index }, 'json', BindDropDownTypeHandler);
}
function BindDropDownTypeHandler(response) {
    var outputArray = [];
    var s = ''
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].ID + '">' + response[i].Title + '</option>';
        }
    }
    $("#LogType").html(s);
    $("#LogType").multiselect({
        columns: 1,
        placeholder: 'Log Type',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#LogType").multiselect("reload");
}

function BindDropDownName(url, index) {
    Common.Ajax('GET', 'GetLogDropdown', { index }, 'json', BindDropDownNameHandler);
}
function BindDropDownNameHandler(response) {
    var outputArray = [];
    var s = ''
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].ID + '">' + response[i].Title + '</option>';
        }
    }
    $("#LogName").html(s);
    $("#LogName").multiselect({
        columns: 1,
        placeholder: 'Log Name',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#LogName").multiselect("reload");
}

function BindDropDownScreen(url, index) {
    Common.Ajax('GET', 'GetLogDropdown', { index }, 'json', BindDropDownScreenHandler);
}
function BindDropDownScreenHandler(response) {
    var outputArray = [];
    var s = ''
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].ID + '">' + response[i].Title + '</option>';
        }
    }
    $("#LogScreen").html(s);
    $("#LogScreen").multiselect({
        columns: 1,
        placeholder: 'Log Screen',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#LogScreen").multiselect("reload");
}


//function Refresh(url) {
//    Common.Ajax('POST', url, 'json', successRoleUpdateHandler);
//}