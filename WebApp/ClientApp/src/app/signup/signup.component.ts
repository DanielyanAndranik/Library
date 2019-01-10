import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
	selector: 'app-signup',
	templateUrl: './signup.component.html',
	styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
	state1: boolean;
	state2: boolean;
	state3: boolean;
	constructor() { }

	registerForm: FormGroup;

	ngOnInit() {
		this.registerForm = new FormGroup({
			name: new FormGroup({
				firstName: new FormControl(),
				middleName: new FormControl(),
				lastName: new FormControl(),
			}),
			birthDate: new FormControl(),
			phone: new FormControl(),
			email: new FormControl(),
			username: new FormControl(),
			password: new FormControl(),
			repeatPassword: new FormControl()
		});
		this.state1 = true;
		this.state2 = false;
		this.state3 = false;
	}
	backTo1() {
		this.state1 = true;
		this.state2 = false;
	}
	nextTo2() {
		this.state1 = false;
		this.state2 = true;
	}
	backTo2() {
		this.state2 = true;
		this.state3 = false;
	}
	nextTo3() {
		this.state3 = true;
		this.state2 = false;
	}
}
