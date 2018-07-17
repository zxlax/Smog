import { Injectable, Inject } from '@angular/core';
import { ISmog } from './shared/ISmog';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class GlobalsService {

  public smog: ISmog[];

  
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ISmog[]>(baseUrl + 'api/cities/1/smogstation/1/level').subscribe(result => {
      console.log(result);
      this.smog = result;
    }, error => console.error(error));
}

}
