import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { Citizen, CitizenService } from '../../services/citizen.service';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';

@Component({
    selector: 'citizenIndex',
    templateUrl: './citizen.index.component.html'
})
export class CitizenIndexComponent {
    public citizens: Citizen[];

    constructor(private citizenService: CitizenService, private toastr: ToastsManager, private vRef: ViewContainerRef) {
        this.toastr.setRootViewContainerRef(vRef);
    }
    ngOnInit() {
        this.citizenService.getAll()
            .then(result => {
                this.citizens = result as Citizen[];
            })
            .catch(error => console.error(error))
    }

    public pressSuccess() {
        this.toastr.success('Hello world!', 'Toastr fun!');
    }

}