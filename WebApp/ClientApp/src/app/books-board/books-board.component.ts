import { Component, OnInit } from '@angular/core';
import { BookService, Book, BooksFilter } from '../services/BookService/book.service';

declare var init: Function;

@Component({
	selector: 'app-books-board',
	providers: [BookService],
	templateUrl: './books-board.component.html',
	styleUrls: ['./books-board.component.css']
})
export class BooksBoardComponent implements OnInit {

	public books;
	filter: BooksFilter;

	constructor(private service: BookService) {
		this.filter = new BooksFilter();
	}

	ngOnInit() {
		init();
	}

	getBooks() {
		console.log(this.filter);
		this.service.getAll(this.filter).subscribe(
			data => { this.books = data; },
			error => console.log(error)
		);
	}

	newBook() {
		BookService.mode = 'Ավելացնել նոր գիրք';
		BookService.editableBook = new Book();
	}
	editBook(book: Book) {
		BookService.mode = 'Խմբագրել գիրքը';
		BookService.editableBook = book;
	}
}

