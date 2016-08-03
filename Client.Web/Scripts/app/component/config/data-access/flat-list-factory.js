angular.module('component.config.data-access', ['api.currentServer']).factory('flatListFactory', function($resource,currentServer) {

        return $resource('http://giglobapi.igstest.ru/v1/propertyoffer/getall',
            null,
            {
                'query': {
                    method: 'GET',
                    isArray : true
                }
            });
});