angular.module('component.flat-filter', [
    'component.multiselect-list',
    'component.multiselect-dropdown'
]).directive('flatFilter', function($filter, localStorageService) {
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
            $scope.cityId = localStorageService.get('city').id;
            $scope.price = {
                min: '',
                max: ''
            };
            $scope.roomCount = [{name: '1', value: '1'}, {name: '2', value: '2'}, {name: '3', value: '3'}, {name: '4+', value: '4'}];
            $scope.applyFilter = function() {
                $scope.params = {
                    cityId : localStorageService.get('city') ? localStorageService.get('city').id : 1,
                    skip: 0,
                    take: 6,
                    minCost: $scope.price.min,
                    maxCost: $scope.price.max,
                    roomCount: ($scope.selectedRoomCount[0] || {}).value,
                    metroIds: $scope.selectedStations.map(function (station) {
                        return station.id;
                    })
                };

                $scope.$emit('applyFilter', $scope.params,true)
            };
            window.onscroll = function() {
                if ((window.innerHeight + window.scrollY) >= document.body.scrollHeight) {
                    $scope.params.skip+=6;
                    $scope.params.take+=6;
                    $scope.$emit('applyFilter', $scope.params,false);
                    console.log("Bottom of page");
                }
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