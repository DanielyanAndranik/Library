import { Component, OnInit } from '@angular/core';
import { BookService, Book } from '../services/BookService/book.service';

@Component({
	selector: 'app-books-board',
	providers: [BookService],
	templateUrl: './books-board.component.html',
	styleUrls: ['./books-board.component.css']
})
export class BooksBoardComponent implements OnInit {

	public books;
	filter: Filter;

	constructor(private service: BookService) {
		this.filter = new Filter();
	}

	ngOnInit() {
		var tab = M.Tabs.init(document.querySelector('.tabs'), {});
		var collapsables = M.Collapsible.init(document.querySelectorAll('.collapsible'), {});
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

export class Filter {
	public title: string;
	public author: string;
	public publisher: string;
	public published: string;
	public language: Array<string>;
}
