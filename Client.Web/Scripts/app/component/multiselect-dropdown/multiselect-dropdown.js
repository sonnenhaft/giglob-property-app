angular.module('component.multiselect-dropdown', []).directive('multiselectDropdown', function () {
    return {
        replace: true,
        templateUrl: 'app/component/multiselect-dropdown/multiselect-dropdown.html',
        scope: {
            selectedItems: '='
        },
        link: function ($scope) {
            $scope.items = ['Спортивная', 'Московская', 'Уручье', 'Ленинская'];
            $scope.selectItem = function (item) {
                $scope.selectedItems.push(item);
            };
        }
    };
});