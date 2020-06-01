using System.Collections;
using System.Collections.Generic;
public class estage1 : IfindInterface
{
    
    public List<Object> listOfObjects; // lista com todos os componentes do estage

         
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

        this.listOfObjects = createListObjectsOfEstage();
    }
    public List<Object> createListObjectsOfEstage(){
        List<Object> obList = new List<Object>();
        obList.add(this.chave01);
        obList.add(this.chave02);
        obList.add(this.chave03);
        obList.add(this.chave04);
        obList.add(this.chave05);
        obList.add(this.chave06);
        obList.add(this.disjuntor01);
        obList.add(this.disjuntor02);
        obList.add(this.disjuntor03);
        obList.add(this.disjuntor04);

        return obList;    
	}
    public Object findName(string name){
        return this.listOfObjects.Find(x => x.toString().Contains(name));
	}
    public int findIndexByName(string name){
        return this.listOfObjects.FindIndex(x => x.toString().equals(name)); //if dont find return -1
	}
}
   