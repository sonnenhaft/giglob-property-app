angular.module('component.multiselect-dropdown', []).directive('multiselectDropdown', function (metroStations) {
    return {
        replace: true,
        templateUrl: 'app/component/multiselect-dropdown/multiselect-dropdown.html',
        scope: {
            selectedItems: '=',
            cityId: '='
        },
        link: function ($scope) {

            $scope.getStations = function (metroName) {
                if(!$scope.cityId) {
                    return;
                }
                metroStations.query({id: $scope.cityId, stationName: metroName}, function (stations) {
                    $scope.filteredItems  = stations;
                });
            };
            $scope.selectItem = function (item, $e) {
                $e.stopPropagation();

                !$scope.selectedItems.some(function(selectedItem) {
                    return item.id === selectedItem.id
                }) && $scope.selectedItems.push(item);
            };

            $scope.removeItem = function (index) {
                $scope.selectedItems.splice(index, 1);
            };
        }
    };
});