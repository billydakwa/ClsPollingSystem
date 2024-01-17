import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PollService {
  private baseUrl: string = 'https://localhost:7075/api/';
  constructor(private http: HttpClient) {}

  createPoll(poll: any) {
    return this.http.post<any>(`${this.baseUrl}Poll/create`, poll);
  }

  GetPolls() {
    return this.http.get<any>(`${this.baseUrl}Poll/polls`);
  }
}
