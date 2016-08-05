using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.YandexGeocoder.Dtos
{
    public class GeoObjectCollectionDto
    {
        [JsonProperty("featureMember")]
        public IEnumerable<FeatureMemberDto> FeatureMembers { get; set; }
    }
}