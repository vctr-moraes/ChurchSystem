package persistencia;

import dominio.Membro;
import java.util.ArrayList;

/**
 *
 * @author victor
 */
public class MembroBD {
    
    private static ArrayList<Membro> lista = new ArrayList<Membro>();
    
    public static void inserir(Membro novoMembro){
        lista.add(novoMembro);
    }
    
    public static void alterar(Membro membroAlterado){
        excluir(membroAlterado.getMatricula());
        inserir(membroAlterado);
    }
    
    public static void excluir(int matricula){
        for(int i = 0; i < lista.size(); i++){
            Membro cadaMembro = lista.get(i);
            if (cadaMembro.getMatricula() == matricula){
                lista.remove(i);
                break;
            }
        }
    }
    
    public static ArrayList<Membro> listar(){
        return lista;
    }
}
