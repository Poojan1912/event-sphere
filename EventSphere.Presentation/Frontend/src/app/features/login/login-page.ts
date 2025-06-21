import { CommonModule } from "@angular/common";
import { Component } from "@angular/core";
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from "@angular/forms";
import { AuthService } from "../../services/http/auth/auth.service";
import { LoginRequest } from "../../services/http/auth/models/login-request.model";
import { LoginForm } from "./models/login.model";

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './login.component.html',
})
export class LoginPage {
  form = new FormGroup<LoginForm>({
    email: new FormControl<string>('', {
      nonNullable: true,
      validators: [Validators.required, Validators.email],
    }),
    password: new FormControl<string>('', { nonNullable: true, validators: [Validators.required] }),
  });

  constructor(private authService: AuthService) {}

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
