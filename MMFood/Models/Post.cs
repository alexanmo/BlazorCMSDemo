using System;
using System.Collections.Generic;

namespace MMFood.Models
{
    public class Post
    {
        public int RowNumber { get; set; }
        public string Title { get; set; }
        public string Published { get; set; }
        public string TeaserImage { get; set; }
        public string Teaser { get; set; }
        public string ArticleImage { get; set; }
        public string Ingress { get; set; }
        public List<string>  ContentBlocks { get; set; }
    }
}
