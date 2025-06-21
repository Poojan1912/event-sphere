import { Injectable } from "@angular/core";
import { environment } from "../../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { LoginRequest } from "./models/login-request.model";

@Injectable({ providedIn: 'root' })
export class LoginHttpClient {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  login(request: LoginRequest) {
    return this.http.post(`${this.baseUrl}/auth/login`, request);
  }
}
