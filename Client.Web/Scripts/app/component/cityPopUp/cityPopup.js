angular.module('component.cityPopup',[]).controller('cityPopupCtrl',function($scope,$modalInstance,localStorageService,$http){
    localStorageService.set('city','Moscow');

    $scope.changeCity = function(){
        $http.get('https://api.giglob.local/v1/home/getdata').then(function(res){
            $scope.cities = res.data.cities;
            $scope.autocomplite = true;
        });

    };

    $scope.chooseCity = function(name){
        var arr = [];
        $scope.cities.find(function(el,i,ar){
            if(el.name.indexOf(name) != -1){
                arr.push(el);
            }
        });
        console.log(arr);
        return arr;
    };

    $scope.ok = function(){
        $modalInstance.close();
    };

    $scope.selected=function(name){
        localStorageService.set('city',name);
        $scope.ok();
    };


});