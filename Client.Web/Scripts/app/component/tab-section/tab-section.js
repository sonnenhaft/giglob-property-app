angular.module('component.tab-section', [
    'ngSanitize',
    'ngFileUpload',
    'component.strict-price-input'
]).directive('tabSection', function (addFlatTabs, cityDistrictFactory, $rootScope, Upload, currentServer) {
    return {
        restrict: 'E',
        scope: {
            model: '=?',
            currentTab: '=',
            tabCollectionType: '@'
        },
        templateUrl: 'app/component/tab-section/tab-section.html',
        link: function ($scope) {
            $scope.addFlatTabs = addFlatTabs;
            $scope.uploadedFiles = [];
            $scope.model = [];
            $scope.data = {
                cities: [],
                districts: [],
                stations: [{id: 1, name: 'Библиотек4а им. Ленина'}, {id: 2, name: 'Кузминки'}],
                buildCategories: [{id: 1, name: 'Многоквартирный дом'}, {id: 2, name: 'Частный дом'}],
                realEstateTypes: [{id: 1, name: 'Новостройка'}, {id: 2, name: 'Вторичка'}]
            };

            $scope.selectCity = function () {
                $scope.data.districts = $scope.cityDistricts[$scope.model.city.id].districtsAsArray;
            };

            cityDistrictFactory.get().$promise.then(function (data) {
                $scope.cityDistricts = data.asArray;
                $scope.data.cities = data.asMap;
                $scope.model.city = $scope.model.city || data.asArray[0];
                $scope.selectCity();
            });

            $scope.uploadFiles = function (files, getMeta, type) {
                if (files && files.length) {
                    files.forEach(function (file) {
                        if (getMeta) {
                            file.formattedName = file.name.split('.')[0];
                            file.format = file.name.split('.').pop().toUpperCase();
                        }
                        var upload = Upload.upload({
                            url: currentServer + '/v1/file/upload',
                            data: {File: file, FileName: file.name},
                            headers: {'Authorization': 'Bearer ' + $rootScope.accessToken}
                        });
                        upload.then(function (file) {
                            if (type == 'doc') {
                                $scope.model.push(file.data.id);
                            } else {
                                $scope.model.push(file.data);
                                $scope.setCoverModel();
                            }

                        }, function (resp) {
                        }, function (evt) {
                        });
                        $scope.uploadedFiles.push(file);
                    });
                    !$scope.lastCoverIndex && $scope.setCover();
                }
            };

            $scope.setCover = function (index, skip) {
                if ($scope.uploadedFiles.length) {
                    !skip && ($scope.uploadedFiles[$scope.lastCoverIndex || 0].isCover = false);
                    $scope.lastCoverIndex = index || 0;
                    $scope.uploadedFiles[$scope.lastCoverIndex].isCover = true;
                    $scope.isAdded = true;
                } else {
                    $scope.isAdded = false;
                }

            };

            $scope.setCoverModel = function (index, skip) {
                if ($scope.model.length) {
                    !skip && ($scope.model[$scope.lastCoverIndex || 0].isCover = false);
                    $scope.lastCoverIndex = index || 0;
                    $scope.model[$scope.lastCoverIndex].isCover = true;
                }

            };

            $scope.removeFile = function (index, skipCover, type) {
                $scope.uploadedFiles.splice(index, 1);
                $scope.model.splice(index, 1);

                if ($scope.lastCoverIndex === index) {
                    index = $scope.uploadedFiles.length <= index ? index - 1 : index;
                    $scope.setCover(index, true);
                    if (type != 'doc') {
                        $scope.setCoverModel(index, true);
                    }

                }
            };

            $scope.saveAndGoTo = function (currentTab, tabCollectionType) {
                var currentTabIndex = addFlatTabs[tabCollectionType].indexOf(currentTab);
                var nexTabIndex = currentTabIndex + 1;
                addFlatTabs[tabCollectionType][currentTabIndex].filled = true;
                addFlatTabs[tabCollectionType][nexTabIndex].disabled = '';
                addFlatTabs[tabCollectionType][nexTabIndex].active = true;
            };

            $scope.sendData = function (type) {
                $rootScope.$broadcast('addFormSubmitted', type);
            };

            $scope.$on('objectSaved', function () {
                if ($scope.uploadedFiles) {
                    $scope.uploadedFiles = [];
                }
            });
        }
    };
});