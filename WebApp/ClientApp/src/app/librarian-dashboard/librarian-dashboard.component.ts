import { Component, OnInit } from '@angular/core';
declare var init: Function;

@Component({
  selector: 'app-librarian-dashboard',
  templateUrl: './librarian-dashboard.component.html',
	styleUrls: ['./librarian-dashboard.component.css']
})
export class LibrarianDashboardComponent implements OnInit {

  constructor() { }

	ngOnInit() {
		init();
  }

}
