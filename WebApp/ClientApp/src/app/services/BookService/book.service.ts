import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';


@Injectable()
export class BookService {

	constructor(private http: HttpClient) { }

	static mode: string;
	static editableBook: Book;

	getAll(filter: BooksFilter) {
		let params = new HttpParams();
		if (filter.title !== undefined) params = params.append('title', filter.title);
		if (filter.author !== undefined) params = params.append('author', filter.author);
		if (filter.publisher !== undefined) params = params.append('publisher', filter.publisher);
		if (filter.published !== undefined) params = params.append('published', filter.published);
		if (filter.language !== undefined ) params = params.append('language', filter.language.join(","));
		console.log(params);
		return this.http.get('api/books', { params: params });
	}

}

export class Book {
	id: number;
	title: string;
	author: string;
	publisher: string;
	published: number;
	type: string;
	count: number;
	language: string;
}

export class BooksFilter {
	public title: string;
	public author: string;
	public publisher: string;
	public published: string;
	public language: Array<string>;
}
