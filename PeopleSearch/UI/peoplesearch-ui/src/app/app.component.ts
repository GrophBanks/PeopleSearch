import { Component, } from '@angular/core';
import { HttpService } from './services/http.service';
import { Person} from './models/person';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  searchString = new FormControl('');
  searchResults: any[] = new Array();

  personForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    address: new FormControl(''),
    interests: new FormControl(''),
    imageURL: new FormControl(''),
  });

  addPersonResponseMessage: string;
  newPerson:string;
  noResults:boolean;

  constructor(private httpService: HttpService){
    
  };

  addPerson(): void{
    
    this.addPersonResponseMessage = null;

    let serializedForm = JSON.stringify(this.personForm.getRawValue());

    this.httpService.Post("Search", "Add",  serializedForm)
      .subscribe(response => this.addPersonResponse(response))
  }

  search(): void{

    this.httpService.Get("Search", undefined, this.searchString.value)
      .subscribe(response => this.searchResponse(response))
  }

  searchResponse(response: any): void{
     this.searchResults = JSON.parse(response);

     if(this.searchResults.length == 0 || this.searchResults == null){
       this.noResults = true;
     }
  }

  addPersonResponse(response: any): void {

    let personObj = JSON.parse(response);
    if(personObj.PersonId){
      this.addPersonResponseMessage = "New person successfully added!"
    }
    else{
      this.addPersonResponseMessage = "Error creating new person."
    }
  }
}
