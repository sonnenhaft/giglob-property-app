angular.module('component.tab-section', ['ngSanitize', 'ngFileUpload']).directive('tabSection', function() {
    return {
        restrict: 'E',
        scope: {
            model: '=?',
            tabTitle: '=',
            tabDescription: '=?',
            tabType: '=',
            tabCollectionType: '@'
        },
        templateUrl: 'app/component/tab-section/tab-section.html',
        link: function($scope, $element) {
            $scope.uploadedFiles = [];
            $scope.data = {
                cities: [
                    {
                        id: 1,
                        name: 'Москва'
                    },
                    {
                        id: 2,
                        name: 'Санкт-Петербург'
                    }
                ],
                districts: [
                    {
                        id: 1,
                        name: 'Академический'
                    },
                    {
                        id: 2,
                        name: 'Алексеевский'
                    }
                ],
                stations: [
                    {
                        id: 1,
                        name: 'Библиотек4а им. Ленина'
                    },
                    {
                        id: 2,
                        name: 'Кузминки'
                    }
                ],
                buildCategories : [
                    {
                        id: 1,
                        name: 'Многоквартирный дом'
                    },
                    {
                        id: 2,
                        name: 'Частный дом'
                    }
                ],
                realEstateTypes: [
                    {
                        id: 1,
                        name: 'Новостройка'
                    },
                    {
                        id: 2,
                        name: 'Вторичка'
                    }
                ]
            };
            $scope.uploadFiles = function (files, getMeta) {
                if (files && files.length) {
                    files.forEach(function(file) {
                        if(getMeta) {
                            file.formattedName = file.name.split('.')[0];
                            file.format = file.type.indexOf('pdf') + 1 ? 'PDF' : 'DOC';
                        }
                        $scope.uploadedFiles.push(file);
                    });
                    !$scope.lastCoverIndex && $scope.setCover();
                }
            };

            $scope.setCover = function (index, skip) {
                !skip && ($scope.uploadedFiles[$scope.lastCoverIndex || 0].isCover = false);

                $scope.lastCoverIndex = index || 0;
                $scope.uploadedFiles[$scope.lastCoverIndex].isCover = true;
            };

            $scope.removeFile = function (index, skipCover) {
                $scope.uploadedFiles.splice(index, 1);

                if($scope.lastCoverIndex === index) {
                    index = $scope.uploadedFiles.length <= index ? index - 1 : index;
                    $scope.setCover(index, true);
                }
            };
        }
    };
});