import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { CitizenService } from '../../services/citizen.service';
import { TypeAhead } from '../../classes/type.ahead';

@Component({
    selector: 'issue-walk-through',
    templateUrl: './issue.walk.through.component.html',
    styleUrls: ['./issue.walk.through.component.css']
})
export class IssueWalkThroughComponent {
    public loading: boolean = false;

    public citizenId: number | undefined;
    public citizenLocationId: number | undefined;

    public locationMatch: boolean | undefined;
    public locationTypeIsPoint: boolean | undefined;
    public issueLocationId: number | undefined;

    public title = 'Issue Creation Walk Through';
    public activeStepId: number = 1;
    public previousStepId: number | undefined;
    public activeStep = 'Step 1: Add a citizen';

    constructor(private citizenService: CitizenService,
                private activeRoute: ActivatedRoute,
                private router: Router,
                private toastr: ToastsManager,
                private vRef: ViewContainerRef) {
        this.toastr.setRootViewContainerRef(vRef);
    }

    ngOnInit() {

    }

    getActiveStep() {

        this.previousStepId = this.activeStepId;
        if (this.citizenId && this.citizenId > 0 && this.activeStepId === 1) {
            this.activeStepId = 2;
            this.activeStep = 'Step 2: Please add the citizen\'s address.';
        } else if (this.citizenLocationId && this.citizenLocationId > 0 && this.activeStepId === 2) {
            this.activeStepId = 3;
            this.activeStep = 'Step 3: Is the issue\'s location the same as the citizen\'s address?';
        } else if (!this.locationMatch && this.activeStepId === 3) {
            this.activeStepId = 4;
            this.activeStep = 'Step 4: Is the issue\'s location best described as an address or GPS point?';
        } else if (!this.locationMatch && this.activeStepId === 4) {
            this.activeStepId = 5;
            this.activeStep = 'Step 5: Please add the issue\'s location.';
        } else if (this.locationMatch && this.activeStepId === 3) {
            this.activeStepId = 6;
            this.activeStep = 'Step 6: Please add an issue. [Step 4 and 5 skipped.]';
        } else if (this.issueLocationId && this.issueLocationId > 0 && this.activeStepId === 5) {
            this.activeStepId = 6;
            this.activeStep = 'Step 6: Please add an issue.';
        } else {
            this.activeStepId = 1;
            this.activeStep = 'Step 1: Please add a citizen.';
        }
    }

    receiveCitizenId($event: number) {
        this.citizenId = $event;
        this.getActiveStep();
    }

    setLocationMatch(match: boolean) {
        this.locationMatch = match;
        if(match){
            this.issueLocationId = this.citizenLocationId;
        }
        this.getActiveStep();
    }

    setLocationType(isPoint: boolean) {
        this.locationTypeIsPoint = isPoint;
        this.getActiveStep();
    }

    previousStep() {
        this.activeStepId = !this.previousStepId ? 1 : this.previousStepId;
    }

    receiveLocationId($event: number) {
        if(this.activeStepId === 2 && this.citizenId){
            this.citizenLocationId = $event;
            this.citizenService.addLocation(this.citizenId, this.citizenLocationId)
            .then(result => {
                this.toastr.success('Citizen\'s location has saved.', 'Success:')
            })
            .catch(error => this.failure(error));
        }

        if(this.activeStepId === 5){
            this.issueLocationId = $event;
        }
        this.getActiveStep();
    }

    failure(error: any)
    {
        var body = JSON.parse(error._body);
        this.toastr.error(body.message, 'Error:')
    }


}