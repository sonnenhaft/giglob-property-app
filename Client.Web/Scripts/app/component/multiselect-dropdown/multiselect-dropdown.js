angular.module('component.multiselect-dropdown', []).directive('multiselectDropdown', function () {
    return {
        replace: true,
        templateUrl: 'app/component/multiselect-dropdown/multiselect-dropdown.html',
        scope: {
            selectedItems: '='
        },
        link: function ($scope) {
            $scope.items = [
                {
                    id: 1,
                    name: 'Спортивная',
                    color: '#3F82E3'
                },
                {
                    id: 2,
                    name: 'Московская',
                    color: '#FFBD1C'
                },
                {
                    id: 3,
                    name: 'Уручье',
                    color: '#E33F3F'
                },
                {
                    id: 4,
                    name: 'Ленинская',
                    color: '#000'
                }
            ];

            $scope.filteredItems = $scope.items;

            $scope.selectItem = function (item, $e) {
                $e.stopPropagation();

                !$scope.selectedItems.some(function(selectedItem) {
                    return item.id === selectedItem.id
                }) && $scope.selectedItems.push(item);
            };

            $scope.removeItem = function (index) {
                $scope.selectedItems.splice(index, 1);
            };

            $scope.findStation = function() {
                var regex = new RegExp('^' + $scope.dropdownFilter, 'i');

                $scope.filteredItems =  $scope.items.filter(function(item) {
                    return regex.test(item.name);
                })
            }
        }
    };
});