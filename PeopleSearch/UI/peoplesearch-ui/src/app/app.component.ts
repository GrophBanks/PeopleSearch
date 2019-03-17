import { Component, OnInit} from '@angular/core';
import { HttpService } from './services/http.service';
import { Person} from './models/person';
import { FormControl, FormGroup } from '@angular/forms';
import { constants } from './constants'
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  searchString = new FormControl('');
  searchResults: any[] = new Array();

  personForm = new FormGroup({
    firstName: new FormControl(),
    lastName: new FormControl(),
    address: new FormControl(),
    interests: new FormControl(),
    imageURL: new FormControl(),
    delay: new FormControl()
  });

  addPersonResponseMessage: string;
  validationMessage: string;
  searchValidationMessage: string;
  newPerson:string;
  saving:boolean;

  constructor(private httpService: HttpService){
    
  };

  addPerson(): void{
    
    this.addPersonResponseMessage = null;
    this. validationMessage = null;

    if(this.validateInputs()){

      this.personForm.disable();
      this.saving = true;

      let serializedForm = JSON.stringify(this.personForm.getRawValue());

      this.httpService.Post("Search", "Add",  serializedForm)
        .subscribe(response => this.addPersonResponse(response));
    }
  }

  clearForm(): void {
    this.personForm.reset();
  }

  search(): void{

    if(this.validateSearchInput()){
      this.httpService.Get("Search", undefined, this.searchString.value)
      .subscribe(response => this.searchResponse(response));
    }
  }

  validateSearchInput(): boolean {
    var isValid = true;

    if(!this.searchString.value){
      this.searchValidationMessage = constants.InvalidSearch;
      isValid = false;
    }

    return isValid;
  }

  clearSearch(): void{
    this.searchString.reset();
    this.searchResults = [];
  }

  searchResponse(response: any): void{
     
    this.clearSearch();

    this.searchResults = JSON.parse(response);

     if(this.searchResults.length == 0 || this.searchResults == null){
       this.searchValidationMessage = constants.NoResultsMessage;
     }
  }

  addPersonResponse(response: any): void {

    let personObj = JSON.parse(response);
    if(personObj.PersonId){
      this.clearForm();
      this.addPersonResponseMessage = constants.AddUserSuccess;
    }
    else{
      this.addPersonResponseMessage = constants.AddUserError;
    }

    this.saving = false;
    this.personForm.enable();

  }

  validateInputs(): boolean{

    var isValid = true;

    if(!this.personForm.controls['firstName'].value || !this.personForm.controls['lastName'].value ){
      this.validationMessage = constants.InputValidationMessage;
      isValid = false;
    }

    return isValid;
  }
}
