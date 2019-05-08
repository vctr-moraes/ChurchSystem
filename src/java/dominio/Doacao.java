package dominio;

import java.util.Date;

/**
 *
 * @author victor
 */
public class Doacao {
    
    private int codigo;
    private Date data;
    private float quantia;
    private Membro membro;

    public int getCodigo() {
        return codigo;
    }

    public void setCodigo(int codigo) {
        this.codigo = codigo;
    }
    
    public Date getData() {
        return data;
    }

    public void setData(Date data) {
        this.data = data;
    }

    public float getQuantia() {
        return quantia;
    }

    public void setQuantia(float quantia) {
        this.quantia = quantia;
    }

    public Membro getMembro() {
        return membro;
    }

    public void setMembro(Membro membro) {
        this.membro = membro;
    }
}
