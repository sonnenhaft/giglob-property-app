angular.module('component.header', []).directive('gheader', function () {
    return {
        restrict: 'E',
        templateUrl: 'app/component/gheader/gheader.html',
        scope: true,
        controller: function ($scope, $modal, localStorageService, $rootScope, $state, $http) {
            $scope.accessToken = localStorageService.get('access-token');
            $scope.login = function (state) {
                $modal.open({
                    templateUrl: 'app/component/login/login.html',
                    windowClass: 'entry-point',
                    controller: 'loginController'
                }).result.then(function () {
                    $scope.accessToken = localStorageService.get('access-token');
                    state ? $state.go(state) : console.log('something went wrong while logining')
                });
            };

            $scope.addAds = function () {
                if (localStorageService.get('access-token')) {
                    $state.go('add-ads');
                } else {
                    $scope.login('add-ads');
                }
            };

            $scope.logout = function () {
                localStorageService.remove('access-token');
                $scope.accessToken = localStorageService.get('access-token');
                $http.defaults.headers.common.Authorization = undefined;
                $state.go('search');
            }
        }
    };
});