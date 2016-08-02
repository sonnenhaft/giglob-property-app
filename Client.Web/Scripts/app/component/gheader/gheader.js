﻿angular.module('component.gheader', []).directive('gheader', function() {
    return {
        restrict: 'E',
        templateUrl: 'app/component/gheader/gheader.html',
        scope: true,
        link: function($scope) {
        },
        controller: function($scope,$modal,localStorageService,$rootScope){

            $scope.login = function(){
                var modalInstance = $modal.open({
                    templateUrl:'app/component/login/login.html',
                    windowClass:'entry-point',
                    controller:'loginCtrl'
                })
            };

            $scope.logout = function(){
                localStorageService.remove('access-token');
                $rootScope.accessToken = undefined;
            }
        }
    };
});