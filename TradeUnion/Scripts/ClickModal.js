//$('#openBtn').click(function () {
//    $('#myModal').modal({ show: true })
//});

$("#myModal").on("hidden.bs.modal", function () {
    $(this).removeData("bs.modal");
});
