public class estage1
{
    // aplicar as classes chave e disjuntor 
    public Chave chave01;
    public Disjuntor disjuntor01;
    public Disjuntor disjuntor02;
    public Chave chave02;

    //linha 1
    public Chave chave03;
    public Disjuntor disjuntor03;
    public Chave chave04;

    //linha 2
    public Chave chave05;
    public Disjuntor disjuntor04;
    public Chave chave06;

    public estage1()
    {
        this.chave01 = new Chave(false, "1", "1");
        this.chave02 = new Chave(false, "2", "2");
        this.chave03 = new Chave(false, "3", "3");
        this.chave04 = new Chave(false, "4", "3");
        this.chave05 = new Chave(false, "5", "4");
        this.chave06 = new Chave(false, "6", "4");

        this.disjuntor01 = new Disjuntor(false, "1", "1");
        this.disjuntor02 = new Disjuntor(false, "2", "2");
        this.disjuntor03 = new Disjuntor(false, "3", "3", "4");
        this.disjuntor04 = new Disjuntor(false, "3", "5", "6");
    }
}
   