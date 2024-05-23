using System.Collections.Generic;

namespace _1st_attemp
{
    public class TabletopData
    {
        public List<string> Names;
        public List<string> Tags;

        public TabletopData(List<string> names, List<string> tags)
        {
            Names = names;
            Tags = tags;
        }
    }
}