angular.module('component.flat-filter', [
    'component.multiselect-list',
    'component.multiselect-dropdown'
]).directive('flatFilter', function($filter) {
    return {
        replace: true,
        templateUrl: 'app/component/flat-filter/flat-filter.html',
        scope: {
            allFlats: '=',
            filteredFlats: '='
        },
        link: function ($scope) {
            $scope.selectedRoomCount = [];
            $scope.selectedStations = [];
            $scope.price = {
                min: '',
                max: ''
            };
            $scope.roomCount = [{name: '1', value: '1'}, {name: '2', value: '2'}, {name: '3', value: '3'}, {name: '4+', value: '4+'}];
            $scope.applyFilter = function() {
                $scope.filteredFlats = $filter('flatFilter')(
                    $scope.allFlats,
                    $scope.selectedRoomCount,
                    $scope.selectedStations,
                    $scope.price);
            };
            $scope.applyFilter();
        }
    };
}).directive('onClickOutside', function($document) {
    return function($scope, $element, $attrs) {
        function cb($e) {
            $e.stopPropagation();
            if(!$element[0].contains($e.target)) {
                $scope.$eval($attrs.onClickOutside);
                $scope.$applyAsync();
            }
        }

        $document[0].addEventListener('click', cb);

        $scope.$on('$destroy', function() {
            $document[0].removeEventListener('click', cb);
        })
    }
});