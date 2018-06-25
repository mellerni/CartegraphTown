import { Injectable, Inject } from '@angular/core';
import { Http} from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

export interface Citizen {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    phone: string;
    createdDate: Date;
}

@Injectable()
export class CitizenService {
   constructor(private http: Http, @Inject('BASE_API_URL') private baseUrl: string) {}

   public getAll() {
        let apiURL = `${this.baseUrl}citizen/getAll`;
        return this.http.get(apiURL)
          .map((response) => response.json())
          .toPromise()
   }



}