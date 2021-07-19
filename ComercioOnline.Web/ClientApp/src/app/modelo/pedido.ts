import { itemPedido } from "./itemPedido";

export class Pedido{

  public id: number;
  public dataPedido: Date;
  public usuarioId: number;
  public dataPrevisaoEntrega: Date;
  public cep: string;
  public estado: string;
  public cidade: string;
  public enderecoCompleto: string;
  public numeroEndereco: string;
  public fomaPagamentoId: number;

  public itensPedido: itemPedido[];

  constructor() {
    this.itensPedido=[];
  }
}
