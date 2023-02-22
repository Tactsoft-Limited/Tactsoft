//Country Modal Popup
var AddCountry = function () {
    var url = "/Country/Create";
    $('#titleSmallModal').html("Add New Country");
    loadSmallModal(url);
};

var SubmitCountry = function () {
    var countryObj = {
        Id:0,
        CountryName: $('#CountryName').val(),
        CountryCode: $('#CountryCode').val(),
        CountryCurrency: $('#CountryCurrency').val(),
        CountryFlag: $('#CountryFlag').val()
    };
    console.log(countryObj)
    if ($("#Country").valid()) {
        $.ajax({
            url: "/Country/Create",
            data: JSON.stringify(countryObj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                $('#SmallModal').modal('hide');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

var EditCountry = function (id) {
    var url = "/Country/Edit?id=" + id;
    $('#titleSmallModal').html("Update Country");
    loadSmallModal(url);
};

var CountryDetails = function (id) {
    var url = "/Country/Details?id=" + id;
    $('#titleSmallModal').html("Country Details");
    loadSmallModal(url);
};

var DeleteCountry = function (id) {
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
                url: "/Country/Delete?id=" + id,
                success: function (result) {
                    var message = "Country has been deleted successfully";
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


var loadSmallModal = function (url) {
    $("#SmallModalDiv").load(url, function () {
        $("#SmallModal").modal("show");
        
    });
};

