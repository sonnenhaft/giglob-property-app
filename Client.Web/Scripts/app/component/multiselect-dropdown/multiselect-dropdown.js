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
                    name: 'Улица Подбельского',
                    color: '#ff0000'
                },
                {
                    id: 2,
                    name: 'Черкизовская',
                    color: '#ff0000'
                },
                {
                    id: 3,
                    name: 'Преображенская площадь',
                    color: '#ff0000'
                },
                {
                    id: 4,
                    name: 'Сокольники',
                    color: '#ff0000'
                },
                {
                    id: 5,
                    name: 'Красносельская',
                    color: '#ff0000'
                },
                {
                    id: 6,
                    name: 'Красные ворота',
                    color: '#ff0000'
                },
                {
                    id: 7,
                    name: 'Чистые пруды',
                    color: '#ff0000'
                },
                {
                    id: 8,
                    name: 'Лубянка',
                    color: '#ff0000'
                },
                {
                    id: 9,
                    name: 'Охотный ряд',
                    color: '#ff0000'
                },
                {
                    id: 10,
                    name: 'Библиотека имени Ленина',
                    color: '#ff0000'
                },
                {
                    id: 11,
                    name: 'Преображенская площадь',
                    color: '#ff0000'
                },
                {
                    id: 12,
                    name: 'Кропоткинская',
                    color: '#ff0000'
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