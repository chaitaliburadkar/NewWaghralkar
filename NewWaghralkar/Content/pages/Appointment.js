var SaveAppointment = function () {
  //  var Id = $("#txtId").val();
    var Name = $("#txtName").val();
    var Email = $("#txtEmail").val();
    var City = $("#txtCity").val();
    var Mobile = $("#txtMobile").val();
    var Date = $("#txtDate").val();
    var Gender = $("#txtGender").val();
    var Message = $("#txtMessage").val();

    var model = {
       // Id: Id,
        Name: Name,
        Email: Email,
        City: City,
        Mobile: Mobile,
        Date: Date,
        Gender: Gender,
        Message: Message
    };

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