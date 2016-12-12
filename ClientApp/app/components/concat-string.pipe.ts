import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name:'concat'})
export class ConcatStringPipe implements PipeTransform {
    transform(value: string, args?: any) :string {
        return "http://shrt1.azurewebsites.net" + "/u" + value; //  "http://localhost:5000" + "/u" + value; 
    }
}