import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { Route, extract } from '@app/core';
import { HomeComponent } from './home.component';

const routes: Routes = [
  Route.withShell([
    { path: 'home', component: HomeComponent, data: { title: extract('Home') } },
    { path: '', redirectTo: '/home', pathMatch: 'full' }
  ])
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class HomeRoutingModule { }
