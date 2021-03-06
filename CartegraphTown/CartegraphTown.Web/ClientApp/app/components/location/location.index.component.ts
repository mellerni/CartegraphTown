import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { Address } from '../../classes/address';
import { Point } from '../../classes/point';
import { LocationService } from '../../services/location.service';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';

@Component({
    selector: 'location-index',
    templateUrl: './location.index.component.html',
    styleUrls: ['./location.index.component.css']
})
export class LocationIndexComponent {
    public addresses: Address[] | undefined;
    public points: Point[] | undefined;
    public loadingAddresses: boolean = true;
    public loadingPoints: boolean = true;

    constructor(private locationService: LocationService, private toastr: ToastsManager, private vRef: ViewContainerRef) {
        this.toastr.setRootViewContainerRef(vRef);
    }
    ngOnInit() {
        this.getAddresses();
        this.getPoints();
    }

    getAddresses()
    {
        this.locationService.getAllAddresses()
        .then(result => {
            this.addresses = result as Address[];
            this.loadingAddresses = false;
        })
        .catch(error => this.failure(error));
    }

    getPoints()
    {
        this.locationService.getAllPoints()
        .then(result => {
            this.points = result as Point[];
            this.loadingPoints = false;
        })
        .catch(error => this.failure(error));
    }

    deletePoint(locationId: number)
    {
        this.locationService.delete(locationId)
            .then(result => {
                this.toastr.success('Point deleted.')
                this.loadingPoints = true;
                this.getAddresses();
                this.getPoints()
            })
            .catch(error => this.failure(error));
    }

    deleteAddress(locationId: number)
    {
        this.locationService.delete(locationId)
            .then(result => {
                this.toastr.success('Address deleted.')
                this.loadingAddresses = true;
                this.getAddresses();
                this.getPoints()
            })
            .catch(error => this.failure(error));
    }

    failure(error: any)
    {
        var body = JSON.parse(error._body);
        this.toastr.error(body.message, 'Error:')
    }

}