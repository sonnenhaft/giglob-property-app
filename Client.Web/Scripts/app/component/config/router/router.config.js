angular.module('component.config.router', [
    'ui.router',
    'component.keep-on-scroll',
    'component.set-height',
    'api.resource',
    'component.config.data-access'
]).config(function ($stateProvider, $urlRouterProvider, EXCLUDED_DEMO_ROUTERS, $locationProvider) {
        $urlRouterProvider.otherwise("/");

        $stateProvider
            .state('demo', {
                url: "/demo",
                templateUrl: "app/component/config/router/demo-page.html",
                controller: function ($scope, $state) {
                    $scope.routes = $state.get().filter(function (route) {
                        return !!route.name && EXCLUDED_DEMO_ROUTERS.indexOf(route.name) === -1;
                    });

                    $scope.modules = angular.modules.filter(function (moduleName) {
                        return !(EXCLUDED_DEMO_ROUTERS.indexOf(moduleName) + 1);
                    });
                }
            })
            .state('demo-example', {
                url: '/demo/:name',
                templateUrl: function ($stateParams) {
                    var name = $stateParams.name;
                    return 'app/' + name.split('.').join('/') + '/example/index.html';
                },
                controller: function ($scope, $stateParams) {
                    $scope.testData = {
                        summary: {
                            description: 'Сдается 1-комн. квартира на длительный срок в 5-7 минутах ходьбы от ст. м. Полежаевская. Квартира после капитального ремонта. Мебель IKEA, холодильник, стиралка, посудомойка, микроволновка, пылесос. Кровать с большим отделением для хранения вещей. Wi-Fi 80 Mbs. Спокойные соседи. Чистый двор и подъезд (ЖСК). Два лифта. Расположение действительно уникальное. До ТЦ Авиапарк 5 минут на бесплатном автобусе. В 3-5 минутах ходьбы детская и взрослая поликлиники.',
                            roomsCount: 2,
                            address: 'Москва, ул. Юных Ленинцев, д. 228, корп. 14, кв. 88, стр. 14',
                            price: 1035000,
                            station: 'Кузьминки, район Богородское',
                            floor: 7,
                            area: 54,
                            type: 'Квартира',
                            category: 'Новостройка',
                            hasDocs: true,
                            publishDate: 1469007765797
                        },
                        coords: [38.715175, 55.833436],
                        images: [{
                            src: '../content/images/flat/1.jpeg'
                        }, {
                            src: '../content/images/flat/2.jpeg'
                        }, {
                            src: '../content/images/flat/3.jpeg'
                        }, {
                            src: '../content/images/flat/4.jpeg'
                        }, {
                            src: '../content/images/flat/1.jpeg'
                        }, {
                            src: '../content/images/flat/2.jpeg'
                        }, {
                            src: '../content/images/flat/3.jpeg'
                        }, {
                            src: '../content/images/flat/4.jpeg'
                        }, {
                            src: '../content/images/flat/5.jpeg'
                        }, {
                            src: '../content/images/flat/5.jpeg'
                        }]
                    }
                }
            })
            .state('apartment-detail', {
                url: "/apartment-detail/:id",
                templateUrl: 'app/component/config/router/apartment-detail.html',

                //controller: function($scope, $filter, $state, $stateParams, flatListFactory) {
                //    var flats = flatListFactory.getAllFlats();
                //    $scope.flat = $filter('filter')(flats, {id: $state.params.id}, true)[0];
                //},

                resolve: {
                    getInfo: function ($state, $stateParams, getProperty) {
                        return getProperty.query({id: $stateParams.id}).$promise.then(function (res) {
                            return res
                        }, function (err) {
                            console.log(err);
                            $state.go('search');
                        })
                    }
                },
                controller: function ($scope, $stateParams, getInfo) {
                    $scope.testData = getInfo;
                    $scope.testData.photos = function () {
                        var obj = [];
                        for (var i = 0; i < $scope.testData.photoUrls.length; i++) {
                            obj.push({'src': $scope.testData.photoUrls[i]})
                        }
                        return obj;
                    }();
                    $scope.testData.coords = {
                        geometry: {
                            type: 'Point',
                            coordinates: [$scope.testData.lon, $scope.testData.lat]
                        }
                    };
                }
            })
            .state('search', {
                url: '/',
                templateUrl: 'app/component/config/router/search-page.html',
                resolve: {

                    getFlats: function ($state, $stateParams, flatListFactory, localStorageService) {
                        var params = {
                            take: 6
                        };

                        return flatListFactory.query(params).$promise.then(function (res) {
                            return res;
                        });
                    }
                },
                controller: function ($scope, $stateParams, getFlats, localStorageService, currentServer, flatListFactory) {
                    $scope.filteredFlats = [];
                    $scope.flats = [];
                    $scope.$on('applyFilter', function (e, params, flag) {
                        var server = currentServer + '/file/get/';
                        $scope.pagination = 6;
                        flatListFactory.query(params).$promise.then(function (res) {

                            res.forEach(function (flat) {
                                var obj = [];
                                for (var i = 0; i < flat.photos.length; i++) {
                                    obj.push({'src': server + flat.photos[i]})
                                }
                                flat.images = obj;
                                flat.coords = {geometry: {type: 'Point', coordinates: [flat.lon, flat.lat]}};
                                if (!flag) {
                                    $scope.flats.push(flat);
                                    $scope.filteredFlats.push(flat);
                                }
                            });
                            if (flag) {
                                $scope.flats = angular.copy(res);
                                $scope.filteredFlats = angular.copy(res);
                            }
                        });
                    });

                    $scope.pagination = 6;
                    window.onscroll = function() {
                        if ((window.innerHeight + window.scrollY) >= document.body.scrollHeight) {
                            $scope.$apply(function(){
                                $scope.pagination +=6;
                            });
                            console.log('bottom page');
                        }
                    };

                    var markersMapping = {};

                    $scope.addMarkerToMapping = function (id, $target) {
                        markersMapping[id] = $target;
                    };


                    $scope.setHighlighting = function (id, value) {
                        var image = value ? 'map-icon-hover' : 'map-icon-small';

                        $scope.filteredFlats.find(function (flat) {
                            return flat.id === id;
                        }).highlighted = value;
                        markersMapping[id].options.set('iconImageHref', '../content/images/' + image + '.svg');
                    };
                }
            })
            .state('my-ads', {
                url: "/my-ads",
                templateUrl: 'app/component/config/router/my-ads-page.html',
                controller: function ($scope, $stateParams, giglobApi) {
                    giglobApi.getMyOffers({type: 'propertyoffer', action: 'myoffers'}, null, function (data) {
                        $scope.myOffers = data;
                    });
                }
            })
            .state('add-ads', {
                url: "/add-ads",
                resolve: {
                    checkPerm: function ($rootScope, $state,localStorageService) {
                        if (!localStorageService.get('access-token')) {
                            $state.go('search');
                        }
                    }
                },
                templateUrl: 'app/component/config/router/add-ads.html',
                controller: function ($scope, $element, $timeout, flatCreationTabsList, giglobApi, $rootScope) {
                    $scope.tabs = flatCreationTabsList;
                    $scope.roomCountNames = [
                        'Однокомнатная',
                        'Двухкомнатная',
                        'Трехкомнатная',
                        'Четырхкомнатная',
                        'Пятикомнатная',
                        'Шестикомнатная'
                    ];
                    var defaultModel = {
                        sale: {
                            location: {
                                city: {
                                    id: 1,
                                    name: 'Москва'
                                }
                            }
                        },
                        swap: {
                            location: {
                                city: {
                                    id: 1,
                                    name: 'Москва'
                                }
                            }
                        }

                    };
                    $scope.model = angular.copy(defaultModel);
                    $scope.$watchGroup([
                        'model[tabCollectionType].location',
                        'model[tabCollectionType].details'
                    ], function (group) {
                        $scope.modelLocation = group[0];
                        $scope.modelDetails = group[1] || {};
                    });

                    $scope.$watch(function () {
                        var d = $scope.modelDetails || {};
                        var l = $scope.modelLocation || {};
                        var s = l.selectedStations;

                        var hasDetails = d.price || d.floor || d.area || d.roomsCount;
                        var hasStation = (s && s.length && s[0].name);
                        var hasLocation = l.street || l.build || l.housing || l.flat;
                        
                        return hasDetails || hasLocation || hasStation
                    }, function (isNotEmpty) {
                        $scope.isNotEmpty = isNotEmpty;
                    });

                    function closeAllTabs() {
                        flatCreationTabsList.sale.forEach(function (item) {
                            item.active = false;
                        });
                        flatCreationTabsList.swap.forEach(function (item) {
                            item.active = false;
                        });
                    }

                    $scope.$on('addFormSubmitted', function (event, type) {
                        var offerTypeName = type === 0 ? 'sale' : 'swap';

                        var location = $scope.model[offerTypeName].location;
                        var details = $scope.model[offerTypeName].details;
                        $scope.model.postData = {
                            cityId: location.city.id,
                            districtId: location.district ? location.district.id : undefined,
                            streetName: location.street,
                            houseNumber: location.build,
                            housing: location.housing,
                            apartmentNumber: location.flat,
                            level: details.floor,
                            areaSize: details.area,
                            roomCount: details.roomsCount,
                            type: details.realEstateType.id,
                            buildingCategory: details.buildCategory.id,
                            cost: details.price,
                            comment: details.comment,
                            offerType: type,
                            nearMetroBranchStationIds: location.selectedStations.map(function (item) {
                                return item.id
                            }),
                            photoes: $scope.model[offerTypeName].photos,
                            documents: $scope.model[offerTypeName].docs,
                            exchangeDetails: {
                                "cityId": 0,
                                "districtId": 0,
                                "roomCount": 0,
                                "areaSize": 0,
                                "minCost": 0,
                                "maxCost": 0
                            }
                        };

                        giglobApi.save({type: 'propertyoffer', action: 'create'}, $scope.model.postData, function () {
                            $scope.model = {};
                            $scope.model = angular.copy(defaultModel);
                            closeAllTabs();
                            $rootScope.$emit('api.object-saved');
                        });

                    });
                }
            })
            .state('confirm', {
                url: '/user/confirmemail/:token',
                resolve: {
                    confirmEmail: function ($state, $stateParams, confirm) {
                        confirm.save({'token': $stateParams.token}).$promise.then(function () {
                            $state.go('search');
                        }, function (err) {
                            console.log(err);
                        })
                    }
                }
            });

    }).constant('EXCLUDED_DEMO_ROUTERS', [
        'demo',
        'demo-example',
        'giglob-app',
        'component.config.router',
        'component.config.filters'
    ]);