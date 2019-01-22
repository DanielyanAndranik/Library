import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from '../services/AuthService/auth.service';

@Component({
	selector: 'app-login',
	providers: [AuthService],
	templateUrl: './login.component.html',
	styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

	loginForm: FormGroup;

	constructor(private auth: AuthService) { }

	ngOnInit() {
		this.loginForm = new FormGroup({
			username: new FormControl('', Validators.required),
			password: new FormControl('', Validators.required)
		});
	}

	canLogin() {
		return this.loginForm.controls.username.valid && this.loginForm.controls.password.valid;
	}

	login() {

		var username = this.loginForm.value.username;
		var password = this.loginForm.value.password;
		this.auth.login(username, password).subscribe(
			res => { localStorage.setItem('token', res.toString()); },
			err => { }
		);
	}
}
