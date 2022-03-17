import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddressRoutingModule } from './address-routing.module';
import { AddressComponent } from './address.component';
import { AddressDetailComponent } from './address-detail/address-detail.component';
import { AddressSearchComponent } from './address-search/address-search.component';


@NgModule({
  declarations: [
    AddressComponent,
    AddressDetailComponent,
    AddressSearchComponent
  ],
  imports: [
    CommonModule,
    AddressRoutingModule
  ],
  exports: []
})
export class AddressModule { }
