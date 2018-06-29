import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { Issue } from '../../classes/issue';
import { IssueService } from '../../services/issue.service';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';

@Component({
    selector: 'issue-index',
    templateUrl: './issue.index.component.html',
    styleUrls: ['./issue.index.component.css']
})
export class IssueIndexComponent {
    public issues: Issue[] | undefined;
    public loading: boolean = true;

    constructor(private issueService: IssueService, private toastr: ToastsManager, private vRef: ViewContainerRef) {
        this.toastr.setRootViewContainerRef(vRef);
    }
    ngOnInit() {
        this.getIssues();
    }

    getIssues()
    {
        this.issueService.getAll()
        .then(result => {
            this.issues = result as Issue[];
            this.loading = false;
        })
        .catch(error => this.failure(error));
    }

    deleteIssue(issueId: number)
    {
        this.issueService.delete(issueId)
            .then(result => {
                this.toastr.success('Issue deleted.')
                this.loading = true;
                this.getIssues();
            })
            .catch(error => this.failure(error));
    }

    failure(error: any)
    {
        var body = JSON.parse(error._body);
        this.toastr.error(body.message, 'Error:');
    }

}