$(document).ready(function () {
    GetAppointmentList();
});
var SaveAppointment = function () {
    debugger;
    var Id = $("#hdnId").val();
    var Name = $("#txtappotName").val();
    var Email = $("#txtappotEmail").val();
    var City = $("#txtappotCity").val();
    var Mobile = $("#txtappotMobile").val();
    var Date = $("#txtDate").val();
    var Gender = $("#txtGender").val();
    var Message = $("#txtMessage").val();

    var model = {
        Id: Id,
        Name: Name,
        Email: Email,
        City: City,
        Mobile: Mobile,
        Date: Date,
        Gender: Gender,
        Message: Message
    };
    debugger;
    $.ajax({
        url: "/Appointment/SaveAppointment",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.Message);
        },
        Error: function (response) {
            alert(response.Message);
        }
    });
}

var GetAppointmentList = function () {
    debugger;
    $.ajax({
        url: "/Appointment/GetAppointmentList",
        method: "post",
        contentType: "application/Json;charset=utf-8",
        dataType: "Json",
        async: false,
        success: function (response) {
            var html = "";
            $("#Appointment tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Id +
                    "</td><td>" + elementValue.Name +
                    "</td><td>" + elementValue.Email +
                    "</td><td>" + elementValue.City +
                    "</td><td>" + elementValue.Mobile +
                    "</td><td>" + elementValue.Date +
                    "</td><td>" + elementValue.Gender +
                    "</td><td>" + elementValue.Message
                "</td><td><input type='button' value='Delete' onclick='deletePhotoGallary(" + elementValue.PhotoId + ")'class='btn btn-danger'/><input type='button' value='Update' onclick='GetPhotoGallarybyId(" + elementValue.PhotoId + ")' class='btn btn-info'/></td></tr>";

            });
            $("#Appointment tbody").append(html);
        }
    });

}