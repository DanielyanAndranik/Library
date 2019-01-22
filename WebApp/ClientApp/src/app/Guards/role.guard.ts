import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { AuthService } from '../services/AuthService/auth.service';

@Injectable()
export class RoleGuard implements CanActivate {

	constructor(private authService: AuthService, private router: Router) {

	}

	canActivate(
		next: ActivatedRouteSnapshot,
		state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

		let user = this.authService.decode();

		if (next.data.role === user.role) {
			return true;
		}
		this.router.navigateByUrl('/login');
		return false;
	}
}
