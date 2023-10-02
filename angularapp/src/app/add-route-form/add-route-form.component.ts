import { Component } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { DataService } from "../data.service";
import { Boulder } from "../Boulder";

@Component({
    selector: "app-add-route-form",
    templateUrl: "./add-route-form.component.html",
    styleUrls: ["./add-route-form.component.css"],
})
export class AddRouteFormComponent {
    constructor(private dataService: DataService) {}

    listItemForm = new FormGroup({
        routeName: new FormControl(""),
        routeDescription: new FormControl(""),
      routeRating: new FormControl(""),
      routeImage: new FormControl(""),
    });

    submitRoute() {
        const newRoute = {
            id: 0,
            name: this.listItemForm.value.routeName ?? "",
            description: this.listItemForm.value.routeDescription ?? "",
             rating: this.listItemForm.value.routeRating ?? "",
          dateAdded: new Date().toISOString() ?? "",
             imageLink: this.listItemForm.value.routeImage ?? "",
        };

        this.dataService.postRoute(newRoute).subscribe((res) => {});

        this.listItemForm.reset();
    }
}
