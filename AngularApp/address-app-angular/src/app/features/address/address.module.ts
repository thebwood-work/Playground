import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddressRoutingModule } from './address-routing.module';
import { AddressComponent } from './address.component';
import { AddressDetailComponent } from './address-detail/address-detail.component';


@NgModule({
  declarations: [
    AddressComponent,
    AddressDetailComponent
  ],
  imports: [
    CommonModule,
    AddressRoutingModule
  ],
  exports: []
})
export class AddressModule { }
