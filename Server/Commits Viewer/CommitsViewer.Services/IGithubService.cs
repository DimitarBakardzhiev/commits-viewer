namespace CommitsViewer.Services
{
    using CommitsViewer.Models.Github;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGithubService
    {
        Task<IEnumerable<CommitWrapper>> GetCommits(string owner, string repository);
        Task<IEnumerable<UserItem>> SearchUsers(string user);
        Task<IEnumerable<RepositoryItem>> SearchRepositories(string repository);
        Task<IEnumerable<RepositoryItem>> GetUserRepositories(string user);
    }
}
