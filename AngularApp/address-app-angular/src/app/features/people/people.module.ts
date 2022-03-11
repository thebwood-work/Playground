import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PeopleRoutingModule } from './people-routing.module';
import { PeopleComponent } from './people.component';
import { PeopleDetailComponent } from './people-detail/people-detail.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    PeopleComponent,
    PeopleDetailComponent
  ],
  imports: [
    CommonModule,
    PeopleRoutingModule,
    SharedModule
  ],
  exports: []
})
export class PeopleModule { }
