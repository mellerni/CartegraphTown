import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Point } from '../../classes/point';
import { LocationService } from '../../services/location.service';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';

@Component({
    selector: 'point-add-edit',
    templateUrl: './point.add.edit.component.html',
    styleUrls: ['./point.add.edit.component.css']
})
export class PointAddEditComponent {
    public point: Point = new Point();
    public pointId: number = 0;
    public loading: boolean = true;
    public title = 'Add Point';

    constructor(private locationService: LocationService,
                private activeRoute: ActivatedRoute,
                private router: Router,
                private toastr: ToastsManager,
                private vRef: ViewContainerRef) {
        this.toastr.setRootViewContainerRef(vRef);
    }

    ngOnInit() {
        this.point = new Point();
        this.activeRoute.params.subscribe(params => {
            console.log(params);
            this.pointId = params.id;
            this.getPoint();
          });
    }

    getPoint()
    {
        if(this.pointId > 0){
            this.title = 'Edit Point';
            this.locationService.getPoint(this.pointId)
            .then(result => {
                this.point = result as Point;
                this.loading = false;
            })
            .catch(error => this.toastr.error(error, 'Error:'));
        } else {
            this.loading = false;
        }
    }

    onSubmit()
    {
        if(this.point.id === 0){
            this.locationService.postPoint(this.point)
                .then(result => {
                    this.pointId = result as number;
                    this.point.id = this.pointId;
                    this.toastr.success('New point saved.', 'Success:')
                    this.router.navigate(['/location-index']);
                })
                .catch(error => this.toastr.error(error, 'Error:'));
        } else {
            this.locationService.putPoint(this.point)
                .then(result => {
                    this.toastr.success('Point edits saved.', 'Success:')
                    this.router.navigate(['/location-index']);
                })
                .catch(error => this.toastr.error(error, 'Error:'));
        }
    }

}