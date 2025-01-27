import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';

import { CoreModule } from '@app/core';
import { SharedModule } from '@app/shared';
import { PacienteRoutingModule } from './paciente-routing.module';
import { PacienteGetAllComponent } from './paciente.getall.component';


@NgModule({
  imports: [
    CommonModule,
    TranslateModule,
    CoreModule,
    SharedModule,
    PacienteRoutingModule
  ],
  declarations: [
    PacienteGetAllComponent
  ],
  providers: [
    
  ]
})
export class PacienteModule { }
