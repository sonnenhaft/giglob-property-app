angular.module("api.currentServer", [])
    .factory('currentServer', function () {
        var server = document.getElementById('apiUrl').dataset.url;
        if (server === '@Model'){
            server = 'http://giglobapi.igstest.ru/';
        }
        return server;
    });