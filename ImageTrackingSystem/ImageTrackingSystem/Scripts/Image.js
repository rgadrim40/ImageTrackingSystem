$(document).ready(function () {

    //----------------------------Initiate------------------------------------------------------------->
    $("#ExistingDiv").hide();

    $("#existCompBtn").click(function () {
        $("#ExistingDiv").show();
        $("#NewDiv").hide();
    });

    $("#ExistingDiv").hide();

    $("#newCompBtn").click(function () {
        $("#NewDiv").show();
        $("#ExistingDiv").hide();
    });
});