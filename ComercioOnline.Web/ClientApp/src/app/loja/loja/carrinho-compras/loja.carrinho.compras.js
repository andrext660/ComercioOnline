"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.LojacarrinhoCompras = void 0;
var LojacarrinhoCompras = /** @class */ (function () {
    function LojacarrinhoCompras() {
        this.produtos = [];
    }
    LojacarrinhoCompras.prototype.adicionar = function (produto) {
        var produtoLocalStorage = localStorage.getItem("produtoLocalStorage");
        if (!produtoLocalStorage) {
            this.produtos.push(produto);
        }
        else {
            this.produtos = JSON.parse(produtoLocalStorage);
            this.produtos.push(produto);
        }
        localStorage.setItem("produtoLocalStorage", JSON.stringify(this.produtos));
    };
    LojacarrinhoCompras.prototype.obterProdutos = function () {
        var produtoLocalStorage = localStorage.getItem("produtoLocalStorage");
        if (produtoLocalStorage) {
            return JSON.parse(produtoLocalStorage);
        }
    };
    LojacarrinhoCompras.prototype.removerProduto = function (produto) {
        var produtoLocalStorage = localStorage.getItem("produtoLocalStorage");
        if (produtoLocalStorage) {
            this.produtos = JSON.parse(produtoLocalStorage);
            this.produtos = this.produtos.filter(function (p) { return p.id != produto.id; });
            localStorage.setItem("produtoLocalStorage", JSON.stringify(this.produtos));
        }
    };
    LojacarrinhoCompras.prototype.atualizar = function (produtos) {
        localStorage.setItem("produtoLocalStorage", JSON.stringify(produtos));
    };
    LojacarrinhoCompras.prototype.itensNoCarrinho = function () {
        var itens = this.obterProdutos();
        return (itens.length > 0);
    };
    return LojacarrinhoCompras;
}());
exports.LojacarrinhoCompras = LojacarrinhoCompras;
//# sourceMappingURL=loja.carrinho.compras.js.map