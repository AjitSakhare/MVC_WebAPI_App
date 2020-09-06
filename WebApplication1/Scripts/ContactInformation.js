$(document).ready(function () {
    LoadBindData();
});
$(document).on({
    ajaxStart: function () {
        $("#loader").show();
    },
    ajaxStop: function () {
        $("#loader").hide();
    }
});
function LoadBindData() {
    $.ajax({
        type: "GET",
        url: "/GetAllInfoList",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data === "No Record Found") {
                $('#tblBody').append("Zero records found");
                $('#tblBody').css("color", "red");
            }
            else {
                $("#tblBody tr").remove();
                $.each(data, function (i, item) {
                    if (item.Status === true) {
                        item.Status = "Active";
                    }
                    else {
                        item.Status = "Inactive";
                    }
                    var rows = "<tr>" +
                        "<td id='Id'>" + item.Id + "</td>" +
                        "<td id='fname'>" + item.FirstName + "</td>" +
                        "<td id='lname'>" + item.LastName + "</td>" +
                        "<td id='email'>" + item.Email + "</td>" +
                        "<td id='phno'>" + item.PhoneNumber + "</td>" +
                        "<td id='status'>" + item.Status + "</td>" +
                        "<td><a href='#' onclick='return GetRecordToEdit(" + item.Id + ")'>Edit</a> | <a href='#' onclick='DeletRecord(" + item.Id + ")'>Delete</a></td>" +
                        "</tr>"; $('#tblBody').append(rows);
                });
            }
        },
        failure: function () { $('#tblBody').append("Error in loading data"); },
        error: function () { $('#tblBody').append("Error in loading data"); }
    });
}

function GetRecordToEdit(ContInfoId) {
    $.ajax({
        url: "/EditContDetails?id=" + ContInfoId,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ContInfoId').val(result.Id);
            $('#fName').val(result.FirstName);
            $('#lName').val(result.LastName);
            $('#emailId').val(result.Email);
            $('#phoneNo').val(result.PhoneNumber);
            $('#UpdateModal').modal('show');
            $('#btnUpdate').show();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function DeletRecord(ContInfoId) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/DeleteContDetails?id=" + ContInfoId,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                LoadBindData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

function UpdateDetails() {
    var res = validateFields();
    if (res === false) {
        return false;
    }
    var contactInfoObject = {
        Id: $('#ContInfoId').val(),
        FirstName: $('#fName').val(),
        LastName: $('#lName').val(),
        Email: $('#emailId').val(),
        PhoneNumber: $('#phoneNo').val(),
        Status: true
    };
    $.ajax({
        url: "/UpdateContDetails",
        data: JSON.stringify(contactInfoObject),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            LoadBindData();
            if (result === "Updated Successfully") {
                window.location.reload();
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function validateFields() {
    var isValid = true;
    if ($('#fName').val().trim() === "") {
        $('#fName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#fName').css('border-color', 'lightgrey');
    }
    if ($('#lName').val().trim() === "") {
        $('#lName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#lName').css('border-color', 'lightgrey');
    }
    if ($('#emailId').val().trim() === "") {
        $('#emailId').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#emailId').css('border-color', 'lightgrey');
    }
    if ($('#phoneNo').val().trim() === "") {
        $('#phoneNo').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#phoneNo').css('border-color', 'lightgrey');
    }
    return isValid;
}

function clearValidation() {
    $('.field-validation-error').html("");
    $('#phoneNo').css('border-color', 'lightgrey');
    $('#emailId').css('border-color', 'lightgrey');
    $('#lName').css('border-color', 'lightgrey');
    $('#fName').css('border-color', 'lightgrey');
}