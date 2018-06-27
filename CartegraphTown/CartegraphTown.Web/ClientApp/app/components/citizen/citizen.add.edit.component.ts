import { Component, OnInit, ViewContainerRef } from '@angular/core';
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
    public citizen: Citizen;
    public citizenId: number;
    public loading: boolean;
    public title = 'Add Citizen';

    constructor(private citizenService: CitizenService,
                private activeRoute: ActivatedRoute,
                private router: Router,
                private toastr: ToastsManager,
                private vRef: ViewContainerRef) {
        this.toastr.setRootViewContainerRef(vRef);
    }

    ngOnInit() {
        this.loading = true;
        this.citizen = new Citizen({id:0, firstName: '', lastName: '',  email: '',  phone: ''});
        this.activeRoute.params.subscribe(params => {
            console.log(params);
            this.citizenId = params.id;
            this.getCitizen();
          });
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
            .catch(error => this.toastr.error(error, 'Error:'))
        } else {
            this.loading = false;
        }
    }

    onSubmit()
    {
        if(this.citizen.id === 0){
            this.citizenService.post(this.citizen)
                .then(result => {
                    this.citizenId = result as number;
                    this.citizen.id = this.citizenId;
                    this.toastr.success('New citizen saved.', 'Success:')
                    this.router.navigate(['/citizen-index/']);
                })
                .catch(error => this.toastr.error(error, 'Error:'))
        } else {
            this.citizenService.put(this.citizen)
                .then(result => {
                    this.toastr.success('Citizen edits saved.', 'Success:')
                    this.router.navigate(['/citizen-index/']);
                })
                .catch(error => this.toastr.error(error, 'Error:'))
        }
    }

}