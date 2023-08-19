

$('#makes').change(function () {
    var makeId = $(this).val();
    console.log("The Id is " + makeId);

    $('#models').html('<option>Select Model</option>');


    $.getJSON('/Logics/Create?handler=CarModel', { id: makeId }, function (data) {

        console.log("This is data " + Jsondata);
        $.each(data, function (key, value) {
            var option = $('<option></option>').attr('value', value.id).text(value.name);
            

            //var selectedOption = option.attr('value', value.id).text(value.name);
            $('#models').append(option);

        });
    });

});

   