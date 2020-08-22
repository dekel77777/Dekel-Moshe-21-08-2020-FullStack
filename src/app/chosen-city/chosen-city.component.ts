import { Component, OnInit, Input } from '@angular/core';
import { CityService } from '../city.service';
import { CurrentConditionsLight } from '../models/CurrentConditionsLight'
import { AutocompleteLight } from '../models/AutocompleteLight'


@Component({
  selector: 'app-chosen-city',
  templateUrl: './chosen-city.component.html',
  styleUrls: ['./chosen-city.component.css']
})
export class ChosenCityComponent implements OnInit {
  @Input() isAddToFavorites: boolean;
  currentConditionsLight: CurrentConditionsLight;

  constructor(private cityService: CityService) { }

  ngOnInit(): void {
    this.cityService.currentConditionsLightChanged.subscribe(
      (currentConditionsLight: CurrentConditionsLight)=>{
        this.currentConditionsLight = currentConditionsLight;
    });
  }

  onAddToFavorites(currentConditionsLight: CurrentConditionsLight){
    var favorite = new AutocompleteLight();
    favorite.cityKey = currentConditionsLight.locationKey;
    favorite.localizedName = currentConditionsLight.localizedName;
    this.cityService.saveFavoriteCity(favorite);
  }

  onRemoveFromFavorites(currentConditionsLight: CurrentConditionsLight){
    var favorite = new AutocompleteLight();
    favorite.cityKey = currentConditionsLight.locationKey;
    favorite.localizedName = currentConditionsLight.localizedName;
    this.cityService.deleteCityFromFavorites(favorite.cityKey);
    this.currentConditionsLight = null;
  }

}
