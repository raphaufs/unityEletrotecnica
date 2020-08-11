using System.Collections;
using System.Collections.Generic;

public class Bypass
{
    private string type;
    private bool status;
    private string codigo;
    private string disjuntorCode;

    public Bypass(bool status, string codigo, string disjuntorCode)
    {
        this.type = "Bypass";
        this.status = status;
        this.codigo = codigo;
        this.disjuntorCode = disjuntorCode;
    }
    public void setStatus(bool value)
    {
        this.status = value;
    }
    public bool getStatus() => this.status;
    public void setCodigo(string code)
    {
        this.codigo = code;
    }
    public string getCodigo() => this.codigo;
    public void setDisjuntorCode(string code)
    {
        this.disjuntorCode = code;
    }
    public string getDisjuntorCode() => this.disjuntorCode;
    public string toString()
    {
        return this.type + this.codigo;
    }
}
