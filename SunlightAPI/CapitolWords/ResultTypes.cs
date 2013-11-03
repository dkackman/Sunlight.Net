using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SunlightAPI.CapitolWords
{
    /// <summary>
    /// Used to derefence collections of restuls in the format
    /// { "results": [] }
    /// where the collection is the only meaningful return value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultsWrapper<T>
    {
        public List<T> results { get; set; }
    }

    public class VolumeResult : EquatableObject<VolumeResult>
    {
        public double count { get; set; }


        public int Volume;
    }

    public class LegislatorResult : EquatableObject<LegislatorResult>
    {
        public double count { get; set; }

        public string legislator { get; set; }
    }

    public class StateResult : EquatableObject<StateResult>
    {
        public double count { get; set; }

        public string state { get; set; }
    }

    public class ChamberResult : EquatableObject<ChamberResult>
    {
        public double count { get; set; }

        public string chamber { get; set; }
    }

    public abstract class TimeSeriesResult<T> : EquatableObject<T> where T : class
    {
        public double count { get; set; }

        public double percentage { get; set; }

        public int total { get; set; }
    }

    public class MonthResult : TimeSeriesResult<MonthResult>
    {
        public string month { get; set; }
    }

    public class YearResult : TimeSeriesResult<YearResult>
    {
        public string year { get; set; }
    }

    public class DayResult : TimeSeriesResult<DayResult>
    {
        public DateTime day { get; set; }

        public double raw_count { get; set; }
    }

    public class PhraseResult : EquatableObject<PhraseResult>
    {
        public int count { get; set; }

        public double tfidf { get; set; }

        public string ngram { get; set; }
    }
}
