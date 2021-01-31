import {Component, OnInit} from "@angular/core"
import { from } from "rxjs";
import { Produto } from "../modelo/produto";
import { ProdutoServico } from "../servicos/produto/produto.servico";


@Component({

  selector: "app-produto",
  templateUrl: "./produto.component.html",
  styleUrls: ["./produto.component.css"]

})
export class ProdutoComponent implements OnInit{

  public produto: Produto
  public arquivoSelecionado: File;

  ngOnInit(): void {
    this.produto = new Produto();
  }

  public inputChange(files: FileList) {
      this.arquivoSelecionado = files.item(0);
      this.produtoServico.enviarArquivo(this.arquivoSelecionado).subscribe(
      retorno => {
        console.log(retorno);
      },
      e => {
        console.log(e.error);
      }
    );
    //alert(this.arquivoSelecionado.name);
}

  constructor(private produtoServico: ProdutoServico) {

  }

  public cadastrar() {
    this.produtoServico.cadastrar(this.produto).
      subscribe(

        produtoJson => {
          console.log(produtoJson)
        },
        e => {console.log(e.error)}
      );
  }
 
  //public nome: string;
  //public liberadoParaVenda: boolean;
  //public obterNome(): string {
  //  return "Samsung";
  //}


}
