angular.module("api.currentServer", [])
    .factory('currentServer', function ($resource) {
        return  document.getElementById('apiUrl').dataset., {});
    });
