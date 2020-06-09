namespace CommitsViewer.Tests
{
    using CommitsViewer.Services;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;

    public class GithubServiceTests
    {
        private readonly GithubService githubService;

        public GithubServiceTests()
        {
            this.githubService = new GithubService();
        }

        [Theory]
        [InlineData("microsoft", "vscode")]
        [InlineData("DimitarBakardzhiev", "RandomTeamPicker")]
        [InlineData("microsoft", "STL")]
        public async Task GivenValidData_ShouldReturnCommits(string owner, string repository)
        {
            var commits = await githubService.GetCommits(owner, repository);

            Assert.NotNull(commits);
            Assert.True(commits.Count() > 0);
        }

        [Theory]
        [InlineData("microsoft", "pesho")]
        [InlineData("asdgqwer", "STL")]
        [InlineData("", "")]
        [InlineData(null, null)]
        public async Task GivenInvalidData_ShouldReturnThrowException(string owner, string repository)
        {
            await Assert.ThrowsAsync<HttpRequestException>(async () => await githubService.GetCommits(owner, repository));
        }

        [Theory]
        [InlineData("Dimitar")]
        [InlineData("microsoft")]
        public async Task GivenExistingUser_ShouldReturnFoundUsers(string user)
        {
            var users = await githubService.SearchUsers(user);

            Assert.NotNull(users);
            Assert.True(users.Count() > 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task GivenInvalidUser_ShouldThrowException(string user)
        {
            await Assert.ThrowsAsync<HttpRequestException>(async () => await githubService.SearchUsers(user));
        }

        [Theory]
        [InlineData("RandomTeamPicker")]
        [InlineData("vscode")]
        public async Task GivenExistingRepo_ShouldReturnResult(string repo)
        {
            var repos = await githubService.SearchRepositories(repo);

            Assert.NotNull(repos);
            Assert.True(repos.Count() > 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task GivenInvalidRepo_ShouldThrowException(string repo)
        {
            await Assert.ThrowsAsync<HttpRequestException>(async () => await githubService.SearchRepositories(repo));
        }
    }
}
