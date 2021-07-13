/// <reference path="GenericAjax.js" />
$(document).ready(function () {
 //   BindDropDown('getAllRefrenceCode');

    $('#bttnSubmit').click(function () {
        saveData('addSpecialOrder');
    });

    $('#redirect').click(function () {
        window.location.href = "/dashboard/dashboard";
    });

    $('#btnGetMaterials').click(function () {
        GetMaterials();
    });

    $('#btnGetOrderReferences').click(function () {
        BindDropDown('getAllRefrenceCode');
    });
    BindDropDownMATERIAL('GetMaterials', '','');
    BindDropDownSALESORG('getSALESORG', '', '', '', '', '', '', '', '');
    BindDropDownDivision('getDivision', '', '', '', '', '', '', '', '');

    GetMaterials();

    $('#GetAllMaterialRecords').prop('style', 'width:100%');

    $('#GetAllMaterialRecords').on('change', 'input', function (e) {
        var row = $(this).closest('tr');
        Materialgroup1 = row.find("TD").eq(0).html();
        res = $.grep(jsonData, function (n, i) {
            return n.Materialgroup1 == Materialgroup1;
        });
        var temp = res[0];
        unitPriceM = temp.unitPriceM;

        if (!$.isNumeric($(this).val()))
            $(this).val('0');

        $('input', row).each(function () {

            var FirmOrder = row.find("TD").eq(3).html();
            var Unitprice = row.find("TD").eq(4).html();

            TotalFirmValue = FirmOrder * Unitprice;
            Uplift = Number($(this).val());
            total = parseInt(Uplift) + parseInt(FirmOrder);

            unitPriceM = parseFloat(total) * parseFloat(Unitprice);
        });

        $('.unitPriceM', row).text(Math.round(unitPriceM));

        var total = 0;
        var total_Sp_Value = 0;
        var TotalFirmValue = 0;

        $('input', '#GetAllMaterialRecords').each(function () {
            row = $(this).closest('tr');
            var FirmOrder = row.find("TD").eq(3).html();
            var Unitprice = row.find("TD").eq(4).html();

            TotalFirmValue += FirmOrder * Unitprice;
            Uplift = Number($(this).val());
            total = parseInt(Uplift) + parseInt(FirmOrder);

            total_Sp_Value += parseFloat(Uplift) * Unitprice;
        });

        api = $('#GetAllMaterialRecords').dataTable().api();

        api.column(6).footer().innerHTML = 'Total Value: ' + (total_Sp_Value + TotalFirmValue) +
            '<br>Total Firm Order Value: ' + TotalFirmValue +
            '<br>Total Special Order Value: ' + total_Sp_Value;

        e.preventDefault();
    });

    $('#drpRefrenceCode').change(function () {
        $('#listStatus').dataTable().fnDestroy();
        var orderID = $('#drpRefrenceCode').val();

        $.ajax({
            type: "GET",
            url: "GetAllSpecialOrderRecords?OrderID=" + orderID,
            data: { OrderID: orderID },
            datatype: "json",
            //traditional: true,
            success: function (data) {
                $("#listStatus").DataTable({
                    "processing": true, // for show progress bar
                    "serverSide": false, // for process server side
                    "filter": true, // this is for disable filter (search box)
                    "orderMulti": true, // for disable multiple column at once
                    "data": data,
                    "dataSrc": "",
                    "deferRender": true,
                    beforeSend: function () {
                        setTimeout(function () {
                            $("#divLoader").show();
                        }, 1);
                    },
                    complete: function (data) {
                        $("#divLoader").hide();
                    },
                    "columns": [
                        { "data": "Material", "class": "Material", "name": "Material", "autoWidth": true },
                        { "data": "Description", "class": "Description", "name": "Description", "autoWidth": true },
                        { "data": "SalesOrganization", "class": "SalesOrganization", "name": "SalesOrganization", "autoWidth": true, "visible": false },
                        { "data": "Quantity", "class": "Quantity", "name": "Quantity", "autoWidth": true },
                        { "data": "UnitPrice", "class": "UnitPrice", "name": "UnitPrice", "autoWidth": true},
                        { "data": "Value", "class": "Value", "name": "Value", "autoWidth": true},
                        { "data": "Status", "class": "Status", "name": "Status", "autoWidth": true },


                    ],

                    footerCallback: function (tfoot, data, start, end, display) {
                        var api = this.api();
                        $(api.column(3).footer()).html(
                            api.column(3).data().reduce(function (a, b) {
                                return a + b;
                            }, 0),
                            $(tfoot).find('th').eq(1).html("Total Quantity")

                        );

                        $(api.column(5).footer()).html(
                            api.column(5).data().reduce(function (a, b) {
                                return a + b;
                            }, 0)
                        );
                        $(tfoot).find('th').eq(3).html("Total Value");
                    },

                });

            }
        });
    });
});

function BindDropDown(url) {
    Common.Ajax('GET', url, {StartDate: $('#StartDate').val(), EndDate: $('#EndDate').val()}, 'json', BindDropDownHandler);
}

function BindDropDownHandler(response) {
    var s = '<option value="-1">Please Select a Reference Code</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].SP_Order_ID + '">' + response[i].SP_Order_ID + '</option>';
    }
    $("#drpRefrenceCode").html(s);
}


function saveData(url) {
    Common.toggleSubmitRequest(true);
    $('#GetAllMaterialRecords').dataTable().fnDestroy();

    var specialOrderList = new Array();
    $("#GetAllMaterialRecords TBODY TR").each(function () {
        var row = $(this);
        var specialOrderModel = {};
        specialOrderModel.SP_Order_ID = '';
        specialOrderModel.Material = row.find("TD").eq(0).html();
        specialOrderModel.SalesOrganization = row.find("TD").eq(7).html();
        specialOrderModel.Division = row.find("TD").eq(8).html();
        specialOrderModel.Quantity = row.find('#txtQuantity').val();

        if (specialOrderModel.Quantity !== "" && specialOrderModel.Quantity != "0") {
            specialOrderList.push(specialOrderModel);
        }

    });

    if (specialOrderList == null || specialOrderList.length == 0) {
        $('#OperationFailed').show('fade');
            GetMaterials();
        setTimeout(function () {
            $('#OperationFailed').hide('fade');
        }, 6000);
        return;
    }

    var dataToPost = specialOrderList;

    Common.Ajax('POST', url, JSON.stringify(dataToPost), 'json', successSpecialOrderCreateHandler);
}

function GetMaterials() {
    Common.toggleSubmitRequest(true);
    _Material = $('#drpmaterial').val() == "-1" || null ? "" : $('#drpmaterial').val().toString();
    _SalesOrganization = $('#drpsalesOrg').val() == "-1" || null ? "" : $('#drpsalesOrg').val().toString();
    _Division = $('#drpDivision').val() == "-1" || null ? "" : $('#drpDivision').val().toString();

    $('#GetAllMaterialRecords').dataTable().fnDestroy();

    var table = $("#GetAllMaterialRecords").DataTable({
        "paging": false,
        "ajax": {
            "url": "GetAllMaterialRecords",
            "data": { Material: _Material, SalesOrganization: _SalesOrganization, Division: _Division },
            "type": "GET",
            "datatype": "json",
            "processing": false, // for show progress bar
            "serverSide": false, // for process server side
            "filter": true, // this is for disable filter (search box)
            "orderMulti": true, // for disable multiple column at once
            "dataSrc": function (json) {
                //Make your callback here.
                jsonData = json;
                Common.toggleSubmitRequest(false);
                return json;
            },
            complete: function (data) {
                Common.toggleSubmitRequest(false);
            },
            always:  function () {
                Common.toggleSubmitRequest(false);
            }
        },

        "columns": [
            { "data": "Materialgroup1", "class": "Materialgroup1", "name": "Materialgroup1", "width": 100 },
            { "data": "Description", "class": "Description", "name": "Description", "autoWidth": true },
            { "data": "quantity", "class": "quantity", "name": "quantity", "autoWidth": true },
            { "data": "firmQuantity", "class": "firmQuantity", "name": "firmQuantity", "autoWidth": true },
            { "data": "unitPrice2", "class": "unitPrice2", "name": "unitPrice2", "autoWidth": true, "width": 50 },
            {
                "defaultContent": "<input type='number' id='txtQuantity' name='Quantity' class='form-control' placeholder='Enter special Quantity' onkeypress='return NumKeyCheck(this);' min='0'>"
            },
            { "data": "unitPriceM", "class": "unitPriceM", "name": "unitPriceM", "autoWidth": true },
            { "data": "SalesOrganization", "class": "SalesOrganization", "name": "SalesOrganization", "visible": false },
            { "data": "Division", "class": "Division", "name": "Division", "visible": false },

        ],
        footerCallback: function (tfoot, data, start, end, display) {
            var api = this.api();
            $(api.column(2).footer()).html('Total Proposed Order = ' +
                api.column(2).data().reduce(function (a, b) {
                    return a + b;
                }, 0)
            );
            $(api.column(3).footer()).html('Total Firm Order = ' +
                api.column(3).data().reduce(function (a, b) {
                    return a + b;
                }, 0)
            );    // $(tfoot).find('th').eq(3).html("Total Quantity =")
            $(api.column(6).footer()).html('Total Value = ' +
                api.column(6).data().reduce(function (a, b) {
                    return a + b;
                }, 0)
            );
        },
    });
}

function NumKeyCheck(e) {
    var KeyID = (window.event) ? event.keyCode : e.keyCode;

    if ((KeyID == 8) || (KeyID == 9) || (KeyID == 13) || (KeyID >= 48 && KeyID <= 57)) {
        return true;
    }
    else {
        return false;
    }
}

function successSpecialOrderCreateHandler(response) {

    GetMaterials();
    if (response == '1') {
        $('#txtReleDesc').val('');

        $('#successAlert').show('fade');
        setTimeout(function () {
            $('#successAlert').hide('fade');
            //window.location.href = '/Customer_Special_Orders/Create_Customer_Special_Orders';
        }, 6000);
    }
    if (response == '-1') {
        $('#errorAlert').show('fade');

        setTimeout(function () {
            $('#errorAlert').hide('fade');
        }, 6000);
    }

    Common.toggleSubmitRequest(false);
}

function BindDropDownMATERIAL(url, material, sales, PGD, division) {
    Common.Ajax('GET', url, { material, sales, PGD, division }, 'json', BindDropDownMATERIALHandler);
}
function BindDropDownMATERIALHandler(response) {

    var outputArray = [];
    var s = '';//<option value="-1">SALES ORGANIZATION</option>';
    for (var i = 0; i < response.length; i++) {

        if ((jQuery.inArray(response[i], outputArray)) == -1) {
            s += '<option value="' + response[i].Material + '">' + response[i].Description + ' (' + response[i].Material + ') (' + response[i].SalesOrganization + ') </option>';
        }
    }


    $("#drpmaterial").html(s);

    $("#drpmaterial").multiselect({
        
        columns: 1,
        placeholder: 'Material',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    $("#drpmaterial").multiselect("reload");
    Common.toggleSubmitRequest(false);
}


function BindDropDownSALESORG(url, material, sales, PGD, division) {
    Common.Ajax('GET', url, { material, sales, PGD, division }, 'json', BindDropDownSalesOrgHandler);
}
function BindDropDownSalesOrgHandler(response) {

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

function BindDropDownDivision(url, material, sales, PGD, division) {
    Common.Ajax('GET', url, { material, sales, PGD, division }, 'json', BindDropDownDivisionHandler);
}

function BindDropDownDivisionHandler(response) {
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
