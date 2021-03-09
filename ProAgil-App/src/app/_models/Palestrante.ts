import { RedeSocial} from './RedeSocial';
import { Evento} from './Evento';
export interface Palestrante {
        id: number;
        name: string;
        miniCurriculo: string;
        imagemUrl: string;
        telefone: string ;
        email: string ;
        redesSociais: RedeSocial[];
        palestrantesEvento: Evento[];

}
