/// <reference path="GenericAjax.js" />
var val = $('#txtUserName').val() == "-1" || null ? "" : $('#txtUserName').val();
var table;
$(document).ready(function () {
    var su = '';
    //var val = '-1';
    $.ajax({
        type: "post",
        url: "GetUserDropMenu",
        datatype: "json",
        multiselect: false,
        data: { 'type': 0 },
        traditional: true,
        success: function (data2) {
            for (var i = 0; i < data2.length; i++) {
                su += '<option value="' + data2[i].User_ID + '">' + data2[i].UserFirstName + '</option>';
            }
            if (val != '-1') {
                $("#txtUserName").attr("multiple", "multiple");
                $("#txtUserName").html(su);
                $("#txtUserName").multiselect('disable');
                $("#txtUserName").multiselect({
                    columns: 1,
                    placeholder: 'Please Select User Name',
                    search: true,
                    searchOptions: {
                        'default': 'Search'
                    },
                    selectAll: false
                });
                $("#txtUserName").multiselect("reload");

            }
            else {
                $('#txtUserName').multiselect('reload');
            }
        },
        error: function () {
            su = '<option value="-1">No Data found</option>';
            $("#txtUserName").html(su);
            $("#txtUserName").multiselect("reload");
        }
    });


    $("#txtUserName").change(function () {
        var val = $('#txtUserName').children("option:selected").val();
        getSetupForm(val);
        getMasterData(val);
        getTransactionForms(val);
        getReviewOrder(val);
        getClaimForms(val);
        getSummary(val);
        getReports(val);
    });

    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });
    $('#bttnReg').click(function () {
        var id = $('#txtUserName').children("option:selected").val();
        var setup = $('#drpSetupForms').val() || '';
        if (setup != '')
            setup = $('#drpSetupForms').val().join(',');
        var Master = $('#drpMasterData').val() || '';
        if (Master != '')
            Master = $('#drpMasterData').val().join(',');
        var Transaction = $('#drpTransactionForms').val() || '';
        if (Transaction != '')
            Transaction = $('#drpTransactionForms').val().join(',');
        var Review = $('#drpRevieworder').val() || '';
        if (Review != '')
            Review = $('#drpRevieworder').val().join(',');
        var Claim = $('#drpClaimForms').val() || '';
        if (Claim != '')
            Claim = $('#drpClaimForms').val().join(',');
        var Summary = $('#drpSummary').val() || '';
        if (Summary != '')
            Summary = $('#drpSummary').val().join(',');
        var Reports = $('#drpReports').val() || '';
        if (Reports != '')
            Reports = $('#drpReports').val().join(',');
        var screen = setup + ',' + Master + ',' + Transaction + ',' + Review + ',' + Claim + ',' + Summary + ',' + Reports;
        screen = screen.replace(',,,', ',').replace(',,', ',');
        if (id != '' || id != '-1') {
            var Data = {
                ID: id,
                Screens: screen,
                Action: 'Insert'
            }
            $.ajax({
                type: "post",
                url: "InsertUpdateUserMenu",
                datatype: "json",
                data: Data,
                traditional: true,
                success: function (data2) {
                    getUserMenutoGrid();
                    $('#successAlert').show().delay(5000).fadeOut();
                    reset();
                },
                error: function () {
                    $('#warningAlert').show().delay(5000).fadeOut();
                }
            });
        }
    });
    $('#bttnUpdateUserMenuSetup').click(function () {
        var id = $('#txt_ID_Update').val();
        var setup = $('#drpSetupForms_Update').val() || '';
        if (setup != '')
            setup = $('#drpSetupForms_Update').val().join(',');
        var Master = $('#drpMasterData_Update').val() || '';
        if (Master != '')
            Master = $('#drpMasterData_Update').val().join(',');
        var Transaction = $('#drpTransactionForms_Update').val() || '';
        if (Transaction != '')
            Transaction = $('#drpTransactionForms_Update').val().join(',');
        var Review = $('#drpRevieworder_Update').val() || '';
        if (Review != '')
            Review = $('#drpRevieworder_Update').val().join(',');
        var Claim = $('#drpClaimForms_Update').val() || '';
        if (Claim != '')
            Claim = $('#drpClaimForms_Update').val().join(',');
        var Summary = $('#drpSummary_Update').val() || '';
        if (Summary != '')
            Summary = $('#drpSummary_Update').val().join(',');
        var Reports = $('#drpReports_Update').val() || '';
        if (Reports != '')
            Reports = $('#drpReports_Update').val().join(',');
        var screen = setup + ',' + Master + ',' + Transaction + ',' + Review + ',' + Claim + ',' + Summary + ',' + Reports;
        if (id != '' || id != '-1') {
            var Data = {
                ID: id,
                Screens: screen,
                Action: 'Update'
            }
            $.ajax({
                type: "post",
                url: "InsertUpdateUserMenu",
                datatype: "json",
                data: Data,
                traditional: true,
                success: function (data2) {
                    //$("#closeModel").trigger('click');
                    getUserMenutoGrid();
                    $('#UpdatesuccessAlert').fadeIn();

                    setTimeout(function () {
                        $('#UpdatesuccessAlert').fadeOut();
                        $('#UserMenuSetupModal').modal('hide');
                    }, 3000);

                    

                },
                error: function () {
                    $('#UpdatewarningAlert').show().delay(5000).fadeOut();
                }
            });
        }
    });
    $('#edit_UserMenu').click(function () {
        var tr = $(this).closest('tr');
        // alert(tr.first('td').text());
    });

    getUserMenutoGrid();

    $('#UserMenuLists tbody').on('click', 'button', function () {
        var currentRow = $(this).closest("tr");
        var data = $('#UserMenuLists').DataTable().row(currentRow).data();
        var ID = (data['ID']);
        var UserName = (data['UserName']);
        $("#UserMenuSetupModal").modal();
        $("#txt_ID_Update").val(ID);
        $("#txtUserName_Update").val(UserName);
        getSetupForm_Modal(ID);
        getMasterData_Modal(ID);
        getTransactionForms_Modal(ID);
        getReviewOrder_Modal(ID);
        getClaimForms_Modal(ID);
        getSummary_Modal(ID);
        getReports_Modal(ID);
    });
    $('#UserMenuLists tbody').on('click', 'td.details-control', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);

        if (row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
            tr.removeClass('shown');
        }
        else {
            // Open this row
            row.child(format(row.data())).show();
            tr.addClass('shown');
        }
    });
});

function format(d) {
    // `d` is the original data object for the row
    return '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' +
        '<tr>' +
        '<td>Setup Forms:</td>' +
        '<td>' + d.SetupForms + '</td>' +
        '</tr>' +
        '<tr>' +
        '<td>Master Data:</td>' +
        '<td>' + d.MasterData + '</td>' +
        '</tr>' +
        '<tr>' +
        '<td>Review Orders:</td>' +
        '<td>' + d.ReviewOrders + '</td>' +
        '</tr>' +
        '<tr>' +
        '<td>Transaction Forms:</td>' +
        '<td>' + d.TransactionForms + '</td>' +
        '</tr>' +
        '<tr>' +
        '<td>Claim Forms:</td>' +
        '<td>' + d.ClaimForms + '</td>' +
        '</tr>' +
        '<tr>' +
        '<td>Summary:</td>' +
        '<td>' + d.Summary + '</td>' +
        '</tr>' +
        '</table>';
}

function getSetupForm(val) {
    $("#drpSetupForms").html('');
    var drp = '';
    $.ajax({
        type: "post",
        url: "getDropUserMenu",
        datatype: "json",
        data: { 'type': 1 },
        traditional: true,
        success: function (data2) {
            for (var i = 0; i < data2.length; i++) {
                drp += '<option value="' + data2[i].ID + '">' + data2[i].Screens + '</option>';
            }
            if (val != '-1') {
                $("#drpSetupForms").attr("multiple", "multiple");
                $("#drpSetupForms").html(drp);
                $("#drpSetupForms").multiselect({
                    columns: 1,
                    placeholder: 'Select Setup Forms',
                    search: true,
                    searchOptions: {
                        'default': 'Search'
                    },
                    selectAll: true
                });
                $("#drpSetupForms").multiselect("reload");

            }
            else {
                $('#drpSetupForms').multiselect('reload');
            }
        },
        error: function () {
            drp = '<option value="-1">No Data found</option>';
            $("#drpSetupForms").html(drp);
            $("#drpSetupForms").multiselect("reload");
        }
    });
}
function getMasterData(val) {
    $("#drpMasterData").html('');
    var drp = '';
    $.ajax({
        type: "post",
        url: "getDropUserMenu",
        datatype: "json",
        data: { 'type': 2 },
        traditional: true,
        success: function (data2) {
            for (var i = 0; i < data2.length; i++) {
                drp += '<option value="' + data2[i].ID + '">' + data2[i].Screens + '</option>';
            }
            if (val != '-1') {
                $("#drpMasterData").attr("multiple", "multiple");
                $("#drpMasterData").html(drp);
                $("#drpMasterData").multiselect({
                    columns: 1,
                    placeholder: 'Select Master Data Forms',
                    search: true,
                    searchOptions: {
                        'default': 'Search'
                    },
                    selectAll: true
                });
                $("#drpMasterData").multiselect("reload");

            }
            else {
                $('#drpMasterData').multiselect('reload');
            }
        },
        error: function () {
            drp = '<option value="-1">No Data found</option>';
            $("#drpMasterData").html(drp);
            $("#drpMasterData").multiselect("reload");
        }
    });
}
function getTransactionForms(val) {
    $("#drpTransactionForms").html('');
    var drp = '';
    $.ajax({
        type: "post",
        url: "getDropUserMenu",
        datatype: "json",
        data: { 'type': 3 },
        traditional: true,
        success: function (data2) {
            for (var i = 0; i < data2.length; i++) {
                drp += '<option value="' + data2[i].ID + '">' + data2[i].Screens + '</option>';
            }
            if (val != '-1') {
                $("#drpTransactionForms").attr("multiple", "multiple");
                $("#drpTransactionForms").html(drp);
                $("#drpTransactionForms").multiselect({
                    columns: 1,
                    placeholder: 'Select Transaction Forms',
                    search: true,
                    searchOptions: {
                        'default': 'Search'
                    },
                    selectAll: true
                });
                $("#drpTransactionForms").multiselect("reload");

            }
            else {
                $('#drpTransactionForms').multiselect('reload');
            }
        },
        error: function () {
            drp = '<option value="-1">No Data found</option>';
            $("#drpTransactionForms").html(drp);
            $("#drpTransactionForms").multiselect("reload");
        }
    });
}
function getReviewOrder(val) {
    $("#drpRevieworder").html('');
    var drp = '';
    $.ajax({
        type: "post",
        url: "getDropUserMenu",
        datatype: "json",
        data: { 'type': 4 },
        traditional: true,
        success: function (data2) {
            for (var i = 0; i < data2.length; i++) {
                drp += '<option value="' + data2[i].ID + '">' + data2[i].Screens + '</option>';
            }
            if (val != '-1') {
                $("#drpRevieworder").attr("multiple", "multiple");
                $("#drpRevieworder").html(drp);
                $("#drpRevieworder").multiselect({
                    columns: 1,
                    placeholder: 'Select Review Order Forms',
                    search: true,
                    searchOptions: {
                        'default': 'Search'
                    },
                    selectAll: true
                });
                $("#drpRevieworder").multiselect("reload");

            }
            else {
                $('#drpRevieworder').multiselect('reload');
            }
        },
        error: function () {
            drp = '<option value="-1">No Data found</option>';
            $("#drpRevieworder").html(drp);
            $("#drpRevieworder").multiselect("reload");
        }
    });
}
function getClaimForms(val) {
    $("#drpClaimForms").html('');
    var drp = '';
    $.ajax({
        type: "post",
        url: "getDropUserMenu",
        datatype: "json",
        data: { 'type': 5 },
        traditional: true,
        success: function (data2) {
            for (var i = 0; i < data2.length; i++) {
                drp += '<option value="' + data2[i].ID + '">' + data2[i].Screens + '</option>';
            }
            if (val != '-1') {
                $("#drpClaimForms").attr("multiple", "multiple");
                $("#drpClaimForms").html(drp);
                $("#drpClaimForms").multiselect({
                    columns: 1,
                    placeholder: 'Select Claim Forms',
                    search: true,
                    searchOptions: {
                        'default': 'Search'
                    },
                    selectAll: true
                });
                $("#drpClaimForms").multiselect("reload");

            }
            else {
                $('#drpClaimForms').multiselect('reload');
            }
        },
        error: function () {
            drp = '<option value="-1">No Data found</option>';
            $("#drpClaimForms").html(drp);
            $("#drpClaimForms").multiselect("reload");
        }
    });
}
function getSummary(val) {
    $("#drpSummary").html('');
    var drp = '';
    $.ajax({
        type: "post",
        url: "getDropUserMenu",
        datatype: "json",
        data: { 'type': 6 },
        traditional: true,
        success: function (data2) {
            for (var i = 0; i < data2.length; i++) {
                drp += '<option value="' + data2[i].ID + '">' + data2[i].Screens + '</option>';
            }
            if (val != '-1') {
                $("#drpSummary").attr("multiple", "multiple");
                $("#drpSummary").html(drp);
                $("#drpSummary").multiselect({
                    columns: 1,
                    placeholder: 'Select Summary Forms',
                    search: true,
                    searchOptions: {
                        'default': 'Search'
                    },
                    selectAll: true
                });
                $("#drpSummary").multiselect("reload");

            }
            else {
                $('#drpSummary').multiselect('reload');
            }
        },
        error: function () {
            drp = '<option value="-1">No Data found</option>';
            $("#drpSummary").html(drp);
            $("#drpSummary").multiselect("reload");
        }
    });
}
function getReports(val) {
    $("#drpReports").html('');
    var drp = '';
    $.ajax({
        type: "post",
        url: "getDropUserMenu",
        datatype: "json",
        data: { 'type': 7 },
        traditional: true,
        success: function (data2) {
            for (var i = 0; i < data2.length; i++) {
                drp += '<option value="' + data2[i].ID + '">' + data2[i].Screens + '</option>';
            }
            if (val != '-1') {
                $("#drpReports").attr("multiple", "multiple");
                $("#drpReports").html(drp);
                $("#drpReports").multiselect({
                    columns: 1,
                    placeholder: 'Select Reports Forms',
                    search: true,
                    searchOptions: {
                        'default': 'Search'
                    },
                    selectAll: true
                });
                $("#drpReports").multiselect("reload");

            }
            else {
                $('#drpReports').multiselect('reload');
            }
        },
        error: function () {
            drp = '<option value="-1">No Data found</option>';
            $("#drpReports").html(drp);
            $("#drpReports").multiselect("reload");
        }
    });
}




function getSetupForm_Modal(valz) {
    $("#drpSetupForms_Update").html('');
    var drp = '';
    var loop = 0;
    $.ajax({
        type: "post",
        url: "getDropUserMenu",
        datatype: "json",
        data: { 'type': 1 },
        traditional: true,
        success: function (data2) {
            loop = data2.length;
            for (var i = 0; i < data2.length; i++) {
                drp += '<option value="' + data2[i].ID + '">' + data2[i].Screens + '</option>';
            }
            $("#drpSetupForms_Update").attr("multiple", "multiple");
            $("#drpSetupForms_Update").html(drp);
            $("#drpSetupForms_Update").multiselect({
                columns: 1,
                placeholder: 'Please Select Setup Forms',
                search: true,
                searchOptions: {
                    'default': 'Search'
                },
                selectAll: true
            });
            $("#drpSetupForms_Update").multiselect("reload");
            $.ajax({
                type: "post",
                url: "geteditUserMenubyID",
                datatype: "json",
                data: { 'ID': valz, 'type': 1 },
                traditional: true,
                success: function (data3) {

                    var b = data3.Screens.split(',');
                    for (var l = 0; l < loop; l++) {
                        if (b[l] == $('#drpSetupForms_Update option').eq(parseInt(l)).val())
                            $('#drpSetupForms_Update option').eq(parseInt(l)).prop('selected', true);
                        else if (b[l] == $('#drpSetupForms_Update option').eq(parseInt(l + 1)).val())
                            $('#drpSetupForms_Update option').eq(parseInt(l + 1)).prop('selected', true);
                        else if (b[l] == $('#drpSetupForms_Update option').eq(parseInt(l + 2)).val())
                            $('#drpSetupForms_Update option').eq(parseInt(l + 2)).prop('selected', true);
                        else if (b[l] == $('#drpSetupForms_Update option').eq(parseInt(l + 3)).val())
                            $('#drpSetupForms_Update option').eq(parseInt(l + 3)).prop('selected', true);
                        else if (b[l] == $('#drpSetupForms_Update option').eq(parseInt(l + 4)).val())
                            $('#drpSetupForms_Update option').eq(parseInt(l + 4)).prop('selected', true);
                        else if (b[l] == $('#drpSetupForms_Update option').eq(parseInt(l + 5)).val())
                            $('#drpSetupForms_Update option').eq(parseInt(l + 5)).prop('selected', true);
                    }
                    $("#drpSetupForms_Update").multiselect("reload");
                }
            });
        }
    });
}
function getMasterData_Modal(valz) {
    $("#drpMasterData_Update").html('');
    var drp = ''; var loop = 0;
    $.ajax({
        type: "post",
        url: "getDropUserMenu",
        datatype: "json",
        data: { 'type': 2 },
        traditional: true,
        success: function (data2) {
            loop = data2.length;
            for (var i = 0; i < data2.length; i++) {
                drp += '<option value="' + data2[i].ID + '">' + data2[i].Screens + '</option>';
            }
            $("#drpMasterData_Update").attr("multiple", "multiple");
            $("#drpMasterData_Update").html(drp);
            $("#drpMasterData_Update").multiselect({
                columns: 1,
                placeholder: 'Please Select Setup Forms',
                search: true,
                searchOptions: {
                    'default': 'Search'
                },
                selectAll: true
            });
            $("#drpMasterData_Update").multiselect("reload");
            $.ajax({
                type: "post",
                url: "geteditUserMenubyID",
                datatype: "json",
                data: { 'ID': valz, 'type': 2 },
                traditional: true,
                success: function (data3) {

                    var b = data3.Screens.split(',');
                    for (var l = 0; l < loop; l++) {
                        if (b[l] == $('#drpMasterData_Update option').eq(parseInt(l)).val())
                            $('#drpMasterData_Update option').eq(parseInt(l)).prop('selected', true);
                        else if (b[l] == $('#drpMasterData_Update option').eq(parseInt(l + 1)).val())
                            $('#drpMasterData_Update option').eq(parseInt(l + 1)).prop('selected', true);
                        else if (b[l] == $('#drpMasterData_Update option').eq(parseInt(l + 2)).val())
                            $('#drpMasterData_Update option').eq(parseInt(l + 2)).prop('selected', true);
                        else if (b[l] == $('#drpMasterData_Update option').eq(parseInt(l + 3)).val())
                            $('#drpMasterData_Update option').eq(parseInt(l + 3)).prop('selected', true);
                    }
                    $("#drpMasterData_Update").multiselect("reload");
                }
            });
        }
    });
}
function getTransactionForms_Modal(valz) {
    $("#drpTransactionForms_Update").html('');
    var drp = ''; var loop = 0;
    $.ajax({
        type: "post",
        url: "getDropUserMenu",
        datatype: "json",
        data: { 'type': 3 },
        traditional: true,
        success: function (data2) {
            loop = data2.length;
            for (var i = 0; i < data2.length; i++) {
                drp += '<option value="' + data2[i].ID + '">' + data2[i].Screens + '</option>';
            }
            $("#drpTransactionForms_Update").attr("multiple", "multiple");
            $("#drpTransactionForms_Update").html(drp);
            $("#drpTransactionForms_Update").multiselect({
                columns: 1,
                placeholder: 'Please Select Setup Forms',
                search: true,
                searchOptions: {
                    'default': 'Search'
                },
                selectAll: true
            });
            $("#drpTransactionForms_Update").multiselect("reload");
            $.ajax({
                type: "post",
                url: "geteditUserMenubyID",
                datatype: "json",
                data: { 'ID': valz, 'type': 3 },
                traditional: true,
                success: function (data3) {

                    var b = data3.Screens.split(',');
                    for (var l = 0; l < loop; l++) {
                        if (b[l] == $('#drpTransactionForms_Update option').eq(parseInt(l)).val())
                            $('#drpTransactionForms_Update option').eq(parseInt(l)).prop('selected', true);
                        else if (b[l] == $('#drpTransactionForms_Update option').eq(parseInt(l + 1)).val())
                            $('#drpTransactionForms_Update option').eq(parseInt(l + 1)).prop('selected', true);
                        else if (b[l] == $('#drpTransactionForms_Update option').eq(parseInt(l + 2)).val())
                            $('#drpTransactionForms_Update option').eq(parseInt(l + 2)).prop('selected', true);
                        else if (b[l] == $('#drpTransactionForms_Update option').eq(parseInt(l + 3)).val())
                            $('#drpTransactionForms_Update option').eq(parseInt(l + 3)).prop('selected', true);
                        else if (b[l] == $('#drpTransactionForms_Update option').eq(parseInt(l + 4)).val())
                            $('#drpTransactionForms_Update option').eq(parseInt(l + 4)).prop('selected', true);
                        else if (b[l] == $('#drpTransactionForms_Update option').eq(parseInt(l + 5)).val())
                            $('#drpTransactionForms_Update option').eq(parseInt(l + 5)).prop('selected', true);
                        else if (b[l] == $('#drpTransactionForms_Update option').eq(parseInt(l + 6)).val())
                            $('#drpTransactionForms_Update option').eq(parseInt(l + 6)).prop('selected', true);
                    }
                    $("#drpTransactionForms_Update").multiselect("reload");
                }
            });
        }
    });
}
function getReviewOrder_Modal(valz) {
    $("#drpRevieworder_Update").html('');
    var drp = ''; var loop = 0;
    $.ajax({
        type: "post",
        url: "getDropUserMenu",
        datatype: "json",
        data: { 'type': 4 },
        traditional: true,
        success: function (data2) {
            loop = data2.length;
            for (var i = 0; i < data2.length; i++) {
                drp += '<option value="' + data2[i].ID + '">' + data2[i].Screens + '</option>';
            }
            $("#drpRevieworder_Update").attr("multiple", "multiple");
            $("#drpRevieworder_Update").html(drp);
            $("#drpRevieworder_Update").multiselect({
                columns: 1,
                placeholder: 'Please Select Setup Forms',
                search: true,
                searchOptions: {
                    'default': 'Search'
                },
                selectAll: true
            });
            $("#drpRevieworder_Update").multiselect("reload");
            $.ajax({
                type: "post",
                url: "geteditUserMenubyID",
                datatype: "json",
                data: { 'ID': valz, 'type': 4 },
                traditional: true,
                success: function (data3) {

                    var b = data3.Screens.split(',');
                    for (var l = 0; l < loop; l++) {
                        if (b[l] == $('#drpRevieworder_Update option').eq(parseInt(l)).val())
                            $('#drpRevieworder_Update option').eq(parseInt(l)).prop('selected', true);
                        else if (b[l] == $('#drpRevieworder_Update option').eq(parseInt(l + 1)).val())
                            $('#drpRevieworder_Update option').eq(parseInt(l + 1)).prop('selected', true);
                    }
                    $("#drpRevieworder_Update").multiselect("reload");
                }
            });
        }
    });
}
function getClaimForms_Modal(valz) {
    $("#drpClaimForms_Update").html('');
    var drp = '';
    var loop = 0;
    $.ajax({
        type: "post",
        url: "getDropUserMenu",
        datatype: "json",
        data: { 'type': 5 },
        traditional: true,
        success: function (data2) {
            loop = data2.length;
            for (var i = 0; i < loop; i++) {
                drp += '<option value="' + data2[i].ID + '">' + data2[i].Screens + '</option>';
            }
            $("#drpClaimForms_Update").attr("multiple", "multiple");
            $("#drpClaimForms_Update").html(drp);
            $("#drpClaimForms_Update").multiselect({
                columns: 1,
                placeholder: 'Please Select Claim Forms',
                search: true,
                searchOptions: {
                    'default': 'Search'
                },
                selectAll: true
            });
            $("#drpClaimForms_Update").multiselect("reload");
            $.ajax({
                type: "post",
                url: "geteditUserMenubyID",
                datatype: "json",
                data: { 'ID': valz, 'type': 5 },
                traditional: true,
                success: function (data3) {

                    var b = data3.Screens.split(',');
                    for (var l = 0; l < loop; l++) {
                        if (b[l] == $('#drpClaimForms_Update option').eq(parseInt(l)).val())
                            $('#drpClaimForms_Update option').eq(parseInt(l)).prop('selected', true);
                        else if (b[l] == $('#drpClaimForms_Update option').eq(parseInt(l + 1)).val())
                            $('#drpClaimForms_Update option').eq(parseInt(l + 1)).prop('selected', true);
                        else if (b[l] == $('#drpClaimForms_Update option').eq(parseInt(l + 2)).val())
                            $('#drpClaimForms_Update option').eq(parseInt(l + 2)).prop('selected', true);
                    }
                    $("#drpClaimForms_Update").multiselect("reload");
                }
            });

        }
    });
}
function getSummary_Modal(valz) {
    $("#drpSummary_Update").html('');
    var drp = ''; var loop = 0;
    $.ajax({
        type: "post",
        url: "getDropUserMenu",
        datatype: "json",
        data: { 'type': 6 },
        traditional: true,
        success: function (data2) {
            loop = data2.length;
            for (var i = 0; i < data2.length; i++) {
                drp += '<option value="' + data2[i].ID + '">' + data2[i].Screens + '</option>';
            }
            $("#drpSummary_Update").attr("multiple", "multiple");
            $("#drpSummary_Update").html(drp);
            $("#drpSummary_Update").multiselect({
                columns: 1,
                placeholder: 'Please Select Setup Forms',
                search: true,
                searchOptions: {
                    'default': 'Search'
                },
                selectAll: true
            });
            $("#drpSummary_Update").multiselect("reload");
            $.ajax({
                type: "post",
                url: "geteditUserMenubyID",
                datatype: "json",
                data: { 'ID': valz, 'type': 6 },
                traditional: true,
                success: function (data3) {

                    var b = data3.Screens.split(',');
                    for (var l = 0; l < loop; l++) {
                        if (b[l] == $('#drpSummary_Update option').eq(parseInt(l)).val())
                            $('#drpSummary_Update option').eq(parseInt(l)).prop('selected', true);
                        else if (b[l] == $('#drpSummary_Update option').eq(parseInt(l + 1)).val())
                            $('#drpSummary_Update option').eq(parseInt(l + 1)).prop('selected', true);
                    }
                    $("#drpSummary_Update").multiselect("reload");
                }
            });
        }
    });
}
function getReports_Modal(valz) {
    $("#drpReports_Update").html('');
    var drp = ''; var loop = 0;
    $.ajax({
        type: "post",
        url: "getDropUserMenu",
        datatype: "json",
        data: { 'type': 7 },
        traditional: true,
        success: function (data2) {
            loop = data2.length;
            for (var i = 0; i < data2.length; i++) {
                drp += '<option value="' + data2[i].ID + '">' + data2[i].Screens + '</option>';
            }
            $("#drpReports_Update").attr("multiple", "multiple");
            $("#drpReports_Update").html(drp);
            $("#drpReports_Update").multiselect({
                columns: 1,
                placeholder: 'Please Select Reports',
                search: true,
                searchOptions: {
                    'default': 'Search'
                },
                selectAll: true
            });
            $("#drpReports_Update").multiselect("reload");
            $.ajax({
                type: "post",
                url: "geteditUserMenubyID",
                datatype: "json",
                data: { 'ID': valz, 'type': 7 },
                traditional: true,
                success: function (data3) {

                    var b = data3.Screens.split(',');
                    for (var l = 0; l < loop; l++) {
                        if (b[l] == $('#drpReports_Update option').eq(parseInt(l)).val())
                            $('#drpReports_Update option').eq(parseInt(l)).prop('selected', true);
                        else if (b[l] == $('#drpReports_Update option').eq(parseInt(l + 1)).val())
                            $('#drpReports_Update option').eq(parseInt(l + 1)).prop('selected', true);
                    }
                    $("#drpReports_Update").multiselect("reload");
                }
            });
        }
    });
}

function getUserMenutoGrid() {
    if ($.fn.DataTable.isDataTable('#UserMenuLists')) {
        $('#UserMenuLists').DataTable().destroy();
    }
    table = $("#UserMenuLists").DataTable({
        "ajax": {
            "url": "GetUserMenuGrid",
            "type": "POST",
            "datatype": "json",
            "processing": false,
            "serverSide": false,
            "filter": true,
            "orderMulti": true,
            "dataSrc": "",
        },
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            }],
        "columns": [
            { "data": "ID", "name": "ID", "autoWidth": true },
            {
                "className": 'details-control',
                "orderable": false,
                "data": null,
                "defaultContent": ''
            },
            { "data": "UserName", "name": "UserName", "autoWidth": true },
            { "data": "Email", "name": "Email", "autoWidth": true },
            {
                "defaultContent": "<button id='click' class='btn btn-primary m-t-6 waves-effect'>Edit</button>"
            }
        ],
        "order": [[0, "desc"]]
    });
}
function reset() {
    $('#txtUserName option').eq(0).prop('selected', true);
    var val = $('#txtUserName').children("option:selected").val();
    getSetupForm(val);
    getMasterData(val);
    getTransactionForms(val);
    getReviewOrder(val);
    getClaimForms(val);
    getSummary(val);
}
