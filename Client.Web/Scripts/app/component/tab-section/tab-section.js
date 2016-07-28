angular.module('component.tab-section', ['ngSanitize']).directive('tabSection', function() {
    return {
        restrict: 'E',
        scope: {
            model: '=?',
            tabTitle: '=',
            tabDescription: '=?',
            tabType: '='
        },
        templateUrl: 'app/component/tab-section/tab-section.html',
        link: function($scope) {

        }
    };
});