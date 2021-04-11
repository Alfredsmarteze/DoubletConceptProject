// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    $(".pn").on("hover", function () {
        $(this).addClass('spinner-grow')
    })


    $(".Ani").mouseenter(function () {
        //$(this).css({ border: "10px solid #19b141" })
        $(this).addClass('shadow-lg border-primary')

        $(this).mouseleave(function () {
            //$(this).css({ border: "0px" })
            $(this).removeClass('shadow-lg border-primary')
            //$(this).addClass('card')
        })

    })

    

})