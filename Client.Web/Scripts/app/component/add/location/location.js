angular.module('component.add.location', []).directive('addLocation', function() {
    return {
        restrict: 'E',
        templateUrl: 'app/component/add/location/location.html',
        scope: false
    };
});