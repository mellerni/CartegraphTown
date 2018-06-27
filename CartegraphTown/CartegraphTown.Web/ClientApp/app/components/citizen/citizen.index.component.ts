import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { Citizen } from '../../classes/citizen';
import { CitizenService } from '../../services/citizen.service';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';

@Component({
    selector: 'citizen-index',
    templateUrl: './citizen.index.component.html',
    styleUrls: ['./citizen.index.component.css']
})
export class CitizenIndexComponent {
    public citizens: Citizen[] | undefined;
    public loading: boolean | undefined;

    constructor(private citizenService: CitizenService, private toastr: ToastsManager, private vRef: ViewContainerRef) {
        this.toastr.setRootViewContainerRef(vRef);
    }
    ngOnInit() {
        this.loading = true;
        this.getCitizens();
    }

    getCitizens()
    {
        this.citizenService.getAll()
        .then(result => {
            this.citizens = result as Citizen[];
            this.loading = false;
        })
        .catch(error => this.toastr.error(error, 'Error:'));
    }

    deleteCitizen(citizenId: number)
    {
        this.citizenService.delete(citizenId)
            .then(result => {
                this.toastr.success('Citizen deleted.')
                this.loading = true;
                this.getCitizens();
            })
            .catch(error => this.toastr.error(error, 'Error:'));
    }

}