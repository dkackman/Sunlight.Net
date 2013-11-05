﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.Congress
{
    public class History
    {
        public bool active { get; set; }
        public string active_at { get; set; }
        public bool awaiting_signature { get; set; }
        public bool enacted { get; set; }
        public string house_passage_result { get; set; }
        public string house_passage_result_at { get; set; }
        public string senate_passage_result { get; set; }
        public string senate_passage_result_at { get; set; }
        public bool vetoed { get; set; }
    }

    public class Urls
    {
        public string html { get; set; }
        public string pdf { get; set; }
        public string xml { get; set; }
    }

    public class LastVersion
    {
        public string version_code { get; set; }
        public string issued_on { get; set; }
        public string version_name { get; set; }
        public string bill_version_id { get; set; }
        public Urls urls { get; set; }
        public int pages { get; set; }
    }

    public class Urls2
    {
        public string congress { get; set; }
        public string govtrack { get; set; }
        public string opencongress { get; set; }
    }

    public class BillResult
    {
        public string bill_id { get; set; }
        public string bill_type { get; set; }
        public string chamber { get; set; }
        public List<string> committee_ids { get; set; }
        public int congress { get; set; }
        public int cosponsors_count { get; set; }
        public object enacted_as { get; set; }
        public History history { get; set; }
        public string introduced_on { get; set; }
        public string last_action_at { get; set; }
        public LastVersion last_version { get; set; }
        public string last_version_on { get; set; }
        public string last_vote_at { get; set; }
        public int number { get; set; }
        public string official_title { get; set; }
        public object popular_title { get; set; }
        public List<string> related_bill_ids { get; set; }
        public object short_title { get; set; }
        public string sponsor_id { get; set; }
        public Urls2 urls { get; set; }
        public int withdrawn_cosponsors_count { get; set; }
    }
}