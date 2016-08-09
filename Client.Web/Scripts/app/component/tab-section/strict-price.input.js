angular.module('component.strict-price-input', [
]).directive('strictPriceInput', function ($filter) {
    return {
        require: 'ngModel',
        link: function ($scope, $element, ignored, ngModel) {
            $element.bind('keyup', function (e) {
                var val = $element.val() || '';
                var digits = val.replace(/\D+/g, '').slice(0, 12);
                var number;
                if (digits) {
                    number = digits - 0;
                    digits = digits ? $filter('number')((number) + '') : digits;
                }
                if (val !== digits) {
                    $element.val(digits);
                    ngModel.$setViewValue(number);
                }
            });
        }
    }
});