﻿angular.module('component.city-popup', ['mm.foundation.modal', 'LocalStorageModule']).directive('cityPopup', function($modal, localStorageService){
    return function($scope) {
        if(!localStorageService.get('city')) {
            $modal.open({
                templateUrl: 'app/component/city-popup/city-popup.html',
                windowClass: 'choose-city',
                backdrop: 'static',
                closeOnClick: false,
                keyboard: false,
                controller: function($scope, $http, $modalInstance, localStorageService, currentServer) {
                    $scope.changeCity = function () {
                        //TODO вынести в отдельный API сервис
                        $http.get(currentServer + '/v1/home/getdata').then(function (res) {
                            $scope.cities = res.data.cities;
                            $scope.autocomplete = true;
                        });

                    };

                    $scope.chooseCity = function (name) {
                        var regex = new RegExp('^' + name, 'i');

                        return $scope.cities.filter(function (city) {
                            return regex.test(city.name);
                        });
                    };

                    $scope.ok = function () {
                        localStorageService.set('city', {id:1,name:'Moscow'});
                        $modalInstance.close();
                    };

                    $scope.selected = function (name) {
                        localStorageService.set('city', name);
                        $modalInstance.close();
                    };
                }
            });
        }
    }
});