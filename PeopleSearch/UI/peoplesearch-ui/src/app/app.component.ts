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

  personForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    address: new FormControl(''),
    interests: new FormControl(''),
  });

  addPersonResponseMessage: string;
  newPerson:string;

  constructor(private httpService: HttpService){
    
  };

  addPerson(): void{
    
    this.addPersonResponseMessage = '';

    let serializedForm = JSON.stringify(this.personForm.getRawValue());

    this.httpService.Post("Search", "Add",  serializedForm)
      .subscribe(response => this.searchResponse(response))
  }

  search(): void{

    this.httpService.Get("Search", undefined, this.searchString.value)
      .subscribe(response => this.searchResponse(response))
  }

  searchResponse(searchResponse: any): void{
     console.log(JSON.stringify(searchResponse));
  }

  addPersonResponse(response: any): void {
    if(response.PersonId){
      this.addPersonResponseMessage = "Person Added Successfully!"
      this.newPerson = response;
    }

    console.log(JSON.stringify(response));
  }
}
