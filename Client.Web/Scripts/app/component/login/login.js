angular.module('component.login',['passToText'])
    .controller('loginCtrl',function($scope,$modalInstance,$http,register,login){

        $scope.reg = {};
        $scope.login = {};
        $scope.EMAIL_REGEX=/^[a-z0-9\.\-_]+@[a-z0-9\-]+\.[a-z0-9]{2,4}$/;
        $scope.activePage = 'login';
        $scope.SetActivePage = function(page){
            $scope.activePage = page;
        };
        $scope.register = function(){
            console.log('123');
            $scope.register = register.save($scope.reg).$promise.then(function(res){
                console.log(res);
            })
        };
        $scope.signin = function(){
            console.log('321');
            login.save($scope.login).$promise.then(function(res){
                console.log(res);
            });
        }


});

