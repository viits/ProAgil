import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
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

  registerForm!: FormGroup;

  imagemLargura = 50;
  imagemMargem = 3;
  mostrarImagem = false;

  modalRef!: BsModalRef;

  constructor(private eventoService: EventoService, private modalService: BsModalService, private fb: FormBuilder) {}

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
    this.validation();
    this.getEventos();
  }

  openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
  }

  alternarImagem() {
    this.mostrarImagem = !this.mostrarImagem;
  }

  validation(){
    this.registerForm = this.fb.group({
      tema: ['', [ Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local: ['', Validators.required],
      dataEvento: ['', Validators.required],
      imagemUrl: ['', Validators.required],
      qtPessoas: ['', [ Validators.required, Validators.max(120000) ]],
      telefone:['', Validators.required],
      email: ['', [ Validators.required, Validators.email]]
  });
  }

  salvarAlteracao(){
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
