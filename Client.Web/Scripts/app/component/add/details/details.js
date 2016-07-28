angular.module('component.add.details', []).directive('addDetails', function() {
    return {
        restrict: 'E',
        templateUrl: 'app/component/add/details/details.html',
        scope: false
    };
});