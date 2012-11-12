var ProductEditModel = function (images, deleteImageURL) {
    var self = this;

    self.DeleteImageUrl = deleteImageURL;
    self.Images = ko.observableArray(images);

    self.RemoveImage = function (image) {
        self.Images.remove(image);
        $.post(self.DeleteImageUrl, { imageUrl: image });
    };
    self.AddImage = function (image) {
        self.Images.push(image);
    };
};