import { Component, OnInit } from '@angular/core';

declare var init: Function;

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

	constructor() { }

	showSpinner: boolean = true;

	ngOnInit() {
		init();
		this.get();
	}

	get() {
		setTimeout('', 5000);
		this.showSpinner = false;
	}
}
