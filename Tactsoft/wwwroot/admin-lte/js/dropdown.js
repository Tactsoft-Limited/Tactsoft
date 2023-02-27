$(document).ready(function () {

    $('body').on('change', '#CountryId', function () {
        var CountryId = $(this).val();
        LoadState(CountryId);
    })

    $('body').on('change', '#StateId', function () {
        var StateId = $(this).val();
        LoadCity(StateId);
    })

    //Checkbox Checked
    var $ssc = $("#Ssc");
    var $hsc = $("#Hsc");
    var $bsc = $("#Bsc");
    var $msc = $("#Msc");

    $hsc.on("click", function () {
        var anyChecked = $hsc.is(":checked");
        $ssc.prop("checked", anyChecked);
    });
    $bsc.on("click", function () {
        var anyChecked = $bsc.is(":checked");
        $ssc.prop("checked", anyChecked);
        $hsc.prop("checked", anyChecked);
    });
    $msc.on("click", function () {
        var anyChecked = $msc.is(":checked");
        $ssc.prop("checked", anyChecked);
        $hsc.prop("checked", anyChecked);
        $bsc.prop("checked", anyChecked);
    });

});


function LoadCountry() {
    $.ajax({
        type: "get",
        url: "/Common/GetCountry",
        datatype: "json",
        traditional: true,
        success: function (data) {
            var country = "<select id='CountryId'>";
            country = country + '<option value="">Select Country</option>';
            for (var i = 0; i < data.length; i++) {
                country = country + '<option value=' + data[i].id + '>' + data[i].countryName + '</option>';
            }
            country = country + '</select>';
            $('#CountryId').html(country);
        }
    });
}

function LoadState(CountryId) {
    var $state = $('#StateId');
    $.ajax({
        type: "get",
        url: "/Common/GetStatesByCountryId",
        data: { countryId: CountryId },
        datatype: "json",
        traditional: true,
        success: function (data) {
            var state = "<select id='StateId'>";
            state = state + '<option value="">Select State</option>';
            for (var i = 0; i < data.length; i++) {
                state = state + '<option value=' + data[i].id + '>' + data[i].stateName + '</option>';
            }
            state = state + '</select>';
            $('#StateId').html(state);
        }
    });
}

function LoadCity(StateId) {
    var $city = $('#CityId');
    $.ajax({
        type: "get",
        url: "/Common/GetCitiesByStateId",
        data: { stateId: StateId },
        datatype: "json",
        traditional: true,
        success: function (data) {
            var city = "<select id='CityId'>";
            city = city + '<option value="">Select City</option>';
            for (var i = 0; i < data.length; i++) {
                city = city + '<option value=' + data[i].id + '>' + data[i].cityName + '</option>';
            }
            city = city + '</select>';
            $('#CityId').html(city);
        }
    });
}

