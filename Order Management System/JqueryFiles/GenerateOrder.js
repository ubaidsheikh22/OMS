/// <reference path="GenericAjax.js" />
var tableMain;
var groupData = null;
var isFirstLoad = true;
$(document).ready(function () {

    $('#bttnGenerateOrder').click(function () {
        alert('This Process May Take A Few Minutes... Click "OK" to Continue...');
        $("#orderSpinner").show();
        saveData('GetAllGeneratedOrders');
    });

    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });
    $('#bttnConfirmOrder').click(function () {
        if ($(document).find("input[type=checkbox]:checked").length == 0) {
            alert('Please select Orders first...');
            return;
        }
        $("#orderSpinner").show();
        setTimeout(function () {
            saveConfirmData('insertConfirmOrder');
        }, 10);

    });


    ///for all order confirmation /////
    $('#bttnConfirmallOrder').click(function () {
        alert('Confirming All Orders.... Click "OK" to Continue...');
        $("#orderSpinner").show();
        setTimeout(function () {
            saveConfirmallData('insertallConfirmOrder');
        }, 10);

    });
      ///for all order confirmation /////


    $('#drpCustomerName').change(function () { dataload(); });
    $('#drpSalesOrg').change(function () { dataload(); });
    $('#drpDiv').change(function () { dataload(); });
    $('#drpCategory').change(function () { dataload(); });
    $('#drpRegion').change(function () { dataload(); });
    $('#drpArea').change(function () { dataload(); });
    $('#drpTerritory').change(function () { dataload(); });
    $('#drpTown').change(function () { dataload(); });
    $('#drpPlant').change(function () { dataload(); });

    AllDataDataLoad();

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
        var calculated_total_sum = 0;

        $("#list #OrderRefrenceNumber").each(function () {
            var get_textbox_value = $(this).val();
            if ($.isNumeric(get_textbox_value)) {
                calculated_total_sum += parseFloat(get_textbox_value);
            }
        });
        $("#total_sum_Order").html(calculated_total_sum);
    });
    isFirstLoad = false;
});
var table = null;

function BindDropDown(url, name, salesorg, div, category, region, area, territory, town, plant) {

    var url = "getAllDDL";
    Common.Ajax('GET', url, { url, name, salesorg, div, category, region, area, territory, town, plant, isFirstLoad }, 'json', BindDropDownHandler);
}
function BindDropDownHandler(response) {
    ddlData = response;

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



    BindDropDownNAme('/customer/GetCustomerName', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
    BindDropDowndivision('/customer/GetDivision', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
    BindDropDowncategory('/customer/GetCategory', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
    BindDropDownregion('/customer/GetRegion', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
    BindDropDownarea('/customer/GetArea', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
    BindDropDownterritory('/customer/GetTerritory', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
    BindDropDowntown('/customer/GetTown', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
    BindDropDownplant('/customer/GetPlant', name, newsalesorg, newDiv, null, newregion, newArea, newsterr, newtown, newplant);
}


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
function test() {

    $("#orderSpinner").show();
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
    BindDropDown("", newCustomer, drpSalesOrg, drpDiv, "", region, drpArea, drpTerritory, drpTown, drpPlant);

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

        success: function (data) {
            groupData = data.groupdata;
            $('#OrderList').dataTable().fnDestroy();
            table = $("#OrderList").DataTable({
                "processing": false, // for show progress bar
                "serverSide": false, // for process server side
                "filter": true, // this is for disable filter (search box)
                "orderMulti": false, // for disable multiple column at once
                "bInfo": true, //Dont display info e.g. "Showing 1 to 4 of 4 entries"
                "paging": false,//Dont want paging                
                "bPaginate": false,//Dont want paging   
                "data": data.emp,
                "dataSrc": "",
                'order': [[1, 'asc']],
                "columns": [
                    { "data": "distinctValue", "name": "distinctValue" },
                    { "data": "CALDAY", "class": "CALDAY", "name": "CALDAY", "autoWidth": true, "visible": false },
                    //   { "data": "COMP_CODE", "class": "COMP_CODE", "name": "COMP_CODE", "autoWidth": true },
                    { "data": "Order_Ref", "class": "Order_Ref", "name": "Order_Ref", "autoWidth": true },
                    { "data": "SALESORG", "class": "SALESORG", "name": "SALESORG", "autoWidth": true },
                    {
                        //"data": "CUSTOMER",
                        "class": "CUSTOMER", "name": "CUSTOMER", "autoWidth": true,
                        "render": function (data, type, full, meta) {
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
                    $(api.column(12).footer()).html('Total Proposed Order = ' +
                        api.column(12).data().reduce(function (a, b) {
                            return parseInt(a) + parseInt(b);
                        }, 0)
                    );
                    $(api.column(13).footer()).html('Total Unit Price = ' +
                        api.column(13).data().reduce(function (a, b) {
                            return parseInt(a) + parseInt(b);
                        }, 0)
                    );
                    $(api.column(14).footer()).html('Total Amount = ' +
                        api.column(14).data().reduce(function (a, b) {
                            return parseInt(a) + parseInt(b);
                        }, 0)
                    );
                    setTimeout(function () {
                        $("#orderSpinner").hide();
                        $("#OrderList tbody TR").each(function (i, v) {
                            two = $(v).find("td:eq(21)").text();

                            //three = $(v).find("td:eq(3)").html();
                            if (parseInt(two) >= 48) {
                                $(v).css("background-color", "yellow");
                            }
                        });
                    }, 500);
                },
            });
        }
    });
}
function dataload() {
    $("#orderSpinner").show();
    setTimeout(test, 10);
}

function clickable() {
    $('#OrderList tbody').on('click', 'button', function () {
        var data = table.row($(this).parents("tr")).data();
        var Customer = $(this).closest("tr").find(".CUSTOMER").text();
        var OrderReference = $(this).closest("tr").find(".Order_Ref").text();
        $("#largeModal1").modal();
        $.ajax({
            type: "POST",
            url: "GetFrequency",
            data: {
                customer: Customer,
                OrderReferenceNumber: OrderReference
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
                        { "data": "WeeklyQuantity", "class": "WeeklyQuantity", "name": "WeeklyQuantity", "autoWidth": true },
                        { "data": "Monday", "class": "Monday", "name": "Monday", "autoWidth": true },
                        { "data": "Tuesday", "class": "Tuesday", "name": "Tuesday", "autoWidth": true },
                        { "data": "Wednesday", "class": "Wednesday", "name": "Wednesday", "autoWidth": true },
                        { "data": "Thursday", "class": "Thursday", "name": "Thursday", "autoWidth": true },
                        { "data": "Friday", "class": "Friday", "name": "Friday", "autoWidth": true },
                        { "data": "Saturday", "class": "Saturday", "name": "Saturday", "autoWidth": true },
                        { "data": "Sunday", "class": "Sunday", "name": "Sunday", "autoWidth": true },
                        { "data": "UnitPrice", "class": "UnitPrice", "name": "UnitPrice", "autoWidth": true },
                        { "data": "TotalValue", "class": "TotalValue", "name": "TotalValue", "autoWidth": true },
                    ],

                    footerCallback: function (tfoot, data, start, end, display) {
                        var api = this.api();
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


function AllDataDataLoad() {
    if (true) {
        $('#OrderList').dataTable().fnDestroy();
        table = $("#OrderList").DataTable({
            "processing": false, // for show progress bar
            "serverSide": false, // for process server side
            "filter": true, // this is for disable filter (search box)
            "orderMulti": false, // for disable multiple column at once
            "bPaginate": false,//Dont want paging   
            "paging": false,
            "bInfo": false,

            "data": AllData.Data,
            "dataSrc": "",
            'order': [[1, 'asc']],
            //"deferRender": true,
            "columns": [
                { "data": "distinctValue", "name": "distinctValue" },
                { "data": "CALDAY", "class": "CALDAY", "name": "CALDAY", "autoWidth": true, "visible": false },
                //   { "data": "COMP_CODE", "class": "COMP_CODE", "name": "COMP_CODE", "autoWidth": true },
                { "data": "Order_Ref", "class": "Order_Ref", "name": "Order_Ref", "autoWidth": true },
                { "data": "SALESORG", "class": "SALESORG", "name": "SALESORG", "autoWidth": true },
                {
                    //"data": "CUSTOMER",
                    "class": "CUSTOMER", "name": "CUSTOMER", "autoWidth": true,
                    "render": function (data, type, full, meta) {
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
                $(api.column(12).footer()).html('Total Proposed Order = ' +
                    api.column(12).data().reduce(function (a, b) {
                        return parseInt(a) + parseInt(b);
                    }, 0)
                );
                $(api.column(13).footer()).html('Total Unit Price = ' +
                    api.column(13).data().reduce(function (a, b) {
                        return parseInt(a) + parseInt(b);
                    }, 0)
                );
                $(api.column(14).footer()).html('Total Amount = ' +
                    api.column(14).data().reduce(function (a, b) {
                        return parseInt(a) + parseInt(b);
                    }, 0)
                );
                setTimeout(function () {
                    $("#orderSpinner").hide();
                    $("#OrderList tbody TR").each(function (i, v) {
                        two = $(v).find("td:eq(21)").text();

                        //three = $(v).find("td:eq(3)").html();
                        if (parseInt(two) >= 48) {
                            $(v).css("background-color", "yellow");
                        }
                    });
                }, 500);
            },

        });
        setTimeout(1000, $('#orderSpinner').hide());
    }

}


function saveData(url) {

    Common.Ajax('POST', url, '', 'json', successRoleCreateHandler);
}

function saveConfirmData(url) {
    $('#OrderList').dataTable().fnDestroy();

    var OrderListModal = new Array();
    $("#OrderList TBODY TR").each(function () {
        var row = $(this);
        if (row.find("input[type=checkbox]:checked").length == 0) {
            return;
        }
        var OrderModel = {};
        OrderModel.CALDAY = row.find("TD").eq(1).html();
        OrderModel.Order_Ref = row.find("TD").eq(2).html();
        OrderModel.SALESORG = row.find("TD").eq(3).html();
        OrderModel.CUSTOMER = row.find("TD").eq(4).find("a").html();

        OrderModel.MATERIAL = row.find("TD").eq(10).html();
        OrderModel.Order_Qty = row.find("TD").eq(12).html();
        OrderModel.MaterialTotalValues = row.find("TD").eq(13).html();

        OrderModel.weekNumber = row.find("TD").eq(15).html();
        OrderModel.DIVISION = row.find("TD").eq(16).html();
        OrderModel.DISTR_CHAN = row.find("TD").eq(24).html();
        OrderListModal.push(OrderModel);
    });
    var dataToPost = JSON.stringify(OrderListModal);
    Common.Ajax('POST', url, dataToPost, 'json', successRoleCreateHandlerORder);
}



function saveConfirmallData(url) {
    $('#OrderList').dataTable().fnDestroy();

    var OrderListModal = new Array();
    $("#OrderList TBODY TR").each(function () {
        var row = $(this);
        //if (row.find("input[type=checkbox]:checked").length == 0) {
        //    return;
        //}
        var OrderModel = {};
        OrderModel.CALDAY = row.find("TD").eq(1).html();
        OrderModel.Order_Ref = row.find("TD").eq(2).html();
        OrderModel.SALESORG = row.find("TD").eq(3).html();
        OrderModel.CUSTOMER = row.find("TD").eq(4).find("a").html();

        OrderModel.MATERIAL = row.find("TD").eq(10).html();
        OrderModel.Order_Qty = row.find("TD").eq(12).html();
        OrderModel.MaterialTotalValues = row.find("TD").eq(13).html();

        OrderModel.weekNumber = row.find("TD").eq(15).html();
        OrderModel.DIVISION = row.find("TD").eq(16).html();
        OrderModel.DISTR_CHAN = row.find("TD").eq(24).html();
        OrderListModal.push(OrderModel);
    });
    var dataToPost = JSON.stringify(OrderListModal);
    Common.Ajax('POST', url, dataToPost, 'json', successRoleCreateHandlerORder);
}


function successRoleCreateHandler(response) {

    if (response == '1') {
        $('#successAlert').show('fade');

        setTimeout(function () {
            $('#successAlert').hide('fade');
        }, 5000);

        dataload();
    }
    if (response == '-1') {
        dataload();
    }
}

function successRoleCreateHandlerORder(response) {

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

function BindDropDownNAme(url, name, salesorg, div, category, region, area, territory, town, plant) {
    if (name == '' || name == 'null' || name == null)

        if (name == '' || name == 'null' || name == null) {
            if (ddlData.name == undefined)
                Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownNameHandler);
            else {
                BindDropDownNameHandler(ddlData.name);
            }
        }
}
function BindDropDownNameHandler(response) {
    ddlData.name == response;

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

    if (salesorg == '' || salesorg == 'null' || salesorg == null) {
        if (ddlData.salesorg == undefined)
            Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownSalesHandler);
        else {
            BindDropDownSalesHandler(ddlData.salesorg);
        }
    }
}
function BindDropDownSalesHandler(response) {
    ddlData.salesorg == response;

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



    if (div == '' || div == 'null' || div == null) {
        if (ddlData.div == undefined)
            Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownDivHandler);
        else {
            BindDropDownDivHandler(ddlData.div);
        }
    }

}
function BindDropDownDivHandler(response) {
    ddlData.div == response;

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
    //if (category == '' || category == 'null' || category == null)

    //    Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownCategoryHandler);
}
function BindDropDownCategoryHandler(response) {
    return;
    ddlData.category == response;

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
}
function BindDropDownregion(url, name, salesorg, div, category, region, area, territory, town, plant) {

    if (region == '' || region == 'null' || region == null) {
        if (ddlData.region == undefined)
            Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownRegionHandler);
        else {
            BindDropDownRegionHandler(ddlData.region);
        }
    }
}
function BindDropDownRegionHandler(response) {
    ddlData.region == response;

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


    if (area == '' || area == 'null' || area == null) {
        if (ddlData.area == undefined)
            Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownAreaHandler);
        else {
            BindDropDownAreaHandler(ddlData.area);
        }
    }
}
function BindDropDownAreaHandler(response) {
    ddlData.area == response;

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

    if (territory == '' || territory == 'null' || territory == null) {
        if (ddlData.territory == undefined)
            Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownTerritoryHandler);
        else {
            BindDropDownTerritoryHandler(ddlData.territory);
        }
    }
}

function BindDropDownTerritoryHandler(response) {
    ddlData.territory == response;
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

    if (town == '' || town == 'null' || town == null) {
        if (ddlData.town == undefined)
            Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownTownHandler);
        else {
            BindDropDownTownHandler(ddlData.town);
        }
    }
}
function BindDropDownTownHandler(response) {
    ddlData.town == response;
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

    if (plant == '' || plant == 'null' || plant == null) {
        if (ddlData.plant == undefined)
            Common.Ajax('GET', url, { name, salesorg, div, category, region, area, territory, town, plant }, 'json', BindDropDownPlantHandler);
        else {
            BindDropDownPlantHandler(ddlData.plant);
        }
    }
}
function BindDropDownPlantHandler(response) {
    ddlData.plant == response;
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