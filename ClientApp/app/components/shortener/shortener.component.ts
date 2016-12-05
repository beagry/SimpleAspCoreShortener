import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { UrlHistoryItem } from '../IUrlHistoryItem';

@Component({
    selector: 'shortener',
    templateUrl: './shortener.component.html',
    styleUrls: ['./shortener.component.css']
})

export class ShortenerComponent {
    public url: string = "";
    public answer: UrlHistoryItem = null;
    public requestInProgress: boolean = false;
    public errorMessage : string  = "";

    constructor(private http: Http) {
    }

    public shortenUrl()
    {
        if (!this.url)
        {
            return;
        }

        this.errorMessage = "";
        this.answer = null;
        this.requestInProgress = true;
        const body = JSON.stringify({ url : this.url });
        let headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        this.http.post('/api/shorten', body, { headers: headers })
        .subscribe(r => {
                this.answer = r.json() as UrlHistoryItem;
            }, 
            err => {
                console.log(err)
                //TODO handle different state codes
                this.errorMessage = "Что-то пошло не так :(";
            }, 
            () => {
                console.log("Completed")
                this.requestInProgress = false;
            });
    }
}