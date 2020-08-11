using System.Collections;
using System.Collections.Generic;

public class Disjuntor 
{
    private string type;
    private bool status;
    private string codigo;
    private bool isDoubleKey;
    private string keyCode1;
    private string keyCode2;
    private bool hasBypass;
    private string bypassCode;

    public Disjuntor(bool status, string codigo, string keyCode1)
    {
        this.type = "Disjuntor";
        this.status = status;
        this.codigo = codigo;
        this.isDoubleKey = false;
        this.keyCode1 = keyCode1;
        this.hasBypass = false;
    }
    public Disjuntor(bool status, string codigo, string keyCode1,string keyCode2)
    {
        this.type = "Disjuntor";
        this.status = status;
        this.codigo = codigo;
        this.isDoubleKey = true;
        this.keyCode1 = keyCode1;
        this.keyCode2 = keyCode2;
        this.hasBypass = false;
    }
    public Disjuntor(bool status, string codigo, string keyCode1, string keyCode2, string bypassCode)
    {
        this.type = "Disjuntor";
        this.status = status;
        this.codigo = codigo;
        this.isDoubleKey = true;
        this.keyCode1 = keyCode1;
        this.keyCode2 = keyCode2;
        this.hasBypass = true;
        this.bypassCode = bypassCode;
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
    public void setIsDoubleKey(bool status)
    {
        this.isDoubleKey = status;
    }
    public bool getIsDoubleKey() => this.isDoubleKey;
    public void setKeycode1(string code)
    {
        this.keyCode1 = code;
    }
    public string getKeycode1() => this.keyCode1;
    public void setKeycode2(string code)
    {
        this.keyCode2 = code;
    }
    public string getKeycode2() => this.keyCode2;
    public string toString()
    {
        return this.type + this.codigo;
    }
    public bool getIsHasBypass() => this.hasBypass;
    public void setBypassCode(string code)
    {
        this.bypassCode = code;
    }
    public string getBypassCode() => this.bypassCode;
}
