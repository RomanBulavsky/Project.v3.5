$("#uploadFile").on("change",
      function (e) {
          var files = document.getElementById('uploadFile').files;
          if (files.length > 0) {
              for (var i = 0; i < files.length; i++)
                  $(".upload-text").append(" " + files[i].name + " ");
          }
      });

$(document).on('#submit', 'form', function (e) {
    e.preventDefault();

    $form = $(this);

    uploadImage($form);

});

function uploadImage($form) {
    $form.find('.progress-bar').removeClass('progress-bar-success')
        .removeClass('progress-bar-danger');

    var formdata = new FormData($form[0]); //formelement
    var request = new XMLHttpRequest();

    //progress event...
    request.upload.addEventListener('progress', function (e) {
        var percent = Math.round(e.loaded / e.total * 100);
        $form.find('.progress-bar').width(percent + '%').html(percent + '%');
    });

    //progress completed load event
    request.addEventListener('load', function (e) {
        $form.find('.progress-bar').addClass('progress-bar-success').html('upload completed....');
        setTimeout(function () {
            $('.progress-bar').removeClass('progress-bar-success');
            $('.progress-bar').css("width", "0");

            $('#results').load('@Url.Action("Index", "Home")');
        },
            1500);

    });

    request.open('post', '@Url.Action("Upload", "Home")');
    request.send(formdata);

    $form.on('click', '.cancel', function () {
        request.abort();

        $form.find('.progress-bar')
            .addClass('progress-bar-danger')
            .removeClass('progress-bar-success')
            .html('upload aborted...');
    });

}