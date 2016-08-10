angular.module('component.success-timeout-popup', [
    'mm.foundation.modal'
]).factory('successTimeoutPopup', function ( $modal ) {
    return function ( delay ) {
        return $modal.open({
            templateUrl: 'app/component/success-timeout-popup/success-timeout.popup.html',
            windowClass: 'success-timeout-popup',
            backdrop: 'static',
            closeOnClick: false,
            keyboard: false,
            controller: function ( $scope, $modalInstance, $timeout ) {
                $timeout(function () {
                    $modalInstance.close();
                }, delay);

                $scope.close = function () {
                    $modalInstance.close();
                };
            }
        }).result;
    }
});