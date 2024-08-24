var Savereg = function () {
    debugger;
    var id = $("#hdnId").val();
    var name = $("#txtName").val();
    var email = $("#txtEmail").val();
    var mobile = $("#txtMobile").val();
    var city = $("#txtCity").val();
    var gender = $("#txtGender").val();
    var appointment_date = $("#txtAppointment").val();

    var model = {
        Id: id,
        Name: name,
        Email: email,
        Mobile: mobile,
        City: city,
        Gender: gender,
        Appointment_date: appointment_date,

    };

    $.ajax({
        url: "/BookNow/Savereg",
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