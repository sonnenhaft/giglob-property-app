angular.module('component.set-height',[]).directive('setHeight',function($window){
    var $$window = angular.element($window);
    return function($scope,$element){
       var height = $$window[0].innerHeight-80;
        $element.css('height',height + 'px');

    }
});