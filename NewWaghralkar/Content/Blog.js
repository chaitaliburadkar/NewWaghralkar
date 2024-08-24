$(document).ready(function () {
    GetBlogList();
    Redirectdetails();
    GetBlogList2();
});
var SaveBlog = function () {
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
    var activityId = $("#txtActiveId").val();
    var title = $("#txtTitle").val();
    var details = $("#txtDetails").val();
    var image1 = $("#txtImage1").val();
    var image2 = $("#txtImage2").val();
    var type = $("#txtType").val();
    var date = $("#txtDate").val();

    $formData.append('ActivityId', activityId);
    $formData.append('Title', title);
    $formData.append('Details', details);
    $formData.append('Image1', image1);
    $formData.append('Image2', image2);
    $formData.append('Type', type);
    $formData.append('Date', date);

    debugger;
    $.ajax({
        url: "/Blog/SaveBlog",
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


var GetBlogList = function () {
    debugger;
    $.ajax({
        url: "/Blog/GetBlogList",
        method: "post",
        contentType: "application/Json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#Blogs tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.ActivityId +
                    "</td><td>" + elementValue.Title +
                    "</td><td>" + elementValue.Details +
                    "</td><td>" + elementValue.Image1 +
                    "</td><td>" + elementValue.Image2 +
                    "</td><td>" + elementValue.Type +
                    "</td><td>" + elementValue.Date +
                    "</td><td><input type='button' value='Update' onclick='GetBlogbyId(" + elementValue.ActivityId + ")' class='btn btn-info'/>&nbsp <input type='button' value='Delete' onclick='DeleteBlog(" + elementValue.ActivityId + ")'class='btn btn-danger'/> &nbsp <input type='button' value='Redirectdetails' onclick='details(" + elementValue.ActivityId + ")'class='btn btn-success'/></td></tr>";
            });
            $("#Blogs tbody").append(html);
        }
    });

}
var DeleteBlog = function (ActivityId) {
    debugger;
    model = { ActivityId: ActivityId }
    $.ajax({
        url: "/Blog/DeleteBlog",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.model);
        }
    })
}

var GetBlogbyId = function (ActivityId) {
    debugger;
    model = { ActivityId: ActivityId }
    $.ajax({
        url: "/Blog/GetBlogbyId",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#txtActiveId").val(response.model.ActivityId);
            $("#txtTitle").val(response.model.Title);
            $("#txtDetails").val(response.model.Details);
            $("#txtImage1").val(response.model.Image1);
            $("#txtImage2").val(response.model.Image2);
            $("#txtType").val(response.model.Type);
            $("#txtDate").val(response.model.Date);
        }
    });
}

//var GetSearchList = function () {
//    var NAME = $("#txtName").val();
//    var model = { Name: NAME };


//    $.ajax({
//        url: "/BLOG/GetSearchList",
//        method: "post",
//        data: JSON.stringify(model),
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        async: false,
//        success: function (response) {
//            var html = "";
//            $("#Blogs tbody").empty();
//            $.each(response.model, function (index, elementValue) {
//                html += "<tr><td>" + elementValue.ActivityId +
//                    "</td><td>" + elementValue.Title +
//                    "</td><td>" + elementValue.Details +
//                    "</td><td>" + elementValue.Image1 +
//                    "</td><td>" + elementValue.Image2 +
//                    "</td><td>" + elementValue.Type +
//                    "</td><td>" + elementValue.Date
//                "</td></tr > ";
//            });
//            $("#Blogs").append(html);

//        }
//    });
//}
var details = function (ActivityId) {
    window.location.href = "/Blog/BlogDetailIndex?ActivityId=" + ActivityId;
}
var Redirectdetails = function () {

    var ActivityId = $("#txtActiveId").val();
    debugger;
    model = { ActivityId: ActivityId }
    $.ajax({
        url: "/BLOG/GetBlogbyId",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#txtActiveId").text(response.model.ActivityId);
            $("#txtTitle").text(response.model.Title);
            $("#txtDetails").text(response.model.Details);
            $("#txtImage1").text(response.model.Image1);
            $("#txtImage2").text(response.model.Image2);
            $("#txtType").text(response.model.Type);
            $("#txtDate").text(response.model.Date);
        }
    });
}

var GetBlogList2 = function () {
    debugger;
    $.ajax({
        url: "/Blog/GetBlogList2",
        method: "Post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $.each(response.model, function (index, elementValue) {
               /* html += "<div class='col-md-12 blog-top'>";*/
                html += "<div class='blog-in'>";
                html += "<div class='container'>";
                html += "<div class='col-sm-12'>";
                html += "<div class='row'>";
                html += "<div class='col-sm-2'>";
                html += "<img src='../Content/images/" + elementvalue.Image1 + " 'width=200px' 'height=200px' 'class='img-fluid'/>";
                html += "</div>";
                html += "<div class='col-sm-10'>";
                html += "<div class='blog-grid pull-right'>";
                html += "<div class='Date'>";
                html += "<span class='date-in'><i class='fa fa-calendar'></i>" + elementvalue.Date +"</span>";
                html += "<a href = 'single.html' class='comments'> <i class='fa fa-comment''></i>48</a > ";
                html += "<div class='clearfix'></div>";
                html += "</div>";
                html += "<h3>" + elementvalue.Title + "</h3 > ";
                html += "<p>" + elementvalue.Details + "</p>";
                html += "<a href='~/About/Ayurveda' class='smore'>READ MORE</a>"
                html += "</div>";
                html += "<div class='clearfix'></div>"
                html += "</div>";
                html += "</div>";
                html += "</div>";
                html += "</div>";
                html += "</div>";
                html += "</div>";

            });
            $("#Blogs tbody").append(html);
        }
    });

}

  
       
           
   