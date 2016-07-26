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

            $scope.selectItem = function (item) {
                !$scope.selectedItems.some(function(selectedItem) {
                    return item.id === selectedItem.id
                }) && $scope.selectedItems.push(item);
            };
        }
    };
});