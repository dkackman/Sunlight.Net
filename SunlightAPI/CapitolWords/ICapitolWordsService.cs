using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunlightAPI.CapitolWords
{
    public enum topPhraseEntity
    {
        date,
        month,
        state,
        legislator
    }

    public enum party
    {
        unknown,
        D,
        R,
        I
    }

    public enum chamber
    {
        unknown,
        house,
        senate,
        extensions
    }

    public enum granularity
    {
        day,
        month,
        year
    }

    public enum entity
    {
        state,
        legislator,
        volume,
        chamber
    }

    public interface ICapitolWordsService
    {
        Task<IEnumerable<PhraseResult>> GetTopPhrasesByState(string state, int wordCount = 1, PagingState page = null, string sort = "count desc");

        Task<IEnumerable<PhraseResult>> GetTopPhrasesByDate(DateTime date, int wordCount = 1, PagingState page = null, string sort = "count desc");

        Task<IEnumerable<PhraseResult>> GetTopPhrasesByMonth(DateTime month, int wordCount = 1, PagingState page = null, string sort = "count desc");

        Task<IEnumerable<PhraseResult>> GetTopPhrasesByLegislator(string legislator, int wordCount = 1, PagingState page = null, string sort = "count desc");

        Task<IEnumerable<DayResult>> GetPhraseTimeSeriesByDay(string phrase, string bioGuideId = null, SearchParameters searchParams = null);

        Task<IEnumerable<MonthResult>> GetPhraseTimeSeriesByMonth(string phrase, string bioGuideId = null, SearchParameters searchParams = null);

        Task<IEnumerable<YearResult>> GetPhraseTimeSeriesByYear(string phrase, string bioGuideId = null, SearchParameters searchParams = null);

        Task<IEnumerable<ChamberResult>> GetTopChamberByPhrase(string phrase, PagingState page = null, string sort = "count", SearchParameters searchParams = null);

        Task<IEnumerable<VolumeResult>> GetTopVolumeByPhrase(string phrase, PagingState page = null, string sort = "count", SearchParameters searchParams = null);

        Task<IEnumerable<LegislatorResult>> GetTopLegislatorByPhrase(string phrase, PagingState page = null, string sort = "count", SearchParameters searchParams = null);

        Task<IEnumerable<StateResult>> GetTopStateByPhrase(string phrase, PagingState page = null, string sort = "count", SearchParameters searchParams = null);

        Task<FullTextSearchResultList> FullTextSearch(string phrase, string title = null, string bioGuideId = null, string cr_pages = null, PagingState page = null, SearchParameters searchParams = null);
    }
}

