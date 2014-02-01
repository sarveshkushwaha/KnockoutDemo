/// <reference path="jquery-1.9.1.js" />
/// <reference path="knockout-3.0.0.js" />

$(function () {

    //#region Observable Intilisation ,Get and Set values

    var viewModel = { name : ko.observable("I hate Hello World :)") };//intialize model property
    viewModel.name("change the value"); //set the value
    alert(viewModel.name()); // Get the value
    ko.applyBindings(viewModel); //Make it Two way Thing :)

    //#endregion





    //var viewModel = {
    //    name: ko.observable("Sarvesh"),
    //    changeName: function () {
    //        this.name("Sarvesh Kushwaha");
    //    }
    //};
    //ko.applyBindings(viewModel);
});