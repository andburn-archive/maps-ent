$(function () {
    var __testDisable = (function () {
        var $sf = $('#LocationId'),
            $ln = $('#LocationName'),
            $lat = $('#Latitude'),
            $lon = $('#Longitude'),
            disable = function (bool) {
                $ln.prop('disabled', bool);
                $lat.prop('disabled', bool);
                $lon.prop('disabled', bool)
            };
        disable(false);
        $sf.on("change", function () {
            $sf.val() == "" ? disable(false) : disable(true);
        })
    })()
})