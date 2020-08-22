import { Component, OnInit } from '@angular/core';
import { CityService } from '../city.service';
import { AutocompleteLight } from '../models/AutocompleteLight';

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrls: ['./favorites.component.css']
})
export class FavoritesComponent implements OnInit {
  autocompleteLight: AutocompleteLight[];

  constructor(private cityService : CityService) { }

  ngOnInit(): void {
    this.cityService.getAllFavorites();

    this.cityService.favoritesChanged.subscribe(
      (autocompleteLight: AutocompleteLight[])=>{
        this.autocompleteLight = autocompleteLight;
    });
  }

}
