import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DividerComponent } from './divider/divider.component';
import { TableComponent } from './table/table.component';



@NgModule({
  declarations: [
    DividerComponent,
    TableComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    DividerComponent,
    TableComponent
  ]
})
export class SharedModule { }
