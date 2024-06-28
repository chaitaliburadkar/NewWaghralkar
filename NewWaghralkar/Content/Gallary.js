$(document).ready(function () {
    GetGallaryList()
});

var GetGallaryList = function () {
    debugger
    $.ajax({
        url: "/Gallary/GetGallaryList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {

            var html = "";
            $("#Photogallaries tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Srno +
                    "</td><td>" + elementValue.PhotoId +
                    "</td><td>" + elementValue.Title +
                    "</td><td>" + elementValue.Photo1 +
                    "</td><td>" + elementValue.Photo2 +
                    "</td><td>" + elementValue.Type +
                    "</td></tr>";
            });

            $("#Photogallaries tbody").append(html);
        }
    });
}