angular.module('component.config.filters', []).filter('filterExample', function() {
    return function(items) {
        return items;
    }
});