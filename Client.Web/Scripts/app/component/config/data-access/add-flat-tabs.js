angular.module('component.config.data-access', []).value('addFlatTabs', {
    sale: [
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
    ],
    swap: [
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
        },
        {
            tabTitle: 'Куда хочу переехать',
            tabDescription: 'Адрес, площадь, комнаты, стоимость',
            tabType: 'swap',
            disabled: 'disabled'
        }
    ]
});