angular.module('component.add.docs', []).directive('addDocs', function() {
    return {
        restrict: 'E',
        templateUrl: 'app/component/add/docs/docs.html',
        scope: false
    };
});