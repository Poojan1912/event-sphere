import { CommonModule } from "@angular/common";
import { Component } from "@angular/core";
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from "@angular/forms";
import { LoginRequest } from "./models/login-request.model";
import { LoginForm } from "./models/login.model";
import { LoginHttpClient } from "./login-http-client";

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './login-page.html',
})
export class LoginPage {
  form = new FormGroup<LoginForm>({
    email: new FormControl<string>('', {
      nonNullable: true,
      validators: [Validators.required, Validators.email],
    }),
    password: new FormControl<string>('', { nonNullable: true, validators: [Validators.required] }),
  });

  constructor(private authService: LoginHttpClient) {}

  onSubmit() {
    if (this.form.invalid) {
      return;
    }

    const request: LoginRequest = {
      email: this.form.value.email ?? '',
      password: this.form.value.password ?? '',
    };

    this.authService.login(request).subscribe();
  }
}
