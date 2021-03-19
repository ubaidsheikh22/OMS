$(document).ready(function () {
  
    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });
});
$.ajax({
    type: "POST",
    url: "Summary",
    data: { },
    datatype: "json",
    //traditional: true,
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
            "processing": false, // for show progress bar
            "serverSide": false, // for process server side
            "filter": true, // this is for disable filter (search box)
            "orderMulti": false, // for disable multiple column at once
            "data": data,
            "dataSrc": "",
            "deferRender": true,
            "columns": [
                  { "data": "CustomerName", "class": "CustomerName", "name": "CustomerName", "autoWidth": true },
                  { "data": "UnitPrice", "class": "UnitPrice", "name": "UnitPrice", "autoWidth": true },
                  { "data": "WeeklyQuantity", "class": "WeeklyQuantity", "name": "WeeklyQuantity", "autoWidth": true },
                  { "data": "WeeklyQuantityAmount", "class": "WeeklyQuantityAmount", "name": "WeeklyQuantityAmount", "autoWidth": true },
                  { "data": "FirmOrder", "class": "FirmOrder", "name": "FirmOrder", "autoWidth": true },
                  { "data": "FirmOrderAmount", "class": "FirmOrderAmount", "name": "FirmOrderAmount", "autoWidth": true },
                  { "data": "SpecialQuanity", "class": "SpecialQuanity", "name": "SpecialQuanity", "autoWidth": true, "visible": true },
                  { "data": "SpecialQuanityAmount", "class": "SpecialQuanityAmount", "name": "SpecialQuanityAmount", "autoWidth": true, "visible": true },
                  { "data": "TotalPayable", "class": "TotalPayable", "name": "TotalPayable", "autoWidth": true, "visible": true },




            ],
            footerCallback: function (tfoot, data, start, end, display) {


                var api = this.api();
                $(api.column(2).footer()).html('Total Suggested Quantity = ' +
                                api.column(2).data().reduce(function (a, b) {
                                    return a + b;
                                }, 0)
                                  // $(tfoot).find('th').eq(2).html("Suggested Quantity")
                        ),
                                        $(api.column(3).footer()).html('Suggested Quantity Amount= ' +
                                            api.column(3).data().reduce(function (a, b) {
                                                return a + b;
                                            }, 0),
                                              $(api.column(4).footer()).html('Total Firm Quantity = ' +
                                            api.column(4).data().reduce(function (a, b) {
                                                return a + b;
                                            }, 0)
                                    ),
                                             $(api.column(5).footer()).html('Total Firm Amount = ' +
                                            api.column(5).data().reduce(function (a, b) {
                                                return a + b;
                                            }, 0)
                                    ),

                                              $(api.column(6).footer()).html('Total Special Order Quantity = ' +
                                            api.column(6).data().reduce(function (a, b) {
                                                return a + b;
                                            }, 0)
                                    ),
                                             $(api.column(7).footer()).html('Total Special Order Amount = ' +
                                            api.column(7).data().reduce(function (a, b) {
                                                return a + b;
                                            }, 0)
                                    ),
                                            $(api.column(8).footer()).html('Total Payable Amount = ' +
                                            api.column(8).data().reduce(function (a, b) {
                                                return a + b;
                                            }, 0)
                                    )

                                    );

            },

        });

    }
});

