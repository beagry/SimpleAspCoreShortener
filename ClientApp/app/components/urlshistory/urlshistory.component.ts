import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component ({
    selector: 'shortener',
    templateUrl: './urlshistory.component.html'
})

export class UrlsHistoryComponent {
    public urls: UrlHistoryItem[];

    constructor() { //http: Http) {
        // http.get('/api/History').subscribe(r =>{
            // this.urls = r.json() as UrlHistoryItem[];
        // })
    }
}

interface UrlHistoryItem {
    id: number
    url : string
    shortUrl: string
    createDate: Date
}