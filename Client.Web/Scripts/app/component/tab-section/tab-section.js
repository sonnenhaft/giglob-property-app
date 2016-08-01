angular.module('component.tab-section', ['ngSanitize', 'ngFileUpload']).directive('tabSection', function(addFlatTabs, cityDistrictFactory, $rootScope) {
    return {
        restrict: 'E',
        scope: {
            model: '=?',
            currentTab: '=',
            tabCollectionType: '@'
        },
        templateUrl: 'app/component/tab-section/tab-section.html',
        link: function($scope, $element) {
            $scope.addFlatTabs = addFlatTabs;
            $scope.uploadedFiles = [];
            $scope.data = {
                cities: [],
                districts: [],
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

            $scope.selectCity = function () {

                var dist = $scope.cityDistricts[$scope.model.city.id].districts;

                var distList = []
                for(var item in dist){
                    distList.push({
                        id: item,
                        name: dist[item]
                    });

                }
                $scope.data.districts= distList;
            }

            cityDistrictFactory.get().$promise.then(function(data){
                $scope.cityDistricts = data;
                for(var item in data){
                    $scope.data.cities.push({
                        id: item,
                        name: data[item].name
                    });
                }

                $scope.selectCity();
            });

            $scope.uploadFiles = function (files, getMeta) {
                if (files && files.length) {
                    files.forEach(function(file) {
                        if(getMeta) {
                            file.formattedName = file.name.split('.')[0];
                            file.format = file.name.split('.').pop().toUpperCase();
                        }
                        $scope.uploadedFiles.push(file);
                    });
                    !$scope.lastCoverIndex && $scope.setCover();
                }
            };

            $scope.setCover = function (index, skip) {
                if ($scope.uploadedFiles.length){
                    !skip && ($scope.uploadedFiles[$scope.lastCoverIndex || 0].isCover = false);
                    $scope.lastCoverIndex = index || 0;
                    $scope.uploadedFiles[$scope.lastCoverIndex].isCover = true;
                    $scope.isAdded = true;
                }else{
                    $scope.isAdded = false;
                }

            };

            $scope.removeFile = function (index, skipCover) {
                $scope.uploadedFiles.splice(index, 1);

                if($scope.lastCoverIndex === index) {
                    index = $scope.uploadedFiles.length <= index ? index - 1 : index;
                    $scope.setCover(index, true);
                }
            };
            $scope.saveAndGoTo = function (currentTab, tabCollectionType) {
                var currentTabIndex = addFlatTabs[tabCollectionType].indexOf(currentTab);
                var nexTabIndex = currentTabIndex + 1;
                addFlatTabs[tabCollectionType][currentTabIndex].filled = true;
                addFlatTabs[tabCollectionType][nexTabIndex].disabled = '';
                addFlatTabs[tabCollectionType][nexTabIndex].active = true;
            };

            $scope.sendData = function(type) {
                $rootScope.$broadcast('addFormSubmitted', type);
            }
        }
    };
});