$(document).ready(function () {
	function productModel() {
		var self = this;

		self.name = ko.observable();
		self.code = ko.observable();
		self.price = ko.observable();

		return this;
	}

	function mainModel() {
		var self = this;

		self.modes = {
			All: 1,
			Edit: 2,
			Add: 3
		};

		self.activeMode = ko.observable(self.modes.All);

		self.products = ko.observableArray();
		self.product = ko.observable();

		self.loadProducts = function () {
			$.ajax({
				url: "/api/1.0/products",
				method: "GET",
				dataType: "json",
				success: function (data) {
					self.products([]);
					for (var i = 0; i < data.length; i++) {
						var prod = ko.mapping.fromJS(data[i]);
						self.products.push(prod);
					}
				},
				error: function () {

				},
				fail: function () {

				}
			});
		}

		self.addProduct = function () {
			if (self.validateProduct()) {
				var toAdd = ko.toJSON(self.product());
				$.ajax({
					url: "/api/1.0/products",
					contentType: 'application/json',
					method: "POST",
					data: toAdd,
					dataType: "json",
					success: function (data) {
						var prod = ko.mapping.fromJS(data);
						self.products.push(prod);
						self.cancelEditAdd();
					},
					error: function (data) {
						if (data.responseJSON.codeNotUnique) {
							// code not unique alert
						}
					}
				})
			}
		}

		self.validateProduct = function () {
			return true;
		}


		self.priceConfirmRequired = ko.computed(function () {
			return self.product() && self.product().price() > 999;
		}, this);
		self.priceConfirmed = ko.observable(false);

		/* modes switching */
		self.switchToAddMode = function () {
			self.activeMode(self.modes.Add);

			var p = new productModel();
			self.product(p);
		}
		self.cancelEditAdd = function () {
			self.activeMode(self.modes.All);
			self.product(null);
		}
		return self;
	}
	var model = new mainModel();
	ko.applyBindings(model);
	model.loadProducts();
	window.model = model;
});