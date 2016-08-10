angular.module('component.metro-station-multiselect', [
    'api.resource'
]).directive('metroStationMultiselect', function ( metroStations ) {
    return {
        replace: true,
        templateUrl: 'app/component/metro-station-multiselect/metro-station-multiselect.html',
        scope: {
            selectedItems: '=',
            cityId: '='
        },
        link: function ( $scope ) {
            $scope.$watch('cityId', function () {
                $scope.selectedItems = [];
            });

            $scope.$watch('stationName', function ( stationName ) {
                if ( !$scope.cityId ) { return;}
                metroStations.query({
                    id: $scope.cityId,
                    stationName: stationName
                }).$promise.then(function ( newStations ) {
                    var selectedStationsMap = $scope.selectedItems.reduce(function ( map, station ) {
                        map[ station.id ] = station;
                        return map;
                    }, {});

                    $scope.cityStations = newStations.filter(function ( station ) {
                        return !selectedStationsMap[ station.id ];
                    });
                });
            });

            $scope.selectItem = function ( stationObject, e ) {
                $scope.stationName = '';
                $scope.cityStations = [];
                $scope.selectedItems.push(stationObject);
                e.stopPropagation();
            };

            $scope.removeItem = function ( stationIndex ) {
                $scope.selectedItems.splice(stationIndex, 1);
            };
        }
    };
});