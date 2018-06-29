import { Component, OnInit, Input, ViewContainerRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Issue } from '../../classes/issue';
import { IssueType } from '../../classes/issue.type';
import { IssueService } from '../../services/issue.service';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';

@Component({
    selector: 'issue-add-edit',
    templateUrl: './issue.add.edit.component.html',
    styleUrls: ['./issue.add.edit.component.css']
})
export class IssueAddEditComponent {
    public issue: Issue = new Issue();
    public issueId: number = 0;
    public issueTypes: IssueType[] | undefined;
    public loading: boolean = true;
    public submitted: boolean = false;
    public loadingTypes: boolean = true;
    public title = 'Add Issue';
    @Input() activeWalkThrough: boolean = false;
    @Input() walkThroughCitizenId : number | undefined;
    @Input() walkThroughLocationId : number | undefined;

    constructor(private issueService: IssueService,
                private activeRoute: ActivatedRoute,
                private router: Router,
                private toastr: ToastsManager,
                private vRef: ViewContainerRef) {}

    ngOnInit() {
        this.issue = new Issue();
        this.getTypes();
        this.activeRoute.params.subscribe(params => {
            console.log(params);
            this.issueId = params.id;
            this.getIssue();
          });
        if(!this.activeWalkThrough) {
            this.toastr.setRootViewContainerRef(this.vRef);
        }
    }

    getIssue()
    {
        if(this.issueId > 0){
            this.title = 'Edit Issue';
            this.issueService.get(this.issueId)
            .then(result => {
                this.issue = result as Issue;
                this.loading = false;
            })
            .catch(error => this.failure(error));
        } else {
            this.loading = false;
        }
    }

    getTypes()
    {
        this.issueService.getTypes()
        .then(result => {
            this.issueTypes = result as IssueType[];
            this.loadingTypes = false;
        })
        .catch(error => this.failure(error));
    }

    onSubmit()
    {
        if (this.walkThroughCitizenId && this.walkThroughLocationId){
            this.issue.citizenId = this.walkThroughCitizenId;
            this.issue.locationId = this.walkThroughLocationId;
        }

        // TODO: Use reactive form validation next time
        if (!this.issue.citizenId || !this.issue.locationId){
            this.toastr.error('Missing location or citizen. Could not save.', 'Error:');
            return;
        }

        if (!this.issue.issueTypeId || this.issue.issueTypeId === 0) {
            this.toastr.warning('Type are required.', 'Warning:');
            return;
        }

        if (!this.issue.details) {
            this.toastr.warning('Details are required.', 'Warning:');
            return;
        }

        if(this.issue.id === 0){
            this.issueService.post(this.issue)
                .then(result => {
                    this.issueId = result as number;
                    this.issue.id = this.issueId;
                    this.toastr.success('New issue saved.', 'Success:')
                    this.router.navigate(['/issue-index']);
                })
                .catch(error => this.failure(error));
        } else {
            this.issueService.put(this.issue)
                .then(result => {
                    this.toastr.success('Issue edits saved.', 'Success:')
                    this.router.navigate(['/issue-index']);
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