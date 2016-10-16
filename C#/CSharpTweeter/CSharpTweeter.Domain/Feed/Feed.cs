using System.Collections.Generic;

namespace CSharpTweeter.Domain
{
    public class Feed
    {
        public Feed()
        {
            Items = new List<Tweet>();
        }
        public List<Tweet> Items { get; set; }

    }    
}
