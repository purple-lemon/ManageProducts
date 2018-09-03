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
			showLoader();
			$.ajax({
				url: "/api/1.0/products",
				method: "GET",
				dataType: "json",
				success: function (data) {
					hideLoader();
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

		self.delete = function (item) {
			showLoader();
			$.ajax({
				url: "/api/1.0/products/" + item.id(),
				type: 'DELETE',
				dataType: "json",
				success: function (data) {
					hideLoader();
					self.products.remove(function (x) {
						return x.id() == item.id();
					});
				},
				error: function (data) {
					hideLoader();
					self.products.remove(function (x) {
						return x.id() == item.id();
					});
				}
			})
		}

		self.addProduct = function (data, event) {
			event.preventDefault()
			event.stopPropagation()

			if (self.validateProduct()) {
				var toAdd = ko.toJSON(self.product());
				var addMode = self.activeMode() == self.modes.Add;
				var method = addMode ? "POST" : "PUT";
				showLoader();
				$.ajax({
					url: "/api/1.0/products/",
					contentType: 'application/json',
					method: method,
					data: toAdd,
					dataType: "json",
					success: function (data) {
						hideLoader();
						var prod = ko.mapping.fromJS(data);
						if (addMode) {
							self.products.push(prod);
						}
						self.cancelEditAdd();
					},
					error: function (data) {
						if (data.responseJSON.codeNotUnique) {
							self.showNotUniq();
						}
						hideLoader();
					}
				})
			}
			return false;
		}

		self.validateProduct = function () {
			self.hideNotUniq();
			$(".confirm-price .invalid-feedback").hide();
			var form = $("form")[0];
			if (form.checkValidity() === false) {
				
				$(form).addClass('was-validated');
				return false
			} else if (self.product().price() > 999 && !self.priceConfirmed()) {
				
				$(form).addClass('was-validated');
				$(".confirm-price .invalid-feedback").show();
				return false;
			}
			return true;
		}

		self.showNotUniq = function () {
			$(".not-uniq-code").show();
		}

		self.hideNotUniq = function () {
			$(".not-uniq-code").hide();
		}

		self.switchToEdit = function (product, event) {
			self.product(product);
			self.activeMode(self.modes.Edit);
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

		self.redirect = function () {
			page.redirect('/about');
		}
		return self;
	}

	var model = new mainModel();
	ko.applyBindings(model);
	model.loadProducts();
	window.model = model;
});