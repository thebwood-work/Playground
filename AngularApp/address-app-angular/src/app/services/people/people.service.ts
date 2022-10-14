import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Person } from 'src/app/models/Person';


@Injectable({
  providedIn: 'root'
})
export class PeopleService {
  private url = 'People';
  constructor(private http: HttpClient) { }


  public getPeople(): Observable<Person[]> {
    return this.http.get<Person[]>(`${environment.apiUrl}/${this.url}`);
  }

  public updatePerson(person: Person): Observable<Person[]> {
    return this.http.put<Person[]>(
      `${environment.apiUrl}/${this.url}`,
      person
    );
  }

  public createPerson(person: Person): Observable<Person[]> {
    return this.http.post<Person[]>(
      `${environment.apiUrl}/${this.url}`,
      person
    );
  }

  public deletePerson(person: Person): Observable<Person[]> {
    return this.http.delete<Person[]>(
      `${environment.apiUrl}/${this.url}/${person.id}`
    );
  }
}
