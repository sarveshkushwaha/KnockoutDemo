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
    var data = [{ UserName: "sarvesh" }, { UserName: "Akshay" }, { UserName: "isha" }, { UserName: "divya" }, { UserName: "priya" }];
        debugger;
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
    
    ko.applyBindings(ObservableArray, document.getElementById('ObservableArrayDiv')); //second parameter defines scope of model
    //#endregion

    //#region Computed Observables
    var NameModel = { firstName : ko.observable("Sarvesh"), lastName : ko.observable("Kushwaha")};

    NameModel.fullName = ko.computed(function() {
        return this.firstName() +" "+ this.lastName();
    }, NameModel);

    ko.applyBindings(NameModel, document.getElementById('ComputedObservableDiv'))

    //#endregion

    //#region Dynamically Get and set the data using Knockout and Web API
    $.getJSON("api/GetDetailsApi", function (data) { //added this getjson to deal with real or dynamic data 


        debugger;
        var GetUserName = {
            // data
            items: ko.observableArray(data),
            itemToAdd: ko.observable(""),

            // behaviors
            addItem: function () {
                this.items.push({ name: this.itemToAdd() });
                this.itemToAdd("");
            }
        };

        ko.applyBindings(GetUserName, document.getElementById('KODataFeatures')); //second parameter defines scope of model

    });

    //#endregion


    //var viewModel = {
    //    name: ko.observable("Sarvesh"),
    //    changeName: function () {
    //        this.name("Sarvesh Kushwaha");
    //    }
    //};
    //ko.applyBindings(viewModel);
});