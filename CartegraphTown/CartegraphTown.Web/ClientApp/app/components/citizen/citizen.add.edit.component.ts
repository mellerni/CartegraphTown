import { Component, OnInit, Input, Output, EventEmitter, ViewContainerRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Citizen } from '../../classes/citizen';
import { CitizenService } from '../../services/citizen.service';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';

@Component({
    selector: 'citizen-add-edit',
    templateUrl: './citizen.add.edit.component.html',
    styleUrls: ['./citizen.add.edit.component.css']
})
export class CitizenAddEditComponent {
    public citizen: Citizen = new Citizen();
    public citizenId: number = 0;
    public submitted: boolean = false;
    public loading: boolean = true;
    public showHelp: boolean = true;
    public title = 'Add Citizen';
    @Input() activeWalkThrough: boolean = false;
    @Output() sendCitizenId = new EventEmitter<number>();

    constructor(private citizenService: CitizenService,
                private activeRoute: ActivatedRoute,
                private router: Router,
                private toastr: ToastsManager,
                private vRef: ViewContainerRef) {}

    ngOnInit() {
        this.loading = true;
        this.citizen = new Citizen();
        this.activeRoute.params.subscribe(params => {
            console.log(params);
            this.citizenId = params.id;
            this.getCitizen();
          });

        if(!this.activeWalkThrough) {
            this.toastr.setRootViewContainerRef(this.vRef);
        }

        setTimeout(() => {
            this.showHelp = false;
        }, 2500);
    }

    getCitizen()
    {
        if(this.citizenId > 0){
            this.title = 'Edit Citizen';
            this.citizenService.get(this.citizenId)
            .then(result => {
                this.citizen = result as Citizen;
                this.loading = false;
            })
            .catch(error => this.failure(error));
        } else {
            this.loading = false;
        }
    }

    onSubmit()
    {
        // TODO: Use reactive form validation next time
        if (!this.citizen.firstName){
            this.toastr.warning('First name is required.', 'Warning:');
            return;
        }

        if (!this.citizen.lastName){
            this.toastr.warning('Last name is required.', 'Warning:');
            return;
        }

        if (!this.citizen.phone && !this.citizen.email){
            this.toastr.warning('Some form of contact info is required. Please include phone number or email.', 'Warning:');
            return;
        }

        this.submitted = true;
        if(this.citizen.id === 0){
            this.citizenService.post(this.citizen)
                .then(result => {
                    this.citizenId = result as number;
                    this.citizen.id = this.citizenId;
                    this.toastr.success('New citizen saved.', 'Success:')
                    if(!this.activeWalkThrough) {
                        this.router.navigate(['/citizen-index/']);
                    }
                    if(this.activeWalkThrough) {
                        this.sendCitizenId.emit(this.citizenId)
                    }
                })
                .catch(error => this.failure(error));
        } else {
            this.citizenService.put(this.citizen)
                .then(result => {
                    this.toastr.success('Citizen edits saved.', 'Success:')
                    this.router.navigate(['/citizen-index/']);
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