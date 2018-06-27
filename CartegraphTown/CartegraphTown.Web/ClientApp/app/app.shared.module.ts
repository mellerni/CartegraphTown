import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';

import { CitizenService } from './services/citizen.service';
import { LocationService } from './services/location.service';

import { CitizenIndexComponent } from './components/citizen/citizen.index.component';
import { CitizenAddEditComponent } from './components/citizen/citizen.add.edit.component';
import { LocationIndexComponent } from './components/location/location.index.component';
import { AddressAddEditComponent } from './components/location/address.add.edit.component';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CitizenIndexComponent,
        CitizenAddEditComponent,
        LocationIndexComponent,
        AddressAddEditComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'citizen-index', component: CitizenIndexComponent },
            { path: 'citizen-add', component: CitizenAddEditComponent },
            { path: 'citizen-edit/:id', component: CitizenAddEditComponent},
            { path: 'location-index', component: LocationIndexComponent },
            { path: 'address-add', component: AddressAddEditComponent },
            { path: 'address-edit/:id', component: AddressAddEditComponent},
            //{ path: 'point-add', component: PointAddEditComponent },
            // { path: 'point-edit/:id', component: PointAddEditComponent},
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [CitizenService, LocationService],
})
export class AppModuleShared {
}
