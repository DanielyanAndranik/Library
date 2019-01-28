import { Component, OnInit } from '@angular/core';
import { BookService, Book, BooksFilter } from '../services/BookService/book.service';
import { Router } from '@angular/router';
import { state } from '@angular/core/src/animation/dsl';
import { Mode } from '../edit-book/edit-book.component';
import { Observable } from 'rxjs/Observable';

declare var init: Function;
declare function getSelectedBookId(): any;

@Component({
	selector: 'app-books-board',
	templateUrl: './books-board.component.html',
	styleUrls: ['./books-board.component.css']
})
export class BooksBoardComponent implements OnInit {

	books: Observable<Book>;

	filter: BooksFilter;

	selectedBook: Book;

	public loading: boolean;

	constructor(private service: BookService, private router: Router) {
		this.filter = new BooksFilter();
		this.loading = false;
	}

	ngOnInit() {
		init();
	}

	loadBooks() {
		this.loading = true;
		console.log(this.filter);
		this.service.getAll(this.filter).subscribe(
			data => { this.books = data; this.loading = false; },
			error => { console.log(error); this.loading = false;}
		);
	}

	editBook() {
		this.service.editableBook = this.selectedBook;
		this.service.mode = Mode.Edit;
		this.router.navigateByUrl(this.router.url + '/edit');
	}

	deleteBook() {
		this.service.deleteBook(this.selectedBook)
			.subscribe(
			data => {
					console.log(data);
				},
				err => {
					console.log(err);
				});
	}

	addBook() {
		this.service.editableBook = null;
		this.service.mode = Mode.Add;
		this.router.navigateByUrl(this.router.url + '/new');
	}

	select(book: Book) {
		this.selectedBook = book;
	}

}

