import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { Route, extract } from '@app/core';
import { PacienteGetAllComponent } from './paciente.getall.component';

const routes: Routes = [
  Route.withShell([
    { path: '', redirectTo: '/Paciente', pathMatch: 'full' },
    { path: 'paciente', component: PacienteGetAllComponent, data: { title: extract('Paciente') } }
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class PacienteRoutingModule { }
