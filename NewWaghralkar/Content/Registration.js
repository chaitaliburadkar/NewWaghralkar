var SaveForm = function () {
    debugger;
    var Cust_Name = $("#txtname").val();
    var Contact_No = $("#txtno").val();
    var Email = $("#txtemail").val();
    var Password = $("#txtpass").val();
    var Status = $("#txtstatus").val();
    var model = {

        Cust_Name: Cust_Name,
        Contact_No: Contact_No,
        Email: Email,
        Password: Password,
        Status: Status
    };

    $.ajax({
        url: "/Registration/SaveForm",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function(response) {
            alert(response.Message);
        },
        Error: function(response) {
            alert(response.Message);
        }

    });
    
}
