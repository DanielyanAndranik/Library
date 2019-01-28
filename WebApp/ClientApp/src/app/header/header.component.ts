import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/AuthService/auth.service';

@Component({
	selector: 'app-header',
	templateUrl: './header.component.html',
	styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

	constructor(private authService: AuthService) { }

	ngOnInit() {
	}

	get isLoggedIn(): boolean {
		return this.authService.isLoggedIn();
	}

	get isLibrarian(): boolean {
		return this.authService.decode().role === 'Librarian' && this.isLoggedIn;
	}

	logout() {
		this.authService.logout();
	}
}
