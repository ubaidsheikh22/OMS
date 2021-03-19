/// <reference path="GenericAjax.js" />

var EditStatus = "";
var AreaArray;
var Teritorrydata;
var TownData;
var DistibutorData;
var DivisionData;
var SaleOrgData;
var DynamicRoleId;
var EditUserName;
var EditUserEmail;
var EditUserID;
//var login_Id;
$(document).ready(function () {
    $('#bttnUpdateRegister').click(function () {
        UpdateRegiser('UpdateRegister');
    });
    var fnRegisterLists = $("#RegisterLists").DataTable({
        initComplete: function () {
            this.api().columns().every(function () {
                var column = this;
                if (column.index() == 6)
                    return;
                var select = $('<select><option value="">Select All</option></select>')
                    .appendTo($(column.header()).empty())
                    .on('change', function () {
                        var val = $.fn.dataTable.util.escapeRegex(
                            $(this).val()
                        );

                        column
                            .search(val ? '^' + val + '$' : '', true, false)
                            .draw();
                    });

                column.data().unique().sort().each(function (d, j) {
                    select.append('<option value="' + d + '">' + d + '</option>')
                });
            });
        },



        "ajax": {
            "url": "GetAllRegistraitonRecord",
            "type": "POST",
            "datatype": "json",

            "processing": false, // for show progress bar
            "serverSide": false, // for process server side
            "filter": true, // this is for disable filter (search box)
            "orderMulti": true, // for disable multiple column at once
            "dataSrc": "",
        },

        columnDefs: [
            {
                targets: 6,
                render: $.fn.dataTable.render.ellipsis(20)
            },
            { "orderable": false, "targets": "_all" }
        ],
        order: [[1, 2, 3, 4, 5, 6, 7, 8, 9, "asc"]],

        "columns": [
            { "data": "Login_ID", "class": "Login_ID", "name": "Login_ID", "autoWidth": true, "visible": false },
            { "data": "UserFirstName", "class": "UserFirstName", "name": "UserFirstName", "autoWidth": true },
            { "data": "UserLastName", "class": "UserLastName UL", "name": "UserLastName", "autoWidth": true },
            //{ "data": "txtdistEmail", "class": "txtdistEmail", "name": "txtdistEmail", "autoWidth": true },
            { "data": "UserName", "class": "UserName", "name": "UserName", "autoWidth": true },
            
            { "data": "Designation_ID", "class": "Designation_ID", "name": "Designation_ID", "autoWidth": false },
            { "data": "Rele_Desc", "class": "Rele_Desc", "name": "Rele_Desc", "autoWidth": true },
            { "data": "Distributor_ID", "class": "Distributor_ID", "name": "Distributor_ID", "autoWidth": false, "width": "20px" },
            { "data": "UserEmail", "class": "UserEmail", "name": "UserEmail", "autoWidth": true },
            { "data": "RegionCode", "class": "RegionCode", "name": "RegionCode", "autoWidth": true, },
            { "data": "TerritoryCode", "class": "TerritoryCode", "name": "TerritoryCode", "autoWidth": true },
            { "data": "TownCode", "class": "TownCode", "name": "TownCode", "autoWidth": true, },
            { "data": "AreaCode", "class": "AreaCode", "name": "AreaCode", "autoWidth": true },
            { "data": "Organization", "class": "Organization", "name": "Organization", "autoWidth": true },
            { "data": "Division", "class": "Division", "name": "Division", "autoWidth": true },
            { "data": "Active", "class": "Active", "name": "Active", "autoWidth": true },
            {
                data: null, render: function (data, type, row) {
                    return "<a href='#' onclick=EditById('" + row.Login_ID + "'); class='btn btn-info'>Edit</a> <a href='#'  onclick=DeleteById('" + row.Login_ID + "'); class='btn btn-danger'>Delete</a>";
                }
            },
        ],
        dom: 'Bfrtip',
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print',

        ],

    });

    BindDropDownRegion('/Login/getRegions');
    BindDropDownRole('/Role/GetAllRoles');
    BindDropDownRoleEdit('/Role/GetAllRoles');
    BindDropDownDesignation('/designation/GetAllDesignation');
    BindDropDownDesignationEdit('/designation/GetAllDesignation');
    $('#redirect').click(function () {

        window.location.href = "/dashboard/dashboard";
    });
    $('#RoleId').change(function () {
        var status = $('#RoleId option:selected').text();
        if (DynamicRoleId != 3 && $('#RoleId').val() != 3 && EditStatus == "") {
            $("#txtUserName").show();
            $("#un").show();
            //$("#ADEmail").show();
            //$("#ue").show();
        }
        if (status == "Admin") {
            $("#txtDesignationID").prop("disabled", true);
            $('#passDiv').show();
        }
        else if (status == "Distributor") {
            $("#txtDesignationID").prop("disabled", true);
            $("#txtUserName").hide();
            //$("#ADEmail").hide();
            $('#passDiv').show();
            $("#un").hide();
        }
        else if (status != "Admin" && status != "Distributor") {
            $("#txtDesignationID").prop("disabled", false);
            $('#passDiv').hide();
        }

        else {
            $("#txtDesignationID").prop("disabled", false);
            $("#txtUserName").show();           
            $("#un").show();
            //$("#ADEmail").show();
            //$("#ue").show();
        }
       
    });

    $('#txtRoleIDUpdate').change(function () {
        var status = $('#txtRoleIDUpdate option:selected').text();

        if (status == "Distributor")
            $("#txtDesignationIDedit").prop("disabled", true);
        else
            $("#txtDesignationIDedit").prop("disabled", false)
    });

    $('#bttnReg').click(function () {
        if (EditStatus == 'Update') {
            
            if (($('#RoleId').val() != "3" && $('#RoleId').val() != "1") && $('#txtDesignationID').val() == '-1') {
                alert('Please choose a user Designation!');
                return false;
            }
            else {
                register('UpdateRegister');
            }         
        }
        else {
            if ($('#RoleId').val() == "-1") {
                alert("kindly Select Role ID ");
            }
            else if ($('#txtRegionCode').val() == "") {
                alert("kindly Select Region Code ");
            }
            else if ($('#txtAreaCode').val() == "") {
                alert("kindly Select Area Code  ");
            }
            else if ($('#txtTerritoryCode').val() == "") {
                alert("kindly Select territory Code ");
            }
            else if ($('#txtTownCode').val() == "") {
                alert("kindly Select Town Code ");
            }
            else if ($('#txtDistributorID').val() == "") {
                alert("kindly Select Distributor ");
            }
            else if ($('#SelectSalesOrg').val() == "") {
                alert("kindly Select Sales Organization");
            }
            else if ($('#SelectDivision').val() == "") {
                alert("kindly Select Division");
            }
            else if ($('#txtUserFirstName').val() == "") {
                alert("Fill User First Name");
            }
            else if ($('#txtUserLastName').val() == "") {
                alert("Fill User Last Name");
            }
            else if ($('#txtUserEmail').val() == "") {
                alert($("#txtUserEmail").val());
                alert("Fill User Email");
            }
            else if (($('#RoleId').val() == "3" || $('#RoleId').val() == '1') && $('#txtPass').val() == "" && $('#txtUserEmail').val() == "") {
                alert("Enter a pass for user");
            }
            else if ($('#RoleId').val() != '3' && $('#txtUserName').val() == '-1' && $('#txtUserName').val() == '') {
                alert('Please choose a user from the drop down list!');
            }
            //else if ($('#RoleId').val() != '3' && $('#ADEmail').val() == '-1' && $('#ADEmail').val() == '') {
            //    alert('Please choose a email from the drop down list!');
            //}
            else if (($('#RoleId').val() != "3" && $('#RoleId').val() != "1") && $('#txtDesignationID').val() == '-1') {

                alert('Please choose a user Designation!');
            }
            else {
                register('RegisterAdd');
            }
        }

    });
    $('#bttnUpdate').click(function () {
        update('RegisterUpdate');
    });

    $('#RegisterLists tbody').on('click', 'button', function () {

        //  var data = table.row($(this).parents("tr")).data();

        var currentRow = $(this).closest("tr");

        var data = $('#RegisterLists').DataTable().row(currentRow).data();

        var updateLogin_ID = (data['Login_ID']);
        // var updateLogin_ID = $(this).closest("tr").find(".Login_ID").text();
        var updateUserFirstName = $(this).closest("tr").find(".UserFirstName").text();
        var updateLastName = $(this).closest("tr").find(".UserLastName").text();
        var updateEmail = $(this).closest("tr").find(".txtUserEmail").text();
        //var updateLastName = (data['UserLastName']).text();
        var updateUserName = $(this).closest("tr").find(".UserName").text();
        //var updateADEmail = $(this).closest("tr").find(".ADEmail").text();
        var updatePass = (data['Pass']);
        var updateDesigantionDesc = $(this).closest("tr").find(".DesigantionDesc").text();
        var updateRele_Desc = $(this).closest("tr").find(".Rele_Desc").text();
        var updateRole_ID = (data['Role_ID']);
        var updateDesignation_ID = (data['Designation_ID']);
        var updateDistributorID = (data['Distributor_ID']);
        var UpdateUserID = (data['User_ID']);
        var updateRegionCode = (data['RegionCode']);
        var updateTerritoryCode = (data['TerritoryCode']);
        var updateTownCode = (data['TownCode']);
        var updateAreaCode = (data['AreaCode']);


        $("#largeModal").modal();
        $("#txtLogin_IDUpdate").val(updateLogin_ID);
        $("#txtUserFirstNameup").val(updateUserFirstName);
        $("#txtUserLastNameup").val(updateLastName);
        $("#txtUserEmailup").val(updateEmail);
        $("#txtUserNameup").val(updateUserName);
        //$("#txtADEmailup").val(updateADEmail);

        $("#txtDesignationIDedit").val(updateDesigantionDesc);
        $("#txtRoleDecsUpdate").val(updateRele_Desc);
        $("#txtDesignationIDedit").val(updateDesignation_ID);
        $("#txtRoleIDUpdate").val(updateRole_ID);
        $("#txtDistributorIDUpdate").val(updateDistributorID);
        $("#UserIDUpdate").val(UpdateUserID);

        $("#txtRegionCode1").val(updateRegionCode);
        $("#txtTownCode1").val(updateTownCode);
        $("#txtAreaCode1").val(updateAreaCode);
        $("#txtTerritoryCode1").val(updateTerritoryCode);

        var status = $('#txtRoleIDUpdate option:selected').text();
        if (status == "Distributor") {
            $("#txtDesignationIDedit").prop("disabled", true);
        }
        else {
            $("#txtDesignationIDedit").prop("disabled", false);
        }
       

    });

    $('#txtRoleIDUpdate').change(function () {
        var rol = $('#txtRoleIDUpdate').val();
        $('#txtDistributorIDUpdate').html('');
        $.ajax({
            type: "post",
            url: "/Role/GetDistrict?Role_ID=" + rol,
            data: { Role_ID: rol },
            datatype: "json",
            traditional: true,
            success: function (data) {
                var s1 = '<option value="-1"></option>';
                for (var i = 0; i < data.length; i++) {
                    s1 += '<option value="' + data[i].Distributor_ID + '">' + data[i].Distributor_ID + ' - ' + data[i].Distributor_Name + '</option>';
                }
                $("#txtDistributorIDUpdate").html(s1);
            }

            //{
            //    $.each(data, function (index, value) {
            //        $('#Distributor_ID').append('<option value="' + value.Distributor_ID + '">' + value.Distributor_Name + '</option>');
            //    });
            //}
        });
    });

    $("#drpRegions").change(function () {
        var rol = $('#drpRegions').val();
        if (rol != null && rol.length > 1)
            rol = rol.join(", ")

        $('#txtRegionCode').val(rol);
        $.ajax({
            type: "POST",
            url: "getAllArea?regionCode=" + rol,
            data: { regionCode: rol },
            datatype: "json",
            traditional: true,
            success: function (data) {
                var s1 = '';//<option value="">Select Area</option>
                for (var i = 0; i < data.length; i++) {
                    s1 += '<option value="' + data[i].AreaCode + '">' + data[i].AreaDesc + '</option>';
                }
                $("#drpArea").attr("multiple", "multiple");
                $("#drpArea").html(s1);
                $("#drpArea").multiselect({
                    columns: 1,
                    placeholder: 'Please Select Area',
                    search: true,
                    searchOptions: {
                        'default': 'Search'
                    },
                    selectAll: true
                });

                var data = AreaArray;
                if (data != null) {
                    var AreaArray1 = data.split(",");
                    $('#drpArea').val(AreaArray1);
                }
                if (AreaArray1 != null && AreaArray1.length >= 1) {
                    $('#drpArea').trigger("change");
                }
                $('#drpArea').multiselect('reload');
            }

        });
    });

    $("#drpArea").change(function () {
        var rol = $('#drpArea').val();
        if (rol != null && rol.length > 1)
            rol = rol.join(", ")
        $('#txtAreaCode').val(rol);
        $.ajax({
            type: "POST",
            url: "getAllTerritory?AreaCode=" + rol,
            data: { AreaCode: rol },
            datatype: "json",
            traditional: true,
            success: function (data) {
                var s1 = '';//<option value="">Select Territory</option>
                for (var i = 0; i < data.length; i++) {
                    s1 += '<option value="' + data[i].TerritoryCode + '">' + data[i].TerritoryDesc + '</option>';
                }
                $("#drpTerritory").attr("multiple", "multiple");
                $("#drpTerritory").html(s1);
                $("#drpTerritory").multiselect({
                    columns: 1,
                    placeholder: 'Please Select Territory',
                    search: true,
                    searchOptions: {
                        'default': 'Search'
                    },
                    selectAll: true
                });
                $("#drpTerritory").multiselect("reload");

                var data = Teritorrydata;
                if (data == null)
                    return;
                var TerritoryArray = data.split(",");
                //var PushAreaAray = [];
                //$.each(AreaArray1, function (key, value) {

                //    PushAreaAray.push("SA" + $.trim(value));
                //});
                $('#drpTerritory').val(TerritoryArray);
                $('#drpTerritory').multiselect('reload');
                if (TerritoryArray.length >= 1) {
                    $('#drpTerritory').trigger("change");
                }
            }
        });
    });

    $("#drpTerritory").change(function () {
        var rol = $('#drpTerritory').val();
        if (rol != null && rol.length > 1)
            rol = rol.join(", ")
        $('#txtTerritoryCode').val(rol);
        $.ajax({
            type: "POST",
            url: "getAllTown?TerritoryCode=" + rol,
            data: { TerritoryCode: rol },
            datatype: "json",
            traditional: true,
            success: function (data) {
                var s1 = '';//<option value="">Select Town</option>
                for (var i = 0; i < data.length; i++) {
                    s1 += '<option value="' + data[i].TownCode + '">' + data[i].TownDesc + '</option>';
                }
                $("#drpTown").attr("multiple", "multiple");
                $("#drpTown").html(s1);
                $("#drpTown").multiselect({
                    columns: 1,
                    placeholder: 'Please Select Town',
                    search: true,
                    searchOptions: {
                        'default': 'Search'
                    },
                    selectAll: true
                });
                $("#drpTown").multiselect("reload");

                var data = TownData;
                if (data == null)
                    return;

                var TownArray = data.split(",");
                $('#drpTown').val(TownArray);
                $('#drpTown').multiselect('reload');
                if (TownArray.length >= 1) {
                    $('#drpTown').trigger("change");
                }
            }
        });
    });

    $('#drpTown').change(function () {

        var Region = $('#drpRegions').val();
        if (Region != null && Region.length > 1)
            Region = Region.join(", ")
        var Area = $('#drpArea').val();
        if (Area != null && Area.length > 1)
            Area = Area.join(", ")
        var Territory = $('#drpTerritory').val();
        if (Territory != null && Territory.length > 1)
            Territory = Territory.join(", ")
        var Town = $('#drpTown').val();
        if (Town != null && Town.length > 1)
            Town = Town.join(", ")
        $('#txtTownCode').val(Town);
        $.ajax({
            type: "post",
            url: "GetDistrict",
            data: {
                Region: Region,
                Area: Area,
                Territory: Territory,
                Town: Town
            },
            datatype: "json",
            traditional: true,
            success: function (data) {
                var s1 = '';
                for (var i = 0; i < data.length; i++) {
                    var CustomerName = isNaN(parseInt(data[i].Distributor_ID)) ? data[i].Distributor_Name : data[i].Distributor_Name + ' (' + parseInt(data[i].Distributor_ID) + ')';
                    s1 += '<option value="' + data[i].Distributor_ID + '">' + CustomerName + '</option>';
                }
                $("#txtDistributorID").attr("multiple", "multiple");
                $("#txtDistributorID").html(s1);
                $("#txtDistributorID").multiselect({
                    columns: 1,
                    placeholder: 'Please Select Distributors',
                    search: true,
                    searchOptions: {
                        'default': 'Search'
                    },
                    selectAll: true
                });
                $("#txtDistributorID").multiselect("reload");

                var data = DistibutorData;
                if (data != null && data.length > 0) {
                    var DistributorArray = data.split(",");
                    $('#txtDistributorID').val(DistributorArray);
                    $('#txtDistributorID').multiselect('reload');
                }
                if (DistributorArray.length >= 1) {
                    $('#txtDistributorID').trigger("change");
                }
            }

        });
    });

    $('#txtDistributorID').change(function () {
        var rol = $('#txtDistributorID').val();

        var s1 = '';
        s1 += '<option value="1000">EBM</option>';
        s1 += '<option value="2000">CFL</option>';
        $("#SelectSalesOrg").attr("multiple", "multiple");
        $("#SelectSalesOrg").html(s1);
        $("#SelectSalesOrg").multiselect({
            columns: 1,
            placeholder: 'Please Select Sales Organization',
            search: true,
            searchOptions: {
                'default': 'Search'
            },
            selectAll: true
        });

        var data = SaleOrgData;
        if (data == null)
            return;
        //alert(data);
        var AreaArray1 = data.split(",");
        $('#SelectSalesOrg').val(AreaArray1);
        $('#SelectSalesOrg').multiselect('reload');
        if (AreaArray1.length >= 1) {
            $('#SelectSalesOrg').trigger("change");
        }
    });

    $('#SelectSalesOrg').change(function () {
        if ($('#SelectSalesOrg').children("option:selected").val() < 0) {
            $("#SelectDivision").html('');
            $("#SelectDivision").multiselect("reload");
        }
        else {

            var s2 = '<option value="10">Biscuit</option>';
            s2 += '<option value="30">Cake</option>';
            $("#SelectDivision").attr("multiple", "multiple");
            $("#SelectDivision").html(s2);
            $("#SelectDivision").multiselect({
                columns: 1,
                placeholder: 'Please Select Division',
                search: true,
                searchOptions: {
                    'default': 'Search'
                },
                selectAll: true
            });
            $("#SelectDivision").multiselect("reload");
            var data = DivisionData;
            //alert(data);
            if (data == null)
                return;
            var AreaArray1 = data.split(",");
            $('#SelectDivision').val(AreaArray1);
            $('#SelectDivision').multiselect('reload');
        }
    });

    //At the end of document dot ready
    ADList();
    //ADEmail();
});

function register(url) {

    var RegionCode = $("#txtRegionCode").val();
    var AreaCode = $("#txtAreaCode").val();
    var TerritoryCode = $("#txtTerritoryCode").val();
    var TownCode = $("#txtTownCode").val();
    var Role_ID = $("#RoleId").val();
    var UserEmail = $("#txtUserEmail").val();
    
    var login = {
        Role_ID: Role_ID,
        User_ID: EditUserID,
        Pass: $("#txtPass").val(),
        Distributor_ID: $("#txtDistributorID").val() == null ? '' : $("#txtDistributorID").val().join(", "),
        RegionCode: RegionCode,
        AreaCode: AreaCode,
        TerritoryCode: TerritoryCode,
        TownCode: TownCode,
        SalesOrg: $('#SelectSalesOrg').val() == null ? '' : $('#SelectSalesOrg').val().join(", "),
        Division: $('#SelectDivision').val() == null ? '' : $('#SelectDivision').val().join(", "),
        UserName: Role_ID == 3 || Role_ID == 1 ? $('#txtUserFirstName').val() : $('#txtUserName').val(),
        UserEmail: UserEmail,
        Active: $('#chkActive').is(":checked")
    }
    var User = {
        User_ID: EditUserID,
        Designation_ID: $("#txtDesignationID").val(),
        UserFirstName: $("#txtUserFirstName").val(),
        UserLastName: $("#txtUserLastName").val(),
        IPAddress: 0
    }
    var obj = new Object();

    var model = {
        "login": login,
        "User": User
    }
    Common.Ajax('POST', url, JSON.stringify(model), 'json', successUserRegistrationHandler);
}

function UpdateRegiser(url) {
    var LoginUpdate = {
        Login_ID: $("#txtLogin_IDUpdate").val(),
        Role_ID: $("#txtRoleIDUpdate").val(),
        UserName: $("#txtUserNameup").val(),
        UserEmail: $("#txtUserEmailup").val(),
        Pass: $("#txtPassup").val(),
        //Distributor_ID: $("#txtDistributorIDUpdate").val(),
        RegionCode: $("#txtRegionCode1").val(),
        AreaCode: $("#txtAreaCode1").val(),
        TerritoryCode: $("#txtTerritoryCode1").val(),
        TownCode: $("#txtTownCode1").val(),



    }
    var UserUpdate = {

        Designation_ID: $("#txtDesignationIDedit").val(),
        UserFirstName: $("#txtUserFirstNameup").val(),
        UserLastName: $("#txtUserLastNameup").val(),
        User_ID: $("#UserIDUpdate").val(),
    }
    var model = {
        "login": LoginUpdate,
        "User": UserUpdate
    }
    // alert(JSON.stringify(model));
    Common.Ajax('POST', url, JSON.stringify(model), 'json', successUpdateUserRegistrationHandler);
}




function BindDropDownRegion(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownRegionHandler);
}
function BindDropDownRole(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownRoleHandler);
}
function BindDropDownRoleEdit(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownRoleEditableHandler);
}
function BindDropDownRoleEditableHandler(response) {
    var ss = '<option value="-1">Please Select a Role</option>';
    for (var i = 0; i < response.length; i++) {
        ss += '<option value="' + response[i].Role_ID + '">' + response[i].Rele_Desc + '</option>';
    }
    $("#txtRoleIDUpdate").html(ss);
}

function BindDropDownDesignation(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownDesignationHandler);
}
function BindDropDownDesignationEdit(url) {
    Common.Ajax('GET', url, {}, 'json', BindDropDownDesignationEditableHandler);
}
function BindDropDownDesignationEditableHandler(response) {
    var s = '<option value="-1"></option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Designation_ID + '">' + response[i].DesigantionDesc + '</option>';
    }
    $("#txtDesignationIDedit").html(s);
    //$('#txtDesignationID [value=#txtDesignationID]').attr('selected', 'true');
}
function BindDropDownRegionHandler(response) {
    var s = '';//<option value="0">Please Select a region</option>
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].RegionCode + '">' + response[i].RegionDesc + '</option>';
    }
    $("#drpRegions").attr("multiple", "multiple");
    $("#drpRegions").html(s);
    $("#drpRegions").multiselect({
        columns: 1,
        placeholder: 'Please Select region',
        search: true,
        searchOptions: {
            'default': 'Search'
        },
        selectAll: true
    });
    //$("#drpRegions").multiselect("reload");
}
function BindDropDownRoleHandler(response) {
    var s = '<option value="-1">Please Select a Role</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Role_ID + '">' + response[i].Rele_Desc + '</option>';
    }
    $("#RoleId").html(s);
}
function BindDropDownDesignationHandler(response) {
    var s = '<option value="-1">Please Select a Designation</option>';
    for (var i = 0; i < response.length; i++) {
        s += '<option value="' + response[i].Designation_ID + '">' + response[i].DesigantionDesc + '</option>';
    }
    $("#txtDesignationID").html(s);
}
function successUserRegistrationHandler(response) {

    if (response == '1') {
        $('#successAlert').show('fade');
        setTimeout(function () {
            $('#successAlert').hide('fade');
        }, 5000);
        $("#formID")[0].reset();
        ResetDrowDowns();
        $('#RegisterLists').DataTable().ajax.reload();
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
    if (response == '2') {
        //alert("User Modified Successfully!");
        $('#UpdatesuccessAlert').show('fade');
        setTimeout(function () {
            $('#UpdatesuccessAlert').hide('fade');
            location.reload();
        }, 3000);
        $("#formID")[0].reset();
        ResetDrowDowns();
        $('#RegisterLists').DataTable().ajax.reload();
    }
}

function successUpdateUserRegistrationHandler(response) {

    if (response == '2') {
        $('#UpdatesuccessAlert').show('fade');
        setTimeout(function () {
            $('#UpdatesuccessAlert').hide('fade');
        }, 5000);
        $("#formID")[0].reset();
        ResetDrowDowns();
        $('#RegisterLists').DataTable().ajax.reload();

    }
    if (response == '-2') {
        $('#warningAlert').show('fade');
        setTimeout(function () {
            $('#UpdatewarningAlert').hide('fade');
        }, 5000);

        setTimeout(function () {
            $('#UpdatewarningAlert').hide('fade');
        }, 5000);
    }
}

function DeleteById(id) {
    var dataToPost = '{"designation_id":"' + id + '"}';
    Common.Ajax('DELETE', "DeleteDesignation", dataToPost, 'json', DeleteUserHandler);
}

function EditById(loginid) {
    Common.Ajax("POST", 'EditUser', "{'LoginId' : '" + loginid + "'}", 'json', EditUserHandler);
}

function EditUserHandler(r) {
    EditStatus = 'Update';
    $('#RoleId').val(r[0].Role_ID);
    
    $('#txtUserFirstName').val(r[0].UserFirstName);
    $('#txtUserLastName').val(r[0].UserLastName);
    $('#txtUserName').val(r[0].UserName);
    $('#txtUserEmail').val(r[0].UserEmail);
    $('#txtPass').val(r[0].Pass);
    $('#txtRegionCode').val(r[0].RegionCode);
    $('#txtAreaCode').val(r[0].AreaCode);
    $('#txtTerritoryCode').val(r[0].TerritoryCode);
    $('#txtTownCode').val(r[0].TownCode);
    $('#txtDesignationIDedit').val(r[0].DesigantionDesc);
    $('#chkActive').prop('checked', r[0].Active);
    DynamicRoleId = r[0].Role_ID;
    var dataarray = $.trim(r[0].RegionCode).split(",");
    $('#drpRegions').val(dataarray);
    $('#drpRegions').multiselect('reload');
    EditUserID = r[0].User_ID;
    Teritorrydata = r[0].TerritoryCode;
    TownData = r[0].TownCode;
    AreaArray = r[0].AreaCode;
    DesigantionDesc = r[0].DesigantionDesc;
    Designation_ID = r[0].Position;
    SaleOrgData = r[0].SalesOrg;
    DivisionData = r[0].Division;
    DistibutorData = r[0].Distributor_ID;
    EditUserName = r[0].UserName;
    EditUserEmail = r[0].UserEmail;

    if (r[0].SalesOrg != null) {
        $('#SelectSalesOrg').val(r[0].SalesOrg.trim().split(','));
        $('#SelectSalesOrg').multiselect('reload');
        if (r[0].SalesOrg.length >= 1) {
            $('#SelectSalesOrg').trigger("change");
        }
        if (r[0].Division != null) {
            $('#SelectDivision').val(r[0].Division.trim().split(','));
            $('#SelectDivision').multiselect('reload');
        }
    }
   

    $('#drpRegions').trigger("change");

    if (r[0].Role_ID == '3') {
        $("#txtUserName").hide();
        $("#un").hide();
    }
    else {
        $("#txtUserName").show();
        $("#un").show();
    }

    $('#txtUserFirstName').prop('readOnly', true);
    $('#txtUserLastName').prop('readOnly', true);
    $("#txtUserName").val(r[0].UserName);
    $("#un").val(r[0].UserName);
    if ($('#RoleId').val() == 3 || $('#RoleId').val() == 1) {
        $('#passDiv').show();
        $("#txtDesignationID").prop("disabled", true);
  
    } else {

        $('#passDiv').hide();
      
        $("#txtDesignationID").prop("disabled", false);
    }
    //alert(Designation_ID);
    $('#txtDesignationID').val(Designation_ID);
    $('#hdEditMode').show();
    $('#bttnReg').val('Modify User');

}

function EditRoles(RoleID) {
    var url = "";
    $("#largeModal").modal();
}

function DeleteUserHandler(r) {
    alert(r);
    location.reload(true);
}

function ADList() {
    $.ajax({
        type: "post",
        url: "GetUserDrop",
        datatype: "json",
        traditional: true,
        success: function (data2) {
            var su = '<option value="-1" selected="selected" placeholder="Choose Username">Choose Username</option>';
            for (var i = 0; i < data2.length; i++) {
                su += '<option value="' + data2[i].UserName + '">' + data2[i].UserName + '</option>';
            }
            $("#txtUserName").html(su);
            $("#txtUserName").val(EditUserName);
        }
    });
}

//function ADEmail() {
//    $.ajax({
//        type: "post",
//        url: "GetEmail",
//        datatype: "json",
//        traditional: true,
//        success: function (data2) {
//            var su = '<option value="-1" selected="selected" placeholder="Choose ADEmail">Choose Email</option>';
//            for (var i = 0; i < data2.length; i++) {
//                su += '<option value="' + data2[i].UserADEmail + '">' + data2[i].UserADEmail + '</option>';
//            }
//            $("#ADEmail").html(su);
//            $("#ADEmail").val(EditEmail);
//        }
//    });
//}



function ResetDrowDowns() {
    $('#drpRegions').multiselect('reload');
    $('#drpArea').multiselect('reload');
    $('#drpTerritory').multiselect('reload');
    $('#drpTown').multiselect('reload');
    $('#txtDistributorID').multiselect('reload');
    $('#SelectSalesOrg').multiselect('reload');
    $('#SelectDivision').multiselect('reload');
}