import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule }   from '@angular/forms';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'

import { ShortenerComponent } from  './components/shortener/shortener.component';
import { UrlsHistoryComponent } from './components/urlshistory/urlshistory.component';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        ShortenerComponent,
        UrlsHistoryComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: ShortenerComponent },
            { path: 'history', component: UrlsHistoryComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModule {
}
