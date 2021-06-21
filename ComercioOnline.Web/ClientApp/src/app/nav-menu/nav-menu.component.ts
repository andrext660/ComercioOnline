import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LojacarrinhoCompras } from '../loja/loja/carrinho-compras/loja.carrinho.compras';
import { UsuarioServico } from '../servicos/usuario/usuario.servico';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})


export class NavMenuComponent implements OnInit {
  isExpanded = false;
  public carrinhoCompra: LojacarrinhoCompras;

  ngOnInit(): void {
    this.carrinhoCompra = new LojacarrinhoCompras()
  }

  constructor(private router: Router, private usuarioServico: UsuarioServico) {

  }
  

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  public usuarioLogado(): boolean{
    return this.usuarioServico.usuario_autenticado();
  }

  public usuario_administrador(): boolean {
    return this.usuarioServico.usuario_administrador();
  }

  sair() {
    this.usuarioServico.limpar_sessao();
    this.router.navigate(['/']);

  }

  get usuario() {

    return this.usuarioServico.usuario;
  }

  public itensNoCarrinho():boolean {
    return this.carrinhoCompra.itensNoCarrinho();

}

}
