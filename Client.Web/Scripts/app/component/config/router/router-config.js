angular.module('component.config.router', ['ui.router','api.httpRequestInterceptor']).config(function($stateProvider, $urlRouterProvider, EXCLUDED_DEMO_ROUTERS,$httpProvider) {
    $urlRouterProvider.otherwise("/");

    $httpProvider.interceptors.push('httpRequestInterceptor');

    $stateProvider
        .state('demo', {
            url: "/demo",
            templateUrl: "app/component/config/router/demo-page.html",
            controller: function ($scope, $state) {
                $scope.routes = $state.get().filter(function(route) {
                    return !!route.name && EXCLUDED_DEMO_ROUTERS.indexOf(route.name) === -1;
                });

                $scope.modules = angular.modules.filter(function(moduleName) {
                    return !(EXCLUDED_DEMO_ROUTERS.indexOf(moduleName) + 1);
                });
            }
        }).state('demo-example', {
            url: '/demo/:name',
            templateUrl: function ($stateParams){
                var name = $stateParams.name;
                return 'app/' + name.split('.').join('/') + '/example/index.html';
            },
            controller: function($scope, $stateParams) {
                $scope.testData = {
                    summary: {
                        description: 'Сдается 1-комн. квартира на длительный срок в 5-7 минутах ходьбы от ст. м. Полежаевская. Квартира после капитального ремонта. Мебель IKEA, холодильник, стиралка, посудомойка, микроволновка, пылесос. Кровать с большим отделением для хранения вещей. Wi-Fi 80 Mbs. Спокойные соседи. Чистый двор и подъезд (ЖСК). Два лифта. Расположение действительно уникальное. До ТЦ Авиапарк 5 минут на бесплатном автобусе. В 3-5 минутах ходьбы детская и взрослая поликлиники.',
                        roomsCount: 2,
                        address: 'Москва, ул. Юных Ленинцев, д. 228, корп. 14, кв. 88, стр. 14',
                        price: 1035000,
                        station: 'Кузьминки, район Богородское',
                        floor: 7,
                        area: 54,
                        type: 'Квартира',
                        category: 'Новостройка',
                        hasDocs: true,
                        publishDate: 1469007765797
                    },
                    coords: [37.715175, 55.833436],
                    images: [{
                        src: '../content/images/flat/1.jpeg'
                    }, {
                        src: '../content/images/flat/2.jpeg'
                    }, {
                        src: '../content/images/flat/3.jpeg'
                    }, {
                        src: '../content/images/flat/4.jpeg'
                    }, {
                        src: '../content/images/flat/1.jpeg'
                    }, {
                        src: '../content/images/flat/2.jpeg'
                    }, {
                        src: '../content/images/flat/3.jpeg'
                    }, {
                        src: '../content/images/flat/4.jpeg'
                    }, {
                        src: '../content/images/flat/5.jpeg'
                    }, {
                        src: '../content/images/flat/5.jpeg'
                    }]
                }
            }
        }).state('apartment-detail/:id', {
            url: "/apartment-detail",
            templateUrl: 'app/component/config/router/apartment-detail.html',
            controller: function($scope, $stateParams) {
                $scope.testData = {
                    summary: {
                        description: 'Сдается 1-комн. квартира на длительный срок в 5-7 минутах ходьбы от ст. м. Полежаевская. Квартира после капитального ремонта. Мебель IKEA, холодильник, стиралка, посудомойка, микроволновка, пылесос. Кровать с большим отделением для хранения вещей. Wi-Fi 80 Mbs. Спокойные соседи. Чистый двор и подъезд (ЖСК). Два лифта. Расположение действительно уникальное. До ТЦ Авиапарк 5 минут на бесплатном автобусе. В 3-5 минутах ходьбы детская и взрослая поликлиники.',
                        roomsCount: 2,
                        address: 'Москва, ул. Юных Ленинцев, д. 228, корп. 14, кв. 88, стр. 14',
                        price: 10350000,
                        station: 'Кузьминки, район Богородское',
                        floor: 7,
                        area: 54,
                        type: 'Квартира',
                        category: 'Новостройка',
                        hasDocs: true,
                        publishDate: 1469007765797
                    },
                    coords: {
                        geometry: {
                            type: 'Point',
                            coordinates: [37.715175, 55.833436]
                        },
                        properties: {
                            iconContent: '', // Заголовок метки
                            hintContent: '', //Ховер хинт
                            balloonContent: ''//Разметка для всплывающей подсказки
                        }
                    },
                    images: [{
                        src: '../content/images/flat/1.jpeg'
                    }, {
                        src: '../content/images/flat/2.jpeg'
                    }, {
                        src: '../content/images/flat/3.jpeg'
                    }, {
                        src: '../content/images/flat/4.jpeg'
                    }, {
                        src: '../content/images/flat/5.jpeg'
                    }, {
                        src: '../content/images/flat/1.jpeg'
                    }, {
                        src: '../content/images/flat/2.jpeg'
                    }, {
                        src: '../content/images/flat/3.jpeg'
                    }, {
                        src: '../content/images/flat/4.jpeg'
                    }, {
                        src: '../content/images/flat/5.jpeg'
                    }]
                }
            }
        })
        .state('search', {
            url: '/search',
            templateUrl: 'app/component/config/router/search-page.html'
        })
        .state('my-ads', {
            url: "/my-ads",
            templateUrl: 'app/component/config/router/my-ads-page.html'
        })
        .state('home', {
            url: "/",
            templateUrl: 'app/component/config/router/main-page.html'
        })
        .state('add', {
            url: "/add",
            templateUrl: 'app/component/config/router/add.html'
        });

}).constant('EXCLUDED_DEMO_ROUTERS', [
    'demo',
    'demo-example',
    'giglob-app',
    'component.config.router',
    'component.config.filters'
]);