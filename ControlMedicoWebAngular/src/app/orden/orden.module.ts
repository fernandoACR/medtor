import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';

import { CoreModule } from '@app/core';
import { SharedModule } from '@app/shared';
import { OrdenRoutingModule } from './orden-routing.module';
import { OrdenGetAllComponent } from './orden.getall.component';


@NgModule({
  imports: [
    CommonModule,
    TranslateModule,
    CoreModule,
    SharedModule,
    OrdenRoutingModule
  ],
  declarations: [
    OrdenGetAllComponent
  ],
  providers: [
    
  ]
})
export class OrdenModule { }
