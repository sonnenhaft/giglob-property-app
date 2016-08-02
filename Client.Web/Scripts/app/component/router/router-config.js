angular.module('component.router', ['ui.router'])
    .config(function($stateProvider, $urlRouterProvider, EXCLUDED_DEMO_ROUTERS,$locationProvider) {
    $urlRouterProvider.otherwise("/");

    $locationProvider.html5Mode(true);

    $stateProvider
        .state('demo', {
            url: "/demo",
            templateUrl: "app/component/router/demo-page.html",
            controller: function ($scope) {
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
                        price: 10350000,
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
                        src: 'app/component/carousel/example/images/1.jpeg'
                    }, {
                        src: 'app/component/carousel/example/images/2.jpeg'
                    }, {
                        src: 'app/component/carousel/example/images/3.jpeg'
                    }, {
                        src: 'app/component/carousel/example/images/4.jpeg'
                    }, {
                        src: 'app/component/carousel/example/images/5.jpeg'
                    }, {
                        src: 'app/component/carousel/example/images/5.jpeg'
                    }, {
                        src: 'app/component/carousel/example/images/5.jpeg'
                    }, {
                        src: 'app/component/carousel/example/images/5.jpeg'
                    }, {
                        src: 'app/component/carousel/example/images/5.jpeg'
                    }, {
                        src: 'app/component/carousel/example/images/5.jpeg'
                    }]
                }
            }
        })
        .state('search', {
            url: '/search',
            templateUrl: 'app/component/router/search-page.html'
        })
        .state('my-ads', {
            url: "/my-ads",
            templateUrl: 'app/component/router/my-ads-page.html',
        }).state('apartment-detail/', {
            url: "/apartment-detail/:id",
            templateUrl: 'app/component/router/apartment-detail.html',
            resolve : {
                getInfo : function($stateParams,getProperty){
                    console.log($stateParams.id);
                    getProperty.query({id:$stateParams.id}).$promise.then(function(res){
                        console.log(res)
                    },function(err){
                        console.log(err)
                    })
                }
            },
            controller: function($scope, $stateParams) {

            }
        })
        .state('home', {
            url: "/",
            templateUrl: 'app/component/router/main-page.html'
        });

}).constant('EXCLUDED_DEMO_ROUTERS', [
    'demo',
    'giglob-app',
    'component.router'
]);