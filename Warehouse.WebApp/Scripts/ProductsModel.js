function ProductViewModel() {
    var _this = this;

    _this.ProductsList = ko.observableArray([]);

};

function Product(options) {
    var _this = this;

    _this.ProductModel = new ProductViewModel();

    _this.loadProducts = function () {
        var dataUrl = options.getCatalogUrl;

        $.ajax({
            url: dataUrl,
            dataType: 'json',
            type: 'GET',
            //data: { currentSeasonYear: startYear, isNext: isNext },
            async: true,
            success: function (data) {
                _this.copyToTeamModel(data);
            }
        });

        _this.copyToTeamModel = function (jsonData) {
            _this.ProductModel.ProductsList(jsonData);
        };
    };
}