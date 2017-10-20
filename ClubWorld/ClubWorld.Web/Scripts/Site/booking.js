function cw_SelectInit(filterParam) {
    {
        $('#selectable').selectable({
            //filter: " tr td.free",
            filter: filterParam,
            selected: function (event, ui) {
                var nodeData = $(ui.selected).attr("cw-bookingid").split(":");
                var listNode = $("#toBeBooked ul");

                var addded = '<li Session = "' + nodeData[0] + '" rink="' + nodeData[1] + '"> Session: ' + nodeData[0] + ' Rink: ' + nodeData[1] + '</li>';
                $(listNode).append('<li Session = "' + nodeData[0] + '" rink="' + nodeData[1] + '"> Session: ' + nodeData[0] + ' Rink: ' + nodeData[1] + '</li>');
            },
            unselected: function (event, ui) {
                var nodeData = $(ui.unselected).attr("cw-bookingid").split(":");

                $('li[session="' + nodeData[0] + '"][rink="' + nodeData[1] + '"]').remove();

            }
        });
    }
}

function cw_DatepickerInit() {
    $('#datepicker').datepicker({
        dateFormat: "dd-mm-yy",
        defaultDate: "01-10-2013",
        onSelect: function () { cw_DatepickerSelect() }
    });
}

function cw_DatepickerSelect() {
    var requestedDate = $('#datepicker').val();
    if (requestedDate != "") {
        $("#toBeBooked ul").empty();
        $('#cwbookingview').load("GetBookingDetails", { DateRequested: requestedDate }, function () { cw_SelectInit(" tr td.free") })
    }
}

function cw_BtnConfirmInit() {
    $("#btnConfirm").click(function () {
        var bookings = [];
        $("#toBeBooked ul").children().each(function (item) {
            var booking = { Session: $(this).attr("session"), Rink: $(this).attr("rink") }
            bookings[item] = booking;
        });

        var test = [{ "Session": "5", "Rink": "6" }, { "Session": "6", "Rink": "6" }];

        $.ajax({
            data: JSON.stringify({
                BookingDate: $("#selectable").attr("cw-date"),
                Description: $("#cw-desc").val(),
                RequestedSessions: bookings
            }),
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            url: "RinkBooking",
            success: function () { cw_DatepickerSelect() },
            failure: function () {
                Alert("Bollocks!!");
            }
        });
    })
}

$(cw_SelectInit(" tr td.free"));
$(cw_DatepickerInit());
$(cw_BtnConfirmInit());
