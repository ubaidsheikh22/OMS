/// <reference path="GenericAjax.js" />

$(document).ready(function () {
    BindDropDown('getAllCustomer');


    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });
    $('#drpRefrenceCode').change(function () {
        $('#AllApprovalRecords').dataTable().fnDestroy();
        var orderID = $('#drpRefrenceCode').val();
        // $('#drpRefrenceCode').DataTable().ajax.reload();

        //if (('#drpCustomer').val() == -1)
        //{
        //    orderID = -1;
        //}


        $.ajax({
            type: "GET",
            url: "GetAllSpecialOrderRecords?OrderID=" + orderID,
            data: { OrderID: orderID },
            datatype: "json",
            //traditional: true,

            success: function (data) {
                //console.log(data);
                $("#AllApprovalRecords").DataTable({
                    "processing": false, // for show progress bar
                    "serverSide": false, // for process server side
                    "filter": true, // this is for disable filter (search box)
                    "orderMulti": false, // for disable multiple column at once
                    "data": data,
                    "dataSrc": "",
                    "deferRender": true,
                    "columns": [
                          { "data": "Material", "class": "Material", "name": "Material", "autoWidth": true },
                          { "data": "Description", "class": "Description", "name": "Description", "autoWidth": true },
                          { "data": "SalesOrganization", "class": "SalesOrganization", "name": "SalesOrganization", "autoWidth": true },
                          { "data": "Quantity", "class": "Quantity", "name": "Quantity", "autoWidth": true },
                          { "data": "Aproved", "class": "Aproved", "name": "Aproved", "autoWidth": true, "visible": false },


                {
                    "render": function (data, type, row) {




                        var app = row.Aproved;
                        switch (app) {
                            case 'false':
                                return "Rejected";
                                break;
                            case '0':
                                return "Pending";
                                break;
                            case '1':
                                return "Approved by TM";
                                break;
                            case '2':
                                return "Approved by AM";
                                break;
                            case '3':
                                return "Approved by CSO";
                                break;
                            default:
                                //alert('oyee');
                        }


                        //if (row.Aproved === "") {
                        //    return "NOT Approved";
                        //}
                        //i (row.Aproved === 1)
                        //{
                        //    return "Approved by TM"; // "Approved by TM";
                        //}
                        //if (row.Aproved === 2) {
                        //    return "Approved by AM";
                        //}
                        //if (row.Aproved === 3) {
                        //    return "Approved by CSO";
                        //}
                        //else {

                        //}
                    }


                }

                    ]

                });

            }
        });
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
                url: "getAllRefrenceCode?customerCode=" + orderID,
                data: { customerCode: orderID },
                datatype: "json",
                traditional: true,
                success: function (data) {
                    var s1 = '<option value="-1">Select a Refrence Number</option>';
                    for (var i = 0; i < data.length; i++) {
                        s1 += '<option value="' + data[i].SP_Order_ID + '">' + data[i].SP_Order_ID + '</option>';
                        console.log(s1);
                    }
                    $("#drpRefrenceCode").html(s1);
                }


            });
        }
    });

    //$("#AllApprovalRecords").dataTable().fnDestroy();
});



function saveData(url) {

    var DataToPost = '{"refrenceCode":"' + $("#drpRefrenceCode").val() + '"}';

    if ($("#drpRefrenceCode").val() == -1) {
        alert('Please Select Reference Code')
    }
    else {
        Common.Ajax('POST', url, DataToPost, 'json', successSpApprovalCreateHandler);
        console.log(DataToPost);
    }
}

function RejectData(url) {

    var DataToPost = '{"refrenceCode":"' + $("#drpRefrenceCode").val() + '"}';

    if ($("#drpRefrenceCode").val() == -1) {
        alert('Please Select Reference Code')
    }
    else {
        Common.Ajax('POST', url, DataToPost, 'json', successSpApprovalCreateHandler);
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
        s += '<option value="' + response[i].Customer + '">' + response[i].Name1 + '</option>';
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
    }
    if (response == '-1') {
        $('#warningAlert').show('fade');
        setTimeout(function () {
            $('#warningAlert').hide('fade');
        }, 5000);

        setTimeout(function () {
            $('#warningAlert').hide('fade');
        }, 5000);
    }
}
