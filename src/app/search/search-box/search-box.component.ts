import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ApiService } from 'src/app/api.service';
import { AutocompleteLight } from '../../models/AutocompleteLight'
import { CityService } from 'src/app/city.service';

@Component({
  selector: 'app-search-box',
  templateUrl: './search-box.component.html',
  styleUrls: ['./search-box.component.css']
})
export class SearchBoxComponent implements OnInit {
  autocompleteLight: AutocompleteLight[];

  constructor(private cityService : CityService) { }

  ngOnInit(): void {
  }


  onSubmit(searchForm: NgForm) {
    if (!searchForm.valid) {
      return;
    }
    const searchBox = searchForm.value.searchBox;
    this.cityService.getLocationAutoComplete(searchBox);
    searchForm.reset();
  }

}
