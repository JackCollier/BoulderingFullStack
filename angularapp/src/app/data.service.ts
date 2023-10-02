import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable, Subject } from "rxjs";
import { Boulder } from "./Boulder";
import { tap } from "rxjs/operators";

@Injectable({
    providedIn: "root",
})
export class DataService {
    readonly APIUrl = "https://localhost:7100/api/Boulder";
    private newRouteSubject = new Subject<void>();

    constructor(private http: HttpClient) {}

    getAllRoutes(): Observable<Boulder[]> {
        return this.http.get<Boulder[]>(this.APIUrl);
    }

    postRoute(boulder: Boulder): Observable<Boulder> {
        return this.http.post<Boulder>(this.APIUrl, boulder).pipe(
            tap(() => {
                this.newRouteSubject.next();
            })
        );
    }

  deleteRoute(id: number): Observable<void> {
        return this.http.delete<void>(`${this.APIUrl}?id=${id}`).pipe(
            tap(() => {
                this.newRouteSubject.next();
            })
        );
    }

    getNewRouteObservable(): Observable<void> {
        return this.newRouteSubject.asObservable();
    }
}
