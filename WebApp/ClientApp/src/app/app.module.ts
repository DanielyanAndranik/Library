import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { LoginComponent } from './login/login.component';
import { MainComponent } from './main/main.component';
import { FooterComponent } from './footer/footer.component';
import { SignupComponent } from './signup/signup.component';
import { LibrarianDashboardComponent } from './librarian-dashboard/librarian-dashboard.component';
import { BooksBoardComponent } from './books-board/books-board.component';
import { UserOrdersComponent } from './user-orders/user-orders.component';
import { OrdersBoardComponent } from './orders-board/orders-board.component';
import { EditBookComponent } from './edit-book/edit-book.component';
import { BooksComponent } from './books/books.component';

@NgModule({
	declarations: [
		AppComponent,
		HeaderComponent,
		LoginComponent,
		MainComponent,
		FooterComponent,
		SignupComponent,
		LibrarianDashboardComponent,
		BooksBoardComponent,
		UserOrdersComponent,
		OrdersBoardComponent,
		EditBookComponent,
		BooksComponent
	],
	imports: [
		BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
		HttpClientModule,
		FormsModule,
		ReactiveFormsModule,
		RouterModule.forRoot([
			{ path: '', component: MainComponent, pathMatch: 'full' },
			{ path: 'books', component: BooksComponent, pathMatch: 'full' },
			{ path: 'login', component: LoginComponent, pathMatch: 'full' },
			{ path: 'signup', component: SignupComponent, pathMatch: 'full' },
			{ path: 'lib_dashboard', component: LibrarianDashboardComponent, pathMatch: 'full' },
			{ path: 'lib_dashboard', component: LibrarianDashboardComponent, pathMatch: 'full' },
			{ path: 'my_orders', component: UserOrdersComponent, pathMatch: 'full' },
			{ path: 'edit_book', component: EditBookComponent, pathMatch: 'full' }
		])
	],
	providers: [],
	bootstrap: [AppComponent]
})
export class AppModule { }
