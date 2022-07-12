// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



$('#loginButton').click(function() {

    var email = $('#staticEmail').val()
    var password = $('#inputPassword').val()

    $.ajax({
        url: '/Account/Login',
    type: 'POST',
    contentType: 'application/x-www-form-urlencoded',
    data: {Email: email, Password: password },
    success: function(result) {

        debugger;
        var test = result;
        if (result == true) {
            window.location.href = "/App/Index";
        }


    },
    error: function() {

    }
    });
});

