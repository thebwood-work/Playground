import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PeopleRoutingModule } from './people-routing.module';
import { PeopleComponent } from './people.component';
import { PeopleDetailComponent } from './people-detail/people-detail.component';
import { SharedModule } from '../shared/shared.module';
import { PeopleSearchComponent } from './people-search/people-search.component';
import { PeopleGridComponent } from './people-grid/people-grid.component';


@NgModule({
  declarations: [
    PeopleComponent,
    PeopleDetailComponent,
    PeopleSearchComponent,
    PeopleGridComponent
  ],
  imports: [
    CommonModule,
    PeopleRoutingModule,
    SharedModule
  ],
  exports: []
})
export class PeopleModule { }
