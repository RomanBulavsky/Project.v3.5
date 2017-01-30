$('#submit').on('click', function (e) {
    e.preventDefault();
    var files = document.getElementById('upload1').files;
    if (files.length > 0) {
        if (window.FormData !== undefined) {
            var data = new FormData();
            for (var x = 0; x < files.length; x++) {
                data.append("file" + x, files[x]);
            }

            $.ajax({
                type: "POST",
                url: '@Url.Action("Upload", "Home",new{})',
                contentType: false,
                processData: false,
                data: data,
                error: function (xhr, status, p3) {
                    alert(xhr.responseText);
                }
            });
        }
    }
});

$("#uploadFile").on("change", function (e) {
    var files = document.getElementById('upload1').files;
    if (files.length > 0) {
        for(var i = 0; i <files.length;i++ )
        $(".xxx").append(files[i].name);
    }
});