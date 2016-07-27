angular.module('component.login',['passToText'])
    .controller('loginCtrl',function($scope,$modalInstance,$http,register,login,$rootScope,localStorageService){

        $scope.reg = {};
        $scope.login = {};
        $scope.EMAIL_REGEX=/^[a-z0-9\.\-_]+@[a-z0-9\-]+\.[a-z0-9]{2,4}$/;
        $scope.notRegistered = true;
        $scope.activePage = 'login';
        $scope.SetActivePage = function(page){
            $scope.activePage = page;
        };
        $scope.register = function(){
            $scope.regErr = undefined;
            console.log($scope.reg);
            register.save($scope.reg).$promise.then(function(res){
                $scope.notRegistered = false;
            },function(err){
                console.log(err);
                $scope.regErr = err;

            })
        };
        $scope.signin = function(){
            $scope.error = undefined;
            console.log($scope.login);
            login.save($scope.login).$promise.then(function(res){
                localStorageService.set('access-token',res.accessToken);
                $rootScope.accessToken = res.accessToken;
                $modalInstance.close();
            },function(err){
                $scope.error = err.data.modelState;
            });
        }


});

