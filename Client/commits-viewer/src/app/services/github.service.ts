import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';
import { Observable } from 'rxjs';
import { Repository } from '../models/repository';
import { Commit } from '../models/commit';

@Injectable({
  providedIn: 'root'
})
export class GithubService {

  BASE_URL: string = 'https://localhost:5001/api';

  constructor(private http: HttpClient) { }

  public searchUsers(user: string): Observable<User[]> {
    return this.http.get<User[]>(`${this.BASE_URL}/github/searchUsers?user=${user}`);
  }

  public searchRepository(repository: string): Observable<Repository[]> {
    return this.http.get<Repository[]>(`${this.BASE_URL}/github/searchRepositories?repository=${repository}`);
  }

  public getRepositories(user: string): Observable<Repository[]> {
    return this.http.get<Repository[]>(`${this.BASE_URL}/github/getUserRepositories?user=${user}`);
  }

  public getCommits(user: string, repository: string): Observable<Commit[]> {
    return this.http.get<Commit[]>(`${this.BASE_URL}/github/getCommits?owner=${user}&repository=${repository}`);
  }
}
