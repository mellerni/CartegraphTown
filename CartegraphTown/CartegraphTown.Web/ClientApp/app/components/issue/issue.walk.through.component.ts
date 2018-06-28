import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';

@Component({
    selector: 'issue-walk-through',
    templateUrl: './issue.walk.through.component.html',
    styleUrls: ['./issue.walk.through.component.css']
})
export class IssueAddEditComponent {
    public loading: boolean = true;
    public title = 'Issue Creation Walk Through';
    public activeStep = 'Step 1: Find or add a citizen';
    public helpText = 'Hello. Can I have your first and last name please?';

    constructor(private activeRoute: ActivatedRoute,
                private router: Router,
                private toastr: ToastsManager,
                private vRef: ViewContainerRef) {
        this.toastr.setRootViewContainerRef(vRef);
    }

    ngOnInit() {

    }


}