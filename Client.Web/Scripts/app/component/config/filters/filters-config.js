angular.module('component.config.filters', []).filter('currencyFilter', function($filter) {
    return function(value, currencySign, separator) {
        return $filter('number')(value, 0).replace(/,/g, separator) + ' ' + currencySign;
    }
});