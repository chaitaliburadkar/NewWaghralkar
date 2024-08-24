var Savereg = function () {
    debugger;
    var id = $("#hdnId").val();
    var name = $("#txtName").val();
    var email = $("#txtEmail").val();
    var subject = $("#txtSubject").val();
    var message = $("#txtMessage").val();

    var model = {
        Id: id,
        Name: name,
        Email: email,
        Subject: subject,
        Message: message,
        
    };

    $.ajax({
        url: "/Contact/Savereg",
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