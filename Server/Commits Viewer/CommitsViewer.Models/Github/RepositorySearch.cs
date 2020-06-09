namespace CommitsViewer.Models.Github
{
    using System.Collections.Generic;

    public class RepositorySearch
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        public IList<RepositoryItem> items { get; set; }
    }
}
