import { Component, OnInit } from '@angular/core';
import { Book, BookService } from '../services/BookService/book.service';

@Component({
	selector: 'app-edit-book',
	templateUrl: './edit-book.component.html',
	styleUrls: ['./edit-book.component.css']
})
export class EditBookComponent implements OnInit {
	mode: string;
	book: Book;
	constructor() {
		this.book = BookService.editableBook;
		this.mode = BookService.mode;
	}

	ngOnInit() {
		var selects = M.FormSelect.init(document.querySelectorAll('select'), {});
	}

}
