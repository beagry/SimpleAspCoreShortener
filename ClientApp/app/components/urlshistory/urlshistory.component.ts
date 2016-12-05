import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { UrlHistoryItem } from '../IUrlHistoryItem';

@Component ({
    selector: 'shortener',
    templateUrl: './urlshistory.component.html'
})

export class UrlsHistoryComponent implements OnInit {
    public urls: UrlHistoryItem[];

    constructor(private http: Http) {
    }

    ngOnInit(){
        this.http.get('/api/history').subscribe(r =>{
            this.urls = r.json() as UrlHistoryItem[];
        })
    }
}