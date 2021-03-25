import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { CanActivate } from '@angular/router/src/utils/preactivation';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CanActivatePath implements CanActivate {
  constructor() { }
    path: ActivatedRouteSnapshot[];
    route: ActivatedRouteSnapshot;

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if (localStorage.getItem("token")) {
      return true;
    }
    else {
      return false;
    }
  }
}
