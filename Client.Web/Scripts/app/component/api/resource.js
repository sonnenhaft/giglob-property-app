angular.module("api.resource",["ngResource"])
    .factory('giglobApi', function ($resource) {
        return  $resource('http://giglobapi.igstest.ru/v1/:type/:action', {});
    })
    .factory("register", function ($resource) {

        return  $resource('http://giglobapi.igstest.ru/v1/user/register',
            null,
            {
                'save': { method:'POST'}
            });
    })
    .factory('login',function($resource){
        return $resource('http://giglobapi.igstest.ru/v1/user/signin',
            null,
            {
                'save' : {method:'POST'}
            });
    })
    .factory('confirm',function($resource){
        return $resource('http://giglobapi.igstest.ru/v1/user/confirmemail',
            null,
            {
                'save' : {method:'POST'}
            });
    });

