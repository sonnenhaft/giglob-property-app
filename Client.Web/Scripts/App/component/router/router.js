angular.module('component.router', ['ui.router']).config(function($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise("/");
    $stateProvider
        .state('search', {
            url: "/search",
            templateUrl: "component/router/search-page.html"
        })
        .state('my-ads', {
            url: "/my-ads",
            templateUrl: "component/router/my-ads-page.html"
        })
        .state('home', {
            url: "/",
            templateUrl: "component/router/main-page.html"
        });
});