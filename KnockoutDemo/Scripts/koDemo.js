/// <reference path="jquery-1.9.1.js" />
/// <reference path="knockout-3.0.0.js" />

$(function () {

    //#region Observable Intilisation ,Get and Set values

    var viewModel = { name : ko.observable("I hate Hello World :)") };//intialize model property
    viewModel.name("change the value"); //set the value
    //alert(viewModel.name()); // Get the value
    ko.applyBindings(viewModel, document.getElementById('Observable')); //Make it Two way Thing :)

    //#endregion
    
    //#region  Observable Arrays
    var data = [{ name: "sarvesh" }, { name: "Akshay" }, { name: "isha" }, { name: "divya" }, { name: "priya" }];
    
    var ObservableArray = {
            // data
            items: ko.observableArray(data),
            itemToAdd: ko.observable(""),

            // behaviors
            addItem: function () {
                this.items.push({ name: this.itemToAdd() });
                this.itemToAdd("");
            }
        };
    
    ko.applyBindings(ObservableArray, document.getElementById('ObservableArrayDiv'));

    //#endregion





    //var viewModel = {
    //    name: ko.observable("Sarvesh"),
    //    changeName: function () {
    //        this.name("Sarvesh Kushwaha");
    //    }
    //};
    //ko.applyBindings(viewModel);
});