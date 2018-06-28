import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Address } from '../../classes/address';
import { State } from '../../classes/state';
import { LocationService } from '../../services/location.service';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { Point } from '../../classes/point';

@Component({
    selector: 'address-add-edit',
    templateUrl: './address.add.edit.component.html',
    styleUrls: ['./address.add.edit.component.css']
})
export class AddressAddEditComponent {
    public address: Address = new Address();
    public addressId: number = 0;
    public states: State[] | undefined;
    public loading: boolean = true;
    public loadingStates: boolean = true;
    public title = 'Add Address';

    constructor(private locationService: LocationService,
                private activeRoute: ActivatedRoute,
                private router: Router,
                private toastr: ToastsManager,
                private vRef: ViewContainerRef) {
        this.toastr.setRootViewContainerRef(vRef);
    }

    ngOnInit() {
        this.address = new Address();
        this.getStates();
        this.activeRoute.params.subscribe(params => {
            console.log(params);
            this.addressId = params.id;
            this.getAddress();
          });
    }

    getAddress()
    {
        if(this.addressId > 0){
            this.title = 'Edit Address';
            this.locationService.getAddress(this.addressId)
            .then(result => {
                this.address = result as Address;
                this.loading = false;
            })
            .catch(error => this.toastr.error(error, 'Error:'));
        } else {
            this.loading = false;
        }
    }

    getStates()
    {
        this.locationService.getStates()
        .then(result => {
            this.states = result as State[];
            this.loadingStates = false;
        })
        .catch(error => this.toastr.error(error, 'Error:'));
    }

    onSubmit()
    {
        if(this.address.id === 0){
            this.locationService.postAddress(this.address)
                .then(result => {
                    this.addressId = result as number;
                    this.address.id = this.addressId;
                    this.toastr.success('New address saved.', 'Success:')
                    this.router.navigate(['/location-index']);
                })
                .catch(error => this.toastr.error(error, 'Error:'));
        } else {
            this.locationService.putAddress(this.address)
                .then(result => {
                    this.toastr.success('Address edits saved.', 'Success:')
                    this.router.navigate(['/location-index']);
                })
                .catch(error => this.toastr.error(error, 'Error:'));
        }
    }

}