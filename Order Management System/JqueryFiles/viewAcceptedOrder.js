$(document).ready(function () {
    BindDropDown('getAllCustomer');

    $("#list").dataTable();

    $('#btnGetOrders').click(function () {
        GetOrders();
    });
});

function GetOrders() {
    $('#list').dataTable().fnDestroy();
    var Customer = $('#drpCustomer').val();
    var StartDate = $('#StartDate').val();
    var EndDate = $('#EndDate').val();

    $.ajax({
        type: "GET",
        url: "getAllAcceptedOrders?customer=" + Customer,
        data: { customer: Customer, StartDate: StartDate, EndDate: EndDate },
        datatype: "json",
        beforeSend: function () {
            setTimeout(function () {
                $("#divLoader").show();
            }, 1);
        },
        complete: function (data) {
            $("#divLoader").hide();
        },
        success: function (data) {
            $("#list").DataTable({
                "processing": false,    // for show progress bar
                "serverSide": false,    // for process server side
                "filter": true,         // this is for disable filter (search box)
                "orderMulti": false,    // for disable multiple column at once
                "data": data,
                "dataSrc": "",
                "deferRender": true,
                "columns": [
                    { "data": "OrderRefrenceNumber", "class": "OrderRefrenceNumber", "name": "OrderRefrenceNumber", "autoWidth": true },
                    { "data": "Material", "class": "Material", "name": "Material", "autoWidth": true },
                    { "data": "Description", "class": "Description", "name": "Description", "autoWidth": true },
                    { "data": "WeeklyQuantity", "class": "WeeklyQuantity", "name": "WeeklyQuantity", "autoWidth": true },
                    { "data": "FirmOrder", "class": "FirmOrder", "name": "FirmOrder", "autoWidth": true, "visible": true },
                    { "data": "TotalFirmPrice", "class": "TotalFirmPrice", "name": "TotalFirmPrice", "autoWidth": true, "visible": true },
                    { "data": "SpecialQuanity", "class": "SpecialQuanity", "name": "SpecialQuanity", "autoWidth": true },
                    { "data": "TotalSpecialOrderPrice", "class": "TotalSpecialOrderPrice", "name": "TotalSpecialOrderPrice", "autoWidth": true },
                    { "data": "UnitPrice", "class": "UnitPrice", "name": "UnitPrice", "autoWidth": true },
                    { "data": "totalOrder", "class": "totalOrder", "name": "totalOrder", "autoWidth": true },
                    { "data": "TotalValue", "class": "TotalValue", "name": "TotalValue", "autoWidth": true, "visible": true }
                ],
                footerCallback: function (tfoot, data, start, end, display) {
                    var api = this.api();
                    $(api.column(3).footer()).html('Total Suggested Order = ' +
                        api.column(3).data().reduce(function (a, b) {
                            return a + b;
                        }, 0)
                    ),
                        $(api.column(4).footer()).html('Total Firm Order = ' +
                            api.column(4).data().reduce(function (a, b) {
                                return a + b;
                            }, 0),

                            $(api.column(5).footer()).html('Total Firm Amount = ' +
                                api.column(5).data().reduce(function (a, b) {
                                    return a + b;
                                }, 0) + '/-'
                            ),
                            $(api.column(6).footer()).html('Total Special Order Quantity = ' +
                                api.column(6).data().reduce(function (a, b) {
                                    return a + b;
                                }, 0)
                            ),
                            $(api.column(7).footer()).html('Total special Order Amount = ' +
                                api.column(7).data().reduce(function (a, b) {
                                    return a + b;
                                }, 0) + '/-'
                            ),
                            $(api.column(8).footer()).html('Total Unit Amount = ' +
                                api.column(8).data().reduce(function (a, b) {
                                    return a + b;
                                }, 0) + '/-'
                            ),
                            $(api.column(9).footer()).html('Total Orders = ' +
                                api.column(9).data().reduce(function (a, b) {
                                    return a + b;
                                }, 0)
                            ),
                            $(api.column(10).footer()).html('Total Amount= ' +
                                api.column(10).data().reduce(function (a, b) {
                                    return a + b;
                                }, 0) + '/-'
                            )

                        );
                    setTimeout(function () {
                        $("#list tbody TR").each(function (i, v) {
                            two = $(v).find("td:eq(2)").html();
                            three = $(v).find("td:eq(3)").html();
                            if (two != three) {
                                $(v).css("background-color", "lightgray");
                            }
                        });
                    }, 500);
                },
            });
        }
    });
}

function BindDropDown(url) {
    if (sessionStorage.getItem('sessionn') == '3')
        BindOnlyCurrentCustomer();
    else
        Common.Ajax('GET', url, {}, 'json', BindDropDownHandler);
}

function BindOnlyCurrentCustomer() {
    var s = '<option value="-1">Please Select a Customer</option>';
    var CustomerCode = sessionStorage.getItem('sessionName');
    s += '<option value="' + sessionStorage.getItem('sessionName') + '">' + CustomerCode + '</option>';
    $("#drpCustomer").html(s);
}

function BindDropDownHandler(response) {
    var s = '<option value="-1">Please Select a Customer</option>';
    for (var i = 0; i < response.length; i++) {

        if (response[i].Name1 == '') continue;

        var CustomerName = isNaN(parseInt(response[i].Customer)) ? response[i].Name1 : response[i].Name1 + ' (' + parseInt(response[i].Customer) + ')';
        s += '<option value="' + response[i].Customer + '">' + CustomerName + '</option>';
    }
    $("#drpCustomer").html(s);
}