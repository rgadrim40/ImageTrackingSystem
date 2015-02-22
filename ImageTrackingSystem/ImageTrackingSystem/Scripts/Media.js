$(document).ready(function () {

    strTemp = new String($("#MainContent_hiddenBox").val());
        $("#divMedia").hide();

    $("#btnCancel").click(function () {
        $("#divMedia").hide();
        $("#MainContent_reviewPnl").hide();
        $("#MainContent_editPnl").hide();
        $("#MainContent_divMedia").hide();
        $("#MainContent_lblMessage").text("The Grid is for keeping track of media. With the ability to Edit and Delete, When Deleting A media the media will be set to Inactive for future use!")
    });

    $("#btnCancel2").click(function () {
        $("#divMedia").hide();
        $("#MainContent_reviewPnl").hide();
        $("#MainContent_editPnl").hide();
        $("#MainContent_divMedia").hide();
        $("#MainContent_lblMessage").text("The Grid is for keeping track of media. With the ability to Edit and Delete, When Deleting A media the media will be set to Inactive for future use!")
    });

    $("#btnCancel3").click(function () {
        $("#divMedia").hide();
        $("#MainContent_reviewPnl").hide();
        $("#MainContent_editPnl").hide();
        $("#MainContent_divMedia").hide();
        $("#MainContent_lblMessage").text("The Grid is for keeping track of media. With the ability to Edit and Delete, When Deleting A media the media will be set to Inactive for future use!")
    });

    $("#btnInsert").click(function () {
        $("#divMedia").show();
        $("#MainContent_lblMessage").text("The form is for Inserting a new record!")
    });
});

