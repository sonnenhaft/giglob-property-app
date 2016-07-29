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
                    files.forEach(function(file) {
                        $scope.uploadedFiles.push(file);
                    });
                    $scope.setCover(0);
                }
            };

            $scope.setCover = function (index) {
                $scope.uploadedFiles.some(function(file) {
                    if(file.isCover) {
                        file.isCover = false;
                        return true;
                    }
                });
                $scope.uploadedFiles[index].isCover = true;
            }
        }
    };
});