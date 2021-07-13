/// <reference path="GenericAjax.js" />

$(document).ready(function () {
    BindDropDown('getAllCustomer');

    $('#bttnADDApproval').click(function () {
        saveData('AddAppRoval');
    });


    $('#bttnReject').click(function () {
        RejectData('RejectAppRoval');
    });


    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });
    $('#drpRefrenceCode').change(function () {
        $('#AllApprovalRecords').dataTable().fnDestroy();
        var orderID = $('#drpRefrenceCode').val();

        $.ajax({
            type: "GET",
            url: "GetAllSpecialOrderRecords?OrderID=" + orderID,
            data: { OrderID: orderID },
            datatype: "json",
            //traditional: true,

            success: function (data) {
                $("#AllApprovalRecords").DataTable({
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
                        { "data": "SalesOrganization", "class": "SalesOrganization", "name": "SalesOrganization", "autoWidth": true, "visible": false },
                        { "data": "Quantity", "class": "Quantity", "name": "Quantity", "autoWidth": true },
                        { "data": "Aproved", "class": "Aproved", "name": "Aproved", "autoWidth": true, "visible": false },
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
                    },

                });

            }
        });





    });




    $('#drpCustomer').change(function () {
        var orderID = $('#drpCustomer').val();

        if (orderID == -1) {
            $('#drpRefrenceCode').val(-1);
        }
        else {
            $.ajax({
                type: "get",
                url: "getAllRefrenceCode_Approval?customerCode=" + orderID,
                data: { customerCode: orderID },
                datatype: "json",
                traditional: true,
                success: function (data) {
                    var s1 = '<option value="-1">Select a Reference Number</option>';
                    for (var i = 0; i < data.length; i++) {
                        s1 += '<option value="' + data[i].SP_Order_ID + '">' + data[i].SP_Order_ID + '</option>';
                    }
                    $("#drpRefrenceCode").html(s1);
                }
            });
        }
    });
});

function saveData(url) {
    Common.toggleSubmitRequest(true);
    var DataToPost = '{"CustomerCode":"' + $("#drpCustomer").val() + '", "refrenceCode":"' + $("#drpRefrenceCode").val() + '","Aproved":"0"}';

    if ($("#drpRefrenceCode").val() == -1) {
        alert('Please Select Reference Code')
    }
    else {
        Common.Ajax('POST', url, DataToPost, 'json', successSpApprovalCreateHandler);
    }
}

function RejectData(url) {
    Common.toggleSubmitRequest(true);

    var roleCheck = $("#txtAproved").val();
    var DataToPost = '{"CustomerCode":"' + $("#drpCustomer").val() + '", "refrenceCode":"' + $("#drpRefrenceCode").val() + '","Aproved":"' + $("#txtAproved").val() + '"}';

    if ($("#drpRefrenceCode").val() == -1) {
        alert('Please Select Reference Code')
    }
    else {
        Common.Ajax('POST', url, DataToPost, 'json', successSpApprovalCreateHandler);
    }
}

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
        $('#drpRefrenceCode').val('');

        $('#OperationDone').show('fade');
        setTimeout(function () {
            $('#OperationDone').hide('fade');
        }, 5000);
        $("#AllApprovalRecords").DataTable().clear().draw();
    }
    else if (response == '-1') {
        $('#AlreadyApproved').show('fade');
        setTimeout(function () {
            $('#AlreadyApproved').hide('fade');
        }, 5000);

        $("#AllApprovalRecords").DataTable().clear().draw();
    }
    else if (response == '1') {
        $('#OperationDone').show('fade');
        ResetDropDowns();
        setTimeout(function () {
            $('#OperationDone').hide('fade');
        }, 5000);
        $("#AllApprovalRecords").DataTable().clear().draw();
    }
    else if (response == '-2') {
        $('#RejectDone').show('fade');
        ResetDropDowns();
        setTimeout(function () {
            $('#RejectDone').hide('fade');
        }, 5000);
        $("#AllApprovalRecords").DataTable().clear().draw();
    }
    else if (response == '-3') {
        $('#OperationUnsuccedful').show('fade');
        setTimeout(function () {
            $('#OperationUnsuccedful').hide('fade');
        }, 5000);
        $("#AllApprovalRecords").DataTable().clear().draw();
    }

    Common.toggleSubmitRequest(false);
}

function ResetDropDowns() {
    BindDropDown('getAllCustomer');
    $("#drpRefrenceCode").html('<option value="-1">Select a Reference Number</option>');
}