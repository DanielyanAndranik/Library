import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Mode } from '../../edit-book/edit-book.component';


@Injectable()
export class BookService {

	constructor(private http: HttpClient) { }

	private _mode: Mode;
	private _editableBook: Book;

	get mode(): Mode {
		return this._mode;
	}

	set mode(val) {
		this._mode = val;
	}

	get editableBook(): Book {
		return this._editableBook;
	}

	set editableBook(val) {
		this._editableBook = val;
	}

	getAll(filter: BooksFilter) {
		let params = new HttpParams();
		if (filter.title !== undefined) params = params.append('title', filter.title);
		if (filter.author !== undefined) params = params.append('author', filter.author);
		if (filter.publisher !== undefined) params = params.append('publisher', filter.publisher);
		if (filter.published !== undefined) params = params.append('published', filter.published);
		if (filter.language !== undefined) params = params.append('language', filter.language.join(","));
		console.log(params);
		return this.http.get<Observable<Book>>('api/books', { params: params });
	}

	updateBook(book: Book) {
		console.log(book);
		return this.http.put<Book>('/api/books', book);
	}

	addBook(book: Book) {
		console.log(book);
		return this.http.post('/api/books', book, { headers: new HttpHeaders().set('Content-Type', 'application/json') });
	}

	deleteBook(book: Book) {
		book.totalCount = 0;
		book.availableCount = 0;
		return this.http.put<Book>('/api/books/', book );
	}
}

export class Book {
	id: number;
	title: string;
	author: string;
	publisher: string;
	published: number;
	type: string;
	totalCount: number;
	availableCount: number;
	language: string;
}

export class BooksFilter {
	public title: string;
	public author: string;
	public publisher: string;
	public published: string;
	public language: Array<string>;
}
