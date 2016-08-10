angular.module('component.set-height',[]).directive('setHeight',function($window){
    var $$window = angular.element($window);
    return function($scope,$element){
       var height = $$window[0].innerHeight-80;
        console.log($element.css('position'));
        $element.css('height',height-40 + 'px');
        $$window.bind('scroll',function(){
            if($element.css('position') === 'fixed'){
                $element.css('height',height + 'px');
            }else{
                $element.css('height',height-40 + 'px');
            }
        });

    }
});