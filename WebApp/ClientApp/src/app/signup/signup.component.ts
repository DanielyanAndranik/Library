import { Component, OnInit, state } from '@angular/core';

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

	ngOnInit() {
		this.state1 = true;
		this.state2 = false;
		this.state3 = false;
	}
	toState1() {
		console.log("45");
		this.state1 = true;
		this.state2 = false;
	}
	toState2() {
		console.log("45");
		this.state1 = false;
		this.state2 = true;
	}
	toState3() {
		console.log("45");
		this.state3 = true;
		this.state2 = false;
	}
}
