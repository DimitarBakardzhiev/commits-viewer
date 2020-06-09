namespace CommitsViewer.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using AutoMapper;
    using CommitsViewer.Services;
    using CommitsViewer.ViewModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GithubController : ControllerBase
    {
        private readonly IGithubService githubService;
        private readonly IMapper mapper;

        public GithubController(IGithubService githubService, IMapper mapper)
        {
            this.githubService = githubService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            try
            {
                var commits = await this.githubService.GetCommits("DimitarBakardzhiev", "RandomTeamPicker");
                return Ok(commits);
            }
            catch (HttpRequestException e)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCommits([FromQuery]string owner, [FromQuery]string repository)
        {
            try
            {
                var commits = await this.githubService.GetCommits(owner, repository);
                return Ok(mapper.Map<IEnumerable<CommitVM>>(commits));
            }
            catch (HttpRequestException e)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> SearchRepositories([FromQuery]string repository)
        {
            try
            {
                var repos = await this.githubService.SearchRepositories(repository);
                return Ok(mapper.Map<IEnumerable<RepositoryVM>>(repos));
            }
            catch (HttpRequestException e)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> SearchUsers([FromQuery]string user)
        {
            try
            {
                var users = await this.githubService.SearchUsers(user);
                return Ok(mapper.Map<IEnumerable<UserVM>>(users));
            }
            catch (HttpRequestException e)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserRepositories([FromQuery]string user)
        {
            try
            {
                var repositories = await this.githubService.GetUserRepositories(user);
                return Ok(mapper.Map<IEnumerable<RepositoryVM>>(repositories));
            }
            catch (HttpRequestException e)
            {
                return NotFound();
            }
        }
    }
}