$(document).ready(function () {
   /* GetGallaryList();*/
    GetPhotoGallaryList();
    /*Redirectdetails();*/
});

//var GetGallaryList = function () {
//    debugger
//    $.ajax({
//        url: "/Gallary/GetGallaryList",
//        method: "post",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        async: false,
//        success: function (response) {

//            var html = "";
//            $("#Photogallaries tbody").empty();
//            $.each(response.model, function (index, elementValue) {
//                html += "<tr><td>" + elementValue.Srno +
//                    "</td><td>" + elementValue.PhotoId +
//                    "</td><td>" + elementValue.Title +
//                    "</td><td>" + elementValue.Photo1 +
//                    "</td><td>" + elementValue.Photo2 +
//                    "</td><td>" + elementValue.Type +
//                    "</td></tr>";
//            });

//            $("#Photogallaries tbody").append(html);
//        }
//    });
//}

var SaveGallary = function () {
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
    var PhotoId = $("#txtphotoId").val();
    var Title = $("#txttitle").val();
    var Photo1 = $("#txtPhoto1").val();
    var Photo2 = $("#txtPhoto2").val();
    var Type = $("#txtType").val();

    $formData.append('PhotoId', PhotoId);
    $formData.append('Title', Title);
    $formData.append('Photo1', Photo1);
    $formData.append('Photo2', Photo2);
    $formData.append('Type', Type);

    debugger;
    $.ajax({
        url: "/Gallary/SaveGallary",
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
var GetPhotoGallaryList = function () {
    debugger;
    $.ajax({
        url: "/Gallary/GetPhotoGallaryList",
        method: "post",
        contentType: "application/Json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#Photogallaries tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.PhotoId +
                    "</td><td>" + elementValue.Title +
                    "</td><td>" + elementValue.Photo1 +
                    "</td><td>" + elementValue.Photo2 +
                    "</td><td>" + elementValue.Type +
                    "</td><td><input type='button' value='Delete' onclick='deletePhotoGallary(" + elementValue.PhotoId + ")'class='btn btn-danger'/><input type='button' value='Update' onclick='GetPhotoGallarybyId(" + elementValue.PhotoId + ")' class='btn btn-info'/>&nbsp <input type='button' value='Redirectdetails' onclick='details(" + elementValue.PhotoId + ")'class='btn btn-success'/></td></tr>";

            });
            $("#Photogallaries tbody").append(html);
        }
    });

}

var deletePhotoGallary = function (PhotoId) {
    debugger;
    model = { PhotoId: PhotoId }
    $.ajax({
        url: "/Gallary/deletePhotoGallary",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.model);
        }
    })
}

var GetPhotoGallarybyId = function (PhotoId) {
    debugger
    model = { PhotoId: PhotoId }
    $.ajax({
        url: "/Gallary/GetPhotoGallarybyId",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,

        success: function (response) {

            $("#txtphotoId").val(response.model.PhotoId);
            $("#txttitle").val(response.model.Title);
            $("#txtType").val(response.model.Type);
            $("#txtPhoto1").val(response.model.Photo1);
            $("#txtPhoto2").val(response.model.Photo2);

        }
    });
}

var GetSearchList = function () {
    var NAME = $("#txtName").val();
    var model = { Name: NAME };


    $.ajax({
        url: "/Gallary/GetSearchList",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#Photogallaries tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.PhotoId +
                    "</td><td>" + elementValue.Title +
                    "</td><td>" + elementValue.Photo1 +
                    "</td><td>" + elementValue.Photo2 +
                    "</td><td>" + elementValue.Type
                "</td></tr > ";
            });
            $("#Photogallaries").append(html);

        }
    });
}

var details = function (PhotoId) {
    window.location.href = "/Gallary/DetailsIndex?PhotoId=" + PhotoId;
}
var Redirectdetails = function () {
    var PhotoId = $("#txtphotoId").val();
    debugger;
    model = { PhotoId: PhotoId }
    $.ajax({
        url: "/Gallary/GetPhotoGallarybyId",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#txtphotoId").text(response.model.PhotoId);
            $("#txttitle").text(response.model.Title);
            $("#txtType").text(response.model.Type);
            $("#txtPhoto1").text(response.model.Photo1);
            $("#txtPhoto2").text(response.model.Photo2);
        }
    });
}