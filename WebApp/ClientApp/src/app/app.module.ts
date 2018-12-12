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
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    MainComponent,
    FooterComponent,
    SignupComponent,
    LibrarianDashboardComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
	  RouterModule.forRoot([
		  { path: '', component: MainComponent, pathMatch: 'full' },
		  { path: 'login', component: LoginComponent, pathMatch: 'full' },
		  { path: 'signup', component: SignupComponent, pathMatch: 'full' },
		  { path: 'lib_dashboard', component: LibrarianDashboardComponent, pathMatch: 'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
