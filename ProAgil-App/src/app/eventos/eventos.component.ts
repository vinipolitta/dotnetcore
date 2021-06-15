import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  private _filtroLista!: string;

  public get filtroLista(): string {
    return this._filtroLista;
  }
  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados =  this.filtrarEventos(this.filtroLista);
  }
  eventosFiltrados: any = [];
  eventos: any ;
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImagem = false;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEventos();

  }
  filtrarEventos(filtrarPor: string): any {
    if (filtrarPor) {
      return this.eventos.filter((evento) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1)
    }else {
      return this.eventos
    }


  }

  alternarImagem() {
    this.mostrarImagem = !this.mostrarImagem;
  }

  getEventos() {
    this.http.get('http://localhost:5000/weatherforecast').subscribe(resp => {
      this.eventos = resp
      console.log(this.eventos);

    }, error => {
      console.log(error);

    })
  }

}
