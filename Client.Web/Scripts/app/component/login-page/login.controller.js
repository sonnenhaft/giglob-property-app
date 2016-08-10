angular.module('component.login', [
    'passToText'
]).controller('loginController', function ($scope, $modalInstance, register, login, $rootScope, localStorageService, $http) {

    $scope.reg = {};
    $scope.login = {};
    $scope.EMAIL_REGEX = /^[a-zA-Z0-9\.\-_]+@[a-z0-9\-]+\.[a-zA-Z0-9]{2,4}$/;
    $scope.notRegistered = true;
    $scope.activePage = 'login';
    $scope.SetActivePage = function (page) {
        $scope.activePage = page;
    };
    $scope.register = function () {
        $scope.regErr = undefined;
        register.save($scope.reg).$promise.then(function (res) {
            localStorageService.set('access-token', res.accessToken);
            $http.defaults.headers.common.Authorization = 'Bearer ' + localStorageService.get('access-token');
            $scope.notRegistered = false;
        }, function (err) {
            console.log(err);
            $scope.regErr = err;
        })
    };
    $scope.signin = function () {
        $scope.error = undefined;
        login.save($scope.login).$promise.then(function (res) {
            localStorageService.set('access-token', res.accessToken);
            $http.defaults.headers.common.Authorization = 'Bearer ' + localStorageService.get('access-token');
            $modalInstance.close();
        }, function (err) {
            $scope.error = err.data.modelState;
        });
    }


});

