using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteVerses.Models
{
    public class Verse
    {
        public string BibleReferenceLink { get; set; }
        public string Book { get; set; }
        public string Chapter { get; set; }
        public string FacebookShareUrl { get; set; }
        public string Id { get; set; }
        public string ImageLink { get; set; }
        public bool IsValid { get; set; }
        public string PinterestShareUrl { get; set; }
        public string ReferenceLink { get; set; }
        public string ReferenceText { get; set; }
        public string TwitterShareUrl { get; set; }
        public string Url { get; set; }
        public DateTime VerseDate { get; set; }
        public string VerseNumbers { get; set; }
        public string VerseText { get; set; }
        public string VideoLink { get; set; }

    }
}
