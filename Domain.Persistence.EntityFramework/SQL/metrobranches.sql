IF NOT EXISTS(SELECT NULL FROM [dbo].[MetroStations])
BEGIN
  DECLARE @cityId INT;
select @cityId = Id from [dbo].[Cities] WHERE Name='Москва';

INSERT INTO [dbo].[MetroStations]
            ([Name],[CityId])
     VALUES
		('Авиамоторная',@cityId),
		('Автозаводская',@cityId),
		('Академическая',@cityId),
		('Александровский сад',@cityId),
		('Алексеевская',@cityId),
		('Алма-Атинская',@cityId),
		('Алтуфьево',@cityId),
		('Аннино',@cityId),
		('Арбатская (Арбатско-Покровская линия)',@cityId),
		('Арбатская (Филевская линия)',@cityId),
		('Аэропорт',@cityId),
		('Бабушкинская',@cityId),
		('Багратионовская',@cityId),
		('Баррикадная',@cityId),
		('Бауманская',@cityId),
		('Беговая',@cityId),
		('Белорусская',@cityId),
		('Беляево',@cityId),
		('Бибирево',@cityId),
		('Библиотека имени Ленина',@cityId),
		('Борисово',@cityId),
		('Боровицкая',@cityId),
		('Ботанический сад',@cityId),
		('Братиславская',@cityId),
		('Бульвар адмирала Ушакова',@cityId),
		('Бульвар Дмитрия Донского',@cityId),
		('Бульвар Рокоссовского',@cityId),
		('Бунинская аллея',@cityId),
		('Варшавская',@cityId),
		('ВДНХ',@cityId),
		('Владыкино',@cityId),
		('Водный стадион',@cityId),
		('Войковская',@cityId),
		('Волгоградский проспект',@cityId),
		('Волжская',@cityId),
		('Волоколамская',@cityId),
		('Воробьевы горы',@cityId),
		('Выставочная',@cityId),
		('Выхино',@cityId),
		('Деловой центр',@cityId),
		('Динамо',@cityId),
		('Дмитровская',@cityId),
		('Добрынинская',@cityId),
		('Домодедовская',@cityId),
		('Достоевская',@cityId),
		('Дубровка',@cityId),
		('Жулебино',@cityId),
		('Зябликово',@cityId),
		('Измайловская',@cityId),
		('Калужская',@cityId),
		('Кантемировская',@cityId),
		('Каховская',@cityId),
		('Каширская',@cityId),
		('Киевская',@cityId),
		('Китай-город',@cityId),
		('Кожуховская',@cityId),
		('Коломенская',@cityId),
		('Комсомольская',@cityId),
		('Коньково',@cityId),
		('Красногвардейская',@cityId),
		('Краснопресненская',@cityId),
		('Красносельская',@cityId),
		('Красные ворота',@cityId),
		('Крестьянская застава',@cityId),
		('Кропоткинская',@cityId),
		('Крылатское',@cityId),
		('Кузнецкий мост',@cityId),
		('Кузьминки',@cityId),
		('Кунцевская',@cityId),
		('Курская',@cityId),
		('Кутузовская',@cityId),
		('Ленинский проспект',@cityId),
		('Лермонтовский проспект',@cityId),
		('Лубянка',@cityId),
		('Люблино',@cityId),
		('Марксистская',@cityId),
		('Марьина роща',@cityId),
		('Марьино',@cityId),
		('Маяковская',@cityId),
		('Медведково',@cityId),
		('Международная',@cityId),
		('Менделеевская',@cityId),
		('Митино',@cityId),
		('Молодежная',@cityId),
		('Монорельса Выставочный центр',@cityId),
		('Монорельса Телецентр',@cityId),
		('Монорельса Улица Академика Королева',@cityId),
		('Монорельса Улица Милашенкова',@cityId),
		('Монорельса Улица Сергея Эйзенштейна',@cityId),
		('Монорельсовой дороги Тимирязевская',@cityId),
		('Мякинино',@cityId),
		('Нагатинская',@cityId),
		('Нагорная',@cityId),
		('Нахимовский проспект',@cityId),
		('Новогиреево',@cityId),
		('Новокосино',@cityId),
		('Новокузнецкая',@cityId),
		('Новослободская',@cityId),
		('Новоясеневская',@cityId),
		('Новые Черемушки',@cityId),
		('Октябрьская',@cityId),
		('Октябрьское поле',@cityId),
		('Орехово',@cityId),
		('Отрадное',@cityId),
		('Охотный ряд',@cityId),
		('Павелецкая',@cityId),
		('Парк культуры',@cityId),
		('Парк Победы',@cityId),
		('Партизанская',@cityId),
		('Первомайская',@cityId),
		('Перово',@cityId),
		('Петровско-Разумовская',@cityId),
		('Печатники',@cityId),
		('Пионерская',@cityId),
		('Планерная',@cityId),
		('Площадь Ильича',@cityId),
		('Площадь Революции',@cityId),
		('Полежаевская',@cityId),
		('Полянка',@cityId),
		('Пражская',@cityId),
		('Преображенская площадь',@cityId),
		('Пролетарская',@cityId),
		('Проспект Вернадского',@cityId),
		('Проспект Мира',@cityId),
		('Профсоюзная',@cityId),
		('Пушкинская',@cityId),
		('Пятницкое шоссе',@cityId),
		('Речной вокзал',@cityId),
		('Рижская',@cityId),
		('Римская',@cityId),
		('Рязанский проспект',@cityId),
		('Савеловская',@cityId),
		('Свиблово',@cityId),
		('Севастопольская',@cityId),
		('Семеновская',@cityId),
		('Серпуховская',@cityId),
		('Славянский бульвар',@cityId),
		('Смоленская (Арбатско-Покровская линия)',@cityId),
		('Смоленская (Филевская линия)',@cityId),
		('Сокол',@cityId),
		('Сокольники',@cityId),
		('Спартак',@cityId),
		('Спортивная',@cityId),
		('Сретенский бульвар',@cityId),
		('Строгино',@cityId),
		('Студенческая',@cityId),
		('Сухаревская',@cityId),
		('Сходненская',@cityId),
		('Таганская',@cityId),
		('Тверская',@cityId),
		('Театральная',@cityId),
		('Текстильщики',@cityId),
		('Теплый стан',@cityId),
		('Тимирязевская',@cityId),
		('Третьяковская',@cityId),
		('Тропарево',@cityId),
		('Трубная',@cityId),
		('Тульская',@cityId),
		('Тургеневская',@cityId),
		('Тушинская',@cityId),
		('Улица Академика Янгеля',@cityId),
		('Улица Горчакова',@cityId),
		('Улица Скобелевская',@cityId),
		('Улица Старокачаловская',@cityId),
		('Улица 1905 года',@cityId),
		('Университет',@cityId),
		('Филевский парк',@cityId),
		('Фили',@cityId),
		('Фрунзенская',@cityId),
		('Царицыно',@cityId),
		('Цветной бульвар',@cityId),
		('Черкизовская',@cityId),
		('Чертановская',@cityId),
		('Чеховская',@cityId),
		('Чистые пруды',@cityId),
		('Чкаловская',@cityId),
		('Шаболовская',@cityId),
		('Шипиловская',@cityId),
		('Шоссе Энтузиастов',@cityId),
		('Щелковская',@cityId),
		('Щукинская',@cityId),
		('Электрозаводская',@cityId),
		('Юго-Западная',@cityId),
		('Южная',@cityId),
		('Ясенево',@cityId)
	
END

IF NOT EXISTS(SELECT NULL FROM [dbo].[MetroBranches])
BEGIN
  DECLARE @cityId1 INT;
select @cityId1 = Id from [dbo].[Cities] WHERE Name='Москва';
 INSERT INTO [dbo].[MetroBranches]
            ([HexColor],[CityId])
     VALUES
	 ('ffd803',@cityId),
     ('029a55',@cityId),
     ('fbaa33',@cityId),
     ('019ee0',@cityId),
     ('acadaf',@cityId),
     ('0252a2',@cityId),
     ('b61d8e',@cityId),
     ('00ff00',@cityId),
     ('fbaa33',@cityId),
     ('745c2f',@cityId)	
END

IF NOT EXISTS(SELECT NULL FROM [dbo].MetroBranchStations)
BEGIN
DECLARE @stationId INT;
DECLARE @colorId INT;

select @stationId = ID from [dbo].[MetroStations] WHERE Name='Авиамоторная' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='ffd803' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Автозаводская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Академическая' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Александровский сад' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='019ee0' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Алексеевская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Алма-Атинская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Алтуфьево' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Аннино' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Арбатская (Арбатско-Покровская линия)' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='019ee0' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Арбатская (Филевская линия)' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='019ee0' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Аэропорт' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Бабушкинская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Багратионовская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='019ee0' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Баррикадная' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Бауманская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='0252a2' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Беговая' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Белорусская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Беляево' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Бибирево' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Библиотека имени Ленина' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='00ff00' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Борисово' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='00ff00' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Боровицкая' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Ботанический сад' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Братиславская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='00ff00' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Бульвар адмирала Ушакова' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='019ee0' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Бульвар Дмитрия Донского' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Бульвар Рокоссовского' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Бунинская аллея' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='019ee0' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='ВДНХ' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Владыкино' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Водный стадион' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Войковская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Волгоградский проспект' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Волжская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='00ff00' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Волоколамская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='019ee0' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Воробьевы горы' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Выставочная' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='019ee0' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Выхино' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Деловой центр' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='019ee0' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Динамо' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Дмитровская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Добрынинская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='745c2f' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Домодедовская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Достоевская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='00ff00' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Дубровка' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='00ff00' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Жулебино' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Зябликово' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='00ff00' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Измайловская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='0252a2' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Калужская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Кантемировская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Киевская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='745c2f' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Киевская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='0252a2' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Киевская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='019ee0' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Китай-город' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Китай-город' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Кожуховская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='00ff00' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Коломенская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Комсомольская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='745c2f' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Комсомольская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Коньково' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Красногвардейская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Краснопресненская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Красносельская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Красные ворота' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Крестьянская застава' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='00ff00' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Кропоткинская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Крылатское' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='0252a2' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Кузнецкий мост' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Кузьминки' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Кунцевская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='0252a2' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Курская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='745c2f' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Кунцевская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='019ee0' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Кутузовская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='019ee0' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Ленинский проспект' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Лермонтовский проспект' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Лубянка' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Люблино' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='00ff00' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Марксистская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='ffd803' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Марьина роща' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='00ff00' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Марьино' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='00ff00' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Маяковская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Медведково' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Международная' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='019ee0' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Менделеевская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Митино' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='0252a2' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Молодежная' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='0252a2' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Мякинино' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='0252a2' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Нагатинская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Нагорная' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Нахимовский проспект' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Новогиреево' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='ffd803' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Новокосино' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='ffd803' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Новокузнецкая' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Новослободская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='745c2f' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Новоясеневская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Новые Черемушки' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Октябрьская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Октябрьская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='745c2f' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Октябрьское поле' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Орехово' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Отрадное' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Охотныйряд' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Павелецкая' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Парк культуры' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Павелецкая' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='745c2f' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Парк культуры' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='745c2f' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Парк Победы' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='0252a2' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Партизанская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='0252a2' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Первомайская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='0252a2' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Перово' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='ffd803' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Петровско-Разумовская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Печатники' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='00ff00' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Пионерская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='019ee0' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Планерная	' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Площадь Ильича' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='ffd803' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Площадь Революции' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='0252a2' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Полежаевская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Полянка' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Пражская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Преображенская площадь' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Пролетарская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Проспект Вернадского' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Проспект Мира' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Проспект Мира' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='745c2f' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Профсоюзная' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Пушкинская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Пятницкое шоссе' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='0252a2' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Речной вокзал' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Рижская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Римская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='00ff00' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Рязанский проспект' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Савеловская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Свиблово' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Севастопольская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Семеновская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='0252a2' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Серпуховская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Славянский бульвар' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='0252a2' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Смоленская (Арбатско-Покровская линия)' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='0252a2' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Смоленская (Филевская линия)' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='019ee0' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Сокол' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Сокольники' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Спартак' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Спортивная' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Сретенский бульвар' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='00ff00' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Строгино' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='0252a2' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Студенческая' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='019ee0' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Сухаревская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Сходненская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Таганская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Таганская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='745c2f' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Тверская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Театральная' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Текстильщики' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Теплый стан' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Тимирязевская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Третьяковская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Третьяковская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='ffd803' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Тропарево' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Трубная' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='00ff00' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Тульская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Тургеневская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Тушинская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Улица 1905 года' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Университет' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Филевский парк' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='019ee0' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Фили' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='019ee0' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Фрунзенская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Царицыно' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Цветной бульвар' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Черкизовская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Чертановская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Чеховская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Чистые пруды' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Чкаловская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='00ff00' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Шаболовская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Шипиловская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='00ff00' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Шоссе Энтузиастов' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='ffd803' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Щелковская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='0252a2' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Щукинская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='b61d8e' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Электрозаводская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='0252a2' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Юго-Западная' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Южная' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Ясенево' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='fbaa33' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Каширская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='5091bb' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Варшавская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='5091bb' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Каховская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='5091bb' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Улица Академика Янгеля' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Улица Горчакова' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='85d4f3' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Улица Скобелевская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='85d4f3' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Улица Старокачаловская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='85d4f3' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Монорельсовой дороги Тимирязевская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='acadaf' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Монорельса Выставочный центр' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='5091bb' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)
select @stationId = ID from [dbo].[MetroStations] WHERE Name='Каширская' AND CityId =1
select @colorId = ID from [dbo].[MetroBranches] WHERE HexColor='029a55' AND CityId =1
INSERT INTO [dbo].[MetroBranchStations]([MetroStationId],[MetroBranchId])VALUES (@stationId,@colorId)

END