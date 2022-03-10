import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddressDetailComponent } from './address-detail/address-detail.component';
import { AddressComponent } from './address.component';

const routes: Routes = [
  { path: 'addresses', component: AddressComponent },
  { path: 'addresses/:id', component: AddressDetailComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AddressRoutingModule { }
