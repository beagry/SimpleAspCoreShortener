import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name:'concat'})
export class ConcatStringPipe implements PipeTransform {
    transform(value: string, args?: any) :string {
        return window.location.origin + "/u" + value;
    }
}