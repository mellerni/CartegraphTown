import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Address } from '../classes/address';
import { Point } from '../classes/point';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class LocationService {
    private baseUrl = 'http://localhost:19275/api/';

    constructor(private http: Http) {}

    public getStates() {
        let apiURL = `${this.baseUrl}location/getStates`;
        return this.http.get(apiURL)
            .map((response) => response.json())
            .toPromise()
    }

    public getTypeAhead() {
        let apiURL = `${this.baseUrl}location/getTypeAhead`;
        return this.http.get(apiURL)
          .map((response) => response.json())
          .toPromise()
    }

    public getAllAddresses() {
        let apiURL = `${this.baseUrl}location/getAllAddresses`;
        return this.http.get(apiURL)
            .map((response) => response.json())
            .toPromise()
    }

    public getAllPoints() {
        let apiURL = `${this.baseUrl}location/getAllPoints`;
        return this.http.get(apiURL)
            .map((response) => response.json())
            .toPromise()
    }

    public getAddress(id: number) {
        let apiURL = `${this.baseUrl}location/getAddress/${id}`;
        return this.http.get(apiURL)
            .map((response) => response.json())
            .toPromise()
    }

    public getPoint(id: number) {
        let apiURL = `${this.baseUrl}location/getPoint/${id}`;
        return this.http.get(apiURL)
            .map((response) => response.json())
            .toPromise()
    }

    public postAddress(address: Address) {
        let apiURL = `${this.baseUrl}location/postAddress`;
        return this.http.post(apiURL, address)
            .map((response) => response.json())
            .toPromise()
    }

    public postPoint(point: Point) {
        let apiURL = `${this.baseUrl}location/postPoint`;
        return this.http.post(apiURL, point)
            .map((response) => response.json())
            .toPromise()
    }

    public putAddress(address: Address) {
        let apiURL = `${this.baseUrl}location/putAddress`;
        return this.http.put(apiURL, address)
            .map((response) => response.json())
            .toPromise()
    }

    public putPoint(point: Point) {
        let apiURL = `${this.baseUrl}location/putPoint`;
        return this.http.put(apiURL, point)
            .map((response) => response.json())
            .toPromise()
    }

    public delete(id: number) {
        let apiURL = `${this.baseUrl}location?locationId=${id}`;
        return this.http.delete(apiURL)
            .map((response) => response.json())
            .toPromise()
    }

}