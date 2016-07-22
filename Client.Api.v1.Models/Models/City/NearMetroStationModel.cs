namespace Client.Api.v1.Models.Models.City
{
    public class NearMetroStationModel
    {
        /// <summary>
        /// Идентификатор, если есть
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цвет в шестнадцатиричном формате
        /// </summary>
        public string HexColor { get; set; }
    }
}