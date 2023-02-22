﻿
$(function () {
    $("#example1").DataTable({
        "responsive": true, "lengthChange": true, "autoWidth": true,
        "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
    }).buttons().container().appendTo('#example1_wrapper .col-md-6:eq(0)');
});

$(document).ready(function () {
    setTimeout(function () {
        $("#alert").alert('close');
    }, 5000);
});