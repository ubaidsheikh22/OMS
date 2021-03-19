

$(document).ready(function () {

    $('#bttnCus').click(function () {
        saveData('insertOrder');
    });


    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });
    var table = $("#CustomerList").DataTable({
        //"processing": true, // for show progress bar
        //"serverSide": true, // for process server side
        //"filter": true, // this is for disable filter (search box)
        //"orderMulti": false, // for disable multiple column at once

        //"ajax": {
        //    "url": "GetAllGeneratedOrders",
        //    "type": "POST",
        //    "datatype": "json",
        //    "DataSrc" : ""

        //},

        "ajax": {
            "url": "GetAllGeneratedOrders",
            "type": "POST",
            "datatype": "json",

            "processing": false, // for show progress bar
            "serverSide": false, // for process server side
            "filter": true, // this is for disable filter (search box)
            "orderMulti": true, // for disable multiple column at once
            "dataSrc": "",

        },


        "columns": [
                { "defaultContent": "<input type='checkbox' id='chk' class='checkBox' 'name': 'checkbox' 'value':'Checked'/></th>" },
                { "data": "Customer", "class": "Customer", "name": "Customer", "autoWidth": true },
                { "data": "Name1", "class": "Name1", "name": "Name1", "autoWidth": true },
                { "data": "Division", "class": "Division", "name": "Division", "autoWidth": true },
                { "data": "RegionDescription", "class": "RegionDescription", "name": "RegionDescription", "autoWidth": true },
                { "data": "SalesOrganization", "class": "SalesOrganization", "name": "SalesOrganization", "autoWidth": true },
        ]

    });

    $('#select_all').click(function () {
        if ($(this).prop("checked")) {
            //$("#MaterialList TBODY TR").each(function () {
               // var row = $(this);
            $(".checkBox").prop("checked", true);
           // });
            
        } else {
            $(".checkBox").prop("checked", false);
        }
    });

    //$("#select_all").change(function () {  //"select all" change 
    //    var status = this.checked; // "select all" checked status
    //    $('.checkbox').each(function () { //iterate all listed checkbox items
    //        this.checked = status; //change ".checkbox" checked status
    //    });
    //});

    //$('.checkbox').change(function () { //".checkbox" change 
    //    //uncheck "select all", if one of the listed checkbox item is unchecked
    //    if (this.checked == false) { //if this item is unchecked
    //        $("#select_all")[0].checked = false; //change "select all" checked status to false
    //    }

    //    //check "select all" if all checkbox items are checked
    //    if ($('.checkbox:checked').length == $('.checkbox').length) {
    //        $("#select_all")[0].checked = true; //change "select all" checked status to true
    //    }
    //});
    

});

function saveData(url) {
    $('#CustomerList').dataTable().fnDestroy();
    var FrequencyListModal = new Array();
    $("#CustomerList TBODY TR").each(function () {
        var row = $(this);
        var FrequencyModel = {};
        
        //if ($('#chk').prop("checked") == true) {
            FrequencyModel.Monday = $('#txtMonday').val();
            FrequencyModel.Tuesday = $('#txtTuesday').val();
            FrequencyModel.Wednesday = $('#txtWednesday').val();
            FrequencyModel.Thursday = $('#txtThursday').val();
            FrequencyModel.Friday = $('#txtFriday').val();
            FrequencyModel.Saturday = $('#txtSaturday').val();
            FrequencyModel.Sunday = $('#txtSunday').val();
            //FrequencyModel.chk = row.find("TD").eq(0).html();
            FrequencyModel.Customer = row.find("TD").eq(1).html();
            FrequencyModel.Name1 = row.find("TD").eq(2).html();
            FrequencyModel.Division = row.find("TD").eq(3).html();
            FrequencyModel.RegionDescription = row.find("TD").eq(4).html();
            FrequencyModel.SalesOrganization = row.find("TD").eq(5).html();

            FrequencyListModal.push(FrequencyModel);
        

    });
    var dataToPost = JSON.stringify(FrequencyListModal);
    console.log(dataToPost);
    //var dataToPost = '{Rele_Desc: "' + $("#txtReleDesc").val() + '" }';
    Common.Ajax('POST', url, dataToPost, 'json', successRoleCreateHandler);
    $('#CustomerList').dataTable();
}
