angular.module('component.config.data-access', []).factory('flatListFactory', function() {
    var mockedFlatData = [
        {
            id: '1',
            summary: {
                description: ' Полностью yкомплектована! Новый ремонт, полностью меблирована новой мебелью и новой' +
                ' бытовой техникой, стиральная и посyдомоечная машины, полностью встроенная кухня, паркет массив дуба, ' +
                'двери массив дуба, пол с подогревом , раздельный с/yзел, итальянская плитка. 3 встроенных шкафа, ' +
                'кровать с ортопедическим матрасом. Обустроенная большая лоджия. Продажа с мебелью и техникой, либо ' +
                'без. Большая парковка на улице, видеонаблюдение в доме и на улице, большая детская площадка, детский ' +
                'сад во дворе, вся инфраструктура.',
                roomsCount: 2,
                address: 'Москва, ул. Новинский, д. 1, корп. 1, кв. 88',
                price: 1035000,
                title: 'Двушка на бульв. Новинский',
                street: 'Новинский бульв.',
                station: 'Черкизовская',
                district: 'район Богородское',
                floor: 7,
                area: 54,
                stationLineColor: '#ba46d2',
                type: 'Квартира',
                category: 'Новостройка',
                hasDocs: true,
                publishDate: 1469007765797
            },
            coords: {
                geometry: {
                    type: 'Point',
                    coordinates: [37.755175, 55.853436]
                },
                properties: {
                    iconContent: '', // Заголовок метки
                    hintContent: '', //Ховер хинт
                    balloonContent: ''//Разметка для всплывающей подсказки
                }
            },
            images: [{
                src: '../content/images/flat/1/1.jpeg'
            }, {
                src: '../content/images/flat/1/2.jpeg'
            }, {
                src: '../content/images/flat/1/3.jpg'
            }, {
                src: '../content/images/flat/1/4.jpg'
            }]
        },
        {
            id: '2',
            summary: {
                description: 'Сдается 1-комн. квартира на длительный срок в 5-7 минут ходьбы от ст. м. Кузьминки.' +
                ' Квартира после капитального ремонта. Мебель IKEA, холодильник, стиралка, посудомойка, микроволновка, ' +
                'пылесос. Кровать с большим отделением для хранения вещей. Wi-Fi 80 Mbs. Спокойные соседи. ' +
                'Чистый двор и подъезд (ЖСК). Два лифта. Расположение действительно уникальное. ' +
                'До ТЦ Авиапарк 5 минут на бесплатном автобусе. В 3-5 минутах ходьбы детская и взрослая поликлиники.',
                roomsCount: 1,
                address: 'Москва, ул. Лермонтова, д. 228, корп. 14, кв. 88, стр. 14',
                price: 935000,
                title: 'Однушка на ул. Лермонтова',
                street: 'Лермонтова',
                station: 'Черкизовская',
                district: 'район Богородское',
                floor: 7,
                area: 54,
                stationLineColor: '#ba46d2',
                type: 'Квартира',
                category: 'Новостройка',
                hasDocs: true,
                publishDate: 1469107765796
            },
            coords: {
                geometry: {
                    type: 'Point',
                    coordinates: [37.715175, 55.813436]
                },
                properties: {
                    iconContent: '', // Заголовок метки
                    hintContent: '', //Ховер хинт
                    balloonContent: ''//Разметка для всплывающей подсказки
                }
            },
            images: [{
                src: '../content/images/flat/2/1.jpeg'
            }, {
                src: '../content/images/flat/2/2.jpeg'
            }, {
                src: '../content/images/flat/2/3.jpeg'
            }, {
                src: '../content/images/flat/2/4.jpeg'
            }, {
                src: '../content/images/flat/2/5.jpeg'
            }]
        },
        {
            id: '3',
            summary: {
                description: 'Чистый подъезд. Тамбур на 2 квартиры, закрывается металлической дверью. Колясочная для ' +
                'жителей подъезда. Хорошие и тихие соседи. Идеальное вложение как для сдачи в аренду ' +
                'так и для собственного проживания. ',
                roomsCount: 3,
                address: 'Москва, ул. Арбат, д. 33, кв. 23',
                price: 1135000,
                title: 'Трешка на ул. Арбат',
                street: 'Арбат',
                station: 'Чистые пруды',
                district: 'район Богородское',
                floor: 7,
                area: 54,
                stationLineColor: '#ba46d2',
                type: 'Квартира',
                category: 'Новостройка',
                hasDocs: true,
                publishDate: 1469207765795
            },
            coords: {
                geometry: {
                    type: 'Point',
                    coordinates: [37.725175, 55.823436]
                },
                properties: {
                    iconContent: '', // Заголовок метки
                    hintContent: '', //Ховер хинт
                    balloonContent: ''//Разметка для всплывающей подсказки
                }
            },
            images: [{
                src: '../content/images/flat/3/1.jpg'
            }, {
                src: '../content/images/flat/3/2.jpg'
            }, {
                src: '../content/images/flat/3/3.jpg'
            }, {
                src: '../content/images/flat/3/4.jpg'
            }, {
                src: '../content/images/flat/3/5.jpg'
            }]
        },
        {
            id: '4',
            summary: {
                description: 'Дом 2000 года постройки из силикатных блоков. Территория дома огорожена. Имеется ' +
                'парковочное место. Рядом школа и дет сад - в шаговой доступности. Очень развитое транспортное сообщение.',
                roomsCount: 4,
                address: 'Москва, ул. Ленина, д. 22, корп. 1, кв. 88',
                price: 1435000,
                title: 'Чертырехкомнатная на ул. Ленина',
                street: 'Ленина',
                station: 'Улица Подбельского',
                district: 'район Богородское',
                floor: 7,
                area: 54,
                stationLineColor: '#ba46d2',
                type: 'Квартира',
                category: 'Новостройка',
                hasDocs: true,
                publishDate: 1469007765794
            },
            coords: {
                geometry: {
                    type: 'Point',
                    coordinates: [37.735175, 55.833436]
                },
                properties: {
                    iconContent: '', // Заголовок метки
                    hintContent: '', //Ховер хинт
                    balloonContent: ''//Разметка для всплывающей подсказки
                }
            },
            images: [{
                src: '../content/images/flat/4/1.jpg'
            }, {
                src: '../content/images/flat/4/2.jpg'
            }, {
                src: '../content/images/flat/4/3.jpg'
            }, {
                src: '../content/images/flat/4/4.jpg'
            }]
        },
        {
            id: '5',
            summary: {
                description: 'Уютная, тихая квартира со свежим ремонтом. Спокойные соседи. ' +
                'Один подъезд, у входа консьержка. Входная дверь-металлическая, ' +
                'межкомнатные двери – массив, стеклопакеты ПВХ (с москитными сетками), на полу-паркет. ' +
                'На кухне установлен фильтр для очистки воды, электроплита со стеклокерамической варочной панелью. ' +
                'Раздельный санузел. В ванне и туалете новая сантехника и плитка. Наличие подвала с косметическим ремонтом.',
                roomsCount: 5,
                address: 'Москва, ул. Семенова, д. 31, кв. 2',
                price: 1635000,
                title: 'Пятикомнатная на ул. Семенова',
                street: 'Семенова',
                station: 'Сокольники',
                district: 'район Богородское',
                floor: 7,
                area: 54,
                stationLineColor: '#ba46d2',
                type: 'Квартира',
                category: 'Новостройка',
                hasDocs: true,
                publishDate: 1469007765793
            },
            coords: {
                geometry: {
                    type: 'Point',
                    coordinates: [37.745175, 55.843436]
                },
                properties: {
                    iconContent: '', // Заголовок метки
                    hintContent: '', //Ховер хинт
                    balloonContent: ''//Разметка для всплывающей подсказки
                }
            },
            images: [{
                src: '../content/images/flat/5/1.jpg'
            }, {
                src: '../content/images/flat/5/2.jpg'
            }]
        },
        {
            id: '6',
            summary: {
                description: 'Большaя лоджия оборудовaнной в ней летней комнaтой (полы c подогревом) Видеонaблюдение домa, видеодомофон, конcьерж',
                roomsCount: 2,
                address: 'Москва, ул. Измайловская, д. 1, корп. 1, кв. 42',
                price: 1035000,
                title: 'Однушка на ул. Измайловская',
                street: 'Измайловская',
                station: 'Красные ворота',
                district: 'район Богородское',
                floor: 7,
                area: 54,
                stationLineColor: '#ba46d2',
                type: 'Квартира',
                category: 'Новостройка',
                hasDocs: true,
                publishDate: 1469007765792
            },
            coords: {
                geometry: {
                    type: 'Point',
                    coordinates: [37.755175, 55.853436]
                },
                properties: {
                    iconContent: '', // Заголовок метки
                    hintContent: '', //Ховер хинт
                    balloonContent: ''//Разметка для всплывающей подсказки
                }
            },
            images: [{
                src: '../content/images/flat/6/1.jpg'
            }, {
                src: '../content/images/flat/6/2.jpg'
            }]
        },
        {
            id: '7',
            summary: {
                description: 'Кап. ремонт в 2010г. Дом утеплен, заменены водопроводные трубы, канализация. Окна большие с бесшумными стеклопакетами. В квартире сделан ремонт. Две большие жилые комнаты по 16,7м2. На полах в комнатах лежит ламинат, в прихожей, кухне,с/у плитка, с подогревом. Подведено оптоволокно, что делает интернет скоростной и множество ТВ. каналов. Чистая продажа. В квартире никто не прописан, свободная. Холодильник 2м. и стиралка Индезит в подарок. Реальному покупателю хорошая скидка.',
                roomsCount: 2,
                address: 'Москва, ул. Благородная, д. 4, корп. 4, кв. 31, стр. 4',
                price: 1035000,
                title: 'Однушка на ул. Благородная',
                street: 'Благородная',
                station: 'Чистые пруды',
                district: 'район Богородское',
                floor: 7,
                area: 54,
                stationLineColor: '#ba46d2',
                type: 'Квартира',
                category: 'Новостройка',
                hasDocs: true,
                publishDate: 1469007765791
            },
            coords: {
                geometry: {
                    type: 'Point',
                    coordinates: [37.765175, 55.633436]
                },
                properties: {
                    iconContent: '', // Заголовок метки
                    hintContent: '', //Ховер хинт
                    balloonContent: ''//Разметка для всплывающей подсказки
                }
            },
            images: [{
                src: '../content/images/flat/7/1.jpg'
            }, {
                src: '../content/images/flat/7/2.jpg'
            }]
        },
        {
            id: '8',
            summary: {
                description: 'Квартира в отличном жилом состоянии,Встроенная кухня,шкаф купе,входная металлическая дверь,межкомнатные двери шпонированные, Аккуратный подъезд, ухоженный двор,рядом сад,хорошее транспортное сообщение,',
                roomsCount: 2,
                address: 'Москва, ул. Пушкинская, д. 5, кв. 11',
                price: 1035000,
                title: 'Однушка на ул. Пушкинская',
                street: 'Пушкинская',
                station: 'Лубянка',
                district: 'район Богородское',
                floor: 7,
                area: 54,
                stationLineColor: '#ba46d2',
                type: 'Квартира',
                category: 'Новостройка',
                hasDocs: true,
                publishDate: 1469007765780
            },
            coords: {
                geometry: {
                    type: 'Point',
                    coordinates: [37.775175, 55.733436]
                },
                properties: {
                    iconContent: '', // Заголовок метки
                    hintContent: '', //Ховер хинт
                    balloonContent: ''//Разметка для всплывающей подсказки
                }
            },
            images: [{
                src: '../content/images/flat/8/1.jpg'
            }]
        },
        {
            id: '9',
            summary: {
                description: 'Однокомнатная современная квартира-студия после ремонта. Стеклопакеты, вместительная кладовая. Мебель и бытовая техника остаются покупателю. Окна выходят на разные стороны, парковка во дворе без проблем. До вокзала 15 минут езды без пробок и светофоров. Отличное транспортное сообщение. Лошицкий парк и городская велодорожка в 500 метрах от дома. Гипермаркеты и магазины, школа и детские сады в двух шагах.Санузел требует ремонта.',
                roomsCount: 2,
                address: 'Москва, ул. Петрова, д. 4, кв. 9',
                price: 1035000,
                title: 'Однушка на ул. Петрова',
                street: 'Петрова',
                station: 'Лубянка',
                district: 'район Богородское',
                floor: 7,
                area: 54,
                stationLineColor: '#ba46d2',
                type: 'Квартира',
                category: 'Новостройка',
                hasDocs: true,
                publishDate: 1469007765779
            },
            coords: {
                geometry: {
                    type: 'Point',
                    coordinates: [37.785175, 55.683436]
                },
                properties: {
                    iconContent: '', // Заголовок метки
                    hintContent: '', //Ховер хинт
                    balloonContent: ''//Разметка для всплывающей подсказки
                }
            },
            images: [{
                src: '../content/images/flat/9/1.jpg'
            }]
        },
        {
            id: '10',
            summary: {
                description: 'Однокомнатная современная квартира-студия после ремонта. Стеклопакеты, вместительная ' +
                'кладовая. Мебель и бытовая техника остаются покупателю. Окна выходят на разные стороны, парковка во ' +
                'дворе без проблем. До вокзала 15 минут езды без пробок и светофоров. Отличное транспортное сообщение. ' +
                'парк и городская велодорожка в 500 метрах от дома. Гипермаркеты и магазины, школа и детские ' +
                'сады в двух шагах.Санузел требует ремонта.',
                roomsCount: 2,
                address: 'Москва, ул. Суражская, д. 28, кв. 88',
                price: 1035000,
                title: 'Однушка на ул. Суражская',
                street: 'Суражская',
                station: 'Преображенская площадь',
                district: 'район Богородское',
                floor: 7,
                area: 54,
                stationLineColor: '#ba46d2',
                type: 'Квартира',
                category: 'Новостройка',
                hasDocs: true,
                publishDate: 1469007765777
            },
            coords: {
                geometry: {
                    type: 'Point',
                    coordinates: [37.795175, 55.693436]
                },
                properties: {
                    iconContent: '', // Заголовок метки
                    hintContent: '', //Ховер хинт
                    balloonContent: ''//Разметка для всплывающей подсказки
                }
            },
            images: [{
                src: '../content/images/flat/10/1.jpg'
            }]
        }
    ];

    function getAllFlats() {
        return mockedFlatData;
    }

    return {
        getAllFlats: getAllFlats
    };
});