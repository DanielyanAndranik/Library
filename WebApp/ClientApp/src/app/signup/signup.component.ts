import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';

declare var init: Function;

@Component({
	selector: 'app-signup',
	templateUrl: './signup.component.html',
	styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
	state1: boolean;
	state2: boolean;
	state3: boolean;
	constructor() {}

	registerForm: FormGroup;

	ngOnInit() {
		init();
		this.registerForm = new FormGroup({
			name: new FormGroup({
				firstName: new FormControl('', Validators.required),
				middleName: new FormControl('', Validators.required),
				lastName: new FormControl('', Validators.required),
			}),
			birthDate: new FormControl(),
			phone: new FormControl(),
			email: new FormControl('', [
				Validators.required,
				Validators.pattern(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/)
			]),
			username: new FormControl(),
			password: new FormControl('', [
				Validators.required,
				Validators.minLength(8)
			]),
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

	isFirstStepValid() {
		return this.registerForm.controls.name.valid;
	}

	isSecondStepValid() {
		return this.registerForm.controls.birthDate.valid && this.registerForm.controls.phone.valid && this.registerForm.controls.email.valid;
	}
}
