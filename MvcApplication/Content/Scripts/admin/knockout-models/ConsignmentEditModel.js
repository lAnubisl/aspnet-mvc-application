ko.bindingHandlers.ko_autocomplete = {
    init: function (element, params) {
        $(element).autocomplete(params());
    },
    update: function (element, params) {
        $(element).autocomplete("option", "source", params().source);
    }
};

var ConsignmentEditModel = function(products) {
    var self = this;

    self.Products = ko.observableArray(products);

    self.RemoveProduct = function (product) {
        self.Products.remove(product);
    };
    self.AddProduct = function () {
        self.Products.push({ Name: '', Count: 0 });
    };
};