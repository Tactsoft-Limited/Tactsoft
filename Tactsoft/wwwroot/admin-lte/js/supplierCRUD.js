//Supplier Modal Popup
var AddSupplier = function () {
    var url = "/Supplier/Create";
    $('#titleMediumModal').html("Add New Supplier");
    loadMediumModal(url);
};


var SubmitSupplier = function () {
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}
    var countryObj = {
        Id:0,
        Name: $('#Name').val(),
        Code: $('#Code').val(),
        Currency: $('#Currency').val(),
        Flag: $('#Flag').val()
    };
    console.log(countryObj)
    $.ajax({
        url: "/Supplier/Create",
        data: JSON.stringify(countryObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#MediumModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

var EditSupplier = function (id) {
    var url = "/Supplier/Edit?id=" + id;
    $('#titleMediumModal').html("Update Supplier");
    loadMediumModal(url);
};

var SupplierDetails = function (id) {
    var url = "/Supplier/Details?id=" + id;
    $('#titleMediumModal').html("Supplier Details");
    loadMediumModal(url);
};

var DeleteSupplier = function (id) {
    Swal.fire({
        title: 'Do you want to delete this item?',
        type: 'warning',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: "POST",
                url: "/Supplier/Delete?id=" + id,
                success: function (result) {
                    var message = "Supplier has been deleted successfully";
                    Swal.fire({
                        title: message,
                        text: 'Deleted!',
                        onAfterClose: () => {
                            location.reload();
                        }
                    });
                }
            });
        }
    });
};



var loadMediumModal = function (url) {
    $("#MediumModalDiv").load(url, function () {
        $("#MediumModal").modal("show");
        $("#Name").focus();
    });
};
