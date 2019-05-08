package persistencia;

import dominio.Agenda;
import dominio.Doacao;
import java.util.ArrayList;

/**
 *
 * @author victor
 */
public class AgendaBD {
    
    private static ArrayList<Agenda> lista = new ArrayList<Agenda>();
    
    public static void inserir(Agenda novaAgenda){
        lista.add(novaAgenda);
    }
    
    public static void alterar(Agenda agendaAlterada){
        excluir(agendaAlterada.getCodigo());
        inserir(agendaAlterada);
    }
    
    public static void excluir(int codigo){
        for(int i = 0; i < lista.size(); i++){
            Agenda cadaAgenda = lista.get(i);
            if (cadaAgenda.getCodigo() == codigo){
                lista.remove(i);
                break;
            }
        }
    }
    
    public static ArrayList<Agenda> listar(){
        return lista;
    }
}
