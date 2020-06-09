namespace CommitsViewer.Models.Github
{
    using System.Collections.Generic;

    public class UserSearch
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        public IList<UserItem> items { get; set; }
    }
}
