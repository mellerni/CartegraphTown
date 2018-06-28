import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Citizen } from '../classes/citizen';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class CitizenService {
    private baseUrl = 'http://localhost:19275/api/';

   constructor(private http: Http) {}

   public getTypeAhead() {
    let apiURL = `${this.baseUrl}citizen/getTypeAhead`;
    return this.http.get(apiURL)
      .map((response) => response.json())
      .toPromise()
    }

   public getAll() {
        let apiURL = `${this.baseUrl}citizen/getAll`;
        return this.http.get(apiURL)
          .map((response) => response.json())
          .toPromise()
   }

   public get(id: number) {
    let apiURL = `${this.baseUrl}citizen/get/${id}`;
    return this.http.get(apiURL)
      .map((response) => response.json())
      .toPromise()
    }

    public post(citizen: Citizen) {
        let apiURL = `${this.baseUrl}citizen`;
        return this.http.post(apiURL, citizen)
          .map((response) => response.json())
          .toPromise()
        }

    public addLocation(citizenId: number, locationId: number) {
        let apiURL = `${this.baseUrl}citizen/addLocation/` + citizenId +  '/' + locationId;
        return this.http.put(apiURL, null)
            .map((response) => response.json())
            .toPromise()
        }


    public put(citizen: Citizen) {
        let apiURL = `${this.baseUrl}citizen`;
        return this.http.put(apiURL, citizen)
            .map((response) => response.json())
            .toPromise()
        }

    public delete(id: number) {
        let apiURL = `${this.baseUrl}citizen?citizenId=${id}`;
        return this.http.delete(apiURL)
            .map((response) => response.json())
            .toPromise()
        }

}