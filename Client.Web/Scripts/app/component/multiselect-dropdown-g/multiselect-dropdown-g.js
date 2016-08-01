angular.module('component.multiselect-dropdown-g', []).directive('multiselectDropdownG', function () {
    return {
        replace: true,
        templateUrl: 'app/component/multiselect-dropdown-g/multiselect-dropdown-g.html',
        scope: {
            selectedItems: '='
        },
        link: function ($scope) {
            $scope.selectedItems =  $scope.selectedItems ?  $scope.selectedItems : [];

            $scope.items = [
                {
                    id: 1,
                    name: 'Улица Подбельского',
                    color: '#008000'
                },
                {
                    id: 2,
                    name: 'Черкизовская',
                    color: '#008000'
                },
                {
                    id: 3,
                    name: 'Преображенская площадь',
                    color: '#008000'
                },
                {
                    id: 4,
                    name: 'Сокольники',
                    color: '#ff0000'
                },
                {
                    id: 5,
                    name: 'Красносельская',
                    color: '#ff6a14'
                },
                {
                    id: 6,
                    name: 'Красные ворота',
                    color: '#33adff'
                },
                {
                    id: 7,
                    name: 'Чистые пруды',
                    color: '#7d5329'
                },
                {
                    id: 8,
                    name: 'Лубянка',
                    color: '#ff6a14'
                },
                {
                    id: 9,
                    name: 'Охотный ряд',
                    color: '#ff0000'
                },
                {
                    id: 10,
                    name: 'Библиотека имени Ленина',
                    color: '#33adff'
                },
                {
                    id: 11,
                    name: 'Кропоткинская',
                    color: '#7d5329'
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