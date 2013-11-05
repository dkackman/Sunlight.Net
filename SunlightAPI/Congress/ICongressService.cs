﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.Congress
{
    public enum ComitteeChamberType
    {
        Null,
        house,
        senate,
        joint
    }

    public interface ICongressService
    {
        Task<Results<LegislatorResult>> FindLegislators(double lat, double lon);
        Task<Results<LegislatorResult>> FindLegislators(string zip);
        Task<Results<LegislatorResult>> FindLegislators(string query = null, LegislatorResult searchPrototype = null);

        Task<Results<DistrictResult>> FindDistricts(double lat, double lon);
        Task<Results<DistrictResult>> FindDistricts(string zip);

        Task<Results<CommitteeResult>> FindCommittees(string query = null, CommitteeResult searchPrototype = null);

        Task<Results<BillResult>> FindBills(string query = null, BillResult searchPrototype = null);
        Task<Results<BillResult>> SearchBills(string query = null, BillResult searchPrototype = null);

        Task<Results<VoteResult>> FindVotes(string query = null, VoteResult searchPrototype = null);
        Task<Results<FloorUpdateResult>> FindFloorUpdaste(string query = null, FloorUpdateResult searchPrototype = null);

        Task<Results<HearingResult>> FindHearings(string query = null, HearingResult searchPrototype = null);
    }
}
