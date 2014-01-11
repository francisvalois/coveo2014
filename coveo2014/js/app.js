$(document).ready(function() {
    $('#test').slider({
        formater: function (value) {
            return 'Current value: ' + value;
        }
    });
});