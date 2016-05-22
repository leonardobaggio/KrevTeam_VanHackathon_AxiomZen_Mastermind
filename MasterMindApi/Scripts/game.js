$(document).ready(function () {
    $(".Colors td div.circle").click(selectColor);
    $(".stage .circle").click(setColor);
    //$("input.tr_clone_add").click(AddStage);
    $("input.tr_clone_add").click(createPlay);

    $(document).keyup(function (e) {
        if (e.keyCode == 27) {
            $('body').attr("class", "defaultcursor");
            document.getElementById('Game').className = '';
            $('body').removeAttr("color");
        }
    });
});

function AddStage() {
    var stageNumber = $("input.tr_clone_add").attr("class").split(" ")[0];
    stageNumber = parseInt(stageNumber) + 1;

    var $tr = $("#checkButton").closest('.tr_clone');
    var $clone = $tr.clone();
    $clone.attr("id", stageNumber);
    $clone.find("td:first").text("Stage " + stageNumber);
    $clone.find("input.tr_clone_add").attr("id", "checkButton");

    $clone.find("input.tr_clone_add").attr("class", stageNumber + " addButton tr_clone_add buttonCheck");

    $("input.tr_clone_add").unbind('click');
    $("input.tr_clone_add").remove();

    $clone.find(':text').val('');
    $tr.before($clone);
    //$("input.tr_clone_add").click(AddStage);
    $("input.tr_clone_add").click(createPlay);

    $("#" + stageNumber + " td div.circle").attr("class", "circle gray");
    $("#" + stageNumber + " td div.circle-lt").attr("class", "circle-lt gray");
    $(".stage .circle").unbind("click");
    $("#" + stageNumber + ".stage .circle").click(setColor);

    //createPlay();
}
function setColor(ev) {
    var colorSelected = $('body').attr("color");

    if(colorSelected != undefined){
        $(ev.toElement).attr("class", "circle " + colorSelected);
    }
}
function selectColor(ev) {
    var color = $(ev.toElement).attr("class").split(" ")[1];
    var image = "img" + color;

    $('body').attr("class", image);
    $('body').attr("color", color);
    document.getElementById('Game').className = image;
}
function checkGame(bt) {
    var stageNumber = $("#checkButton").attr("class");
    stageNumber += 1;
    $(".stageGarage tr:eq(0)").prop("id", stageNumber);
    $(".stageDescription").text("Stage " + stageNumber)
    var stageNumber = $("#checkButton").attr("class");
    //alert('asdsa');
}

