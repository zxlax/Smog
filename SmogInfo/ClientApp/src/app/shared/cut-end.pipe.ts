import { Pipe, PipeTransform } from '@angular/core';
import { notImplemented } from '@angular/core/src/render3/util';

@Pipe({
    name: 'cutEnd'
})
export class CutEndPipe implements PipeTransform {

    

    transform(value: string, characters: number): string 
    {
        return value.slice(0,(value.length-characters));
        
    }
}
