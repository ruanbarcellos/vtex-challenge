var app = angular.module('developerShopApp', ['ngAnimate', 'ngRoute'])

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

.directive('btn', function () {
    Waves.init();
    return {
        restrict: 'C',
        link: function ($scope, $element) {
            $element.addClass('waves-effect');

            if (!$element.hasClass('btn-flat')) {
                $element.addClass('waves-light');
            }

            if ($element.hasClass('btn-round')) {
                $element.addClass('waves-circle waves-float');
            }

            Waves.attach($element[0]);
        }
    };
})

.directive('mask', function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        compile: function () {
            return function (scope, element, attrs, controller) {

                if (attrs.maskWatch) {
                    scope.$watch(attrs.ngModel, function () {
                        uninitialize();
                        initialize();
                    });
                }

                var maskProcessed = false;
                var eventsBound = false;
                attrs.$observe('mask', initialize);

                function initialize() {

                    if (maskProcessed) {
                        uninitialize()
                    }

                    maskProcessed = true;

                    var maskConfig = {};

                    if (attrs.maskReverse) {
                        maskConfig.reverse = attrs.maskReverse == "true";
                    }

                    $(element).mask(attrs.mask, maskConfig);
                    bindEvents();
                }

                function uninitialize() {
                    maskProcessed = false;

                    $(element).unmask();
                    if (eventsBound) {
                        eventsBound = false;
                        unbindEvents();
                    }
                }

                function bindEvents() {
                    eventsBound = true;
                    element.on('input keyup click focus change', eventHandler);
                }

                function unbindEvents() {
                    element.unbind('input', eventHandler);
                    element.unbind('keyup', eventHandler);
                    element.unbind('click', eventHandler);
                    element.unbind('focus', eventHandler);
                    element.unbind('change', eventHandler);
                }

                function eventHandler() {
                    scope.$evalAsync(function () {
                        controller.$setViewValue($(element).cleanVal());
                    });
                }
            }
        }
    };
})


.controller('DummyController', function ($scope, $location) {
    $scope.backToCart = function () {
        $location.path('/');
    };
})

.controller('HomeController', function ($scope, $http) {
            $scope.cart = {
                id: 1,
                developers: [{
                        $scope.cart.developers.indexOf(
                            id: 1,
                            name: 'Developer 1',
                            price: 100.00
                        }, {
                            id: 2,
                            name: 'Developer 2',
                            price: 200.00
                        }, {
                            id: 3,
                            name: 'Developer 3',
                            price: 300.00
                        }]
                };

                $scope.addToCart = function () {
                    $scope.cart.developers.push({
                        name: $scope.newDeveloper.name,
                        price: $scope.newDeveloper.price
                    });

                    $scope.newDeveloper = {};
                };

                $scope.removeFromCart = function (developerId) {
                    var developerIndex = $scope.cart.developers.filter(function (developer, index) {
                        if (developer.id == developerId) {
                            return index;
                        }
                    });

                    $scope.cart.developers.splice(developerIndex, 1);
                };
            })

        ;
