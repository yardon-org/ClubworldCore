var CWrinks = 0;
var CWleagueId = 0;
var CWfixtureType = 0;
var CWfixtureRef = 0;

//  Callback definitions
var cw_AjaxReturn;
var cw_SuccessCallback;
var cw_Ajax_Url;

function cw_LeagueTable_Success(data) {
    $("#cw-leaguedataview").html($(data)).find("#cw-leaguedataview");
}

function cw_LeagueResult_Success(data) {
    $("#cw-leaguedataview").html($(data)).find("#cw-leaguedataview");
    $(cw_ResultWindow());
}

function cw_LeagueFixture_Success(data) {
    $("#cw-leaguedataview").html($(data)).find("#cw-leaguedataview")
}
function cw_AjaxFailure(faildata) {
    alert(faildata);
    console.log(faildata);
}

// Page setup
function cw_LeagueData() {
    $("#cw-league").on("click", cw_LeagueMenuClick);
    $(".cw-menuhorizontal").on("click", cw_LeagueOptionClick);
}

//  Menu functions
function cw_MenuRequest() {
    cw_AjaxReturn = $.ajax({
        data: { LeagueId: CWleagueId },
        type: 'POST',
        url: cw_Ajax_Url,
    })

    cw_AjaxReturn.done(cw_SuccessCallback);
    cw_AjaxReturn.fail(cw_AjaxFailure);
}

function cw_LeagueMenuClick(e) {
    CWleagueId = $(e.target).attr("id");
    $("#cw-leaguetitle").text("(" + $(e.target).text() + ")");

    cw_MenuRequest();
}
function cw_LeagueOptionClick(e) {
    var menuId = $(e.target).attr("id");
    $(".cw-menuhorizontal li").removeClass("cw-selected");
    $(e.target).addClass("cw-selected");
    cw_Ajax_Url = "League/" + menuId;

    switch (menuId) {
        case "Table":
            cw_SuccessCallback = cw_LeagueTable_Success;
            break;

        case "Result":
            cw_SuccessCallback = cw_LeagueResult_Success;
            break;

        case "Fixture":
            cw_SuccessCallback = cw_LeagueFixture_Success;
            break;

        default:

    }
    cw_MenuRequest();
}

//  Main functions
//function cw_LeagueData() {
//    $("#cw-league").on("click", function (e) {
//        CWleagueId = $(e.target).attr("id");
//        $("#cw-leaguetitle").text("(" + $(e.target).text() + ")");

//        cw_AjaxReturn = $.ajax({
//            data: { LeagueId: $(e.target).attr("id") },
//            type: 'POST',
//            url: cw_Ajax_Url,//"Table",
//        })

//        cw_AjaxReturn.done(cw_SuccessCallback);
//        cw_AjaxReturn.fail(cw_AjaxFailure);
//        //$.ajax({
//        //    data: { LeagueId: $(e.target).attr("id") },
//        //    type: 'POST',
//        //    url: cw_Ajax_Url,//"Table",
//        //    success: function (data) {
//        //        cw_SuccessCallback(data)
//        //    },
//        //    //success: function (data) {
//        //    //    $("#cw-tableview").html($(data)).find("#cw-tableview");
//        //    //},
//        //    error: function (xhr, exc) {
//        //        console.log(xhr);
//        //    }
//        //})
//    });

//    $(".cw-menuhorizontal").on("click", function (e) {
//        var menuId = $(e.target).attr("id");
//        $(".cw-menuhorizontal li").removeClass("cw-selected");
//        $(e.target).addClass("cw-selected");
//        cw_Ajax_Url = "League/" + menuId;

//        switch (menuId) {
//            case "Table":
//                cw_SuccessCallback = cw_LeagueTable_Success;
//                break;

//            case "Result":
//                cw_SuccessCallback = cw_LeagueResult_Success;
//                break;

//            case "Fixture":
//                cw_SuccessCallback = cw_LeagueFixture_Success;
//                break;

//            default:

//        }
//    })
//}
//function cw_LeagueFixture() {
//    $("#cw-league").on("click", function (e) {
//        CWleagueId = $(e.target).attr("id");

//        //$("#cw-resultview").load("Fixtures", { LeagueId: t });//, function () { cw_ResultWindow(); });
//        $.ajax({
//            data: { LeagueId: $(e.target).attr("id") },
//            type: 'POST',
//            //contentType: "application/json; charset=utf-8",
//            url: cw_Ajax_Url,   //"Fixtures",
//            success: cw_SuccessCallback,
//            //success: function (data) {
//            //    $("#cw-resultview").html($(data)).find("#cw-resultview");
//            //},
//            error: function (xhr, exc) {
//                console.log(xhr);
//            }
//        })
//    })
//}
function cw_ResultWindow() {
    $("#cw-resultview").on("click", function (e) {
        var node = $(e.target).parent();
        var x = node.data("cw-fixture");
        //fixtureRef = x.FixtureRef;
        CWfixtureRef = node.data("cw-fixture").FixtureRef;
        //var obj = {
        //    FixtureRef: node.attr("cw-fixtureid"),
        //    HomeTeamName: node.attr("cw-homename"),
        //    HomeTeamRef: parseInt(node.attr("cw-homeref")),
        //    AwayTeamRef: parseInt(node.attr("cw-awayref")),
        //    AwayTeamName: node.attr("cw-awayname")//,
        // }
        var json = node.data("cw-fixture");

        cw_AjaxReturn = $.ajax({
            data: JSON.stringify(node.data("cw-fixture")),
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            url: "League/AddResult"
        });

        cw_AjaxReturn.done(function (data) {
            $("#cw-addresult").html($(data)).find("#cw-addresult");
            cw_DragDropInit();
            cw_FixtureSelect(1)
        });

        cw_AjaxReturn.fail(cw_AjaxFailure);
        //var rvm = JSON.parse(json);
        //$("#cw-addresult").load("AddResult", JSON.stringify(obj));
        //$.ajax({
        //    //data: JSON.stringify(obj),
        //    data: JSON.stringify(node.data("cw-fixture")),
        //    type: 'POST',
        //    contentType: "application/json; charset=utf-8",
        //    url: "League/AddResult",
        //    success: function (data) {
        //        $("#cw-addresult").html($(data)).find("#cw-addresult");
        //        cw_DragDropInit();
        //        cw_FixtureSelect(1)
        //    }
        //}
        //);
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

    //cw_DragDropInit();

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

//$(cw_LeagueFixture());
//$(cw_ResultWindow());
$(cw_LeagueData());