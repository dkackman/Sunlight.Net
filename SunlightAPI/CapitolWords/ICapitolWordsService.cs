using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunlightAPI.CapitolWords
{
    public interface ICapitolWordsService
    {
        Task<IEnumerable<PhraseCount>> GetTopPhrasesByState(string state, int wordCount = 1, PagingState page = null, string sort = "count desc");

        Task<IEnumerable<PhraseCount>> GetTopPhrasesByDate(DateTime date, int wordCount = 1, PagingState page = null, string sort = "count desc");

        Task<IEnumerable<PhraseCount>> GetTopPhrasesByMonth(DateTime month, int wordCount = 1, PagingState page = null, string sort = "count desc");

        Task<IEnumerable<PhraseCount>> GetTopPhrasesByLegislator(string legislator, int wordCount = 1, PagingState page = null, string sort = "count desc");

        Task<IEnumerable<DayCount>> GetPhraseTimeSeriesByDay(string phrase, string bioGuideId = null, SearchParameters searchParams = null);

        Task<IEnumerable<MonthCount>> GetPhraseTimeSeriesByMonth(string phrase, string bioGuideId = null, SearchParameters searchParams = null);

        Task<IEnumerable<YearCount>> GetPhraseTimeSeriesByYear(string phrase, string bioGuideId = null, SearchParameters searchParams = null);

        Task<IEnumerable<ChamberCount>> GetTopChamberByPhrase(string phrase, PagingState page = null, string sort = "count", SearchParameters searchParams = null);

        Task<IEnumerable<VolumeCount>> GetTopVolumeByPhrase(string phrase, PagingState page = null, string sort = "count", SearchParameters searchParams = null);

        Task<IEnumerable<LegislatorCount>> GetTopLegislatorByPhrase(string phrase, PagingState page = null, string sort = "count", SearchParameters searchParams = null);

        Task<IEnumerable<StateCount>> GetTopStateByPhrase(string phrase, PagingState page = null, string sort = "count", SearchParameters searchParams = null);

        Task<FullTextSearchResultList> FullTextSearch(string phrase, string title = null, string bioGuideId = null, string cr_pages = null, PagingState page = null, SearchParameters searchParams = null);
    }
}

