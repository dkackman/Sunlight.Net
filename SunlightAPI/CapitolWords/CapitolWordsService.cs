using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunlightAPI.CapitolWords
{
    public class CapitolWordsService : ICapitolWordsService
    {
        private SunlightRestClient _service;

        public CapitolWordsService(string api_key, string user_agent = "")
        {
            _service = new SunlightRestClient("http://capitolwords.org/api/1", api_key, user_agent);
        }
        public async Task<IEnumerable<PhraseCount>> GetTopPhrasesByState(string state, int wordCount = 1, PagingState page = null, string sort = "count desc")
        {
            return await GetTopPhrases("state", state, wordCount, page, sort);
        }
        public async Task<IEnumerable<PhraseCount>> GetTopPhrasesByDate(DateTime date, int wordCount = 1, PagingState page = null, string sort = "count desc")
        {
            return await GetTopPhrases("date", date.ToString("yyyy-MM-dd"), wordCount, page, sort);
        }
        public async Task<IEnumerable<PhraseCount>> GetTopPhrasesByMonth(DateTime month, int wordCount = 1, PagingState page = null, string sort = "count desc")
        {
            return await GetTopPhrases("month", month.ToString("yyyyMM"), wordCount, page, sort);
        }
        public async Task<IEnumerable<PhraseCount>> GetTopPhrasesByLegislator(string legislator, int wordCount = 1, PagingState page = null, string sort = "count desc")
        {
            return await GetTopPhrases("legislator", legislator, wordCount, page, sort);
        }

        private async Task<IEnumerable<PhraseCount>> GetTopPhrases(string entityType, string entityValue, int wordCount, PagingState page, string sort)
        {
            Debug.Assert(wordCount >= 1 && wordCount <= 5);

            var parms = new Dictionary<string, object>();
            parms.Add("entity_type", entityType);
            parms.Add("entity_value", entityValue);
            parms.Add("n", wordCount);
            parms.Add("page", page != null ? page.Page : 0);
            parms.Add("sort", sort);

            return await _service.Get<IEnumerable<PhraseCount>>("phrases.json", parms);
        }

        public async Task<IEnumerable<DayCount>> GetPhraseTimeSeriesByDay(string phrase, string bioGuideId = null, SearchParameters searchParams = null)
        {
            return await GetPhraseTimeSeries<DayCount>("day", phrase, bioGuideId, searchParams);
        }

        public async Task<IEnumerable<MonthCount>> GetPhraseTimeSeriesByMonth(string phrase, string bioGuideId = null, SearchParameters searchParams = null)
        {
            return await GetPhraseTimeSeries<MonthCount>("month", phrase, bioGuideId, searchParams);
        }

        public async Task<IEnumerable<YearCount>> GetPhraseTimeSeriesByYear(string phrase, string bioGuideId = null, SearchParameters searchParams = null)
        {
            return await GetPhraseTimeSeries<YearCount>("year", phrase, bioGuideId, searchParams);
        }

        private async Task<IEnumerable<T>> GetPhraseTimeSeries<T>(string granularity, string phrase, string bioGuideId, SearchParameters searchParams)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("granularity", granularity);
            parms.Add("phrase", phrase);
            parms.Add("bioguide_id", bioGuideId);
            parms.Add("percentages", "true");
            if (searchParams != null)
                searchParams.GetParameters(parms);

            var results = await _service.Get<ResultsWrapper<T>>("dates.json", parms);
            return results.results;
        }

        public async Task<IEnumerable<ChamberCount>> GetTopChamberByPhrase(string phrase, PagingState page = null, string sort = "count", SearchParameters searchParams = null)
        {
            return await GetTopEntityByPhrase<ChamberCount>("chamber", phrase, page, sort, searchParams);
        }

        public async Task<IEnumerable<VolumeCount>> GetTopVolumeByPhrase(string phrase, PagingState page = null, string sort = "count", SearchParameters searchParams = null)
        {
            return await GetTopEntityByPhrase<VolumeCount>("volume", phrase, page, sort, searchParams);
        }

        public async  Task<IEnumerable<LegislatorCount>> GetTopLegislatorByPhrase(string phrase, PagingState page = null, string sort = "count", SearchParameters searchParams = null)
        {
            return await GetTopEntityByPhrase<LegislatorCount>("legislator", phrase, page, sort, searchParams);
        }

        public async  Task<IEnumerable<StateCount>> GetTopStateByPhrase(string phrase, PagingState page = null, string sort = "count", SearchParameters searchParams = null)
        {
            return await GetTopEntityByPhrase<StateCount>("state", phrase, page, sort, searchParams);
        }

        private async Task<IEnumerable<T>> GetTopEntityByPhrase<T>(string entity, string phrase, PagingState page, string sort, SearchParameters searchParams)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("phrase", phrase);
            parms.Add("page", page != null ? page.Page : 0);
            parms.Add("per_page", 50);
            parms.Add("sort", sort);
            if (searchParams != null)
                searchParams.GetParameters(parms);

            var results = await _service.Get<ResultsWrapper<T>>(string.Format("phrases/{0}.json", entity), parms);
            return results.results;
        }

        public async Task<FullTextSearchResultList> FullTextSearch(string phrase, string title = null, string bioGuideId = null, string cr_pages = null, PagingState page = null, SearchParameters searchParams = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("phrase", phrase);
            parms.Add("title", title);
            parms.Add("bioGuideId", bioGuideId);
            parms.Add("cr_pages", cr_pages);
            parms.Add("page", page != null ? page.Page : 0);
            if (searchParams != null)
                searchParams.GetParameters(parms);

            return await _service.Get<FullTextSearchResultList>("text.json", parms);
        }
    }
}