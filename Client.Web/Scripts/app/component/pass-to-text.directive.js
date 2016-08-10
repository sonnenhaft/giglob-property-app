angular.module('passToText',[]).directive('passToText', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs, ngModelCtrl) {
            attrs.$observe('passToText', function (val) {
                console.log(val);
                if (val == 'true') {
                    element.attr('type', 'text');
                }
                else if (val == 'false') {
                    element.attr('type', 'password');
                }
            });
        }
    }
});
