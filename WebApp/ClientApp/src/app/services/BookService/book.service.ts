import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Filter } from '../../books-board/books-board.component';

@Injectable()
export class BookService {

	constructor(private http: HttpClient) { }

	getAll(filter: Filter) {
		let params = new HttpParams();
		if (filter.title !== undefined) params = params.append('title', filter.title);
		if (filter.author !== undefined) params = params.append('author', filter.author);
		if (filter.publisher !== undefined) params = params.append('publisher', filter.publisher);
		if (filter.published !== undefined) params = params.append('published', filter.published);
		if (filter.language !== undefined ) params = params.append('language', filter.language.join(","));
		console.log(params);
		return this.http.get('../../../assets/data/books.json', { params: params });
	}

}

export class Book {

}
