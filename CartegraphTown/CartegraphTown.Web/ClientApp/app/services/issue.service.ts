import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Issue } from '../classes/issue';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class IssueService {
    private baseUrl = 'http://localhost:19275/api/';

    constructor(private http: Http) {}

    public getTypes() {
        let apiURL = `${this.baseUrl}issue/getTypes`;
        return this.http.get(apiURL)
            .map((response) => response.json())
            .toPromise()
    }

    public getAll() {
        let apiURL = `${this.baseUrl}issue/getAll`;
        return this.http.get(apiURL)
            .map((response) => response.json())
            .toPromise()
    }

    public get(id: number) {
        let apiURL = `${this.baseUrl}issue/get/${id}`;
        return this.http.get(apiURL)
            .map((response) => response.json())
            .toPromise()
    }

    public post(issue: Issue) {
        let apiURL = `${this.baseUrl}issue`;
        return this.http.post(apiURL, issue)
            .map((response) => response.json())
            .toPromise()
    }

    public put(issue: Issue) {
        let apiURL = `${this.baseUrl}issue`;
        return this.http.put(apiURL, issue)
            .map((response) => response.json())
            .toPromise()
    }

    public delete(id: number) {
        let apiURL = `${this.baseUrl}issue?issueId=${id}`;
        return this.http.delete(apiURL)
            .map((response) => response.json())
            .toPromise()
    }

}