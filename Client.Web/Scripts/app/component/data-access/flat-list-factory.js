angular.module('component.data-access', []).factory('flatListFactory', function() {
    var mockedFlatData = [
        {
            id: '1',
            summary: {
                description: 'Сдается 2-комн. квартира на длительный срок в 15-17 минут ходьбы от ст. м. Кузьминки.' +
                ' Квартира после капитального ремонта. Мебель IKEA, холодильник, стиралка, посудомойка, микроволновка, ' +
                'пылесос. Кровать с большим отделением для хранения вещей. Wi-Fi 80 Mbs. Спокойные соседи. ' +
                'Чистый двор и подъезд (ЖСК). Два лифта. Расположение действительно уникальное. ' +
                'До ТЦ Авиапарк 5 минут на бесплатном автобусе. В 3-5 минутах ходьбы детская и взрослая поликлиники.',
                roomsCount: 2,
                address: 'Москва, ул. Лермантова, д. 228, корп. 14, кв. 88, стр. 14',
                price: 1035000,
                title: 'Однушка на ул. Лермантова',
                street: 'Лермантова',
                station: 'Кузьминки, район Богородское',
                floor: 7,
                area: 54,
                stationLineColor: '#ba46d2',
                type: 'Квартира',
                category: 'Новостройка',
                hasDocs: true,
                publishDate: 1469007765797
            },
            coords: [37.915175, 55.133436],
            images: [{
                src: '../content/images/flat/1.jpeg'
            }, {
                src: '../content/images/flat/2.jpeg'
            }, {
                src: '../content/images/flat/3.jpeg'
            }, {
                src: '../content/images/flat/4.jpeg'
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