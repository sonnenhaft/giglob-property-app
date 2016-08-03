namespace Domain.Entities.Implementation.PropertyOffer.Dtos
{
    public class ViewPortDto
    {
        ///// <summary>
        ///// Верхная левая точка широты
        ///// </summary>
        public double LeftTopLat { get; set; }

        ///// <summary>
        ///// Верхная левая точка долготы
        ///// </summary>
        public double LeftTopLon { get; set; }

        ///// <summary>
        ///// Нижняя левая точка широты
        ///// </summary>
        public double LeftBottomLat { get; set; }

        ///// <summary>
        ///// Нижняя левая точка долготы
        ///// </summary>
        public double LeftBottomLon { get; set; }

        /// <summary>
        ///     Верхная правая точка широты
        /// </summary>
        public double RightTopLat { get; set; }

        /// <summary>
        ///     Верхная правая точка долготы
        /// </summary>
        public double RightTopLon { get; set; }

        /// <summary>
        ///     Нижняя правая точка широты
        /// </summary>
        public double RightBottomLat { get; set; }

        /// <summary>
        ///     Нижняя правая точка долготы
        /// </summary>
        public double RightBottomLon { get; set; }
    }
}