import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { enviroment } from 'src/enviroments/enviroment';
import { Country } from "../models/country";

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  private url="Country";

  constructor(private http: HttpClient) { }

  public getCountries() : Observable<Country[]>{
    return this.http.get<Country[]>(`${enviroment.apiUrl}/${this.url}`);
  }
}