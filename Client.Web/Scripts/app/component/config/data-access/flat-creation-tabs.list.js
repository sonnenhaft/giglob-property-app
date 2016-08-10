angular.module('component.config.data-access').factory('flatCreationTabsList', function () {
    var saleTabs = [
        {
            tabTitle: 'Локация',
            tabDescription: 'Адрес, район, метро',
            tabType: 'location'
        },
        {
            tabTitle: 'Детали',
            tabDescription: 'Площадь, этаж, комнаты, тип, стоимость',
            tabType: 'details',
            disabled: 'disabled'
        },
        {
            tabTitle: 'Фотографии',
            tabDescription: 'Настоящие фотографии объекта',
            tabType: 'photos',
            disabled: 'disabled'
        },
        {
            tabTitle: 'Документы',
            tabDescription: 'Свидетельство о собственности, <br>кадастровый номер',
            tabType: 'docs',
            disabled: 'disabled'
        }
    ];
    return {
        sale: angular.copy(saleTabs).concat([{
            tabTitle: 'Объект добавлен',
            tabDescription: 'Объект добавлен',
            tabType: 'add_confirmation',
            invisible: true
        }]),
        swap: angular.copy(saleTabs).concat([{
            tabTitle: 'Куда хочу переехать',
            tabDescription: 'Адрес, площадь, комнаты, стоимость',
            tabType: 'swap',
            disabled: 'disabled'
        }])
    }
});