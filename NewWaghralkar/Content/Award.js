$(document).ready(function () {
    GetAwardsList();
    GetAwardsDetailById();
    Redirectdetails();
    GetAwardList2();
});
var SaveReg = function () {
    debugger;
    $formData = new FormData();
    var Photo = document.getElementById('txtPhoto1');
    var Photo = document.getElementById('txtPhoto2');
    if (Photo.files.length > 0) {
        for (var i = 0; i < Photo.files.length; i++) {
            $formData.append('txtPhoto1-' + i, Photo.files[i]);
            $formData.append('txtPhoto2-' + i, Photo.files[i]);
        }
    }
    var activityId = $("#hdnId").val();
    var title = $("#txttitle").val();
    var details = $("#txtdetails").val();
    var image1 = $("#txtPhoto1").val();
    var image2 = $("#txtPhoto2").val();
    var type = $("#txtType").val();
    var date = $("#txtdate").val();

    $formData.append('ActivityId', activityId);
    $formData.append('Title', title);
    $formData.append('Details', details);
    $formData.append('Image1', image1);
    $formData.append('Image2', image2);
    $formData.append('Type', type);
    $formData.append('Date', date);

    debugger;
    $.ajax({
        url: "/Awards/SaveReg",
        method: "post",
        data: $formData,
        contentType: "application/json;charset=utf-8",
        contentType: false,
        processData: false,
        async: false,
        success: function (response) {
            alert(response.Message);
            location.reload();
        }
    });
}
var GetAwardsList = function () {
    debugger;
    $.ajax({
        url: "/Awards/GetAwardsList",
        method: "post",
        contentType: "application/Json;charset=utf-8",
        dataType: "Json",
        async: false,
        success: function (response) {
            var html = "";
            $("#Awards tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.ActivityId +
                    "</td><td>" + elementValue.Title +
                    "</td><td>" + elementValue.Details +
                    "</td><td>" + elementValue.Image1 +
                    "</td><td>" + elementValue.Image2 +
                    "</td><td>" + elementValue.Type +
                    "</td><td>" + elementValue.Date +
                    "</td><td><input type='button' value='Update' onclick=' GetAwardsDetailById(" + elementValue.ActivityId + ")' class='btn btn-info'/>&nbsp <input type='button' value='Delete' onclick='DeleteAwards(" + elementValue.ActivityId + ")'class='btn btn-danger'/> &nbsp <input type='button' value='Redirectdetails' onclick='details(" + elementValue.ActivityId + ")'class='btn btn-success'/></td></tr>";

            });
            $("#Awards tbody").append(html);
        }
    });

}
var DeleteAwards = function (ActivityId) {
    debugger;
    model = { ActivityId: ActivityId }
    $.ajax({
        url: "/Awards/DeleteAwards",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.model);
        }
    })
}

var GetAwardsDetailById = function (ActivityId) {
    debugger;
    var model = { ActivityId: ActivityId }
    $.ajax({
        url: "/Awards/GetAwardsDetailById",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#hdnId").val(response.model.ActivityId);
            $("#txttitle").val(response.model.Title);
            $("#txtdetails").val(response.model.Details);
            $("#txtType").val(response.model.Type);
            $("#txtdate").val(response.model.Date);
            $("#txtPhoto1").val(response.model.Image1);
            $("#txtPhoto2").val(response.model.Image2);
        }
    });
}

var GetSearchList = function () {
    var NAME = $("#txtName").val();
    var model = { Name: NAME };


    $.ajax({
        url: "/Awards/GetSearchList",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#Awards tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.ActivityId +
                    "</td><td>" + elementValue.Title +
                    "</td><td>" + elementValue.Details +
                    "</td><td>" + elementValue.Image1 +
                    "</td><td>" + elementValue.Image2 +
                    "</td><td>" + elementValue.Type +
                    "</td><td>" + elementValue.Date
                "</td></tr > ";
            });
            $("#Awards").append(html);

        }
    });
}

var details = function (ActivityId) {
    window.location.href = "/Awards/AwardsDetailsIndex?ActivityId=" + ActivityId;

}
var Redirectdetails = function () {
    debugger;
    var ActivityId = $("#hdnId").val();
    model = { ActivityId: ActivityId }
    $.ajax({
        url: "/Awards/GetAwardsDetailById",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#hdnId").text(response.model.ActivityId);
            $("#txttitle").text(response.model.Title);
            $("#txtdetails").text(response.model.Details);
            $("#txtType").text(response.model.Type);
            $("#txtdate").text(response.model.Date);
            $("#txtPhoto1").text(response.model.Image1);
            $("#txtPhoto2").text(response.model.Image2);

        }
    });
}
//var GetAwardList2 = function () {
//    debugger;
//    $.ajax({
//        url: "/Awards/GetAwardList2",
//        method: "Post",
//        contentType: "application/Json;charset=utf-8",
//        dataType: "Json",
//        async: false,
//        success: function (response) {
//            var html = "";
//            $("#Awards tbody").empty();
//            $.each(response.model, function (index, elementValue) {
//                html += "<tr><td>" + elementValue.Srno +
//                    "</td><td>" + elementValue.ActivityId +
//                    "</td><td>" + elementValue.Title +
//                    "</td><td>" + elementValue.Details +
//                    "</td><td>" + elementValue.Image1 +
//                    "</td><td>" + elementValue.Image2 +
//                    "</td><td>" + elementValue.Type +
//                    "</td><td>" + elementValue.Date +
//                    "</td></tr>";

//            });
//            $("#Awards tbody").append(html);
//        }
//    });

//}