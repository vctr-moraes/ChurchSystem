package persistencia;

import dominio.Funcao;
import dominio.Grupo;
import java.util.ArrayList;

/**
 *
 * @author victor
 */
public class GrupoBD {
    
    private static ArrayList<Grupo> lista = new ArrayList<Grupo>();
    
    public static void inserir(Grupo novoGrupo){
        lista.add(novoGrupo);
    }
    
    public static void alterar(Grupo grupoAlterado){
        excluir(grupoAlterado.getCodigo());
        inserir(grupoAlterado);
    }
    
    public static void excluir(int codigo){
        for(int i = 0; i < lista.size(); i++){
            Grupo cadaGrupo = lista.get(i);
            if (cadaGrupo.getCodigo() == codigo){
                lista.remove(i);
                break;
            }
        }
    }
    
    public static ArrayList<Grupo> listar(){
        return lista;
    }
}
