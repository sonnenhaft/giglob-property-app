angular.module('component.config.data-access', []).factory('flatListFactory', function($resource) {


        return $resource('http://api.giglob.local/v1/propertyoffer/getall',
            null,
            {
                'query': {
                    method: 'GET',
                    isArray : true
                }
            });

});