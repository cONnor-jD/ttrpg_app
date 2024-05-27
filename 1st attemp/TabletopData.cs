using System.Collections.Generic;

namespace _1st_attemp
{
    public class TabletopData
    {
        public List<string> Names;
        public List<string> Tags;
        public List<PdfFile> PdfFiles;
        
        public TabletopData(List<string> names, List<string> tags, List<PdfFile> pdfFiles = null)
        {
            Names = names;
            Tags = tags;
            PdfFiles = pdfFiles;
        }
    }

    public class PdfFile
    {
        public string Url;
        public List<string> RelatedTags;

        public PdfFile(string url, List<string> relatedTags)
        {
            Url = url;
            RelatedTags = relatedTags;
        }
    }
}