/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { assert } from 'chai';
import { ShortenerComponent } from './shortener.component';
import { TestBed, async, ComponentFixture } from '@angular/core/testing';

let fixture: ComponentFixture<ShortenerComponent>;

describe('Shortener component', () => {
    beforeEach(() => {
        TestBed.configureTestingModule({ declarations: [ShortenerComponent] });
        fixture = TestBed.createComponent(ShortenerComponent);
        fixture.detectChanges();
    });

    it('Editable text field', () => {
       let textfield = document.getElementById('urlInput');
       textfield.innerText = "Some url";
       expect(textfield.innerText).toEqual("Some url");
    });

    // it('Should return an item with same url', async(() => {
       //...
    // }));
});