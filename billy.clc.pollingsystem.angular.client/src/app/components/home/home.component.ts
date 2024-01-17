import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { PollService } from 'src/app/services/poll.service';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  polls: any[] = [];
  user: any;
  constructor(private authService: AuthService, private poll: PollService) {}

  ngOnInit(): void {
    this.authService.tokenStorage;
    this.getPolls();
  }
  getPolls() {
    this.poll.GetPolls().subscribe({
      next: (res) => {
        console.log(res);
        this.polls = res;
      },
      error: (err) => {
        alert('Error...');
      },
    });
  }
  createPolls() {}
  viewResults() {}
  logOut() {
    this.authService.signOut();
  }
}
