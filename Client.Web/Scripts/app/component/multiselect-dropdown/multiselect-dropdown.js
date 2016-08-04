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
                    $scope.filteredItems = stations.filter(function(station) {
                        return !($scope.selectedItems || []).some(function(selectedItem) {
                            return selectedItem.id === station.id;
                        })
                    });
                });
            };

            $scope.selectItem = function (item, $e) {
                $e.stopPropagation();

                !$scope.selectedItems.some(function(selectedItem) {
                    return item.id === selectedItem.id
                }) && $scope.selectedItems.push(item);

                $scope.dropdownFilter = '';
                $scope.showList = false;
                $scope.filteredItems = [];
            };

            $scope.removeItem = function (index) {
                $scope.selectedItems.splice(index, 1);
            };

            $scope.getDeclension = function(number, labels) {
                var cases = [2, 0, 1, 1, 1, 2];
                return labels[(number % 100 > 4 && number % 100 < 20) ? 2 : cases[(number%10<5) ? number % 10 : 5]];
            }
        }
    };
});