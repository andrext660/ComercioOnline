import { Component, OnInit } from "@angular/core";
import { Pedido } from "../../modelo/pedido";
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
  public total: number;

  ngOnInit(): void {
    this.carrinhoCompras = new LojacarrinhoCompras();
    this.produtos = this.carrinhoCompras.obterProdutos();
    this.atualizarTotal();

  }

  public atualizarPreco(produto: Produto, quantidade: number) {

    if(!produto.precoOriginal) {
        produto.precoOriginal = produto.preco;
    }
    if(quantidade <= 0) {
      quantidade = 1;
      produto.quantidade = quantidade;
    }
    produto.preco = produto.precoOriginal * quantidade;
    this.carrinhoCompras.atualizar(this.produtos);
    this.atualizarTotal();

  }

  public remover(produto:Produto) {

    this.carrinhoCompras.removerProduto(produto);
    this.produtos = this.carrinhoCompras.obterProdutos();
    this.atualizarTotal();
  }

  public atualizarTotal() {
    this.total = this.produtos.reduce((acc, produto) => acc + produto.preco, 0);
  }

  public efetivarCompra() {
    let pedido = new Pedido();
  }

}
