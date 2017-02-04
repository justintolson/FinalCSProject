using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Top90sHits.Models
{
    public class TheHitsGenreViewModel
    {
        public List<TheHits> songs;
        public SelectList genres;
        public string songGenre { get; set; }
    }
}