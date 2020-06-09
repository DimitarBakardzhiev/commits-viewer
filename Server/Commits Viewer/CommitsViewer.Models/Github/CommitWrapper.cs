namespace CommitsViewer.Models.Github
{
    using System.Collections.Generic;

    public class CommitWrapper
    {
        public string url { get; set; }
        public string sha { get; set; }
        public string node_id { get; set; }
        public string html_url { get; set; }
        public string comments_url { get; set; }
        public Commit commit { get; set; }
        public Author author { get; set; }
        public Committer committer { get; set; }
        public IList<Parent> parents { get; set; }
    }
}
