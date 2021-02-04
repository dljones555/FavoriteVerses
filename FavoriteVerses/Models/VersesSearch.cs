using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteVerses.Models
{
    public class VerseSearch
    {
        public string Url { get; set; }
        public bool HasMorePages { get; set; }
        public string Id { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<Verse> Verses { get; set; }

    }
}
