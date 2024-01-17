import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import ValidateForm from 'src/app/helpers/form.validation';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
})
export class SignupComponent implements OnInit {
  passType: string = 'password';
  passIcon: string = 'fa-eye-slash';
  passIsText: boolean = false;
  signUpForm!: FormGroup;
  constructor(
    private fb: FormBuilder,
    private auth: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.signUpForm = this.fb.group({
      firstname: ['', Validators.required],
      lastname: ['', Validators.required],
      email: ['', Validators.required],
      username: ['', Validators.required],
      password: ['', Validators.required],
      conPassword: ['', Validators.required],
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
    if (this.signUpForm.valid) {
      this.auth.signUp(this.signUpForm.value).subscribe({
        next: (res) => {
          alert('successful...');
          this.signUpForm.reset();
          this.router.navigate(['login']);
        },
        error: (err) => {
          console.log(err);
          alert('error');
        },
      });
    } else {
      ValidateForm.ValidateAllFormsFields(this.signUpForm);
    }
  }
}
