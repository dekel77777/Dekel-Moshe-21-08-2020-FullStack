import { Component, OnInit, Input } from '@angular/core';
import { AutocompleteLight } from '../models/AutocompleteLight'
import { CityService } from '../city.service';

@Component({
  selector: 'app-city-item',
  templateUrl: './city-item.component.html',
  styleUrls: ['./city-item.component.css']
})
export class CityItemComponent implements OnInit {

  @Input() city: AutocompleteLight;
  @Input() index: number;


  constructor(private cityService: CityService) { }

  ngOnInit(): void {
  }

  onSelectCity(city){
    this.cityService.getCurrentConditions(city);
  }

}
