/// <reference path="GenericAjax.js" />
$(document).ready(function () {
    BindClaimOrderrefDropDown('GetAllClaimRefRecord');

    $('#bttnClaimOrder').click(function () {
        saveClaim2('CreateClaim');
    });

    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });
    $('#drpOrderRefrence').change(function () {
        $('#ClaimOrdersList').dataTable().fnDestroy();
        var ClaimorderID = $('#drpOrderRefrence').val();
        var ClaimRefNum = $('#drpOrderRefrence option:selected').text();
        $.ajax({
            type: "POST",
            url: "GetAllClaimRecord" ,
            data: { refrence: ClaimorderID, ClaimRefNum: ClaimRefNum },
            datatype: "json",
            //traditional: true,

            success: function (data) {
                //console.log(data);
                $("#ClaimOrdersList").DataTable({
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
                        //{ "data": "refrence", "class": "refrence", "name": "refrence", "autoWidth": true },
                        { "data": "materialCode", "class": "materialCode", "name": "materialCode", "autoWidth": true },
                        { "data": "materialDescription", "class": "materialDescription", "name": "materialDescription", "autoWidth": true },
                        
                        { "data": "day", "class": "day", "name": "day", "autoWidth": true },
                        { "data": "orderQuantity", "class": "orderQuantity", "name": "orderQuantity", "autoWidth": true },
                        { "data": "recievedQuantity", "class": "recievedQuantity", "name": "recievedQuantity", "autoWidth": true },
                        { "data": "Damaged", "class": "Damaged", "name": "Damaged", "autoWidth": true },
                        { "data": "Expired", "class": "Expired", "name": "Expired", "autoWidth": true },
                        { "data": "Short", "class": "Short", "name": "Short", "autoWidth": true },
                        { "data": "TotalClaimed", "class": "TotalClaimed", "name": "TotalClaimed", "autoWidth": true },
                        { "data": "unitPrice", "class": "unitPrice", "name": "unitPrice", "autoWidth": true },
                        { "data": "ClaimValue", "class": "ClaimValue", "name": "ClaimValue", "autoWidth": true },
                        { "data": "ClaimComment", "class": "ClaimComment", "name": "ClaimComment", "autoWidth": true },
                        { "data": "filepath", render: function (filepath) { if (filepath == null || filepath == 'null' || filepath == '' || typeof filepath == "undefined") { return 'No files attached'; } else { return '<a href="' + filepath + '" download>Download Attachment</a>'; } } },
                        //{ "data": "filepath", render: function (filepath) { return '<a href="' + filepath + '" download>Download Attachment</a>'; } },
                        { "data": "newApproved", "class": "newApproved", "name": "newApproved", "autoWidth": true, "visible": false },
                        { "data": "Status", "class": "Status", "name": "Status", "autoWidth": true, "visible": true },
                    ],
                    footerCallback: function (tfoot, data, start, end, display) {
                        var api = this.api();
                        //$(api.column(2).footer()).html('Total price = ' +
                        //    api.column(2).data().reduce(function (a, b) {
                        //        return a + b;
                        //    }, 0),

                            $(api.column(3).footer()).html('Total Ordered Quantity = ' +
                                api.column(3).data().reduce(function (a, b) {
                                    return a + b;
                                }, 0),
                             
                            $(api.column(4).footer()).html('Total Received Quantity = ' +
                                api.column(4).data().reduce(function (a, b) {
                                    return a + b;
                                }, 0),
                            ),
                            $(api.column(5).footer()).html('Total Damaged Quantity = ' +
                                api.column(5).data().reduce(function (a, b) {
                                    return a + b;
                                }, 0),
                            ),
                            $(api.column(6).footer()).html('Total Expired Quantity = ' +
                                api.column(6).data().reduce(function (a, b) {
                                    return a + b;
                                }, 0),
                            ),
                            $(api.column(7).footer()).html('Total Short Quantity = ' +
                                api.column(7).data().reduce(function (a, b) {
                                    return a + b;
                                }, 0),
                            ),

                            $(api.column(8).footer()).html('Total Claimed Quantity = ' +
                                api.column(8).data().reduce(function (a, b) {
                                    return a + b;
                                }, 0),
                            ),
                        );
                    },

                });

            }
        });





    });

});

function BindClaimOrderrefDropDown(url) {
    Common.Ajax('GET', url, {}, 'json', BindClaimOrderrefDropDownHandler);
}

function BindClaimOrderrefDropDownHandler(response) {
    var s = '<option value="-1">Select Billing Number</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].BillingId + '">' + response[i].BillingNo + '</option>';
    }
    $("#drpOrderRefrence").html(s);
}
