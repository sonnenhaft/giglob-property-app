angular.module('component.config.router', ['ui.router','api.httpRequestInterceptor','api.resource','component.config.data-access'])
    .config(function($stateProvider, $urlRouterProvider, EXCLUDED_DEMO_ROUTERS, $locationProvider) {
    $urlRouterProvider.otherwise("/");

    $stateProvider
        .state('demo', {
            url: "/demo",
            templateUrl: "app/component/config/router/demo-page.html",
            controller: function ($scope, $state) {
                $scope.routes = $state.get().filter(function(route) {
                    return !!route.name && EXCLUDED_DEMO_ROUTERS.indexOf(route.name) === -1;
                });

                $scope.modules = angular.modules.filter(function(moduleName) {
                    return !(EXCLUDED_DEMO_ROUTERS.indexOf(moduleName) + 1);
                });
            }
        })
        .state('demo-example', {
            url: '/demo/:name',
            templateUrl: function ($stateParams){
                var name = $stateParams.name;
                return 'app/' + name.split('.').join('/') + '/example/index.html';
            },
            controller: function($scope, $stateParams) {
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
                getInfo : function($state,$stateParams,getProperty){
                    return getProperty.query({id:$stateParams.id}).$promise.then(function(res){
                        return res
                    },function(err){
                        console.log(err);
                        $state.go('search');
                    })
                }
            },
            controller: function($scope, $stateParams,getInfo) {
                $scope.testData = getInfo;
                $scope.testData.photos = function(){
                    var obj = [];
                    for(var i=0;i<$scope.testData.photoUrls.length;i++){
                        obj.push({'src':$scope.testData.photoUrls[i]})
                    }
                    return obj;
                }();
                $scope.testData.coords = {geometry:{type:'Point',coordinates:[$scope.testData.lon,$scope.testData.lat]}};
                console.log($scope.testData);
            }
    })
        .state('search', {
            url: '/',
            templateUrl: 'app/component/config/router/search-page.html',
            resolve : {
              getFlats : function($state, $stateParams, flatListFactory, localStorageService){
                  var params = {
                      cityId : localStorageService.get('city') ? localStorageService.get('city').id : 1,
                      take: 10
                  };
                  return flatListFactory.query(params).$promise.then(function(res){
                      return res;
                  });
              }
            },
            controller: function($scope, $stateParams, getFlats, localStorageService, currentServer, flatListFactory) {
                $scope.$on('applyFilter', function(e, params) {
                    var server = currentServer + '/file/get/';

                    flatListFactory.query(params).$promise.then(function(res){
                        $scope.flats = res;

                        $scope.flats.forEach(function(flat) {
                            var obj = [];
                            for (var i = 0; i < flat.photos.length; i++) {
                                obj.push({'src': server + flat.photos[i]})
                            }
                            flat.images = obj;
                            flat.coords = {geometry: {type:'Point', coordinates:[flat.lon,flat.lat]}};
                        });

                        $scope.filteredFlats = $scope.flats;
                    });
                });


                var markersMapping = {};

                $scope.addMarkerToMapping = function(id, $target) {
                    markersMapping[id] = $target;
                };

                $scope.setHighlighting = function(id, value) {
                    var image = value ? 'map-icon-hover' : 'map-icon-small';

                    $scope.filteredFlats.find(function(flat) {
                        return flat.id === id;
                    }).highlighted = value;
                    markersMapping[id].options.set('iconImageHref', '../content/images/' + image + '.svg');
                };
            }
        })
        .state('my-ads', {
            url: "/my-ads",
            templateUrl: 'app/component/config/router/my-ads-page.html',
            controller: function($scope, $stateParams, giglobApi) {
                giglobApi.getMyOffers({type: 'propertyoffer', action: 'myoffers'}, null, function (data) {
                    $scope.myOffers = data;
                });
            }
        })
        .state('add-ads', {
            url: "/add-ads",
            templateUrl: 'app/component/config/router/add-ads.html',
            controller: function ($scope, $element, $timeout, addFlatTabs, giglobApi) {
                $scope.tabs = addFlatTabs;
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

                function closeAllTabs () {
                    addFlatTabs.sale.forEach(function (item) {
                        item.active = false;
                    });
                    addFlatTabs.swap.forEach(function (item) {
                        item.active = false;
                    });
                }

                $scope.$on('addFormSubmitted', function(event, type) {
                    var offerTypeName = type === 0 ? 'sale' : 'swap';

                    $scope.model.postData = {
                        cityId: $scope.model[offerTypeName].location.city.id,
                        districtId: $scope.model[offerTypeName].location.district.id,
                        streetName: $scope.model[offerTypeName].location.street,
                        houseNumber: $scope.model[offerTypeName].location.build,
                        housing: $scope.model[offerTypeName].location.housing,
                        apartmentNumber: $scope.model[offerTypeName].location.flat,
                        level: $scope.model[offerTypeName].details.floor,
                        areaSize: $scope.model[offerTypeName].details.area,
                        roomCount: $scope.model[offerTypeName].details.roomsCount,
                        type: $scope.model[offerTypeName].details.realEstateType.id,
                        buildingCategory: $scope.model[offerTypeName].details.buildCategory.id,
                        cost: $scope.model[offerTypeName].details.price,
                        comment: $scope.model[offerTypeName].details.comment,
                        offerType: type,
                        nearMetroBranchStationIds: $scope.model[offerTypeName].location.selectedStations.map(function (item){return item.id}),
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
                        $scope.$emit('objectSaved');
                    });

                });
            }
        })
        .state('confirm', {
            url:'/user/confirmemail/:token',
            resolve: {
                confirmEmail : function($state, $stateParams, confirm){
                    confirm.save({'token' : $stateParams.token}).$promise.then(function(){
                        $state.go('search');
                    },function(err){
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