angular.module('component.multiselect-dropdown-g', []).directive('multiselectDropdownG', function (metroStations) {
    return {
        replace: true,
        templateUrl: 'app/component/multiselect-dropdown-g/multiselect-dropdown-g.html',
        scope: {
            selectedItems: '=',
            cityId: '='
        },
        link: function ($scope) {
            $scope.selectedItems =  $scope.selectedItems ?  $scope.selectedItems : [];

            $scope.getStations = function (metroName) {
                if(!$scope.cityId) {
                    return;
                }
                metroStations.get({id: $scope.cityId, stationName: metroName}, function (stations) {
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