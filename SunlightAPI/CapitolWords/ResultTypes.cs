using System;
using System.Collections.Generic;

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

    public class VolumeCount
    {
        public double count { get; set; }

        public int Volume;
    }

    public class LegislatorCount 
    {
        public double count { get; set; }

        public string legislator { get; set; }
    }

    public class StateCount
    {
        public double count { get; set; }

        public string state { get; set; }
    }

    public class ChamberCount
    {
        public double count { get; set; }

        public string chamber { get; set; }
    }

    public abstract class TimeSeriesCount
    {
        public double count { get; set; }

        public double percentage { get; set; }

        public int total { get; set; }
    }

    public class MonthCount : TimeSeriesCount
    {
        public string month { get; set; }
    }

    public class YearCount : TimeSeriesCount
    {
        public string year { get; set; }
    }

    public class DayCount : TimeSeriesCount
    {
        public DateTime day { get; set; }

        public double raw_count { get; set; }
    }

    public class PhraseCount 
    {
        public int count { get; set; }

        public double tfidf { get; set; }

        public string ngram { get; set; }
    }
}
