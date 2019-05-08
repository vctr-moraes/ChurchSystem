package persistencia;

import dominio.Doacao;
import dominio.Funcao;
import java.util.ArrayList;

/**
 *
 * @author victor
 */
public class DoacaoBD {
    
    private static ArrayList<Doacao> lista = new ArrayList<Doacao>();
    
    public static void inserir(Doacao novaDoacao){
        lista.add(novaDoacao);
    }
    
    public static void alterar(Doacao doacaoAlterada){
        excluir(doacaoAlterada.getCodigo());
        inserir(doacaoAlterada);
    }
    
    public static void excluir(int codigo){
        for(int i = 0; i < lista.size(); i++){
            Doacao cadaDoacao = lista.get(i);
            if (cadaDoacao.getCodigo() == codigo){
                lista.remove(i);
                break;
            }
        }
    }
    
    public static ArrayList<Doacao> listar(){
        return lista;
    }
}
