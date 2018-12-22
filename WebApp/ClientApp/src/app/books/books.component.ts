import { Component, OnInit } from '@angular/core';
import { BookService, BooksFilter, Book } from '../services/BookService/book.service';
import { Observable } from 'rxjs/Observable';

declare var init: Function;

@Component({
	selector: 'app-books',
	providers: [BookService],
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

	books: Object;
	constructor(private service: BookService) { }

	showSpinner: boolean = true;

	ngOnInit() {
		init();
		this.get();
	}

	get() {
		this.service.getAll(new BooksFilter()).subscribe(
			data => { this.books = data; this.showSpinner = false; },
			err => console.log(err)
		);
	}
}
