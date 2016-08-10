angular.module('component.tab-section', [
    'ngSanitize',
    'ngFileUpload',
    'component.strict-price-input'
]).directive('tabSection', function ( cityDistrictFactory, $rootScope, Upload, currentServer, $q ) {
    return {
        restrict: 'E',
        scope: {
            model: '=?',
            currentTab: '=',
            tabCollectionType: '@',
            tabs: '='
        },
        templateUrl: 'app/component/tab-section/tab-section.html',
        link: function ( $scope ) {
            $scope.uploadedFiles = [];
            $scope.model = $scope.model || [];
            $scope.data = {
                cities: [],
                districts: [],
                stations: [ { id: 1, name: 'Библиотек4а им. Ленина' }, { id: 2, name: 'Кузминки' } ],
                buildCategories: [ { id: 1, name: 'Многоквартирный дом' }, { id: 2, name: 'Частный дом' } ],
                realEstateTypes: [ { id: 1, name: 'Новостройка' }, { id: 2, name: 'Вторичка' } ]
            };

            $scope.selectCity = function () {
                var cityObj = $scope.cityDistricts.filter(function ( obj ) {return obj.id === $scope.model.city.id});
                $scope.data.districts = cityObj[ 0 ].districts;
            };

            cityDistrictFactory.get().$promise.then(function ( data ) {
                $scope.cityDistricts = data.asArray;
                $scope.data.cities = data.asMap;
                $scope.model.city = $scope.model.city || data.asArray[ 0 ];
                $scope.selectCity();
            });

            $scope.uploadFiles = function ( files, getMeta, type ) {
                if ( files && files.length ) {
                    $q.all(files.map(function ( file ) {
                        if ( getMeta ) {
                            file.formattedName = file.name.split('.')[ 0 ];
                            file.format = file.name.split('.').pop().toUpperCase();
                        }
                        $scope.uploadedFiles.push(file);
                        return Upload.upload({
                            url: currentServer + '/v1/file/upload',
                            data: { File: file, FileName: file.name }
                        });
                    })).then(function ( files ) {
                        files.forEach(function ( file ) {
                            if ( type == 'doc' ) {
                                $scope.model.push(file.data.id);
                            } else {
                                $scope.model.push(file.data);
                            }
                        });
                        $scope.setCoverModel();
                        $scope.setCover();
                    });
                    !$scope.lastCoverIndex && $scope.setCover();
                }
            };

            $scope.setCover = function ( index, skip ) {
                if ( $scope.uploadedFiles.length ) {
                    !skip && ($scope.uploadedFiles[ $scope.lastCoverIndex || 0 ].isCover = false);
                    $scope.lastCoverIndex = index || 0;
                    $scope.uploadedFiles[ $scope.lastCoverIndex ].isCover = true;
                    $scope.isAdded = true;
                    var photo = $scope.model[ $scope.lastCoverIndex ];
                    if ( photo ) {
                        $scope.model.forEach(function ( p ) {p.isCover = false;});
                        photo.isCover = true
                    }
                } else {
                    $scope.isAdded = false;
                }

            };

            $scope.setCoverModel = function ( index, skip ) {
                if ( $scope.model.length >= index - 1 ) {
                    !skip && ($scope.model[ $scope.lastCoverIndex || 0 ].isCover = false);
                    $scope.lastCoverIndex = index || 0;
                    $scope.model[ $scope.lastCoverIndex ].isCover = true;
                }
            };

            $scope.removeFile = function ( index, skipCover, type ) {
                $scope.uploadedFiles.splice(index, 1);
                $scope.model.splice(index, 1);

                if ( $scope.lastCoverIndex === index ) {
                    index = $scope.uploadedFiles.length <= index ? index - 1 : index;
                    $scope.setCover(index, true);
                    if ( type != 'doc' ) {
                        $scope.setCoverModel(index, true);
                    }

                }
            };

            $scope.saveAndGoTo = function ( currentTab, tabCollectionType ) {
                var tabs = $scope.tabs;
                var currentTabIndex = tabs[ tabCollectionType ].indexOf(currentTab);
                var nexTabIndex = currentTabIndex + 1;
                tabs[ tabCollectionType ][ currentTabIndex ].filled = true;
                tabs[ tabCollectionType ][ nexTabIndex ].disabled = '';
                tabs[ tabCollectionType ][ nexTabIndex ].active = true;
            };

            $scope.sendData = function ( type ) {
                $scope.isPublishing = true;
                $rootScope.$broadcast('add.form-submitted', type);
            };

            $rootScope.$on('api.property-offer-saved', function () {
                $scope.isPublishing = false;
            });
        }
    };
});