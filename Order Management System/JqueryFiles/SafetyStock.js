$(document).ready(function () {

    $("#FileUpload").click(function () {
        if ($("#Resume").val() != "") {
            var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.xlsx|.xls)$/;
            /*Checks whether the file is a valid excel file*/
            if (!regex.test($("#Resume").val().toLowerCase())) {
                alert("Please upload a valid Excel file!");
                return false;
            }
            else {
                UploadSelectedExcelsheet();
            }
        }
        else {
            alert("Please upload a Excel file!");
            return false;
        }
    });
    //$.get("Role/GetAllRoleRecord", null, DataBind);
    var table = $("#SafetyList").DataTable({
        //('.display').$("#SafetyList").DataTable({
        "ajax": {
            "url": "gridView",
            "type": "GET",
            "datatype": "application/json",
            "processing": true, // for show progress bar
            "serverSide": true, // for process server side
            "filter": true, // this is for disable filter (search box)
            "orderMulti": true, // for disable multiple column at once
            "dataSrc": "",
        },
        "columns": [
            { "data": "customer", "class": "customer", "name": "customer", "autoWidth": true },
            // { "data": "Role_ID", "class": "Role_ID", "name": "Role_ID", "autoWidth": true },
            { "data": "material", "class": "material", "name": "material", "autoWidth": true },
            { "data": "division", "class": "division", "name": "division", "autoWidth": true },
            // { "data": "Role_ID", "class": "Role_ID", "name": "Role_ID", "autoWidth": true },
            { "data": "salesOrg", "class": "salesOrg", "name": "salesOrg", "autoWidth": true },
            { "data": "distr_chan", "class": "distr_chan", "name": "distr_chan", "autoWidth": true },
            { "data": "region", "class": "region", "name": "region", "autoWidth": true },
            // { "data": "Role_ID", "class": "Role_ID", "name": "Role_ID", "autoWidth": true },
            { "data": "area", "class": "area", "name": "area", "autoWidth": true },
            { "data": "territory", "class": "territory", "name": "territory", "autoWidth": true },
            { "data": "town", "class": "town", "name": "town", "autoWidth": true },
            { "data": "quantity", "class": "quantity", "name": "quantity", "autoWidth": true },
            //{ "data": '<input type="number" "id":"quantity", "name": "quantity","class": "quantity"' },
            {
                "defaultContent": "<button id='click' class='btn btn-primary m-t-6 waves-effect'>Edit!</button>"
            }

        ]

    });


    $('#SafetyList tbody').on('click', 'button', function () {
        var data = table.row($(this).parents("tr")).data();
        var txtupdateCustomer = $(this).closest("tr").find(".customer").text();
        var txtupdateMaterial = $(this).closest("tr").find(".material").text();
        var txtupdateQuantity = $(this).closest("tr").find(".quantity").text();
        var txtupdatesalesOrg = $(this).closest("tr").find(".salesOrg").text();
        var txtupdatedistr_chan = $(this).closest("tr").find(".distr_chan").text();

        $("#largeModalStock").modal();
        $("#txtupdateQuantity").val(txtupdateQuantity);
        $("#txtupdateMaterial").val(txtupdateMaterial);
        $("#txtupdateCustomer").val(txtupdateCustomer);
        $("#txtupdatesalesOrg").val(txtupdatesalesOrg);
        $("#txtupdatedistr_chan").val(txtupdatedistr_chan);
        

    });

    $('#bttnUpdateStock').click(function () {
        if ($("#txtupdateQuantity").val().length <= 0) {
            alert("Quantity must be Required");
            $("#checkempty").empty();

            $("#checkempty").append("Quantity must be provide");
        }
        else {
            var qtyvalidate = $("#txtupdateQuantity").val();
            var regexp = /^[0-9]*$/;
            var numberCheck = regexp.exec(qtyvalidate);

            if (numberCheck == null) {
                alert("Enter Only Numbers");

            }
            else {
                update('updateStock');
            }
        }
       
    });

    function update(url) {
        var dataToPost = '{"material":"' + $("#txtupdateMaterial").val() + '","quantity":"' + $("#txtupdateQuantity").val() + '","customer":"' + $("#txtupdateCustomer").val() + '","salesOrg":"' + $("#txtupdatesalesOrg").val() + '","distr_chan":"' + $("#txtupdatedistr_chan").val() + '"}';

        Common.Ajax("POST", url, dataToPost, 'json', successQuantityUpdateHandler);
    }

    //  UploadSelectedImagesForPersonalisation();

    function UploadSelectedExcelsheet() {
        var SafetyStockModel = new FormData();
        var i = 0;
        var fl = $("#Resume").get(0).files[0];
       
        if (fl != undefined) {

            SafetyStockModel.append("file", fl);

        }
        var Url = '/SafetyStock/UploadExcelsheet';

        $.ajax({
            type: "POST",
            url: Url,
            contentType: false,
            processData: false,
            data: SafetyStockModel,
            success: function (result) {


                alert("sucess")
                //$("#Products").html(result);

                //$('.ddlRecipient').multiselect({
                //    includeSelectAllOption: true
                //});
                //$('.ddlOccasionmaster').multiselect({
                //    includeSelectAllOption: true
                //});

            },
            error: function (xhr, status, p3, p4) {
                var err = "Error " + " " + status + " " + p3 + " " + p4;
                if (xhr.responseText && xhr.responseText[0] == "{")
                    err = JSON.parse(xhr.responseText).Message;
                alert(err);
                return false;
            }
        });
    }



    function successQuantityUpdateHandler(response) {

        if (response == '1') {
            $('#txtupdateQuantity').val('');
            //$('#dropDownUser').val(-1);
            $('#SafetyList').DataTable().ajax.reload();
            $('#successAlertup').show('fade');
            setTimeout(function () {
                $('#successAlertup').hide('fade');
            }, 5000);
        }
        if (response == '-1') {
            $('#warningAlertup').show('fade');

            setTimeout(function () {
                $('#warningAlertup').hide('fade');
            }, 5000);
        }

    }




    //$('#Apply').prop('disabled', true);
    //$("#Resume").change(function () {

    //    // Get uploaded file extension
    //    var extension = $(this).val().split('.').pop().toLowerCase();
    //    // Create array with the files extensions that we wish to upload
    //    var validFileExtensions = ['doc', 'docx', 'pdf', 'xlsx', 'jpg'];
    //    //Check file extension in the array.if -1 that means the file extension is not in the list.
    //    if ($.inArray(extension, validFileExtensions) == -1) {
    //        alert("Sorry!! Upload only 'doc', 'docx', 'pdf','jpg' file")
    //        // Clear fileuload control selected file
    //        $(this).replaceWith($(this).val('').clone(true));
    //        //Disable Submit Button
    //        $('#Apply').prop('disabled', true);
    //    }
    //    else {
    //        // Check and restrict the file size to 128 KB.
    //        if ($(this).get(0).files[0].size > (131072622)) {
    //            alert("Sorry!! Max allowed file size is 128 kb");
    //            // Clear fileuload control selected file
    //            $(this).replaceWith($(this).val('').clone(true));
    //            //Disable Submit Button
    //            $('#Apply').prop('disabled', true);
    //        }
    //        else {
    //            //Enable Submit Button
    //            $('#Apply').prop('disabled', false);
    //        }
    //    }
    //});

    //$('#FileUpload').click(function () {
    //    saveClaim2('SaveToPhysicalLocation');
    //});


});

//function saveClaim2(url) {

//    var file_data = $('#Resume').prop('files')[0];
//    var form_data = new FormData();
//    form_data.append('file', file_data);
//    //var SafetyStockModel = {
//    //    Resume: form_data.append('file', file_data)
//    //}


//    $.ajax({
//        url: '/SafetyStock/ImportData',
//        type: "POST",
//        contentType: false, // Not to set any content header  
//        processData: false, // Not to process data  
//        data: form_data,
//        success: function (result) {
//            alert(result);
//        },
//        error: function (err) {
//            alert(err.statusText);
//        }
//    });
//    //var file = PendiingQuantities;
//    //Common.Ajax('POST', url, JSON.stringify(file), 'json', successManualClaimHandler);


//    //if (window.FormData !== undefined) {

//    //    var fileUpload = $("#FileUpload1").get(0);
//    //    var files = fileUpload.files;

//    //    // Create FormData object  
//    //    var fileData = new FormData();

//    //    // Looping over all files and add it to FormData object  
//    //    for (var i = 0; i < files.length; i++) {
//    //        fileData.append(files[i].name, files[i]);
//    //    }

//    //    // Adding one more key to FormData object  
//    //    fileData.append('username', 'Manas');
//    //    $.ajax({
//    //        url: '/SafetyStock/ImportData',
//    //        type: "POST",
//    //        contentType: false, // Not to set any content header  
//    //        processData: false, // Not to process data  
//    //        data: fileData,
//    //        success: function (result) {
//    //            alert(result);
//    //        },
//    //        error: function (err) {
//    //            alert(err.statusText);
//    //        }
//    //    });
//    //    //var claim = JSON.stringify(ClaimOrders);
//    //    //console.log(claim);
//    //    //  Common.Ajax('POST', url, fileData, 'json', successOrderClaimCreateHandler);



//    //} else {
//    //    alert("FormData is not supported.");
//    //}

//}
//function successManualClaimHandler(response) {
//    if (response == '2') {
//        // $('#RoleList').DataTable().ajax.reload();

//        setTimeout(function () {
//            $('#successAlertup').hide('fade');
//        }, 5000);
//    }
//    if (response == '-2') {

//        $('#warningAlertup').show('fade');

//        setTimeout(function () {
//            $('#warningAlertup').hide('fade');
//        }, 5000);
//    }
//}