angular.module('component.router', ['ui.router']).config(function($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise("/");
    $stateProvider
        .state('search', {
            url: "/search",
            templateUrl: "app/component/router/search-page.html"
        })
        .state('my-ads', {
            url: "/my-ads",
            templateUrl: "app/component/router/my-ads-page.html"
        })
        .state('home', {
            url: "/",
            templateUrl: "app/component/router/main-page.html"
        });
});