// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.getElementById("passwordShowCheckbox").addEventListener('change', function () {
    var passwordField = document.getElementById("passwordTextField");
    var passwordConfirmationField = document.getElementById("passwordConfirmationTextField");

    if (this.checked) {
        passwordField.type = "text";
        passwordConfirmationField.type = "text";
    } else {
        passwordField.type = "password";
        passwordConfirmationField.type = "password";
    }
});