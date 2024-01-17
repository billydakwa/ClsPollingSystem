import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './components/home/home.component';
import { AuthService } from './services/auth.service';
import { CreatePollsComponent } from './components/create-polls/create-polls.component';
import { ViewPollResultsComponent } from './components/view-poll-results/view-poll-results.component';
import { VoteComponent } from './components/vote/vote.component';

@NgModule({
  declarations: [AppComponent, LoginComponent, SignupComponent, HomeComponent, CreatePollsComponent, ViewPollResultsComponent, VoteComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
  ],
  providers: [AuthService],
  bootstrap: [AppComponent],
})
export class AppModule {}
