// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    setTimeout(function () {
        $(".rubber-span").removeClass("animate__delay-1s");
    }, 2000);
    setTimeout(function () {
        $(".rubber-span").removeClass("animate__delay-2s");
    }, 3000);
    setTimeout(function () {
        $(".rubber-span").removeClass("animate__delay-3s");
    }, 4000);
});

$(function () {
    $("#form-email").validate({
        errorClass: "invalid-input",
        rules: {
            fname: "required",
            femail: "required",
            fsubject: "required",
            fmessage: "required"
        },
        submitHandler: function () { alert("Success, your e-mail has been submited!") }
    });

});

$("#btn-home").click(function () {
    window.scrollTo(0, 0);
});

$("#btn-about").click(function () {
    window.scrollTo(0, 980);
});

$("#btn-skills").click(function () {
    window.scrollTo(0, 1950);
});

$("#btn-portfolio").click(function () {
    window.scrollTo(0, 2930);
});

$("#btn-contact").click(function () {
    window.scrollTo(0, 4000);
});

$("#contact-me-btn,#about-link").click(function () {
    window.scrollTo(0, 4000);
});
