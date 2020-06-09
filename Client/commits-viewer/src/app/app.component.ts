import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { GithubService } from './services/github.service';
import { isNullOrUndefined } from 'util';
import { Repository } from './models/repository';
import { Commit } from './models/commit';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'commits-viewer';

  userControl = new FormControl();
  usersAutocomplete: string[] = [];

  repoControl = new FormControl();
  reposAutocomplete: Repository[] = [];

  commits: Commit[] = [];

  constructor(private githubService: GithubService) {
  }

  searchUser() {
    if (isNullOrUndefined(this.userControl.value) || this.userControl.value.length < 4) {
      return;
    }

    this.githubService.searchUsers(this.userControl.value).subscribe(users => this.usersAutocomplete = users.map(u => u.name), err => console.error(err));
  }

  searchRepo() {
    if (isNullOrUndefined(this.repoControl.value) || this.repoControl.value.length < 4) {
      return;
    }

    this.githubService.searchRepository(this.repoControl.value).subscribe(repos => this.reposAutocomplete = repos, err => console.error(err));
  }

  repoSelected(option: Repository) {
    this.userControl.setValue(option.owner);
  }

  userSelected(user: string) {
    this.githubService.getRepositories(user).subscribe(repos => this.reposAutocomplete = repos, err => console.error(err));
  }

  clear() {
    this.userControl.setValue('');
    this.repoControl.setValue('');
    this.usersAutocomplete = [];
    this.reposAutocomplete = [];
    this.commits = [];
  }

  getCommits() {
    this.githubService.getCommits(this.userControl.value, this.repoControl.value).subscribe(commits => this.commits = commits, err => console.error(err));
  }
}
