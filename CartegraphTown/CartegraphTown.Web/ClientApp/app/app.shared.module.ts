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

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CitizenIndexComponent,
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
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [CitizenService],
})
export class AppModuleShared {
}
