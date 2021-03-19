$(document).ready(function () {
  
    BindDropDownCustomer('getAllCustomer');
    BindDropDownRegions('getAllRegions');
    BindDropDownBrands('getAllBrands');
    BindDropDownSKU('getAllSKUs');
    BindDropDownSalesOrg('getAllSalesOrg');

    BindDropDownArea('getAllArea');
    BindDropDownTown('getAllTown');
    BindDropDownTerritory('getAllTerritory');
    BindDropDownPlant('getAllPlant');


    BindDropDownMatGrp1('getAllMatgrp1');
    BindDropDownMatGrp2('getAllMatgrp2');
    BindDropDownMatGrp3('getAllMatgrp3');
    BindDropDownMatGrp4('getAllMatgrp4');
});
function BindDropDownCustomer(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownHandlerCustomer);
}
function BindDropDownRegions(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownHandlerRegions);
}
function BindDropDownBrands(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownHandlerBrands);
}
function BindDropDownSKU(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownHandlerSKU);
}
function BindDropDownSalesOrg(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownHandlerSalesOrg);
}


function BindDropDownArea(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownHandlerArea);
}
function BindDropDownTown(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownHandlerTown);
}
function BindDropDownTerritory(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownHandlerTerritory);
}
function BindDropDownPlant(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownHandlerPlant);
}


function BindDropDownMatGrp1(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownHandlerMatGrp1);
}
function BindDropDownMatGrp2(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownHandlerMatGrp2);
}
function BindDropDownMatGrp3(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownHandlerMatGrp3);
}
function BindDropDownMatGrp4(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownHandlerMatGrp4);
}





function BindDropDownHandlerCustomer(response) {
    var s = '<option value="-1">Select Customer</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Customer + '">' + response[i].Name1 + '  (' + response[i].Customer + ')</option>';
    }
    $("#drpCustomer").html(s);
}
function BindDropDownHandlerRegions(response) {
    var s = '<option value="-1">Select Region</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].RegionCode + '">' + response[i].RegionDescription + ' </option>';
    }
    $("#drpRegion").html(s);
}
function BindDropDownHandlerBrands(response) {
    var s = '<option value="-1">Select Brand</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Material + '">' + response[i].Description + ' </option>';
    }
    $("#drpBrand").html(s);
}
function BindDropDownHandlerSKU(response) {
    var s = '<option value="-1">Select SKU</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].SKUMapping + '">' + response[i].SKUMapping + ' </option>';
    }
    $("#drpSKU").html(s);
}
function BindDropDownHandlerSalesOrg(response) {
    var s = '<option value="-1">Select Sales Org</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].SalesOrganization + '">' + response[i].SalesOrganization + ' </option>';
    }
    $("#drpSalesOrg").html(s);
}



function BindDropDownHandlerArea(response) {
    var s = '<option value="-1">Select Area</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].AreaCode + '">' + response[i].AreaDescription + '  (' + response[i].AreaCode + ')</option>';
    }
    $("#drpArea").html(s);
}
function BindDropDownHandlerTown(response) {
    var s = '<option value="-1">Select Town</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].TownCode + '">' + response[i].TownDescription + ' </option>';
    }
    $("#drpTown").html(s);
}
function BindDropDownHandlerTerritory(response) {
    var s = '<option value="-1">Select Territory</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].TerritoryCode + '">' + response[i].TerritoryDescription + ' </option>';
    }
    $("#drpTerritory").html(s);
}
function BindDropDownHandlerPlant(response) {
    var s = '<option value="-1">Select Plant</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].PlantDescription + '">' + response[i].PlantDescription + ' </option>';
    }
    $("#drpPlant").html(s);
}




function BindDropDownHandlerMatGrp1(response) {
    var s = '<option value="-1">Select Material Group1</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Materialgroup1 + '">' + response[i].MaterialGroup1_Description + ' </option>';
    }
    $("#drpMatGrp1").html(s);
}
function BindDropDownHandlerMatGrp2(response) {
    var s = '<option value="-1">Select Material Group2</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Materialgroup2 + '">' + response[i].MaterialGroup2_Description + ' </option>';
    }
    $("#drpMatGrp2").html(s);
}
function BindDropDownHandlerMatGrp3(response) {
    var s = '<option value="-1">Select Material Group3</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Materialgroup3 + '">' + response[i].MaterialGroup3_Description + ' </option>';
    }
    $("#drpMatGrp3").html(s);
}
function BindDropDownHandlerMatGrp4(response) {
    var s = '<option value="-1">Select Material Group4</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Materialgroup4 + '">' + response[i].MaterialGroup4_Description + ' </option>';
    }
    $("#drpMatGrp4").html(s);
}