(function () {
    angular.module('developerShopApp', ['ngRoute', 'ngLocale', 'ui.bootstrap'])

        .value('apiUrl', 'http://10.0.0.186/DeveloperShop.Api/api/')

        .config(function ($routeProvider, $provide) {
            $routeProvider
                .when('/', {
                    templateUrl: 'views/home.html',
                    controller: 'HomeController'
                }).when('/payment-confirmation', {
                    templateUrl: 'views/paymentConfirmation.html',
                    controller: 'DummyController'
                }).when('/404', {
                    templateUrl: 'views/404.html',
                    controller: 'DummyController'
                }).otherwise({
                    templateUrl: 'views/404.html',
                    controller: 'DummyController'
                });
        })

        //.directive('btn', function () {
        //    Waves.init();
        //    return {
        //        restrict: 'C',
        //        link: function ($scope, $element) {
        //            $element.addClass('waves-effect');

        //            if (!$element.hasClass('btn-flat')) {
        //                $element.addClass('waves-light');
        //            }

        //            if ($element.hasClass('btn-round')) {
        //                $element.addClass('waves-circle waves-float');
        //            }

        //            Waves.attach($element[0]);
        //        }
        //    };
        //})

        .directive('developerList', function () {
            return {
                restrict: 'E',
                scope: {
                    data: '='
                },
                link: function (scope, el, attrs) {
                    scope.$watchCollection('data', function (newValue, oldValue) {
                        if (!newValue) {
                            return;
                        }
                        React.renderComponent(
                            DeveloperList({
                                data: newValue
                            }),
                            el[0]
                        );
                    })
                }
            }
        })

        .filter('pager', function () {
            return function (input, start) {
                var pagedItems;

                if (input) {
                    start = +start; //parse to int
                    pagedItems = input.slice(start);
                }

                return input ? pagedItems : [];
            }
        })

        .factory("$pagination", [
            function () {
                return {
                    // Utilização na view:
                    // ng-repeat="item in itensFiltrados = (Itens | filter:textoDaBusca) | pager:(paginaAtual-1)*itensPorPagina | limitTo:itensPorPagina"
                    pageItems: function (itemsToPage, $scope, $timeout) {
                        function updateTotalPages() {
                            $scope.totalPages = Math.ceil(itemsToPage.length / $scope.itemsPerPage);
                        }

                        $scope.currentPage = 1;
                        $scope.Items = itemsToPage;
                        $scope.totalItems = itemsToPage.length;
                        $scope.itemsPerPage = 5;
                        $scope.lastIndexInThisPage = $scope.currentPage * $scope.itemsPerPage;
                        $scope.firstIndexInThisPage = ($scope.currentPage - 1) * $scope.itemsPerPage;

                        updateTotalPages();

                        $scope.showPagination = function () {
                            return $scope.totalItems && $scope.totalItems > $scope.itemsPerPage;
                        };

                        $scope.setPage = function (pageNumber) {
                            $route.currentPage = pageNumber;
                        };

                        $scope.filter = function () {
                            $timeout(function () {
                                updateTotalPages();
                                $scope.totalItems = $scope.filteredItems.length;
                            });
                        };
                    }
                };
            }])

        .controller('DummyController', function ($scope, $location) {
            $scope.backToCart = function () {
                $location.path('/');
            };
        })

        .controller('HomeController', function ($scope, $http, $timeout, $pagination, $location, apiUrl) {
            $scope.organization = "";
            $scope.cart = [];

            var showProgress = function () {
                $scope.loading = true;
            };

            var hideProgress = function () {
                $scope.loading = false;
            };

            $scope.calculateCartAmount = function () {
                var cartAmount = 0;
                angular.forEach($scope.cart, function (developer) {
                    cartAmount += developer.price;
                });

                return cartAmount;
            };

            $scope.setOrganization = function (organization) {
                $scope.organization = organization;
            };

            $scope.addToCart = function (developer) {
                $scope.developers.splice($scope.developers.indexOf(developer), 1);
                $scope.cart.push(developer);

                $pagination.pageItems($scope.developers, $scope, $timeout);
            };

            $scope.removeFromCart = function (developer) {
                var index = $scope.cart.indexOf(developer);
                $scope.cart.splice(index, 1)

                $scope.developers.push(developer);
                $pagination.pageItems($scope.developers, $scope, $timeout);
            };

            $scope.buy = function () {

                if ($scope.cart && $scope.cart.length >= 1) {
                    $http.post(apiUrl + '/Order', {
                        developers: $scope.cart,
                        amount: $scope.calculateCartAmount()
                    }).success(function () {
                        $location.path('payment-confirmation');
                    });
                }
            };

            $scope.$watch('organization', function (newValue) {
                if (!newValue) {
                    return;
                }

                showProgress();
                $http.get(apiUrl + 'Developer/GetFromOrganization/' + newValue)
                .success(function (data) {
                    $scope.developers = data.filter(function (developer) {
                        var cartDevelopers = $scope.cart.filter(function (cartDeveloper) {
                            return cartDeveloper.id == developer.id;
                        });

                        return !cartDevelopers.length;
                    });
                    $pagination.pageItems($scope.developers, $scope, $timeout);
                }).error(function () {
                    Materialize.toast('Ocorreu um erro ao obter os desenvolvedores', 3000, 'rounded');
                }).finally(function () {
                    hideProgress();
                });
            });


        })

    ;
})();
