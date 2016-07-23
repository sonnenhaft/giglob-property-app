angular.module('component.city-popup', ['mm.foundation.modal', 'LocalStorageModule']).directive('cityPopup', function($modal, localStorageService){
    return {
        restrict: 'E',
        scope: {
            ignoreLocalStorageValue: '=?'
        },
        link: function($scope) {
            localStorageService.set('city', 'Moscow');

            if(!localStorageService.get('city') || $scope.ignoreLocalStorageValue) {
                var modalInstance = $modal.open({
                    templateUrl: '/app/component/city-popup/city-popup.html',
                    controller: 'cityPopupCtrl',
                    windowClass: 'choose-city',
                    backdrop: 'static',
                    closeOnClick: false,
                    resolve: {
                        items: function () {
                            console.log('123');
                        }
                    }
                });
            }
        }
    };
}).controller('cityPopupCtrl', function($scope, $http, $modalInstance, localStorageService) {
    $scope.changeCity = function() {
        //TODO вынести в отдельный API сервис
        $http.get('https://giglobapi.igstest.ru/v1/home/getdata').then(function(res){
            $scope.cities = res.data.cities;
            $scope.autocomplete = true;
        });

    };

    $scope.chooseCity = function(name) {
        var arr = [];
        $scope.cities.find(function(el) {
            if(el.name.indexOf(name) !== -1){
                arr.push(el);
            }
        });
        console.log(arr);
        return arr;
    };

    $scope.ok = function() {
        $modalInstance.close();
    };

    $scope.selected = function(name) {
        localStorageService.set('city', name);
        $scope.ok();
    };
});