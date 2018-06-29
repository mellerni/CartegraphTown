import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { State } from '../../classes/state';
import { LocationService } from '../../services/location.service';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent {
    public loading: boolean = true;
    public showStatus: boolean = true;
    public isConnected: boolean = false;
    public hasLostConnection: boolean = false;
    public states: State[] | undefined;

    constructor(private locationService: LocationService) {
    }

    ngOnInit() {
        this.getStates();
    }

    getStates()
    {
        this.loading = false;
        this.locationService.getStates()
        .then(result => {
            this.states = result as State[];
            this.loading = false;
            this.isConnected = true;
            setTimeout(() => {
                this.showStatus = false;
            }, 10000);
        })
        .catch(error => {
            this.loading = false;
            this.hasLostConnection = true;
        });
    }
}
