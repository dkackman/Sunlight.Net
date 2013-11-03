using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunlightAPI.CapitolWords
{
    public class CapitolWordsService : ICapitolWordsService
    {
        public async Task<IEnumerable<PhraseResult>> GetTopPhrasesByState(string state, int wordCount = 1, PagingState page = null, string sort = "count desc")
        {
            return await GetTopPhrases(topPhraseEntity.state, state, wordCount, page, sort);
        }
        public async Task<IEnumerable<PhraseResult>> GetTopPhrasesByDate(DateTime date, int wordCount = 1, PagingState page = null, string sort = "count desc")
        {
            return await GetTopPhrases(topPhraseEntity.date, date.ToString("yyyy-MM-dd"), wordCount, page, sort);
        }
        public async Task<IEnumerable<PhraseResult>> GetTopPhrasesByMonth(DateTime month, int wordCount = 1, PagingState page = null, string sort = "count desc")
        {
            return await GetTopPhrases(topPhraseEntity.month, month.ToString("yyyyMM"), wordCount, page, sort);
        }
        public async Task<IEnumerable<PhraseResult>> GetTopPhrasesByLegislator(string legislator, int wordCount = 1, PagingState page = null, string sort = "count desc")
        {
            return await GetTopPhrases(topPhraseEntity.legislator, legislator, wordCount, page, sort);
        }

        private static async Task<IEnumerable<PhraseResult>> GetTopPhrases(topPhraseEntity entityType, string entityValue, int wordCount, PagingState page, string sort)
        {
            Debug.Assert(wordCount >= 1 && wordCount <= 5);

            var parms = new Dictionary<string, object>();
            parms.Add("entity_type", entityType);
            parms.Add("entity_value", entityValue);
            parms.Add("n", wordCount);
            parms.Add("page", page != null ? page.Page : 0);
            parms.Add("sort", sort);

            return await Sunlight.Get<IEnumerable<PhraseResult>>("phrases.json", parms);
        }

        public async Task<IEnumerable<DayResult>> GetPhraseTimeSeriesByDay(string phrase, string bioGuideId = null, SearchParameters searchParams = null)
        {
            return await GetPhraseTimeSeries<DayResult>(granularity.day, phrase, bioGuideId, searchParams);
        }

        public async Task<IEnumerable<MonthResult>> GetPhraseTimeSeriesByMonth(string phrase, string bioGuideId = null, SearchParameters searchParams = null)
        {
            return await GetPhraseTimeSeries<MonthResult>(granularity.month, phrase, bioGuideId, searchParams);
        }

        public async Task<IEnumerable<YearResult>> GetPhraseTimeSeriesByYear(string phrase, string bioGuideId = null, SearchParameters searchParams = null)
        {
            return await GetPhraseTimeSeries<YearResult>(granularity.year, phrase, bioGuideId, searchParams);
        }

        private static async Task<IEnumerable<T>> GetPhraseTimeSeries<T>(granularity granularity, string phrase, string bioGuideId, SearchParameters searchParams)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("granularity", granularity);
            parms.Add("phrase", phrase);
            parms.Add("bioguide_id", bioGuideId);
            parms.Add("percentages", "true");
            if (searchParams != null)
                searchParams.GetParameters(parms);

            var results = await Sunlight.Get<ResultsWrapper<T>>("dates.json", parms);
            return results.results;
        }

        public async Task<IEnumerable<ChamberResult>> GetTopChamberByPhrase(string phrase, PagingState page = null, string sort = "count", SearchParameters searchParams = null)
        {
            return await GetTopEntityByPhrase<ChamberResult>(entity.chamber, phrase, page, sort, searchParams);
        }

        public async Task<IEnumerable<VolumeResult>> GetTopVolumeByPhrase(string phrase, PagingState page = null, string sort = "count", SearchParameters searchParams = null)
        {
            return await GetTopEntityByPhrase<VolumeResult>(entity.volume, phrase, page, sort, searchParams);
        }

        public async  Task<IEnumerable<LegislatorResult>> GetTopLegislatorByPhrase(string phrase, PagingState page = null, string sort = "count", SearchParameters searchParams = null)
        {
            return await GetTopEntityByPhrase<LegislatorResult>(entity.legislator, phrase, page, sort, searchParams);
        }

        public async  Task<IEnumerable<StateResult>> GetTopStateByPhrase(string phrase, PagingState page = null, string sort = "count", SearchParameters searchParams = null)
        {
            return await GetTopEntityByPhrase<StateResult>(entity.state, phrase, page, sort, searchParams);
        }

        private static async Task<IEnumerable<T>> GetTopEntityByPhrase<T>(entity entity, string phrase, PagingState page, string sort, SearchParameters searchParams)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("phrase", phrase);
            parms.Add("page", page != null ? page.Page : 0);
            parms.Add("per_page", 50);
            parms.Add("sort", sort);
            if (searchParams != null)
                searchParams.GetParameters(parms);

            var results = await Sunlight.Get<ResultsWrapper<T>>(string.Format("phrases/{0}.json",entity), parms);
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

            return await Sunlight.Get<FullTextSearchResultList>("text.json", parms);
        }
    }
}