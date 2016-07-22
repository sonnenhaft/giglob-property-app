angular.module('giglob-app',[
    'LocalStorageModule',
    'mm.foundation',
    "component.gheader",
    'component.router',
    'component.cityPopup'
]).directive('giglob', function() {
    return {
        templateUrl: '/app/giglob.html',
        controller: function($scope,$modal,localStorageService){
            if(!localStorageService.get('city')){
                var modalInstance = $modal.open({
                    templateUrl: '/app/component/cityPopup/cityPopup.html',
                    controller:'cityPopupCtrl',
                    windowClass:'choose-city',
                    resolve: {
                        items: function () {
                            console.log('123');
                        }
                    }
                });
            }
        },
        link: function($scope) {

        }
    };
});