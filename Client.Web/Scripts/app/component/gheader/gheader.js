angular.module('component.gheader', []).directive('gheader', function() {
    return {
        restrict: 'E',
        templateUrl: 'app/component/gheader/gheader.html',
        scope: true,
        link: function($scope) {
        },
        controller: function($scope,$modal){
            $scope.login = function(){
                var modalInstance = $modal.open({
                    templateUrl:'app/component/login/login.html',
                    windowClass:'entry-point',
                    controller:'loginCtrl'
                })
            };
        }
    };
});