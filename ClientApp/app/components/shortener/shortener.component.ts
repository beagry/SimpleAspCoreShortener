import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Component({
    selector: 'shortener',
    templateUrl: './shortener.component.html',
    styleUrls: ['./shortener.component.css']
})

export class ShortenerComponent {
    public url: string = "";
    public answer: string = "";

    constructor(private http: Http) {
    }

    public shortenUrl()
    {
        if (!this.url)
        {
            return;
        }

        const body = JSON.stringify({ url : this.url });
        let headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        this.http.post('/api/shorten', body, { headers: headers }).subscribe(r =>{
            this.answer = r.text();
        });
    }
}