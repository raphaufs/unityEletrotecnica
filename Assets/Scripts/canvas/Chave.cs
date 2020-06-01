
public class Chave 
{
    private string type;
    private bool status;
    private string codigo;
    private string disjuntorCode;

    public Chave(bool status)
    {
        this.type = "Chave";
        this.status = status;
    }
    public Chave(bool status,string codigo)
    {
        this.type = "Chave";
        this.status = status;
        this.codigo = codigo;
    }
    public Chave(bool status, string codigo, string disjuntorCod)
    {
        this.type = "Chave";
        this.status = status;
        this.codigo = codigo;
        this.disjuntorCode = disjuntorCod;
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
    public void setDisjuntorCode(string code)
    {
        this.disjuntorCode = code;
    }
    public string getDisjuntorCode () => this.disjuntorCode;
    public string toString(){
        return this.type+this.codigo;
	}
}
