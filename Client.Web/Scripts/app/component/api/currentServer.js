angular.module("api.currentServer", [])
    .factory('currentServer', function () {
        var server = document.getElementById('apiUrl').dataset.url;
        if (server === '@Model'){
            server = 'http://api.giglob.local';
        }
        console.log(server);
        return server;
    });