﻿namespace CommitsViewer.Models.Github
{
    using System;

    public class Committer
    {
        public string name { get; set; }
        public string email { get; set; }
        public DateTime date { get; set; }
    }
}
