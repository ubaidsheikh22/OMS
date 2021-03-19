/// <reference path="GenericAjax.js" />
$(document).ready(function () {
    //BindOrderrefDropDown('GetAllpendingOrderRefRecord');
    BindOrderrefDropDown('GetAllpendingByBillingNo');

    $('#bttnClaimOrder').click(function () {
        //if ($('#txtcomments').val() == "") {
        //    //alert($("#txtcomments").val());
        //    alert("Enter Comments");
        //    return false;
        //}
        //else
        saveClaim2('CreateClaim');
    });



    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });

   // $('#bttnClaimOrder').prop('disabled', true);
    $("#FileUpload").change(function () {

        // Get uploaded file extension
        var extension = $(this).val().split('.').pop().toLowerCase();
        // Create array with the files extensions that we wish to upload
        var validFileExtensions = ['jpg', 'png', 'jpeg', 'pdf', 'zip', 'bitmap'];
        //Check file extension in the array.if -1 that means the file extension is not in the list.
        if ($.inArray(extension, validFileExtensions) == -1) {
            alert("Sorry!! Upload only 'jpg', 'png', 'jpeg', 'pdf', 'zip', 'bitmap' file")
            // Clear fileuload control selected file
            $(this).replaceWith($(this).val('').clone(true));
            //Disable Submit Button
            $('#bttnClaimOrder').prop('disabled', true);
        }
        else {
            // Check and restrict the file size to 128 KB.
            if ($(this).get(0).files[0].size > (1310726)) {
                alert("Sorry!! Max allowed file size is 128 kb");
                // Clear fileuload control selected file
                $(this).replaceWith($(this).val('').clone(true));
                //Disable Submit Button
                $('#bttnClaimOrder').prop('disabled', true);
            }
            else {
                //Enable Submit Button
                $('#bttnClaimOrder').prop('disabled', false);
            }
        }
    });




    $('#drpOrderRefrence').change(function () {
        $('#ClaimOrdersList').dataTable().fnDestroy();
        var orderID = $('#drpOrderRefrence').val();
        $.ajax({
            type: "POST",
            url: "GetAllpendingRecord?refrence=" + orderID,
            data: { refrence: orderID },
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
                             { "data": "refrence", "class": "refrence", "name": "refrence", "autoWidth": true },
                             { "data": "Material", "class": "Material", "name": "Material", "autoWidth": true },
                             { "data": "Description", "class": "Description", "name": "Description", "autoWidth": true },
                             { "data": "unitPrice", "class": "unitPrice", "name": "unitPrice", "autoWidth": true },
                             { "data": "ClaimDay", "class": "ClaimDay", "name": "ClaimDay", "autoWidth": true },
                             { "data": "orderQty", "class": "orderQty", "name": "orderQty", "autoWidth": true },
                             { "data": "recievedQty", "class": "recievedQty", "name": "recievedQty", "autoWidth": true },
                             { "data": "damagedQty", "class": "damaged", "name": "damaged", "autoWidth": true },
                             { "data": "expiredQty", "class": "expired", "name": "expired", "autoWidth": true },
                             { "data": "shortQty", "class": "short", "name": "short", "autoWidth": true },
                        { "data": "TotalClaimed", "class": "TotalClaimed", "name": "TotalClaimed", "autoWidth": true },
                        { "data": "ReceivingComments", "class": "ReceivingComments", "name": "ReceivingComments", "autoWidth": true },
                            //{
                            //     "render": function (data, type, row) {
                            //         return '<textarea class="comments btn-group bootstrap-select form-control show-tick" name="comments" id="txtcomments"/>';
                            //         //<input type="text" class="comments btn-group bootstrap-select form-control show-tick" name="comments" id="txtcomments" value="" />
                            //         //<textarea class="comments btn-group bootstrap-select form-control show-tick" name="comments" id="txtcomments"/>
                            //     },
                             //}

                    ]

                });

            }
        });





    });

});

function saveClaim2(url) {
    if (window.FormData !== undefined) {
    var fileUpload = "";
    hasFile = false;
    
        fileUpload = $("#FileUpload").get(0);
   
            hasFile = true;
          
        
    

    //if no file found, alert error

    var files = fileUpload.files;
    // Create FormData object  
    var fileData = new FormData();

    // Looping over all files and add it to FormData object  
    for (var i = 0; i < files.length; i++) {
        fileData.append(files[i].name, files[i]);
    }
        // Adding one more key to FormData object  
       // fileData.append('username', 'Manas');
        //$.ajax({
        //    url: '/ClaimPortal/UploadFiles',
        //                type: "POST",
        //                contentType: false, // Not to set any content header  
        //                processData: false, // Not to process data  
        //                data: fileData,claim,
        //                success: function (result) {
        //                    alert(result);
        //                },
        //                error: function (err) {
        //                    alert(err.statusText);
        //                }
        //});
        $('#ClaimOrdersList').dataTable().fnDestroy();
        var ClaimOrders = new Array();
        $("#ClaimOrdersList TBODY TR").each(function () {
            var row = $(this);
            var pendingQuantities = {};

            pendingQuantities.Order_Ref = row.find("TD").eq(0).html();
            pendingQuantities.materialCode = row.find("TD").eq(1).html();
            pendingQuantities.materialDescription = row.find("TD").eq(2).html();
            //OrderModel.UnitPrice = row.find("TD").eq(3).html();
            pendingQuantities.unitPrice = row.find("TD").eq(3).html();
            pendingQuantities.day = row.find("TD").eq(4).html();
            pendingQuantities.orderQuantity = row.find("TD").eq(5).html();
            pendingQuantities.recievedQuantity = row.find("TD").eq(6).html();
            pendingQuantities.ClaimComment = row.find("TD").eq(11).html();
            pendingQuantities.BillingId = $('#drpOrderRefrence').val();
            ClaimOrders.push(pendingQuantities);
        });
        var dataToPost = JSON.stringify(ClaimOrders);
       // console.log(claim);
        Common.Ajax('POST', url, dataToPost, 'json', successOrderClaimCreateHandler);
        fileData.append('dataToPost', dataToPost);
        $.ajax({
            url: 'AddManualFile',
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: fileData,

            //success: successWeeklyUpliftCreateHandler(),
            //error: function (err) {
            //    alert(err.statusText);
            //}
        });




    } else {
        alert("FormData is not supported.");
    }
}


function BindOrderrefDropDown(url) {
    Common.Ajax('GET', url, {}, 'json', BindOrderrefDropDownHandler);
}

function BindOrderrefDropDownHandler(response) {
    var s = '<option value="-1">Select Bill Number</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].BillingId + '">' + response[i].BillingNo + '</option>';
    }
    $("#drpOrderRefrence").html(s);
}

function successOrderClaimCreateHandler(response) {

    if (response == '1') {
        $('#successAlert').show('fade');
        setTimeout(function () {
        $('#successAlert').hide('fade');
        }, 5000);

        location.reload(true);
    }
    if (response == '-1') {
        $('#warningAlert').show('fade');
        setTimeout(function () {
        $('#warningAlert').hide('fade');
        }, 5000);
    }
}