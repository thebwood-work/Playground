import { Component, OnInit } from '@angular/core';
import { LocationService } from 'src/app/services/locations/location.service';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.scss']
})
export class AddressComponent implements OnInit {

  constructor(private locationService: LocationService) { }

  ngOnInit(): void {
  }

}
