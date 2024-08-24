$(document).ready(function () {
    GetNewsList();
    DeleteNews();
    GetNewsbyId();
    Redirectdetails();
    GetNewsList2();
});

var SaveNews = function () {
    debugger;
    $formData = new FormData();
    var Photo = document.getElementById('txtImage1');
    var Photo = document.getElementById('txtImage2');
    if (Photo.files.length > 0) {
        for (var i = 0; i < Photo.files.length; i++) {
            $formData.append('txtImage1-' + i, Photo.files[i]);
            $formData.append('txtImage2-' + i, Photo.files[i]);
        }
    }
    var Id = $("#hdnid").val();
    var Enter_News_Title = $("#txtTitle").val();
    var Type = $("#txtType").val();
    var Enter_News_Details = $("#txtDetails").val();
    var Date = $("#date").val();
    var Choose1File = $("#txtImage1").val();
    var Choose2File = $("#txtImage2").val();

    $formData.append('Id', Id);
    $formData.append('Enter_News_Title', Enter_News_Title);
    $formData.append('Type', Type);
    $formData.append('Enter_News_Details', Enter_News_Details);
    $formData.append('Date', Date);
    $formData.append('Choose1File', Choose1File);
    $formData.append('Choose2File', Choose2File);

    debugger;
    $.ajax({
        url: "/NEWS/SaveNews",
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


var GetNewsList = function () {
    debugger;
    $.ajax({
        url: "/NEWS/GetNewsList",
        method: "post",
        contentType: "application/Json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tbl_AddNews tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Id +
                    "</td><td>" + elementValue.Enter_News_Title +
                    "</td><td>" + elementValue.Type +
                    "</td><td>" + elementValue.Enter_News_Details +
                    "</td><td>" + elementValue.Date +
                    "</td><td>" + elementValue.Choose1File +
                    "</td><td>" + elementValue.Choose2File +
                    "</td><td><input type='button' value='Delete' onclick='DeleteNews(" + elementValue.Id + ")'class='btn btn-danger'/> &nbsp <input type='button' value='Update' onclick='GetNewsbyId(" + elementValue.Id + ")' class='btn btn-info'/>&nbsp <input type='button' value='Redirectdetails' onclick='details(" + elementValue.Id + ")'class='btn btn-success'/></td></tr>";

            });
            $("#tbl_AddNews tbody").append(html);
        }
    });

}
var DeleteNews = function (Id) {
    debugger;
    model = { Id: Id }
    $.ajax({
        url: "/NEWS/DeleteNews",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.model);
            location.reload();
        }
    })
}

var GetNewsbyId = function (Id) {
    debugger;
    model = { Id: Id }
    $.ajax({
        url: "/NEWS/GetNewsbyId",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,

        success: function (response) {

            $("#hdnid").val(response.model.Id);
            $("#txtTitle").val(response.model.Enter_News_Title);
            $("#txtType").val(response.model.Type);
            $("#txtDetails").val(response.model.Enter_News_Details);
            $("#date").val(response.model.Date);
            $("#txtImage1").val(response.model.Choose1File);
            $("#txtImage2").val(response.model.Choose2File);

        }
    });
}
var details = function (Id) {
    window.location.href = "/NEWS/NewsDetailsIndex?Id=" + Id;
}
var Redirectdetails = function () {
    var Id = $("#hdnid").val();
    debugger;
    model = { Id: Id }
    $.ajax({
        url: "/NEWS/GetNewsbyId",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#hdnid").text(response.model.Id);
            $("#txtTitle").text(response.model.Enter_News_Title);
            $("#txtType").text(response.model.Type);
            $("#txtDetails").text(response.model.Enter_News_Details);
            $("#date").text(response.model.Date);
            $("#txtImage1").text(response.model.Choose1File);
            $("#txtImage2").text(response.model.Choose2File);
        }
    });
}
//var GetNewsList2 = function () {
//    debugger;
//    $.ajax({
//        url: "/News/GetNewsList2",
//        method: "Post",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        async: false,
//        success: function (response) {
//            var html = "";
//            $("#tbl_AddNews tbody").empty();
//            $.each(response.model, function (index, elementValue) {
//                html += "<tr><td>"+ elementValue.Id +
//                    "</td><td>" + elementValue.Enter_News_Title +
//                    "</td><td>" + elementValue.Type +
//                    "</td><td>" + elementValue.Enter_News_Details +
//                    "</td><td>" + elementValue.Date +
//                    "</td><td>" + elementValue.Choose1File +
//                    "</td><td>" + elementValue.Choose2File +
//                    "</td></tr>";

//            });
//            $("#tbl_AddNews tbody").append(html);
//        }
//    });

//}