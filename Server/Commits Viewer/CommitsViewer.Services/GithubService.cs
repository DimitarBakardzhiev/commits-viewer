namespace CommitsViewer.Services
{
    using CommitsViewer.Models.Github;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class GithubService : IGithubService
    {
        private HttpClient client;

        public GithubService()
        {
            this.client = new HttpClient();

            client.BaseAddress = new Uri("https://api.github.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
        }

        public async Task<IEnumerable<CommitWrapper>> GetCommits(string owner, string repository)
        {
            var response = await client.GetAsync($"/repos/{owner}/{repository}/commits");
            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                var commits = await JsonSerializer.DeserializeAsync<IEnumerable<CommitWrapper>>(stream);

                return commits;
            }
            else
            {
                throw new HttpRequestException("Http request to Github failed!");
            }
        }

        public async Task<IEnumerable<RepositoryItem>> GetUserRepositories(string user)
        {
            var response = await client.GetAsync($"/users/{user}/repos");
            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<IEnumerable<RepositoryItem>>(stream);

                return result;
            }
            else
            {
                throw new HttpRequestException("Http request to Github failed!");
            }
        }

        public async Task<IEnumerable<RepositoryItem>> SearchRepositories(string repository)
        {
            var response = await client.GetAsync($"/search/repositories?q={repository}");
            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<RepositorySearch>(stream);

                return result.items;
            }
            else
            {
                throw new HttpRequestException("Http request to Github failed!");
            }
        }

        public async Task<IEnumerable<UserItem>> SearchUsers(string user)
        {
            var response = await client.GetAsync($"/search/users?q={user}");
            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<UserSearch>(stream);

                return result.items;
            }
            else
            {
                throw new HttpRequestException("Http request to Github failed!");
            }
        }
    }
}
