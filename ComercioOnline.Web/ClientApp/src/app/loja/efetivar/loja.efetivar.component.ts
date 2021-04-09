import { Component, OnInit } from "@angular/core";
import { Produto } from "../../modelo/produto";
import { ProdutoServico } from "../../servicos/produto/produto.servico";
import { LojacarrinhoCompras } from "../loja/carrinho-compras/loja.carrinho.compras";

@Component({
  selector: "loja-efetivar",
  templateUrl: "./loja.efetivar.component.html",
  styleUrls: ["./loja.efetivar.component.css"]

})

export class LojaEfetivarComponent implements OnInit {

  public carrinhoCompras: LojacarrinhoCompras;
  public produtos: Produto[];

  ngOnInit(): void {
    this.carrinhoCompras = new LojacarrinhoCompras();
    this.produtos = this.carrinhoCompras.obterProdutos();




  }
}
