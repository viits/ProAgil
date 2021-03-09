import {Lote  } from './Lote';
import { RedeSocial} from './RedeSocial';
import { Palestrante } from './Palestrante';

export interface Evento {
         id: number;
         local: string;
         dataEvento: Date;
         tema: string;
         qtPessoas: number;
         imagemUrl: string;
         telefone: string;
         email: string;
         lote: string;
         lotes: Lote[];
         redesSociais: RedeSocial[];
         palestrantesEvento: Palestrante[];
}
