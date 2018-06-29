import { Component, OnInit, Input, EventEmitter, Output, ViewContainerRef } from '@angular/core';
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
    public showHelp: boolean = true;
    public submitted: boolean = false;
    public loadingStates: boolean = true;
    public title = 'Add Address';
    @Input() activeWalkThrough: boolean = false;
    @Input() resetLocation: boolean = false;
    @Output() sendLocationId = new EventEmitter<number>();

    constructor(private locationService: LocationService,
                private activeRoute: ActivatedRoute,
                private router: Router,
                private toastr: ToastsManager,
                private vRef: ViewContainerRef) {}

    ngOnInit() {
        this.address = new Address();
        this.getStates();
        this.activeRoute.params.subscribe(params => {
            console.log(params);
            this.addressId = params.id;
            this.getAddress();
          });

        if(!this.activeWalkThrough) {
            this.toastr.setRootViewContainerRef(this.vRef);
        }

        setTimeout(() => {
            this.showHelp = false;
        }, 2500);
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
            .catch(error => this.failure(error));
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
        .catch(error => this.failure(error));
    }

    onSubmit(errors: any)
    {
        // TODO: Use reactive form validation next time
        if(!this.address.address1) {
            this.toastr.warning('Address Line One is required', 'Warning:');
            return;
        }

        if(!this.address.city) {
            this.toastr.warning('City is required', 'Warning:');
            return;
        }

        if (!this.address.stateId || this.address.stateId === 0) {
            this.toastr.warning('State is required.', 'Warning:');
            return;
        }

        if(!this.address.zipCode) {
            this.toastr.warning('Zip code is required', 'Warning:');
            return;
        }

        if(this.address.point && !this.address.point.latitude && this.address.point.longitude) {
            this.toastr.warning('Latitude is required', 'Warning:');
            return;
        }

        if(this.address.point && this.address.point.latitude && !this.address.point.longitude) {
            this.toastr.warning('Longitude is required', 'Warning:');
            return;
        }

        this.submitted = true;
        if(this.address.id === 0){
            this.locationService.postAddress(this.address)
                .then(result => {
                    this.addressId = result as number;
                    this.address.id = this.addressId;
                    this.toastr.success('New address saved.', 'Success:')
                    if(!this.activeWalkThrough) {
                        this.router.navigate(['/location-index']);
                    }
                    if(this.activeWalkThrough) {
                        this.sendLocationId.emit(this.addressId)
                    }
                })
                .catch(error => this.failure(error));
        } else {
            this.locationService.putAddress(this.address)
                .then(result => {
                    this.toastr.success('Address edits saved.', 'Success:')
                    this.router.navigate(['/location-index']);
                })
                .catch(error => this.failure(error));
        }
    }

    failure(error: any)
    {
        var body = JSON.parse(error._body);
        this.toastr.error(body.message, 'Error:');
        this.submitted = false;
    }

}