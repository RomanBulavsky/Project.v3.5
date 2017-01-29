(function () {
    function func() {
        if ($("#Email").hasClass("valid")) {

            $(".targetEmail").removeClass("hidden");
            $(".targetEmail").removeClass("glyphicon-remove red");
            $(".targetEmail").addClass("green glyphicon-ok");

        } else if ($("#Email").hasClass("input-validation-error")) {

            $(".targetEmail").removeClass("hidden");
            $(".targetEmail").removeClass("glyphicon-remove green ");
            $(".targetEmail").addClass("glyphicon-remove red");
        } else {
            $(".targetEmail").addClass("hidden");
        }

        if ($("#Login").hasClass("valid")) {

            $(".targetLogin").removeClass("hidden");
            $(".targetLogin").removeClass("glyphicon-remove red");
            $(".targetLogin").addClass("green glyphicon-ok");

        } else if ($("#Login").hasClass("input-validation-error")) {

            $(".targetLogin").removeClass("hidden");
            $(".targetLogin").removeClass("glyphicon-remove green ");
            $(".targetLogin").addClass("glyphicon-remove red");
        } else {
            $(".targetLogin").addClass("hidden");
        }

        if ($("#Password").hasClass("valid")) {

            $(".targetP").removeClass("hidden");
            $(".targetP").removeClass("glyphicon-remove red");
            $(".targetP").addClass("green glyphicon-ok");

        } else if ($("#Password").hasClass("input-validation-error")) {

            $(".targetP").removeClass("hidden");
            $(".targetP").removeClass("glyphicon-remove green ");
            $(".targetP").addClass("glyphicon-remove red");
        } else {
            $(".targetP").addClass("hidden");
        }

        if ($("#ConfirmPassword").hasClass("valid")) {

            $(".targetCP").removeClass("hidden");
            $(".targetCP").removeClass("glyphicon-remove red");
            $(".targetCP").addClass("green glyphicon-ok");

        } else if ($("#ConfirmPassword").hasClass("input-validation-error") && $("#ConfirmPassword").value === $("#Password").value) {

            $(".targetCP").removeClass("hidden");
            $(".targetCP").removeClass("glyphicon-remove green ");
            $(".targetCP").addClass("glyphicon-remove red");
        } else {
            $(".targetCP").addClass("hidden");
        }
    }

    setInterval(func, 200);
})();