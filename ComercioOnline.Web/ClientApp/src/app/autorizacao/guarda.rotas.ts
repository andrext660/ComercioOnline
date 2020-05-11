import { Injectable } from "@angular/core";

import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";



@Injectable({
  providedIn:'root'

})

export class GuardaRotas implements CanActivate {


  constructor(private route: Router) {

  }


    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
      //se usuario não autenticado
      var autenticado = localStorage.getItem("usuario-autenticado");

      if (autenticado == "1") {
        return true;
      }
      this.route.navigate(['/entrar'], { queryParams: { returnUrl:state.url }});
      return false;
    }



}
