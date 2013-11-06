using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.CapitolWords
{
    public class PagingState
    {
        public PagingState(int itemsPerPage, int startPage = 0)
        {
            ItemsPerPage = itemsPerPage;
            Page = startPage;
        }

        public int ItemsPerPage { get; private set; }

        public int Page { get; private set; }

        public bool Advance(int resultCount)
        {
            Page++;
            return resultCount == ItemsPerPage;
        }
    }
}
