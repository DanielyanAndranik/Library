import { Component, OnInit } from '@angular/core';
import { Book, BookService } from '../services/BookService/book.service';
declare var init: Function;
@Component({
	selector: 'app-edit-book',
	templateUrl: './edit-book.component.html',
	styleUrls: ['./edit-book.component.css']
})
export class EditBookComponent implements OnInit {
	mode: Mode;
	book: Book;
	constructor(private service: BookService) {
		this.mode = this.service.mode;
		this.book = (this.mode === Mode.Edit) ? this.service.editableBook : new Book();
	}

	ngOnInit() {
		init();
	}

	submit() {
		if (this.mode === Mode.Edit) {
			this.service.updateBook(this.book)
				.subscribe(
					data => {
						console.log(data);
					},
					err => {
						console.log(err);
					});
		}
		else if (this.mode === Mode.Add) {
			this.service.addBook(this.book)
				.subscribe(
					data => {
						console.log(data);
					},
					err => {
						console.log(err);
					});
		}
	}

}

export enum Mode {
	Edit,
	Add
}
