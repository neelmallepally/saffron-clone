import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Cookbook } from "./cookbook";
import { Observable } from "rxjs";
import { CookbookService } from "../services/cookbook.service";
import { Injectable } from "@angular/core";

@Injectable()
export class CookbookResolverService implements Resolve<Cookbook[]>{
    constructor(private cookbookService: CookbookService) {}
    resolve(route: ActivatedRouteSnapshot, 
            state: RouterStateSnapshot): Cookbook[] | Observable<Cookbook[]> | Promise<Cookbook[]> {
                return this.cookbookService.getCookbooks();
    }
}