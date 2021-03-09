import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Evento } from '../_models/Evento';
import { EventoService } from '../_services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css'],
})
export class EventosComponent implements OnInit {
  _filtroLista = '';

  eventosFiltrados: Evento[] = [];
  eventos: Evento[] = [];

  imagemLargura = 50;
  imagemMargem = 3;
  mostrarImagem = false;

  modalRef!: BsModalRef;

  constructor(private eventoService: EventoService, private modalService: BsModalService) {}

  get filtroLista(): string {
    return this._filtroLista;
  }
  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this._filtroLista
      ? this.filtrarEvento(this.filtroLista)
      : this.eventos;
  }

  ngOnInit() {
    this.getEventos();
  }

  openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
  }

  alternarImagem() {
    this.mostrarImagem = !this.mostrarImagem;
  }

  getEventos() {
    this.eventoService.getAllEvento().subscribe(
      (_eventos: Evento[]) => {
        this.eventos = _eventos;
        this.eventosFiltrados = this.eventos;
        console.log(_eventos);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  filtrarEvento(value: string): Evento[] {
    value = value.toLocaleLowerCase();
    return this.eventos.filter((e: { tema: string }) => {
      return e.tema.toLocaleLowerCase().indexOf(value) !== -1;
    });
  }
}
