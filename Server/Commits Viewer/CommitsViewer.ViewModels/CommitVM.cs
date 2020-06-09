namespace CommitsViewer.ViewModels
{
    using System;

    public class CommitVM
    {
        public string Sha { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}
