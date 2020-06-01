using System;
using System.Collections;
using System.Collections.Generic;
public class estage1 : IfindInterface
{
    
    public List<Chave> listOfChaves; 
    public List<Disjuntor> listOfDisjuntores; 


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
        this.disjuntor04 = new Disjuntor(false, "4", "5", "6");

        this.listOfChaves = createListOfChaves();
        this.listOfDisjuntores = createListOfDisjuntores();
    }
    public List<Chave> createListOfChaves(){
        List<Chave> obList = new List<Chave>();
        obList.Add(this.chave01);
        obList.Add(this.chave02);
        obList.Add(this.chave03);
        obList.Add(this.chave04);
        obList.Add(this.chave05);
        obList.Add(this.chave06);

        return obList;    
	}
    public List<Disjuntor> createListOfDisjuntores()
    {
        List<Disjuntor> obList = new List<Disjuntor>();
        obList.Add(this.disjuntor01);
        obList.Add(this.disjuntor02);
        obList.Add(this.disjuntor03);
        obList.Add(this.disjuntor04);

        return obList;
    }
    public Chave findChaveName(string name) {
        return this.listOfChaves.Find(x => x.toString().Contains(name));
    }
    public int findChaveIndexByName(string name)
    {
        return this.listOfChaves.FindIndex(x => x.toString().Equals(name)); //if dont find return -1
    }
    public Disjuntor findDisjuntorName(string name)
    {
        return this.listOfDisjuntores.Find(x => x.toString().Contains(name));
    }
    public int findDisjuntorIndexByName(string name)
    {
        return this.listOfDisjuntores.FindIndex(x => x.toString().Equals(name)); //if dont find return -1
    }
}
   