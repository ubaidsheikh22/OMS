/// <reference path="GenericAjax.js" />

$(document).ready(function () {
    BindDropDown('getAllCustomer');

    $('#bttnADDApproval').click(function () {
        saveData('AddAppRoval');
    });


    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });
    $('#bttnReject').click(function () {
        RejectData('RejectAppRoval');
    });

    $('#drpCustomer').change(function () {
        var orderID = $('#drpCustomer').val();
        console.log(orderID);

        if (orderID == -1) {

            $('#drpRefrenceCode').val(-1);

            //   $('#drpRefrenceCode').DataTable().ajax.reload();
        }
        else {
            // $('#txtDistributorID').html('');
            $.ajax({
                type: "get",
                url: "getAllClaimRefrenceCode?customerCode=" + orderID,
                data: { customerCode: orderID },
                datatype: "json",
                traditional: true,
                success: function (data) {
                    var s1 = '<option value="-1">Select a Refrence Number</option>';
                    for (var i = 0; i < data.length; i++) {
                        s1 += '<option value="' + data[i].BillingId + '">' + data[i].BillingNo + '</option>';
                        console.log(s1);
                    }
                    $("#drpRefrenceCode").html(s1);
                }


            });
        }
    });


    $('#drpRefrenceCode').change(function () {
        $('#ClaimOrdersList').dataTable().fnDestroy();
        var ClaimID = $('#drpRefrenceCode').val();
        var ClaimRef = $('#drpRefrenceCode option:selected').text();
        $.ajax({
            type: "POST",
            url: "GetAllClaimRecords",
            data: { ClaimID: ClaimID, ClaimRef:ClaimRef },
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
                        { "data": "Material", "class": "Material", "name": "Material", "autoWidth": true },
                        { "data": "Description", "class": "Description", "name": "Description", "autoWidth": true },
                        { "data": "ClaimDay", "class": "ClaimDay", "name": "ClaimDay", "autoWidth": true },
                        { "data": "orderQty", "class": "orderQty", "name": "orderQty", "autoWidth": true },
                        { "data": "recievedQty", "class": "recievedQty", "name": "recievedQty", "autoWidth": true },
                        { "data": "damagedQty", "class": "damagedQty", "name": "damagedQty", "autoWidth": true },
                        { "data": "expiredQty", "class": "expiredQty", "name": "expiredQty", "autoWidth": true },
                        { "data": "shortQty", "class": "shortQty", "name": "shortQty", "autoWidth": true },
                        { "data": "TotalClaimed", "class": "TotalClaimed", "name": "TotalClaimed", "autoWidth": true },
                        { "data": "unitPrice", "class": "unitPrice", "name": "unitPrice", "autoWidth": true },
                        { "data": "ClaimValue", "class": "ClaimValue", "name": "ClaimValue", "autoWidth": true },
                        { "data": "comments", "class": "comments", "name": "comments", "autoWidth": true },
                        { "data": "filepath", render: function (filepath) { if (filepath == null || filepath == 'null' || filepath == '' || typeof filepath == "undefined") { return 'No files attached'; } else { return '<a href="' + filepath + '" download>Download Attachment</a>'; } } },
                        { "data": "approved", "class": "approved", "name": "approved", "autoWidth": true, "visible": false },
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

function saveData(url) {
    
    var roleCheck = $("#txtAproved").val();
    var DataToPost = '{"CustomerCode":"' + $('#drpCustomer').val() + '", "refrenceCode":"' + $("#drpRefrenceCode").val() + '", "refrenceToMCL":"' + $('#drpRefrenceCode option:selected').text() + '"}';

    if ($("#drpRefrenceCode").val() == -1) {
        alert('Please Select Reference Code')
    }
    else {
        Common.Ajax('POST', url, DataToPost, 'json', successSpApprovalCreateHandler);
        location.reload();
        console.log(DataToPost);
    }
}

function RejectData(url) {
    var roleCheck = $("#txtAproved").val();
    var DataToPost = '{"CustomerCode":"' + $("#drpCustomer").val() + '", "refrenceCode":"' + $("#drpRefrenceCode").val() + '","Aproved":"' + $("#txtAproved").val() + '", "refrenceToMCL":"' + $('#drpRefrenceCode option:selected').text() + '"}';

    if ($("#drpRefrenceCode").val() == -1) {
        alert('Please Select Reference Code')
    }
    else {
        Common.Ajax('POST', url, DataToPost, 'json', successSpApprovalCreateHandler);
        location.reload();
        console.log(DataToPost);
    }
}



//multiselect searchable dropdown ends



function BindDropDown(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownHandler);
}

function BindDropDownHandler(response) {
    var s = '<option value="-1">Please Select a Customer</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Customer + '">' + response[i].Name1 + '  (' + response[i].Customer + ')</option>';
    }
    $("#drpCustomer").html(s);
}

function successSpApprovalCreateHandler(response) {

    if (response == '1') {
        // $('#drpRefrenceCode').DataTable().ajax.reload();
        $('#drpRefrenceCode').val('');

        $('#OperationDone').show('fade');
        setTimeout(function () {
            $('#OperationDone').hide('fade');
        }, 5000);
        $("#ClaimOrdersList").DataTable().clear().draw();
       
    }
    if (response == '-1') {
        $('#AlreadyApproved').show('fade');
        setTimeout(function () {
            $('#AlreadyApproved').hide('fade');
        }, 5000);

        //setTimeout(function () {
        //    $('#AlreadyApproved').hide('fade');
        //}, 5000);
        $("#ClaimOrdersList").DataTable().clear().draw();
       
    }
    //if (response == '1') {
    //    $('#OperationDone').show('fade');
    //    setTimeout(function () {
    //        $('#OperationDone').hide('fade');
    //    }, 5000);
    //}
    if (response == '-2') {
        $('#RejectDone').show('fade');
        setTimeout(function () {
            $('#RejectDone').hide('fade');
        }, 5000);
        $("#ClaimOrdersList").DataTable().clear().draw();
       
    }
    if (response == '-3') {
        $('#OperationUnsuccedful').show('fade');
        setTimeout(function () {
            $('#OperationUnsuccedful').hide('fade');
        }, 5000);
        $("#ClaimOrdersList").DataTable().clear().draw();
        
    }
}
