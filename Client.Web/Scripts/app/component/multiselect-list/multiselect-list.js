angular.module('component.multiselect-list', []).directive('multiselectList', function() {
    return {
        replace: true,
        templateUrl: 'app/component/multiselect-list/multiselect-list.html',
        scope: {
            items: '=?',
            selectedItems: '='
        },
        link: function ($scope) {
            $scope.selectItem = function (item) {
                var index = $scope.selectedItems.indexOf(item);
                if(index === -1) {
                    item.selected = true;
                    $scope.selectedItems.push(item);
                } else {
                    item.selected = false;
                    $scope.selectedItems.splice(index, 1);
                }
            }
        }
    };
});