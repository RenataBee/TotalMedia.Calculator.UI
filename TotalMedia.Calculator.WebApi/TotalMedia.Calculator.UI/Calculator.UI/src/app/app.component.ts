import { Component } from '@angular/core';
import { Country } from './models/country';
import { CountryService } from './services/country.service';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { VatRateService } from './services/vat-rate.service';
import { VatRate } from './models/vatRate';
import { ErrorStateMatcher } from '@angular/material/core';
// import { MyErrorStateMatcher } from './models/customValidator';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements ErrorStateMatcher {
  title = 'Calculator.UI';
  countries: Country[] = [];
  vatRates: VatRate[] = [];
  calculator = new FormControl('');

  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }

  constructor(
    private countryService: CountryService, 
    private vatRateService: VatRateService){}

    vatRateSelected!: any;
    countrySelected!: number;  
    priceWithoutVAT!: any;
    valueAddedTax!: any;
    priceInclVat!: any;
    message!: string;

    validatorFormControl = new FormControl('', [Validators.required]);
    priceWithoutVatFrmControl = new FormControl('',[Validators.required]);
    priceInclVatFrmControl= new FormControl('',[Validators.required]);
    // matcher = new MyErrorStateMatcher();
    // number = new MyErrorStateMatcher();
    
  ngOnInit(): void {
    this.getCountries();
  }

  private getCountries(){
    this.countryService
    .getCountries()
    .subscribe((result: Country[]) => (this.countries = result));
  }

  onCountrySelected(selectedCountryId: any){
    this.vatRateService
    .getVatRatesOfSelectedCountry(selectedCountryId)
    .subscribe(
      data=>{
        this.vatRates = data
      })
    }

    onCalculate()
    {
      this.validatorInputs();   
      var vatPercentual = (this.vatRateSelected / 100);
      
      if(this.priceWithoutVAT != null){
        this.valueAddedTax = this.calculateVAT(this.priceWithoutVAT, vatPercentual).toFixed(2);
        this.priceInclVat = this.sumNumbers(parseFloat(this.priceWithoutVAT)
        ,parseFloat(this.valueAddedTax)).toFixed(2);
      }      

      if(this.priceInclVat != null && this.priceWithoutVAT == null){
        var vatPercentualReverse = (1 + vatPercentual);
        this.priceWithoutVAT = (this.priceInclVat / vatPercentualReverse).toFixed(2); 
        this.valueAddedTax = (this.priceInclVat - this.priceWithoutVAT).toFixed(2);               
      }     
    }

    onClear(){
      this.countrySelected = 0;
      this.vatRateSelected= 0;
      this.vatRates = [];
      this.priceWithoutVAT = null;
      this.valueAddedTax = null;
      this.priceInclVat = null;
      this.message = "";
    }

    sumNumbers(number1: number, number2: number) { 
      return number1 + number2;
    }
    substrationNumbers(number1: number, number2: number){
      return number1 - number2; 
    }
    calculateVAT(number1: number, number2: number){
      return number1 * number2; 
    }

    validatorInputs(){
      //Country
      if(this.countrySelected == null)
      {
        this.message = "Please select a country";
      }
      else
      {
        this.message = "";
      }      
      
      //Vat
      if(this.countrySelected != null)
      {
        if(this.vatRateSelected == null)
        {
          this.message = "Please select a Vat";   
        }
        else
        {
          this.message = "";  
        }
      }

      if(this.countrySelected != null)
      {
        if(this.vatRateSelected != null)
        {
          if(this.priceWithoutVAT == null || this.priceInclVat == null)
          {
            this.message = "Please enter value of Price without VAT or value of Value-added Tax";  
          }
          if(this.priceWithoutVAT != null || this.priceInclVat != null)
          {
            this.message = "";  
          }
        }
      }      
    }
}
