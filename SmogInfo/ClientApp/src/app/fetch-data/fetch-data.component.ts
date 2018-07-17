import { Component, Inject,OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import {ISmog} from '../shared/ISmog';
import { GlobalsService } from '../globals.service';

 
@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent  {
  
  public smog: ISmog[];

  
  constructor(private globals:GlobalsService) {this.smog = globals.smog;
    }

}
