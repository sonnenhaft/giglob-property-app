angular.module('component.add.photos', []).directive('addPhotos', function() {
    return {
        restrict: 'E',
        templateUrl: 'app/component/add/photos/photos.html',
        scope: false
    };
});