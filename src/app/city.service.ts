import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpEventType } from '@angular/common/http';
import { Observable,Subscription, Subject } from 'rxjs';
import { map} from 'rxjs/operators';
import { AutocompleteLight } from './models/AutocompleteLight'
import { CurrentConditionsLight } from './models/CurrentConditionsLight'
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class CityService {
  autocompleteLightChanged = new Subject<AutocompleteLight[]>();
  favoritesChanged = new Subject<AutocompleteLight[]>();
  currentConditionsLightChanged = new Subject<CurrentConditionsLight>();

  constructor(private apiService: ApiService) { }

  getLocationAutoComplete(q: string){
    this.apiService.getLocationAutoComplete(q).subscribe((autocompleteLight: AutocompleteLight[])=>{
      this.autocompleteLightChanged.next(autocompleteLight);
    });
  }

  getCurrentConditions(autocompleteLight: AutocompleteLight){
    this.apiService.getCurrentConditions(autocompleteLight).subscribe((currentConditionsLight: CurrentConditionsLight)=>{
      this.currentConditionsLightChanged.next(currentConditionsLight);
    });
  }

  saveFavoriteCity(favorite : AutocompleteLight){
    this.apiService.saveFavoriteCity(favorite);
  }

  getAllFavorites() {
    this.apiService.getAllFavorites().subscribe(
      (autocompleteLight: AutocompleteLight[])=>{
        this.favoritesChanged.next(autocompleteLight);
    });
  }

  deleteCityFromFavorites(locationKey: string) {
    this.apiService.deleteCityFromFavorites(locationKey).subscribe(
      (autocompleteLight: AutocompleteLight[])=>{
      this.favoritesChanged.next(autocompleteLight);
  });
}


}
