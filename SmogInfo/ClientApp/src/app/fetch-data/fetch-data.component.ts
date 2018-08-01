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
  public reversedSmog: ISmog[];

  public city: ICity[];
  public station:IStation[];

  public averagePm10:number;
  public averagePm25:number;


  public CalculateAveragePm10(list: ISmog[]):number
  {
     let sum=0;
    for (let index = 0; index < 24; index++)
     {
      sum+=list[index].pM10Concentration;
    }

    return sum/24;
  }
  public CalculateAveragePm25(list: ISmog[]):number
  {
     let sum=0;
    for (let index = 0; index < 24; index++)
     {
      sum+=list[index].pM25Concentration;
    }

    return sum/24;
  }

  

  
  constructor(private globals:GlobalsService) 
  {
    this.smog = globals.smog;
    this.city = globals.city;
    this.station = globals.station;
    
    this.reversedSmog = this.smog.map(a => Object.assign({}, a));
    this.reversedSmog.reverse();
    this.averagePm10 = this.CalculateAveragePm10(this.reversedSmog);
    this.averagePm25 = this.CalculateAveragePm25(this.reversedSmog);

  }

}
