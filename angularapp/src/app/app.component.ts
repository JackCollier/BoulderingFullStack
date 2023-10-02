import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { DataService } from "./data.service";
import { Boulder } from "./Boulder";
import { Subscription } from "rxjs";

@Component({
    selector: "app-root",
    templateUrl: "./app.component.html",
    styleUrls: ["./app.component.css"],
})
export class AppComponent {
    routes: Boulder[] = [];
    private newRouteSubscription!: Subscription;

    constructor(private dataService: DataService) {}

    ngOnInit(): void {
        this.GetRoutes();

        this.newRouteSubscription = this.dataService
            .getNewRouteObservable()
            .subscribe(() => this.GetRoutes());
    }

    GetRoutes(): void {
        this.dataService.getAllRoutes().subscribe((response) => {
            this.routes = response;
        });
    }

  DeleteRoutes(id: number): void {
        this.dataService.deleteRoute(id).subscribe(() => {});
  }

    title = "angularapp";
}
