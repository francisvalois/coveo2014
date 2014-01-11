$(document).ready(function() {

    $(".facet-slider").slider();

    $('#test').slider({
        formater: function (value) {
            return 'Current value: ' + value;
        }
    });
});
