//Country Modal Popup
var AddCountry = function () {
    var url = "/Country/CreatePartial";
    $('#titleMediumModal').html("Add New Country");
    loadMediumModal(url);
};
var AddState = function () {
    var url = "/State/CreatePartial";
    $('#titleMediumModal').html("Add New State");
    loadMediumModal(url);
};
var AddCity = function () {
    var url = "/City/CreatePartial";
    $('#titleMediumModal').html("Add New City");
    loadMediumModal(url);
};
var SubmitCountry = function () {
    var countryObj = {
        Id:0,
        CountryName: $('#CountryName').val(),
        CountryCode: $('#CountryCode').val(),
        CountryCurrency: $('#CountryCurrency').val(),
        CountryFlag: $('#CountryFlag').val()
    };
    if ($("#Country").valid()) {
        $.ajax({
            url: "/Country/CreatePartial",
            data: JSON.stringify(countryObj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                LoadCountry();
                $('#MediumModal').modal('hide');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

var SubmitState = function () {
    var stateObj = {
        Id: 0,
        StateName: $('#StateName').val(),
        CountryId: $('#CountryId').val(),
    };

    if ($("#State").valid()) {
        $.ajax({
            url: "/State/CreatePartial",
            data: JSON.stringify(stateObj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                LoadState(stateObj.CountryId);
                $('#MediumModal').modal('hide');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

var SubmitCity = function () {
    var cityObj = {
        Id: 0,
        CityName: $('#CityName').val(),
        StateId: $('#StateId').val(),
    };

    if ($("#City").valid()) {
        $.ajax({
            url: "/City/CreatePartial",
            data: JSON.stringify(cityObj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                LoadCity(cityObj.StateId);
                $('#MediumModal').modal('hide');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}


var loadMediumModal = function (url) {
    $("#MediumModalDiv").load(url, function () {
        $("#MediumModal").modal("show");        
    });
};
