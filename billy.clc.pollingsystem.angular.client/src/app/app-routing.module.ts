import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { HomeComponent } from './components/home/home.component';
import { AuthGuard } from './guards/auth.guard';
import { VoteComponent } from './components/vote/vote.component';
import { ViewPollResultsComponent } from './components/view-poll-results/view-poll-results.component';
import { CreatePollsComponent } from './components/create-polls/create-polls.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'home', component: HomeComponent },
  { path: 'create', component: CreatePollsComponent },
  { path: 'results/:id', component: ViewPollResultsComponent },
  { path: 'vote/:id/:user', component: VoteComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
