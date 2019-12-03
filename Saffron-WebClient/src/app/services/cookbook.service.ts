import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cookbook, Section } from '../cookbook/cookbook';

@Injectable({
  providedIn: 'root'
})
export class CookbookService {
  private cookbooksUrl = 'http://localhost:60222/api/cookbooks'; // TO DO: move localhost to interceptors..
  constructor(
    private http: HttpClient 
  ) { }

  getCookbooks(): Observable<Cookbook[]>{
    return this.http.get<Cookbook[]>(this.cookbooksUrl);
  }

  getCookbook(id: string): Observable<Cookbook>{
    const url = `${this.cookbooksUrl}/${id}`;
    return this.http.get<Cookbook>(url);
  }

  getCookbookSections(cookbookId: string): Observable<Section[]>{
    const url = `${this.cookbooksUrl}/${cookbookId}/sections`;
    return this.http.get<Section[]>(url);
  }
}
