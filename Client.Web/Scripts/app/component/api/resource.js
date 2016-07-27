angular.module("api.resource",["ngResource"])
    .factory("register", function ($resource) {

        return  $resource('http://api.giglob.local/v1/user/register',
            null,
            {
                'save': { method:'POST'}
            });
    })
    .factory('login',function($resource){
        return $resource('http://api.giglob.local/v1/user/signin',
            null,
            {
                'save' : {method:'POST'}
            });
    });

