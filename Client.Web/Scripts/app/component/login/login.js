angular.module('component.login',['passToText'])
    .controller('loginCtrl',function($scope,$modalInstance,$http){

        $scope.EMAIL_REGEX=/^[a-z0-9\.\-_]+@[a-z0-9\-]+\.[a-z0-9]{2,4}$/;
        $scope.info  = '123';
        $scope.activePage = 'login';
        $scope.SetActivePage = function(page){
            $scope.activePage = page;
        }
});

