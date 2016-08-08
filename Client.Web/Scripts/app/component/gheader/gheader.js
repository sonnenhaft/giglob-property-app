angular.module('component.header',[]).directive('gheader', function() {
    return {
        restrict: 'E',
        templateUrl: 'app/component/gheader/gheader.html',
        scope: true,
        link: function($scope) {
        },
        controller: function($scope,$modal,localStorageService,$rootScope,$state){

            $scope.login = function(state){
                var modalInstance = $modal.open({
                    templateUrl:'app/component/login/login.html',
                    windowClass:'entry-point',
                    controller:'loginCtrl'
                });
                modalInstance.result.then(function(){state ? $state.go(state) : console.log('123') });
            };

            $scope.addAds = function(){
                if($rootScope.accessToken){
                    $state.go('add-ads');
                }else{
                    $scope.login('add-ads');
                }

            };



            $scope.logout = function(){
                localStorageService.remove('access-token');
                $rootScope.accessToken = undefined;
            }
        }
    };
});