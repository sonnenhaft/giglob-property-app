angular.module('component.router', ['ui.router']).config(function($stateProvider, $urlRouterProvider, EXCLUDED_DEMO_ROUTERS) {
    $urlRouterProvider.otherwise("/");

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
            }
        })
        .state('search', {
            url: '/search',
            templateUrl: 'app/component/router/search-page.html'
        })
        .state('my-ads', {
            url: "/my-ads",
            templateUrl: 'app/component/router/my-ads-page.html'
        })
        .state('home', {
            url: "/",
            templateUrl: 'app/component/router/main-page.html'
        });

}).constant('EXCLUDED_DEMO_ROUTERS', ['demo', 'giglob-app', 'component.router']);