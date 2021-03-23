/// <reference path="GenericAjax.js" />
var Material = $('#Material').val() == "-1" || null ? "" : $('#Material').val();
var Material = $('#Sales Organization').val() == "-1" || null ? "" : $('#Sales Organization').val();

$(document).ready(function () {
    $("#bttnClaim").click(function () {
        SavemanualClaim('CreateClaim');
    });

    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });

    GetMaterials();

    $('#Apply').prop('disabled', true);
    $("#Resume").change(function () {

        // Get uploaded file extension
       // var extension = $(this).val().split('.').pop().toLowerCase();
        // Create array with the files extensions that we wish to upload
       // var validFileExtensions = ['zip', 'png', 'jpeg'];
        //Check file extension in the array.if -1 that means the file extension is not in the list.
        //if ($.inArray(extension, validFileExtensions) == -1) {
        //    alert("Sorry!! Upload only 'jpg', 'png', 'jpeg' file")
        //    // Clear fileuload control selected file
        //    $(this).replaceWith($(this).val('').clone(true));
        //    //Disable Submit Button
        //    $('#Apply').prop('disabled', true);
        //}
        //else {
        //    // Check and restrict the file size to 128 KB.
        //    if ($(this).get(0).files[0].size > (15000000000000000000)) {
        //        alert("Sorry!! Max allowed file size is 128 kb");
        //        // Clear fileuload control selected file
        //        $(this).replaceWith($(this).val('').clone(true));
        //        //Disable Submit Button
        //        $('#Apply').prop('disabled', true);
        //    }
        //    else {
        //        //Enable Submit Button
        //        $('#Apply').prop('disabled', false);
        //    }
        //}
    });

    $("#drpMaterial").change(function () {
        $("#unitPriceShow").val($("#drpMaterial option:selected").attr("td-unitprice"));
    });

});

function SavemanualClaim(url) {
    if (($("#ClaimComment").val() == "")) {
        alert("Enter the Comment is must");
        return false;
    }
    else {
        var fileUpload = "";
        hasFile = false;

        fileUpload = $("#Resume").get(0); 
        if (fileUpload.files.length > 0) {
            hasFile = true;
        }
        
        if (hasFile == true) {

            //if no file found, alert error

            var files = fileUpload.files;
            // Create FormData object  
            var fileData = new FormData();

            // Looping over all files and add it to FormData object  
            for (var i = 0; i < files.length; i++) {
                fileData.append(files[i].name, files[i]);
            }

            var ClaimList = new Array();

            var PendiingQuantities = {
                materialCode: $("#drpMaterial").val(),
                salesorganization: $('#drpMaterial option:selected').attr('td-salesorganization'),
                division: $('#drpMaterial option:selected').attr('td-division'),
                //day: $("#drpday").val(),
                ManualClaimedQty: $("#txtclaimedQty").val(),
                //recievedQuantity: $("#txtrecievedQuantity").val(),
                //damaged: $("#txtdamagedQuantity").val(),
                //expired: $("#txtexpiredQuantity").val(),
                ManualBatchNo: $("#txtBatchNumber").val(),
                ClaimComment: $("#ClaimComment").val(),
                ClaimValue: $("#claimValue").val(),
                unitPrice: $("#unitPriceShow").val()
                //orderQuantity: $("#txtorderQuantity").val(),

            }
            if (PendiingQuantities != "") {
                var dataToPost = PendiingQuantities;
                Common.Ajax('POST', url, JSON.stringify(dataToPost), 'json', successManualClaimHandler);
            }

            ClaimList.push(PendiingQuantities);

            var dataToPost = JSON.stringify(ClaimList);


            fileData.append('dataToPost', dataToPost);
            $.ajax({
                url: 'AddManualFile',
                type: "POST",
                contentType: false, // Not to set any content header  
                processData: false, // Not to process data  
                data: fileData,

                success: successManualClaimHandler(),
                //error: function (err) {
                //    alert(err.statusText);
                //}
            });
        }
        else {
            alert("no file selected");
            return false;
        }
    }
}  
        
       
function successManualClaimHandler(response) {

    if (response == '1') {
        //$('#drpRefrenceCode').val('');

        $('#OperationDone').show('fade');
        setTimeout(function () {
            $('#OperationDone').hide('fade');
        }, 5000);
        $("#manualclaim")[0].reset();
        $('#ManualClaimList').DataTable().ajax.reload();
    }
     if (response == '-3') {
        $('#OperationUnsuccedful').show('fade');
        setTimeout(function () {
            $('#OperationUnsuccedful').hide('fade');
        }, 5000);
    }
}
function DataLoad() {
    $('#endStockList').dataTable().fnDestroy();

    $("#divLoader").fadeIn();

   
}

function GetMaterials() {
    $.ajax({
        type: "get",
        url: "GetMaterials",
        data: {},
        datatype: "json",
        traditional: true,
        success: function (data) {
            var s1 = '<option value="-1">Select Material</option>';
            for (var i = 0; i < data.length; i++) {
                s1 += '<option td-SalesOrganization="' + data[i].SalesOrganization + '" td-Division = "' + data[i].Division + '" value="' + data[i].Material + '" td-UnitPrice="' + data[i].unitPrice + '">' + data[i].Material + ' | ' + data[i].Description + ' (' + data[i].SalesOrganization + ')</option>';
            }
            $("#drpMaterial").html(s1);

            //$("#drpMaterial").multiselect({
            //    columns: 1,
            //    placeholder: 'Material',
            //    search: true,
            //    searchOptions: {
            //        'default': 'Search'
            //    },
            //});
            //$("#drpMaterial").multiselect("reload");

        }


    });
}
function checkUplift(e) {
    /*
      8 - (backspace)
      32 - (space)
      48-57 - (0-9)Numbers
      97-122 - (a-z)Small Alphabets
      65-90 - (A-Z)Capital Alphabets
    */
    var KeyID = (window.event) ? event.keyCode : e.keyCode;

      //var newChar = String.fromCharCode(e.keyCode);
        var oldVal = $("#txtclaimedQty").val();
        //var total = parseInt(oldVal + newChar)
        //if (isNaN(oldVal + newChar) && oldVal != '')
        //    return false;
        //else if (total < 0 || total > 100)
        //    return false;
        $("#claimValue").val(oldVal * Number($("#unitPriceShow").val()));
        return true;
}