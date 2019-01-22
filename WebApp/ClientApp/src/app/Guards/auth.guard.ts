import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { AuthService } from '../services/AuthService/auth.service';

@Injectable()
export class AuthGuard implements CanActivate {

	constructor(private authService: AuthService) {

	}

	canActivate() {
		return true;
	}
}
