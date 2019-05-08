package persistencia;

import dominio.Funcao;
import dominio.Membro;
import java.util.ArrayList;

/**
 *
 * @author victor
 */
public class FuncaoBD {
    
    private static ArrayList<Funcao> lista = new ArrayList<Funcao>();
    
    public static void inserir(Funcao novaFuncao){
        lista.add(novaFuncao);
    }
    
    public static void alterar(Funcao funcaoAlterada){
        excluir(funcaoAlterada.getCodigo());
        inserir(funcaoAlterada);
    }
    
    public static void excluir(int codigo){
        for(int i = 0; i < lista.size(); i++){
            Funcao cadaFuncao = lista.get(i);
            if (cadaFuncao.getCodigo() == codigo){
                lista.remove(i);
                break;
            }
        }
    }
    
    public static ArrayList<Funcao> listar(){
        return lista;
    }
}
