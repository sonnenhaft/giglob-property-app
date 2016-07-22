angular.module('component.cityPopup',[]).controller('cityPopupCtrl',function($scope,$modalInstance,localStorageService,$http){
    localStorageService.set('city','Moscow');

    $scope.changeCity = function(){
        //TODO обернуть в  resource
        $http.get('https://giglobapi.igstest.ru/v1/home/getdata').then(function(res){
            $scope.cities = res.data.cities;
            $scope.autocomplete = true;
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