import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  _filtroLista = '';

  get filtroLista(): string{
    return this._filtroLista;
  }
  set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this._filtroLista ? this.filtrarEvento(this.filtroLista) : this.eventos;
  }

  eventosFiltrados: any = [];

  eventos: any = [];
  imagemLargura = 50;
  imagemMargem = 3;
  mostrarImagem = false;
  

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEventos();
  }

    alternarImagem(){
      this.mostrarImagem = !this.mostrarImagem;
    }

  getEventos(){
    this.http.get('http://localhost:5000/api/weatherforecast').subscribe(response => {
      console.log(response);
      this.eventos = response;
    }, error =>{
        console.log(error);
    });
  }

  filtrarEvento(value: string): any {
    value = value.toLocaleLowerCase();
    return this.eventos.filter(
      (      e: { tema: string; }) => {
        return e.tema.toLocaleLowerCase().indexOf(value) !== -1;
      }
    );
  }

}
