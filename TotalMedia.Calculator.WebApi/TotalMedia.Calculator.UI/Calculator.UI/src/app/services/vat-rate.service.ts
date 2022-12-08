import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { VatRate } from '../models/vatRate';
import { enviroment } from 'src/enviroments/enviroment';

@Injectable({
  providedIn: 'root'
})
export class VatRateService {
  private url="VatRate";

  constructor(private http: HttpClient) { }
  
  public getVatRates() : Observable<VatRate[]>{
    return this.http.get<VatRate[]>(`${enviroment.apiUrl}/${this.url}`);
  }
  
  public getVatRatesOfSelectedCountry(countrySelected: number): Observable<any>{    
    return this.http.get("https://localhost:5001/api/VatRates/" + countrySelected);
  }
}