angular.module('component.city-popup', ['mm.foundation.modal', 'LocalStorageModule'])
    .directive('cityPopup', function($modal, localStorageService){
    return {
        restrict: 'E',
        scope: {
            ignoreLocalStorageValue: '=?'
        },
        link: function($scope) {

            if(!localStorageService.get('city')) {
                var modalInstance = $modal.open({
                    templateUrl: 'app/component/city-popup/city-popup.html',
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
        $http.get('http://giglobapi.igstest.ru/v1/home/getdata').then(function(res){
            $scope.cities = res.data.cities;
            $scope.autocomplete = true;
        });

    };

    $scope.chooseCity = function(name) {
        var regex = new RegExp('^' + name, 'i');

        return $scope.cities.filter(function(city) {
            return regex.test(city.name);
        });
    };

    $scope.ok = function() {
        localStorageService.set('city','Moscow');
        $modalInstance.close();
    };

    $scope.selected = function(name) {
        localStorageService.set('city', name);
        $modalInstance.close();
    };
});