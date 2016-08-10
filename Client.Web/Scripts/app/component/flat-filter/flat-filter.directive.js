angular.module('component.flat-filter', [
    'component.multiselect-list',
    'component.multiselect-dropdown',
    'component.strict-price-input'
]).directive('flatFilter', function($filter, localStorageService,$rootScope) {
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
            $scope.cityId = (localStorageService.get('city') ? localStorageService.get('city').id : 1);
            $scope.price = {
                min: '',
                max: ''
            };

            var coords = [];
            $rootScope.mapInit = function(e){
                coords = e._bounds;
                $scope.applyFilter();
            };
            $rootScope.mapChange = function (event) {
                coords = event.get('newBounds');
                $scope.applyFilter();
            };
            $scope.roomCount = [{name: '1', value: '1'}, {name: '2', value: '2'}, {name: '3', value: '4'}, {name: '4+', value: '8'}];
            $scope.applyFilter = function() {
                $scope.params = {
                    skip: 0,
                    take: 300,
                    minCost: $scope.price.min,
                    maxCost: $scope.price.max,
                    roomCount: (getArraySum($scope.selectedRoomCount) || {}.value),
                    metroIds: $scope.selectedStations.map(function (station) {
                        return station.id;
                    }),
                    'viewPort.leftBottomLon': coords[0][0],
                    'viewPort.leftBottomLat': coords[0][1],
                    'viewPort.rightTopLon': coords[1][0],
                    'viewPort.rightTopLat': coords[1][1],
                    'viewPort.leftTopLon': coords[0][0],
                    'viewPort.leftTopLat': coords[1][1],
                    //TODO: (mike) fix map, I've commented thing that broke the map
                    'viewPort.rightBottomTopLon': coords[1][0],
                    'viewPort.rightBottomTopLat': coords[0][1],
                    // 'viewPort.rightBottomLon': coords[1][0],
                    // 'viewPort.rightBottomLat': coords[0][1]
                };
                $scope.$emit('applyFilter', $scope.params,true)
            };


            function getArraySum(arr){
                var sum = 0;
                for(var i = 0;i<arr.length;i++){
                    sum+=+arr[i].value;
                }
                return sum
            }


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