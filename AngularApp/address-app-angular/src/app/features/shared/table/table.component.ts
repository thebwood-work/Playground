import { Component, Input, OnInit } from '@angular/core';
import { IHeader } from './models/interfaces/iheader';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent implements OnInit {
  @Input() classNames: string = '';
  @Input() data: Object[] = [];
  @Input() headers: IHeader[] = [];


  constructor() { }

  ngOnInit(): void {
  }

}
