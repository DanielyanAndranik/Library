import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { LoginComponent } from './login/login.component';
import { MainComponent } from './main/main.component';
import { FooterComponent } from './footer/footer.component';
import { SignupComponent } from './signup/signup.component';
import { LibrarianDashboardComponent } from './librarian-dashboard/librarian-dashboard.component';
import { GridComponent } from './grid/grid.component';
import { BooksBoardComponent } from './books-board/books-board.component';
import { UserOrdersComponent } from './user-orders/user-orders.component';

@NgModule({
	declarations: [
		AppComponent,
		HeaderComponent,
		LoginComponent,
		MainComponent,
		FooterComponent,
		SignupComponent,
		LibrarianDashboardComponent,
		GridComponent,
		BooksBoardComponent,
		UserOrdersComponent
	],
	imports: [
		BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
		HttpClientModule,
		FormsModule,
		RouterModule.forRoot([
			{ path: '', component: MainComponent, pathMatch: 'full' },
			{ path: 'login', component: LoginComponent, pathMatch: 'full' },
			{ path: 'signup', component: SignupComponent, pathMatch: 'full' },
			{ path: 'lib_dashboard', component: LibrarianDashboardComponent, pathMatch: 'full' },
			{ path: 'lib_dashboard', component: LibrarianDashboardComponent, pathMatch: 'full' },
			{ path: 'my_orders', component: UserOrdersComponent, pathMatch: 'full' }
		])
	],
	providers: [],
	bootstrap: [AppComponent]
})
export class AppModule { }
