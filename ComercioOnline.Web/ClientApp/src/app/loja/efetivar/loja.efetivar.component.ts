import { Component, OnInit } from "@angular/core";
import { Pedido } from "../../modelo/pedido";
import { Produto } from "../../modelo/produto";
import { ProdutoServico } from "../../servicos/produto/produto.servico";
import { UsuarioServico } from "../../servicos/usuario/usuario.servico";
import { LojacarrinhoCompras } from "../loja/carrinho-compras/loja.carrinho.compras";
import { ItemPedido } from "../../modelo/itemPedido";
import { PedidoServico } from "../../servicos/pedido/pedido.servico";
import { Router } from "@angular/router";

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

  constructor(private usuarioServico: UsuarioServico, private pedidoServico: PedidoServico, private router : Router) {

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
    this.pedidoServico.efetivarCompra(this.criarPedido()).subscribe(
      pedidoId => {
        console.log(pedidoId);
        sessionStorage.setItem("pedidoId", pedidoId.toString());
        this.produtos = [];
        this.carrinhoCompras.limparCarrinhocompras();
        this.router.navigate(["/compra-realizada-sucesso"]);
      },
      e => {

      });
  }

  public criarPedido(): Pedido {
    let pedido = new Pedido();
    pedido.usuarioId = this.usuarioServico.usuario.id;
    pedido.cep = "123456";
    pedido.cidade = "Aracaju";
    pedido.dataPedido = new Date();
    pedido.estado = "Sergipe";
    pedido.dataPrevisaoEntrega = new Date();
    pedido.fomaPagamentoId = 1;
    pedido.numeroEndereco = "12";

    this.produtos = this.carrinhoCompras.obterProdutos();

    for (let produto of this.produtos) {
      let itemPedido = new ItemPedido();
      itemPedido.produtoId = produto.id;
      itemPedido.quantidade = produto.quantidade;

      if (!produto.quantidade) {
        produto.quantidade = 1;
        itemPedido.quantidade = produto.quantidade;
        pedido.itensPedido.push(itemPedido);
      }

    }

    return pedido;
  }

}
