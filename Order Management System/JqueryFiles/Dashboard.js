/// <reference path="GenericAjax.js" />

$(document).ready(function () {

        $.ajax({
            type: "GET",
            url: "GetAllDashboardRecord",
           // data: { TotalOrder},
            contentType: "application/json;charset=utf-8",
            //dataType: "json",
            //success: function (result) {
            //    //
            //   // alert(result)
            //    $('#totalquantity').val(result.TotalOrder);
            //    //$('#EmployeeDesignation').val(response.Designation);
            //    //$('#EmployeeLocation').val(response.Location);
            //},
            //error: function (response) {
            //    
            //    alert('eror');
            //}

            dataType: "json",
            success: function (response) {
                if (response != null) {
                    //$('#totalquantity').val(response[0].TotalOrder);
                    //$('#TotalQuantity').val(response[0].TotalQuantity);
                    //$('#TotalFirmOrder').val(response[0].TotalFirmOrder);
                    //$('#totalquantity').text(response[0].TotalFirmOrder);

                    //$('#totalquantity').data(response[0]).text();

                    //$('#totalquantity123').data('data-to', response[0].TotalOrder);
                    //console.log(response);
                    $('#totalSugessted').text(Number(response.Suggested[0].TotalQuantity));
                    $('#totalquantity123').text(Number(response.Special[0].SpeacialValue));
                    $('#TotalFirmOrder').text(Number(response.Accepted[0].FirOrderValue));
                    //$('#totalquantity').text(response[0].TotalQuantity);
                    //$('#TotalFirmOrder').text(response[0].TotalFirmOrder);

                    //var div = $('#totalquantity123');
                    //div.attr('data-from', 0);
                    //div.attr('data-to', response[0].TotalOrder);
                    //div.attr('data-speed', 15);
                    //div.attr('data-fresh-interval', 20);
                    //console.log(div.attr('data-to'));
                   // $("#totalquantity123").attr("data-to", response[0].TotalOrder);
                   
                    //$('#EmployeeDesignation').val(response.Designation);
                    //$('#EmployeeLocation').val(response.Location);
                } else {
                    alert("Something went wrong");
                }
            }
        });


        $("#Regions").DataTable({
            "ajax": {
                "url": "TotalRegion",
                "type": "GET",
                "datatype": "json",

                "processing": false, // for show progress bar
                "serverSide": false, // for process server side
                "filter": true, // this is for disable filter (search box)
                "orderMulti": true, // for disable multiple column at once
                "dataSrc": "",

            },


            "columns": [
                    { "data": "RegionDescription", "name": "RegionDescription", "class": "RegionDescription", "autoWidth": true },
                    { "data": "NoOfOrders", "name": "NoOfOrders", "class": "NoOfOrders", "autoWidth": true },
                    { "data": "OrderValues", "name": "OrderValues", "autoWidth": true, "OrderValues": false },
            ],
            footerCallback: function (tfoot, data, start, end, display) {
                var api = this.api();

                $(api.column(1).footer()).html('Total Order Generated = ' +
             api.column(1).data().reduce(function (a, b) {
                 return a + b;
             }, 0)

                    );
                $(api.column(2).footer()).html('Total Order Values Rs = ' +
                   api.column(2).data().reduce(function (a, b) {
                       return a + b;
                   }, 0)
                   );

            },
        });

        $("#Entity").DataTable({
            "ajax": {
                "url": "TotalOrdersalesorg",
                "type": "GET",
                "datatype": "json",

                "processing": false, // for show progress bar
                "serverSide": false, // for process server side
                "filter": true, // this is for disable filter (search box)
                "orderMulti": true, // for disable multiple column at once
                "dataSrc": "",

            },


            "columns": [
                    { "data": "Division", "name": "Division", "class": "Division", "autoWidth": true },
                    { "data": "NoOfOrders", "name": "NoOfOrders", "class": "NoOfOrders", "autoWidth": true },
                    { "data": "OrderValues", "name": "OrderValues", "autoWidth": true, "OrderValues": false },
            ],
            footerCallback: function (tfoot, data, start, end, display) {
                var api = this.api();

                $(api.column(1).footer()).html('Total Order Generated = ' +
             api.column(1).data().reduce(function (a, b) {
                 return a + b;
             }, 0)

                    );
                $(api.column(2).footer()).html('Total Order Values Rs = ' +
                   api.column(2).data().reduce(function (a, b) {
                       return a + b;
                   }, 0)
                   );

            },
        });

        $("#Product_Type").DataTable({
            "ajax": {
                "url": "TotalOrderProductType",
                "type": "GET",
                "datatype": "json",

                "processing": false, // for show progress bar
                "serverSide": false, // for process server side
                "filter": true, // this is for disable filter (search box)
                "orderMulti": true, // for disable multiple column at once
                "dataSrc": "",

            },


            "columns": [
                    { "data": "Salesorg", "name": "Salesorg", "class": "Salesorg", "autoWidth": true },
                    { "data": "NoOfOrders", "name": "NoOfOrders", "class": "NoOfOrders", "autoWidth": true },
                    { "data": "OrderValues", "name": "OrderValues", "autoWidth": true, "OrderValues": false },
            ],
            footerCallback: function (tfoot, data, start, end, display) {
                var api = this.api();

                $(api.column(1).footer()).html('Total Order Generated = ' +
             api.column(1).data().reduce(function (a, b) {
                 return a + b;
             }, 0)

                    );
                $(api.column(2).footer()).html('Total Order Values Rs = ' +
                   api.column(2).data().reduce(function (a, b) {
                       return a + b;
                   }, 0)
                   );

            },
        });


        $("#Dashboardcso").DataTable({
            "ajax": {
                "url": "GetDashboardforView",
                "type": "GET",
                "datatype": "json",

                "processing": false, // for show progress bar
                "serverSide": false, // for process server side
                "filter": false, // this is for disable filter (search box)
                "orderMulti": false, // for disable multiple column at once
                "pagging" : false,
                "dataSrc": "",

            },


            "columns": [
                    { "data": "SuggestedOrder", "name": "SuggestedOrder", "class": "SuggestedOrder", "autoWidth": true },
                    { "data": "suggestedValue", "name": "suggestedValue", "class": "suggestedValue", "autoWidth": true },
                    { "data": "TotalFirmOrder", "name": "TotalFirmOrder", "class": "TotalFirmOrder", "autoWidth": true, },
                        { "data": "FirOrderValue", "name": "FirOrderValue", "class": "FirOrderValue", "autoWidth": true },
                    { "data": "InTransactionQty", "name": "InTransactionQty", "class": "InTransactionQty", "autoWidth": true },
                    { "data": "InTransactionQtyValue", "name": "InTransactionQtyValue", "class": "InTransactionQtyValue", "autoWidth": true, },
                        { "data": "PendingQty", "name": "PendingQty", "class": "PendingQty", "autoWidth": true },
                    { "data": "PendingQtyValue", "name": "PendingQtyValue", "class": "PendingQtyValue", "autoWidth": true },
                    { "data": "SpeacialQty", "name": "SpeacialQty", "class": "SpeacialQty", "autoWidth": true, },
                    { "data": "SpeacialValue", "name": "SpeacialValue", "class": "SpeacialValue", "autoWidth": true, },

            ],
            //footerCallback: function (tfoot, data, start, end, display) {
            //    var api = this.api();

            //    $(api.column(1).footer()).html('Total Order Generated = ' +
            // api.column(1).data().reduce(function (a, b) {
            //     return a + b;
            // }, 0)

            //        );
            //    $(api.column(2).footer()).html('Total Order Values Rs = ' +
            //       api.column(2).data().reduce(function (a, b) {
            //           return a + b;
            //       }, 0)
            //       );

            //},
        });

        //$("#Dashboardcsoorder").DataTable({
        //    "ajax": {
        //        "url": "GetDashboardOrderQTY",
        //        "type": "GET",
        //        "datatype": "json",

        //        "processing": false, // for show progress bar
        //        "serverSide": false, // for process server side
        //        "filter": false, // this is for disable filter (search box)
        //        "orderMulti": false, // for disable multiple column at once
        //        "pagging": false,
        //        "dataSrc": "",

        //    },


        //    "columns": [
        //         { "data": "OrderDescription", "name": "OrderDescription", "class": "OrderDescription", "autoWidth": true },
        //        { "data": "SuggestedOrder", "name": "SuggestedOrder", "class": "SuggestedOrder", "autoWidth": true },
        //            //{ "data": "suggestedValue", "name": "suggestedValue", "class": "suggestedValue", "autoWidth": true },
        //            { "data": "TotalFirmOrder", "name": "TotalFirmOrder", "class": "TotalFirmOrder", "autoWidth": true, },
        //                //{ "data": "FirOrderValue", "name": "FirOrderValue", "class": "FirOrderValue", "autoWidth": true },
        //            { "data": "InTransactionQty", "name": "InTransactionQty", "class": "InTransactionQty", "autoWidth": true },
        //            //{ "data": "InTransactionQtyValue", "name": "InTransactionQtyValue", "class": "InTransactionQtyValue", "autoWidth": true, },
        //                { "data": "PendingQty", "name": "PendingQty", "class": "PendingQty", "autoWidth": true },
        //            //{ "data": "PendingQtyValue", "name": "PendingQtyValue", "class": "PendingQtyValue", "autoWidth": true },
        //            { "data": "SpeacialQty", "name": "SpeacialQty", "class": "SpeacialQty", "autoWidth": true, },
        //            //{ "data": "SpeacialValue", "name": "SpeacialValue", "class": "SpeacialValue", "autoWidth": true, },

        //    ],
        //    //footerCallback: function (tfoot, data, start, end, display) {
        //    //    var api = this.api();

        //    //    $(api.column(1).footer()).html('Total Order Generated = ' +
        //    // api.column(1).data().reduce(function (a, b) {
        //    //     return a + b;
        //    // }, 0)

        //    //        );
        //    //    $(api.column(2).footer()).html('Total Order Values Rs = ' +
        //    //       api.column(2).data().reduce(function (a, b) {
        //    //           return a + b;
        //    //       }, 0)
        //    //       );

        //    //},
        //});

        //$("#DashboardcsoorderValues").DataTable({
        //    "ajax": {
        //        "url": "GetDashboardOrderQTYValues",
        //        "type": "GET",
        //        "datatype": "json",

        //        "processing": false, // for show progress bar
        //        "serverSide": false, // for process server side
        //        "filter": false, // this is for disable filter (search box)
        //        "orderMulti": false, // for disable multiple column at once
        //        "pagging": false,
        //        "dataSrc": "",

        //    },


        //    "columns": [
        //         { "data": "OrderDescription", "name": "OrderDescription", "class": "OrderDescription", "autoWidth": true },
        //        //{ "data": "SuggestedOrder", "name": "SuggestedOrder", "class": "SuggestedOrder", "autoWidth": true },
        //            { "data": "PendingQty", "name": "PendingQty", "class": "PendingQty", "autoWidth": true },
        //            //{ "data": "TotalFirmOrder", "name": "TotalFirmOrder", "class": "TotalFirmOrder", "autoWidth": true, },
        //                { "data": "FirOrderValue", "name": "FirOrderValue", "class": "FirOrderValue", "autoWidth": true },
        //            //{ "data": "InTransactionQty", "name": "InTransactionQty", "class": "InTransactionQty", "autoWidth": true },
        //            { "data": "InTransactionQtyValue", "name": "InTransactionQtyValue", "class": "InTransactionQtyValue", "autoWidth": true, },
        //                //{ "data": "PendingQty", "name": "PendingQty", "class": "PendingQty", "autoWidth": true },
        //            { "data": "PendingQtyValue", "name": "PendingQtyValue", "class": "PendingQtyValue", "autoWidth": true },
        //            //{ "data": "SpeacialQty", "name": "SpeacialQty", "class": "SpeacialQty", "autoWidth": true, },
        //            { "data": "SpeacialValue", "name": "SpeacialValue", "class": "SpeacialValue", "autoWidth": true, },

        //    ],
        //    //footerCallback: function (tfoot, data, start, end, display) {
        //    //    var api = this.api();

        //    //    $(api.column(1).footer()).html('Total Order Generated = ' +
        //    // api.column(1).data().reduce(function (a, b) {
        //    //     return a + b;
        //    // }, 0)

        //    //        );
        //    //    $(api.column(2).footer()).html('Total Order Values Rs = ' +
        //    //       api.column(2).data().reduce(function (a, b) {
        //    //           return a + b;
        //    //       }, 0)
        //    //       );

        //    //},
        //});
});




//function successUserLoginHandler(reponse) {

//    if (reponse == '1') {
//        $('#successAlert').show('fade');

//        setTimeout(function () {
//            $('#warningAlert').hide('fade');
//        }, 5000);
//        alert('already have');
//    }
//}