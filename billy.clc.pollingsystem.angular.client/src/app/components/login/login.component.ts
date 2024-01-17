import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import ValidateForm from 'src/app/helpers/form.validation';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  passType: string = 'password';
  passIcon: string = 'fa-eye-slash';
  passIsText: boolean = false;
  loginForm!: FormGroup;
  user: any;
  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  hideShowPassword() {
    this.passIsText = !this.passIsText;
    this.passIsText
      ? (this.passIcon = 'fa-eye')
      : (this.passIcon = 'fa-eye-slash');
    this.passIsText ? (this.passType = 'text') : (this.passType = 'password');
  }

  onSubmit() {
    if (this.loginForm.valid) {
      this.authService.login(this.loginForm.value).subscribe({
        next: (res) => {
          this.user = res.userId;
          this.authService.tokenStorage(res.token);
          this.router.navigate(['home']);
        },
        error: (err) => {
          alert(err);
        },
      });
    } else {
      ValidateForm.ValidateAllFormsFields(this.loginForm);
    }
  }
}
