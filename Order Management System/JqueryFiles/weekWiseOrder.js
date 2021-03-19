var commentsdd = null;
dayName = '';
$(document).ready(function () {
    BindDropDown('claimComments');
    $('#redirect').click(function () {
        window.location.href = "/dashboard/dashboard";
    });

    $('.btn').click(function () {
     
        saveData('AddPendingOrders');
    });

    function getEventTarget(e) {
        e = e || window.event;
        return e.target || e.srcElement;
    }

    var ul = document.getElementById('getday');
    ul.onclick = function (event) {
        var target = getEventTarget(event);
        var day = target.innerHTML;
        dayName = day;
        //alert(day);
        if (day == "Monday") {
            day = 1;
        } else if (day == "Tuesday") {
            day = 2;
        } else if (day == "Wednesday") {
            day = 3;
        } else if (day == "Thursday") {
            day = 4;
        } else if (day == "Friday") {
            day = 5;
        } else if (day == "Saturday") {
            day = 6;
        } else if (day == "Sunday") {
            day = 0;
        }
        //alert(day);  
        switch (day) {
            case 1:
                GetBillingNo('GetBillingNo', 'SapOrderNoMonday');
                $("#TuesdayToggle,#WednesdayToggle,#ThursdayToggle,#FridayToggle,#SaturdayToggle,#SundayToggle").is('.active');
                /*to actually disable clicking the bootstrap tab, as noticed in comments by user3067524*/
                $("#TuesdayToggle,#WednesdayToggle,#ThursdayToggle,#FridayToggle,#SaturdayToggle,#SundayToggle").is('.active');
                break;
            case 2:
                GetBillingNo('GetBillingNo', 'SapOrderNoTuesday');
                $("#MondayToggle,#WednesdayToggle,#ThursdayToggle,#FridayToggle,#SaturdayToggle,#SundayToggle").is('.active');
                /*to actually disable clicking the bootstrap tab, as noticed in comments by user3067524*/
                $("#MondayToggle,#WednesdayToggle,#ThursdayToggle,#FridayToggle,#SaturdayToggle,#SundayToggle").is('.active');
                break;
            case 3:
                GetBillingNo('GetBillingNo', 'SapOrderNoWednesday');
                $("#MondayToggle,#TuesdayToggle,#ThursdayToggle,#FridayToggle,#SaturdayToggle,#SundayToggle").is('.active');
                /*to actually disable clicking the bootstrap tab, as noticed in comments by user3067524*/
                $("#MondayToggle,#TuesdayToggle,#ThursdayToggle,#FridayToggle,#SaturdayToggle,#SundayToggle").is('.active');
                break;
            case 4:
                GetBillingNo('GetBillingNo', 'SapOrderNoThursday');
                $("#MondayToggle,#TuesdayToggle,#WednesdayToggle,#FridayToggle,#SaturdayToggle,#SundayToggle").is('.active');
                /*to actually disable clicking the bootstrap tab, as noticed in comments by user3067524*/
                $("#MondayToggle,#TuesdayToggle,#WednesdayToggle,#FridayToggle,#SaturdayToggle,#SundayToggle").is('.active');
                break;
            case 5:
                GetBillingNo('GetBillingNo', 'SapOrderNoFriday');
                $("#MondayToggle,#TuesdayToggle,#WednesdayToggle,#ThursdayToggle,#SaturdayToggle,#SundayToggle").is('.active');
                /*to actually disable clicking the bootstrap tab, as noticed in comments by user3067524*/
                $("#MondayToggle,#TuesdayToggle,#WednesdayToggle,#ThursdayToggle,#SaturdayToggle,#SundayToggle").is('.active');
                break;
            case 6:
                GetBillingNo('GetBillingNo', 'SapOrderNoSaturday');
                $("#MondayToggle,#TuesdayToggle,#WednesdayToggle,#ThursdayToggle,#FridayToggle,#SundayToggle").is('.active');
                /*to actually disable clicking the bootstrap tab, as noticed in comments by user3067524*/
                $("#MondayToggle,#TuesdayToggle,#WednesdayToggle,#ThursdayToggle,#FridayToggle,#SundayToggle").is('.active');
                break;
            case 0:
                GetBillingNo('GetBillingNo', 'SapOrderNoSunday');
                $("#MondayToggle,#TuesdayToggle,#WednesdayToggle,#ThursdayToggle,#FridayToggle,#SaturdayToggle").is('.active');
                /*to actually disable clicking the bootstrap tab, as noticed in comments by user3067524*/
                $("#MondayToggle,#TuesdayToggle,#WednesdayToggle,#ThursdayToggle,#FridayToggle,#SaturdayToggle").is('.active');
                break;
            default:
                alert("Switch case is not selected");
                break;
        }

        $(".table").DataTable();
        $(".table").dataTable().fnDestroy();

        $(".ddl_BillingNo").change(function () {
            var activeTab = $('.tab-content .tab-pane.active');
            var target = activeTab.attr('value');
            GetDayOrder(target);
        });
    }
});

function GetDayOrder(target) {
    $('#' + target).dataTable().fnDestroy();

    var BillingNo = $('#ddl_BillingNo' + target + ' option:selected').val();

    $.ajax({
        type: "GET",
        url: "gridView?day=" + target,
        data: { day: target, BillingNo: BillingNo },
        datatype: "json",

        success: function (data) {
            var a = '#' + target;
            $('#' + target).DataTable({
                "destroy": true,
                "processing": true, // for show progress bar
                "serverSide": false, // for process server side
                "filter": true, // this is for disable filter (search box)
                "orderMulti": false, // for disable multiple column at once
                "data": data,
                "dataSrc": "",
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
                    { "data": "day", "class": "day", "name": "day", "id":"day", "autoWidth": true },
                    { "data": "day", "class": "rcvd", "id": "rcvd", "name": "rcvd", "autoWidth": true },
                    //{ "defaultContent": "<input type='text' id='txtDamaged' class='dmg' name='Damaged' class='form form-control' min='0' placeholder='Enter Damaged Quantity' onchange='return adjustRcvdQty(this)' min='0' onkeypress='return adjustRcvdQty(this), return checkUplift(event);' />" },
                    { "defaultContent": "<input type='text' id='txtDamaged' class='dmg' name='Damaged' class='form form-control' min='0' placeholder='Enter Damaged Quantity' onchange='return adjustRcvdQty(this)' min='0' onkeypress='return (checkUplift(event) && adjustRcvdQty(this) );' />" },
                    { "defaultContent": "<input type='text' id='txtExpired' class='exp'name='Expired' class='form form-control' min='0'  placeholder='Enter Expired Quantity' onchange='return adjustRcvdQty(this)'  min='0' onkeypress='return (checkUplift(event) && adjustRcvdQty(this) );' />" },
                    { "defaultContent": "<input type='text' id='txtShort' class='sht' name='Short' class='form form-control' min='0'  placeholder='Enter Short Quantity' onchange='return adjustRcvdQty(this)'  min='0' onkeypress='return (checkUplift(event) && adjustRcvdQty(this) );' />" },
                    {
                        "render": function (data, type, row) {
                            return '<textarea class="comments btn-group bootstrap-select form-control show-tick" name="comments" id="txtcomments"/>';
                        },
                    }
                ],
                footerCallback: function (tfoot, data, start, end, display) {
                    var api = this.api();

                    $(api.column(4).footer()).html('Total Firm Order = ' +
                        api.column(4).data().reduce(function (a, b) {
                            return a + b;
                        }, 0)
                    );
                },
            });
        }
    });
}

function GetBillingNo(url, dayName) {
    var dataToPost = '{"SapOrderNoSunday":"' + dayName + '"}';
    Common.Ajax('POST', url, dataToPost, 'json', GetBillNoHandler);
}

function GetBillNoHandler(response) {
    var s = '<option value="">Please Select Bill No.</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].BillingId + '">' + response[i].BillingNo + '</option>';
    }
    $("#ddl_BillingNo" + dayName).html(s);
}

var val1 = 0, val2 = 0, val3 = 0;

function adjustRcvdQty(ele) {

    valu = $(ele).val();
    parent = $(ele).parents("tr");//.find(".day");
    total = $(ele).parents("tr").find(".day").html();
    v1 = $(parent).find('.sht');
    v2 = $(parent).find('.dmg');
    v3 = $(parent).find('.exp');
    v1 = v1.val() == undefined ? 0 : v1.val();
    v2 = v2.val() == undefined ? 0 : v2.val();
    v3 = v3.val() == undefined ? 0 : v3.val();

    sum = Number(v3) + Number(v2) + Number(v1);
    if (sum > total) {
        alert("your entered values are greater than ordered quantities");
      //  $(ele).parents("tr").find('.rcvd').html() = $(ele).parents("tr").find(".day").html()
        
        $(parent).find('#txtDamaged').val( '');
        $(parent).find('#txtExpired').val('');
        $(parent).find('#txtShort').val('');
        $(parent).find('.rcvd').text($(parent).find('.day').text());

        return false;


    }
    flag = '';

    $(parent).find('.rcvd').html(Number(total) < sum ? '0' : Number(total) - sum);
    return;
    if ($(ele).hasClass('sht')) {
        oldv = val1;
        flag = 'sht';
    } else if ($(ele).hasClass('dmg')) {
        oldv = val2;
        flag = 'dmg';
    } else if ($(ele).hasClass('exp')) {
        oldv = val3;
        flag = 'exp';
    }
    tempval = 0;
    if (flag == 'sht') {
        tempval = val2 + val3;
    } else if (flag == 'dmg') {
        tempval = val1 + val3;
    } else if (flag == 'exp') {
        tempval = val2 + val1;
    }
    finalval = tempval + Number(valu);
    var element = $(ele).parents("tr").find(".day");
    var elementrcvd = $(ele).parents("tr").find(".rcvd");
    rcvd = $(element).html();
    rcvd = Number(rcvd);
    if (rcvd - finalval >= 0) {
        rcvd = rcvd - finalval;
        $(elementrcvd).html(rcvd);
        if (flag == 'sht') {
            val1 = Number(valu);
        } else if (flag == 'dmg') {
            val2 = Number(valu);
        } else if (flag == 'exp') {
            val3 = Number(valu);
        }
    } else {

        $(ele).val(oldv);


    }
    return false;
}

function saveData(url) {

    var fileUpload = "";
    hasFile = false;
    for (var i = 1; i < 8; i++) {
        fileUpload = $("#FileUpload" + i).get(0);
        if (fileUpload.files.length > 0) {
            hasFile = true;
        }
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

        var activeTab = $('.tab-content .tab-pane.active');
        var activeId = activeTab.attr('value');

        $('#' + activeId).dataTable().fnDestroy();
        var BillingId = $('#ddl_BillingNo' + activeId + ' option:selected').val();
        if (BillingId == "" || BillingId == null) {
            alert("Select Bill Number");
            return;
        }

        var PendingOrderList = new Array();
        //$("#" + activeId + " TBODY TR").each(function () {
        rowcount = $("#" + activeId + " TBODY TR");
        for (myI = 0; myI < rowcount.length; myI++) {
            var row = $(rowcount[myI]);
            var PendingOrderModel = {};
            var BillingNo = $('#ddl_BillingNo' + activeId + ' option:selected').text();



            var qty = row.find("TD").eq(5).html();

            var qtyDamaged = row.find('#txtDamaged').val();
            var qtyExpired = row.find('#txtExpired').val();
            var qtyShort = row.find('#txtShort').val();
            var txtchkclaim = row.find('#txtcomments').val()

            if (row.find('#txtcomments').val() == "" && (qtyDamaged != '' || qtyExpired != '' || qtyShort != '')) {
                //alert($("#txtcomments").val());
                alert("Enter Comments");
                return false;
            }
            

            var data = $('#' + activeId).DataTable().row(row).data();
            PendingOrderModel.Order_Ref = row.find("TD").eq(0).html();
            PendingOrderModel.materialCode = row.find("TD").eq(1).html();
            PendingOrderModel.materialDescription = row.find("TD").eq(2).html();
            PendingOrderModel.unitPrice = row.find("TD").eq(3).html();
            PendingOrderModel.orderQuantity = row.find("TD").eq(4).html();
            PendingOrderModel.recievedQuantity = (qty == null || qty == "" ? 0 : qty);

            PendingOrderModel.Damaged = (qtyDamaged == null || qtyDamaged == "" ? 0 : qtyDamaged);
            PendingOrderModel.Expired = (qtyExpired == null || qtyExpired == "" ? 0 : qtyExpired);
            PendingOrderModel.Short = (qtyShort == null || qtyShort == "" ? 0 : qtyShort);
            PendingOrderModel.ReceivingComments = row.find('.comments').val();

            PendingOrderModel.day = activeId;
            PendingOrderModel.BillingId = BillingId;
            PendingOrderModel.BillingNo = BillingNo;

            PendingOrderList.push(PendingOrderModel);

        }
        if (PendingOrderList == "" || PendingOrderList == null || PendingOrderList.length == 0) {
            alert("Table is Empty");
            return;
        }

        var dataToPost = JSON.stringify(PendingOrderList);


        fileData.append('dataToPost', dataToPost);
        $.ajax({
            url: 'AddPendingOrders',
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: fileData,
            success: successWeeklyUpliftCreateHandler,
            error: function (err) {
                alert(err.statusText);
            }
        });
        $('#ddl_BillingNo' + activeId + ' option:selected').text().empty();
        $('#' + activeId).dataTable().draw();
        //Common.Ajax('POST', url, dataToPost, 'json', successWeeklyUpliftCreateHandler);
       
    }
    else {
        alert("no file selected");
        for (var i = 1; i < 8; i++) {
            $("#FileUpload" + i).val() = "";

           
      }
        return false;
    }
    
}

function successWeeklyUpliftCreateHandler(response) {

    if (response == '1') {
        //$("#list").DataTable();
        //$('.form').val('');
        //$('.comments').val(-1);

        $('.tab-content .tab-pane.active #successAlert').show('fade');
        // $('#designationList').DataTable().ajax.reload();
        setTimeout(function () {
            $('.alert').hide('fade');
        }, 5000);
        $('#getday li.active a').trigger("click");
        $('.tab-content .tab-pane.active table').DataTable().clear().draw();
        for (var i = 1; i < 8; i++) {
            fileUpload = $("#FileUpload" + i).get(0);
            if (fileUpload.files.length > 0) {
                fileUpload.val()="";
            }
        }
    }
    if (response == '-1') {
        $('.tab-content .tab-pane.active #warningAlert').show('fade');

        setTimeout(function () {
            $('.tab-content .tab-pane.active #warningAlert').hide('fade');
        }, 5000);
        
    }
}

function BindDropDown(url) {
    if (commentsdd == null)
        Common.Ajax('GET', url, {}, 'json', BindDropDownHandler);
    else
        BindDropDownHandler(commentsdd);
}

function BindDropDownHandler(response) {
    commentsdd = response;
    var s = '<option value="-1">Please Select a Comment</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].commentID + '">' + response[i].comment + '</option>';
    }
    $(".comments").html(s);
}

function checkDamage(e) {
    /*
      8 - (backspace)
      32 - (space)
      48-57 - (0-9)Numbers
      97-122 - (a-z)Small Alphabets
      65-90 - (A-Z)Capital Alphabets
    */
    var KeyID = (window.event) ? event.keyCode : e.keyCode;

    if ((KeyID == 8) || (KeyID == 9) || (KeyID == 13) || (KeyID >= 48 && KeyID <= 57)) {

        var newChar = String.fromCharCode(e.keyCode);
        var oldVal = $(e.target).val();
        var total = parseInt(oldVal + newChar)
        if (isNaN(oldVal + newChar) && oldVal != '')
            return false;
        else if (total < 0)
            return false;

        return true;
    }
    else {
        return false;
    }
}

function checkExpired(e) {
    /*
      8 - (backspace)
      32 - (space)
      48-57 - (0-9)Numbers
      97-122 - (a-z)Small Alphabets
      65-90 - (A-Z)Capital Alphabets
    */
    var KeyID = (window.event) ? event.keyCode : e.keyCode;

    if ((KeyID == 8) || (KeyID == 9) || (KeyID == 13) || (KeyID >= 48 && KeyID <= 57)) {

        var newChar = String.fromCharCode(e.keyCode);
        var oldVal = $(e.target).val();
        var total = parseInt(oldVal + newChar)
        if (isNaN(oldVal + newChar) && oldVal != '')
            return false;
        else if (total < 0)
            return false;

        return true;
    }
    else {
        return false;
    }
}

function checkShort(e) {
    /*
      8 - (backspace)
      32 - (space)
      48-57 - (0-9)Numbers
      97-122 - (a-z)Small Alphabets
      65-90 - (A-Z)Capital Alphabets
    */
    var KeyID = (window.event) ? event.keyCode : e.keyCode;

    if ((KeyID == 8) || (KeyID == 9) || (KeyID == 13) || (KeyID >= 48 && KeyID <= 57)) {

        var newChar = String.fromCharCode(e.keyCode);
        var oldVal = $(e.target).val();
        var total = parseInt(oldVal + newChar)
        if (isNaN(oldVal + newChar) && oldVal != '')
            return false;
        else if (total < 0)
            return false;

        return true;
    }
    else {
        return false;
    }
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

    if ((KeyID == 8) || (KeyID == 9) || (KeyID == 13) || (KeyID >= 48 && KeyID <= 57)) {

        //var newChar = String.fromCharCode(e.keyCode);
        //var oldVal = $(e.target).val();
        //var total = parseInt(oldVal + newChar)
        //if (isNaN(oldVal + newChar) && oldVal != '')
        //    return false;
        //else if (total < 0 || total > 100)
        //    return false;

        return true;
    }
    else {
        return false;
    }
}