using Newtonsoft.Json;
using System.Collections.Generic;

namespace HeimkaupLib.Models
{
    public class SearchRequest
    {
        [JsonProperty("filters")]
        public List<Filter> Filters { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("sort_by")]
        public string SortBy { get; set; }

        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("per_page")]
        public long PerPage { get; set; }

        [JsonProperty("include_filters")]
        public bool IncludeFilters { get; set; }

        [JsonProperty("use_after_search_navigation")]
        public bool UseAfterSearchNavigation { get; set; }
    }
}
