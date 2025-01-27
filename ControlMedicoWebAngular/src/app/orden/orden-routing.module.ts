import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { Route, extract } from '@app/core';
import { OrdenGetAllComponent } from './orden.getall.component';

const routes: Routes = [
  Route.withShell([
    { path: '', redirectTo: '/Orden', pathMatch: 'full' },
    { path: 'orden', component: OrdenGetAllComponent, data: { title: extract('Orden') } }
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class OrdenRoutingModule { }
