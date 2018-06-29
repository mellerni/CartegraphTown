import { Component, OnInit, Input, Output, EventEmitter, ViewContainerRef } from '@angular/core';
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
    public submitted: boolean = false;
    public loading: boolean = true;
    public showHelp: boolean = true;
    public title = 'Add Point';
    @Input() activeWalkThrough: boolean = false;
    @Output() sendLocationId = new EventEmitter<number>();

    constructor(private locationService: LocationService,
                private activeRoute: ActivatedRoute,
                private router: Router,
                private toastr: ToastsManager,
                private vRef: ViewContainerRef) {}

    ngOnInit() {
        this.point = new Point();
        this.activeRoute.params.subscribe(params => {
            console.log(params);
            this.pointId = params.id;
            this.getPoint();
          });

        if(!this.activeWalkThrough) {
            this.toastr.setRootViewContainerRef(this.vRef);
        }

        setTimeout(() => {
            this.showHelp = false;
        }, 2500);
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
            .catch(error => this.failure(error));
        } else {
            this.loading = false;
        }
    }

    onSubmit()
    {

        // TODO: Use reactive form validation next time
        if(!this.point.latitude) {
            this.toastr.warning('Latitude is required', 'Warning:');
            return;
        }

        if(!this.point.longitude) {
            this.toastr.warning('Longitude is required', 'Warning:');
            return;
        }

        this.submitted = true;
        if(this.point.id === 0){
            this.locationService.postPoint(this.point)
                .then(result => {
                    this.pointId = result as number;
                    this.point.id = this.pointId;
                    this.toastr.success('New point saved.', 'Success:')
                    if(!this.activeWalkThrough) {
                        this.router.navigate(['/location-index']);
                    }
                    if(this.activeWalkThrough) {
                        this.sendLocationId.emit(this.pointId)
                    }
                })
                .catch(error => this.failure(error));
        } else {
            this.locationService.putPoint(this.point)
                .then(result => {
                    this.toastr.success('Point edits saved.', 'Success:')
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