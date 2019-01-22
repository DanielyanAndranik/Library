import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable()
export class AuthService {

	constructor(private http: HttpClient, private router: Router) { }

	login(username: string, password: string) {
		return this.http.post('api/login', { username, password });
	}

	register() {

	}

	decode() {
		return { role: 'Libraria' };
	}

	logout() {
		localStorage.removeItem('token');
		this.router.navigateByUrl('/');
	}

	isLoggedIn() {
		return !!localStorage.getItem('token');
	}
}
