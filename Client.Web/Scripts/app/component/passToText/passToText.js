angular.module('passToText',[]).directive('passToText', [function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs, ngModelCtrl) {
            attrs.$observe('passwToText', function (val) {
                if (val == 'true') {
                    element.attr('type', 'text');
                }
                else if (val == 'false') {
                    element.attr('type', 'password');
                }
            });
        }
    }
}]);