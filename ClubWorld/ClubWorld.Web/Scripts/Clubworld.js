var CWrinks = 0;
var CWleagueId = 0;
var CWfixtureType = 0;
var CWfixtureRef = 0;

function cw_LeagueFixture() {
    $("#cw-league").on("click", function (e) {
        CWleagueId = $(e.target).attr("id");

        //$("#cw-resultview").load("Fixtures", { LeagueId: t });//, function () { cw_ResultWindow(); });
        $.ajax({
            data: { LeagueId: $(e.target).attr("id") },
            type: 'POST',
            //contentType: "application/json; charset=utf-8",
            url: "Fixtures",
            success: function (data) {
                $("#cw-resultview").html($(data)).find("#cw-resultview");
            },
            error: function (xhr, exc) {
                console.log(xhr);
            }
        })
    })
}
function cw_ResultWindow() {
    $("#cw-resultview").on("click", function (e) {
        var node = $(e.target).parent();
        var x = node.data("cw-fixture");

        CWfixtureRef = node.data("cw-fixture").FixtureRef;
        var json = node.data("cw-fixture");

        //var rvm = JSON.parse(json);
        //$("#cw-addresult").load("AddResult", JSON.stringify(obj));
        $.ajax({
            //data: JSON.stringify(obj),
            data: JSON.stringify(node.data("cw-fixture")),
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            url: "AddResult",
            success: function (data) {
                $("#cw-addresult").html($(data)).find("#cw-addresult");
                cw_DragDropInit();
                cw_FixtureSelect(1)
            }
        }
        );


    })
}
function cw_DragDropInit() {
    $(".cw-homedrag").draggable({
        cursor: "move",
        revert: true,
        appendTo: 'body',
        containment: "#cw-addresult",
        scope: "home",
        stack: ".cw-awaydrag",
    });
    $(".cw-awaydrag").draggable({
        cursor: "move",
        revert: true,
        appendTo: 'body',
        containment: "#cw-addresult",
        snap: true,
        scope: "away"
    });

    $(".cw-homedrop").droppable({
        scope: "home",
        classes: { "ui-droppable-hover": "highlight" },
        drop: function (ev, ui) { cw_DropItem(ev, ui); }
    });
    $(".cw-awaydrop").droppable({
        scope: "away",
        classes: { "ui-droppable-hover": "highlight" },
        drop: function (ev, ui) { cw_DropItem(ev, ui); }
    })
}
function cw_DropItem(ev, ui) {
    var d = ev.target;
    var h = $(ui.draggable).draggable("option", "scope");
    var a = $(d).droppable("option", "scope")
    var g = $(ui.draggable).get();

    $(d).find("ul").append($(ui.draggable))//.get());
}
function cw_SaveResult() {
    var resultList = [];

    for (i = 1; i <= CWrinks; i++) {
        var homeID = "#cw-homescore-" + i;
        var awayId = "#cw-awayscore-" + i;

        var homePlayerId = "#cw-homerink-" + i + "> li";
        var awayPlayerId = "#cw-awayrink-" + i + "> li";

        var homePlayerObj = [];
        var awayPlayerObj = [];

        $(homePlayerId).each(function () {
            homePlayerObj.push($(this).data("cwplayer"));
        });

        $(awayPlayerId).each(function () {
            awayPlayerObj.push($(this).data("cwplayer"));
        });

        resultList.push({
            FixtureRef: CWfixtureRef,
            FixtureType: CWfixtureType,
            HomeShots: $(homeID).val(),
            AwayShots: $(awayId).val(),
            HomeRink: homePlayerObj,
            AwayRink: awayPlayerObj
        })
    };

    $.ajax({
        data: JSON.stringify(resultList),
        //data: JSON.stringify({
        //    FixtureRef: fixtureRef,
        //    FixtureType: fixtureType,
        //    HomeShots: $(homeID).val(),
        //    AwayShots: $(awayId).val(),
        //    HomeRink: homePlayerObj,
        //    AwayRink: awayPlayerObj
        //}),
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: "InsertResult",
        success: function (data) {
            $("#cw-addresult").empty();
            $.ajax({
                data: { LeagueId: CWleagueId },
                type: 'POST',
                //contentType: "application/json; charset=utf-8",
                url: "Fixtures",
                success: function (data) {
                    $("#cw-resultview").html($(data)).find("#cw-resultview");
                },
                error: function (xhr, exc) {
                    console.log(xhr);
                }
            })

        },
        error: function (xhr, exc) {
            console.log(xhr);
        }
    })

}
function cw_FixtureSelect(fixType) {
    CWfixtureType = fixType;

    var sel = $("#cw-fixturetype-" + fixType);
    CWrinks = parseInt($(sel).attr("cw-rinksrequired"));

    if ($("#cw-resultrow-3").hasClass("hidden")) {
        $("#cw-resultrow-3").removeClass("hidden");
    }

    if ($("#cw-resultrow-2").hasClass("hidden")) {
        $("#cw-resultrow-2").removeClass("hidden");
    }

    for (i = CWrinks + 1; i <= 3; i++) {
        var resRow = "#cw-resultrow-" + i;
        $(resRow).addClass("hidden")
    }
}

$(function () {
    $('#selectable').selectable({
        filter: " tr td"
    });
})
$(function cw_Hookup() {
    $('#selectable').selectable({
        filter: " tr td"
    });
})
$(cw_Hookup());
$(function () {
    $('#datepicker').datepicker({
        dateFormat: "dd-mm-yy",
        defaultDate: "01-10-2013",
        onSelect: function () {
            var DateRequested = $('#datepicker').val();
            $('#cwbookingview').load("GetBookingDetails",
                                    { DateRequested: DateRequested },
                                    function () {
                                        $('#selectable').selectable({
                                            filter: " tr td"
                                        });
                                    })
        }
    })
})
$(cw_LeagueFixture());
$(cw_ResultWindow());
