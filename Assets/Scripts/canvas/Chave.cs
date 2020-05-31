
public class Chave 
{
    private bool status;
    private string codigo;
    private string disjuntorRootCode;

    public Chave(bool status)
    {
        this.status = status;
    }
    public Chave(bool status,string codigo)
    {
        this.status = status;
        this.codigo = codigo;
    }
    public Chave(bool status, string codigo, string disjuntorCod)
    {
        this.status = status;
        this.codigo = codigo;
        this.disjuntorRootCode = disjuntorCod;
    }
    public void setStatus(bool value)
    {
        this.status = value;
    }
    public bool getStatus () => this.status;
    public void setCodigo(string code)
    {
        this.codigo = code;
    }
    public string getCodigo () => this.codigo;
    public void setDisjuntorRootCode(string code)
    {
        this.disjuntorRootCode = code;
    }
    public string getDisjuntorRootCode () => this.disjuntorRootCode;
}
