import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpEventType } from '@angular/common/http';
import { Observable,Subscription, Subject } from 'rxjs';
import { map} from 'rxjs/operators';
import { AutocompleteLight } from './models/AutocompleteLight'
import { CurrentConditionsLight } from './models/CurrentConditionsLight'


@Injectable({
  providedIn: 'root'
})
export class ApiService {


  constructor(private http: HttpClient) { }


  getLocationAutoComplete(q: string) {
    const url = 'https://localhost:44384/api/weather/GetLocationAutoComplete';
    let params1 = new HttpParams().set('q',q);

    return this.http.get<AutocompleteLight[]>(url,{params: params1})
    .pipe(map((autocompleteLight) => {
      return autocompleteLight;
    }));
  }


  getCurrentConditions(autocompleteLight: AutocompleteLight) {
    const url = 'https://localhost:44384/api/weather/GetCurrentConditions';
    let params = new HttpParams().set('locationKey',autocompleteLight.cityKey);
    params = params.append('localizedName', autocompleteLight.localizedName);
    return this.http.get<CurrentConditionsLight>(url,{params: params})
    .pipe(map((currentConditionsLight) => {
      return currentConditionsLight;
    }));
  }

  saveFavoriteCity(favorite: AutocompleteLight) {
    const url = 'https://localhost:44384/api/weather/SaveFavoriteCity';
    this.http.post(url, favorite, {reportProgress: true, observe: 'events'})
    .subscribe((event ) => {
    });
  }

  getAllFavorites() {
    const url = 'https://localhost:44384/api/weather/GetAllFavorites';
    return this.http.get<AutocompleteLight[]>(url)
    .pipe(map((currentConditionsLight) => {
      return currentConditionsLight;
    }));
  }

  deleteCityFromFavorites(locationKey: string) {
    const url = 'https://localhost:44384/api/weather/DeleteCityFromFavorites';
    let params = new HttpParams().set('locationKey',locationKey);
    return this.http.delete<AutocompleteLight[]>(url,{params: params})
    .pipe(map((currentConditionsLight) => {
      return currentConditionsLight;
    }));
  }

}
