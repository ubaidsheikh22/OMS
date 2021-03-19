$(document).ready(function () {
    //BindDropDown('getAllCustomer');

    $("#list").dataTable();

    $('#btnGetOrders').click(function () {
        GetOrders();
    });
});

function GetOrders() {
    $('#list').dataTable().fnDestroy();
    // var Customer = $('#drpCustomer').val();
    var StartDate = $('#StartDate').val();
    var EndDate = $('#EndDate').val();

    $.ajax({
        type: "POST",
        url: "getAllReceivedStock",
        data: { StartDate: StartDate, EndDate: EndDate },
        datatype: "json",
        //traditional: true,

        success: function (data) {
            //console.log(data);
            $("#list").DataTable({
                "processing": true, // for show progress bar
                "serverSide": false, // for process server side
                "filter": true, // this is for disable filter (search box)
                "orderMulti": false, // for disable multiple column at once
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
                    { "data": "receivingdate", render: function (receivingDate) { return new Date(receivingDate).toLocaleString("en-GB"); } },
                    { "data": "BillingNo", "class": "BillingNo", "name": "BillingNo", "autoWidth": true },
                    { "data": "refrence", "class": "refrence", "name": "refrence", "autoWidth": true },
                    { "data": "Material", "class": "Material", "name": "Material", "autoWidth": true },
                    { "data": "Description", "class": "Description", "name": "Description", "autoWidth": true },
                    //{ "data": "unitPrice", "class": "unitPrice", "name": "unitPrice", "autoWidth": true },
                    //{ "data": "day", "class": "day", "name": "day", "autoWidth": true },
                    { "data": "orderQty", "class": "orderQty", "name": "orderQty", "autoWidth": true },
                    { "data": "recievedQty", "class": "recievedQty", "name": "recievedQty", "autoWidth": true },
                    { "data": "damagedQty", "class": "damagedQty", "name": "damagedQty", "autoWidth": true },
                    { "data": "expiredQty", "class": "expiredQty", "name": "expiredQty", "autoWidth": true },
                    { "data": "shortQty", "class": "shortQty", "name": "shortQty", "autoWidth": true },
                    { "data": "filepath", render: function (filepath) { if (filepath == null || filepath == 'null' || filepath == '' || typeof filepath == "undefined") { return 'No files attached';} else { return '<a href="' + filepath + '" download>Download Attachment</a>'; } } },
                    { "data": "ReceivingComments", "class": "ReceivingComments", "name": "ReceivingComments", "autoWidth": true },
                    //{ "data": "receivingdate", "class": "receivingdate", "name": "receivingdate", "autoWidth": true },
                    //{ "data": "newApproved", "class": "newApproved", "name": "newApproved", "autoWidth": true, "visible": false },
                    //{ "data": "Status", "class": "Status", "name": "Status", "autoWidth": true, "visible": true },
                ],
                //footerCallback: function (tfoot, data, start, end, display) {
                //    var api = this.api();
                //    $(api.column(2).footer()).html('Total price = ' +
                //        api.column(2).data().reduce(function (a, b) {
                //            return a + b;
                //        }, 0),
                //        $(api.column(4).footer()).html('Total Ordered Quantity = ' +
                //            api.column(4).data().reduce(function (a, b) {
                //                return a + b;
                //            }, 0),
                //        ),    // $(tfoot).find('th').eq(3).html("Total Quantity =")
                //        $(api.column(5).footer()).html('Total Received Quantity = ' +
                //            api.column(5).data().reduce(function (a, b) {
                //                return a + b;
                //            }, 0),
                //        ),
                //        $(api.column(6).footer()).html('Total Damaged Quantity = ' +
                //            api.column(6).data().reduce(function (a, b) {
                //                return a + b;
                //            }, 0),
                //        ),
                //        $(api.column(7).footer()).html('Total Expired Quantity = ' +
                //            api.column(7).data().reduce(function (a, b) {
                //                return a + b;
                //            }, 0),
                //        ),
                //        $(api.column(8).footer()).html('Total Short Quantity = ' +
                //            api.column(8).data().reduce(function (a, b) {
                //                return a + b;
                //            }, 0),
                //        ),

                //        $(api.column(9).footer()).html('Total Claimed Quantity = ' +
                //            api.column(9).data().reduce(function (a, b) {
                //                return a + b;
                //            }, 0),
                //        ),



                //    );
                //},

            });

        }
    });

}