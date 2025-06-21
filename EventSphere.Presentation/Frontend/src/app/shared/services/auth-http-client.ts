import { Injectable } from "@angular/core";
import { environment } from "../../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { LoginRequest } from "../models/request/login-request.model";
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class AuthHttpClient {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  login(request: LoginRequest): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/auth/login`, request);
  }
}
