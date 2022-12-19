using System.Collections.Generic;

namespace GainChangerUITests.Entities
{
    public class Blog
    {
        public List<string> Headers1 { get; set; }
        public List<string> Headers2 { get; set; }
        public string Meta { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public List<string> Paragraphs { get; set; }
    }
}
