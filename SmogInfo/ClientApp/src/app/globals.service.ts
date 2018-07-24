import { Injectable, Inject } from '@angular/core';
import { ISmog } from './shared/ISmog';
import { HttpClient } from '@angular/common/http';
import { ICity } from './shared/ICity';
import { IStation } from './shared/IStation';

@Injectable()
export class GlobalsService {

  public smog: ISmog[];
  public city: ICity[];
  public station: IStation[];


  urlCity:string='/cities/';
  
  urlStation:string ='1/smogstation/';

  urlLevles:string ='1/level';

  
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ISmog[]>(baseUrl +'/api'+ this.urlCity+this.urlStation+this.urlLevles).subscribe(result => {
      console.log(result);
      this.smog = result;
    }, error => console.error(error));

    http.get<ICity[]>(baseUrl +'/api'+ this.urlCity).subscribe(result => {
      console.log(result);
      this.city = result;
    }, error => console.error(error));

    http.get<IStation[]>(baseUrl +'/api'+ this.urlCity+this.urlStation).subscribe(result => {
      console.log(result);
      this.station = result;
    }, error => console.error(error));

   



}

}
