import { Injectable } from '@angular/core';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders, HttpParams, HttpErrorResponse } from '@angular/common/http';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

const url = './api/';

@Injectable({
  providedIn: 'root'
})

export class HttpService {

  constructor(private http: HttpClient) { }

  public Get(Controller: string, Action: string, RouteParam: string): any {

    var route = url + Controller;

    if(Action){
      route = route +  "/"  + Action;
    };  

    if(RouteParam){
      route = route + "/" + RouteParam;
    };

    return this.http.get<any>(route, httpOptions);            
  }

  public Post(Controller: string, Action: string, data: any): any {

      var serializedData = JSON.stringify(data) 

      var route = url + Controller;

      if(Action){
          route = route +  "/"  + Action;
      };

      return this.http.post<any>(route, data, httpOptions);
  }

  private ErrorHandler(error: HttpErrorResponse): void{

  }
}
