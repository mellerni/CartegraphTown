import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';

import { CitizenService } from './services/citizen.service';

import { CitizenIndexComponent } from './components/citizen/citizen.index.component';
import { CitizenAddEditComponent } from './components/citizen/citizen.add.edit.component';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CitizenIndexComponent,
        CitizenAddEditComponent,
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
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [CitizenService],
})
export class AppModuleShared {
}
