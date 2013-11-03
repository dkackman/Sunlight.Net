using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.CapitolWords
{
    public class FullTextSearchResultList
    {
        public int num_found { get; set; }

        public List<FullTextSearchResult> results { get; set; }
    }

    public class FullTextSearchResult
    {
        public string speaker_state { get; set; }
        public string speaker_first { get; set; }
        public int congress { get; set; }
        public string title { get; set; }
        public string origin_url { get; set; }
        public int number { get; set; }
        public int order { get; set; }
        public int volume { get; set; }
        public string chamber { get; set; }
        public int session { get; set; }
        public string id { get; set; }
        public List<string> speaking { get; set; }
        public string capitolwords_url { get; set; }
        public string speaker_party { get; set; }
        public DateTime date { get; set; }
        public object bills { get; set; }
        public string bioguide_id { get; set; }
        public string pages { get; set; }
        public string speaker_last { get; set; }
        public string speaker_raw { get; set; }
    }
}