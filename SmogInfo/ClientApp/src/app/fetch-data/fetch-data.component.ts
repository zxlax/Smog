import { Component, Inject,OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import {ISmog} from '../shared/ISmog';
import { GlobalsService } from '../globals.service';
import { ICity } from '../shared/ICity';
import { IStation } from '../shared/IStation';

 
@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent  {
  
  public smog: ISmog[];
  public city: ICity[];
  public station:IStation[];

  
  constructor(private globals:GlobalsService) 
  {
    this.smog = globals.smog;
    this.city = globals.city;
    this.station = globals.station;
  }

}
