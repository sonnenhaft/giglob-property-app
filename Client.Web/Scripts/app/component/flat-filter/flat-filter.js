angular.module('component.flat-filter', [
    'component.multiselect-list',
    'component.multiselect-dropdown'
]).directive('flatFilter', function() {
    return {
        replace: true,
        templateUrl: 'app/component/flat-filter/flat-filter.html',
        scope: true,
        link: function ($scope) {
            $scope.selectedRoomCount = [];
            $scope.selectedStations = [];
            $scope.roomCount = [{name: '1', value: '1'}, {name: '2', value: '2'}, {name: '3', value: '3'}, {name: '4+', value: '4+'}];
        }
    };
});