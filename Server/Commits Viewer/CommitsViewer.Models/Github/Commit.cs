namespace CommitsViewer.Models.Github
{
    public class Commit
    {
        public string url { get; set; }
        public Author author { get; set; }
        public Committer committer { get; set; }
        public string message { get; set; }
        public Tree tree { get; set; }
        public int comment_count { get; set; }
        public Verification verification { get; set; }
    }
}
