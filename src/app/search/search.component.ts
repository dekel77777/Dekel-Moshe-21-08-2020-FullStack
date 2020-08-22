import { Component, OnInit } from '@angular/core';

import { ApiService } from 'src/app/api.service';
import { AutocompleteLight } from '../models/AutocompleteLight'
import { CityService } from '../city.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  autocompleteLight: AutocompleteLight[];
  constructor(private cityService : CityService) { }

  ngOnInit(): void {
    this.cityService.autocompleteLightChanged.subscribe(
      (autocompleteLight: AutocompleteLight[]) => {
        this.autocompleteLight = autocompleteLight;
    });
  }

}
