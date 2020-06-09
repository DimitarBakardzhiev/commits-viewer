namespace CommitsViewer.Console
{
    using CommitsViewer.Services;
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static async Task Main(string[] args)
        {
            var githubService = new GithubService();
            var commits = await githubService.GetCommits("NikolayIT", "OpenJudgeSystem");
            foreach (var commit in commits)
            {
                Console.WriteLine(commit.commit.author.name);
            }
        }
    }
}
