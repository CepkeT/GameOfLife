// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    setInterval(updateBoard, 1000);
});

function updateBoard() {
    $.ajax({
        url: '/Home/UpdateBoard',
        type: 'GET',
        success: function (data) {
            $('#game-board').html(data);
        }
    });
}