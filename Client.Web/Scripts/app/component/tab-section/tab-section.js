angular.module('component.tab-section', ['ngSanitize', 'ngFileUpload']).directive('tabSection', function() {
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
            $scope.uploadedFiles = [];

            $scope.uploadFiles = function (files) {
                if (files && files.length) {
                    $scope.uploadedFiles.push(files);
                    console.log($scope.uploadedFiles);
                }
            }
        }
    };
});