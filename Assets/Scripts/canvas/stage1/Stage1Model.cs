using System;
using System.Collections;
using System.Collections.Generic;
public class Stage1Model : IfindInterface
{
    
    public List<Chave> listOfChaves; 
    public List<Disjuntor> listOfDisjuntores;
    public List<Bypass> listOfBypass;

    public Bypass bypass01;
    public Chave chave01;
    public Disjuntor disjuntor01;
    public Chave chave07;

    public Bypass bypass02;
    public Chave chave08;
    public Disjuntor disjuntor02;
    public Chave chave02;

    //linha 1
    public Bypass bypass03;
    public Chave chave03;
    public Disjuntor disjuntor03;
    public Chave chave04;

    //linha 2
    public Bypass bypass04;
    public Chave chave05;
    public Disjuntor disjuntor04;
    public Chave chave06;

    public Stage1Model()
    {
        this.chave01 = new Chave(false, "1", "1");
        this.chave02 = new Chave(false, "2", "2");
        this.chave03 = new Chave(false, "3", "3");
        this.chave04 = new Chave(false, "4", "3");
        this.chave05 = new Chave(false, "5", "4");
        this.chave06 = new Chave(false, "6", "4");
        this.chave07 = new Chave(false, "7", "1");
        this.chave08 = new Chave(false, "8", "2");

        this.disjuntor01 = new Disjuntor(false, "1", "1","7","1");
        this.disjuntor02 = new Disjuntor(false, "2", "2","8");
        this.disjuntor03 = new Disjuntor(false, "3", "3", "4");
        this.disjuntor04 = new Disjuntor(false, "4", "5", "6");

        this.bypass01 = new Bypass(true, "1", "1");
        this.bypass02 = new Bypass(true, "2", "2");
        this.bypass03 = new Bypass(true, "3", "3");
        this.bypass04 = new Bypass(true, "4", "4");

        this.listOfChaves = createListOfChaves();
        this.listOfDisjuntores = createListOfDisjuntores();
        this.listOfBypass = createListOfBypass();
    }
    public List<Chave> createListOfChaves(){
        List<Chave> obList = new List<Chave>();
        obList.Add(this.chave01);
        obList.Add(this.chave02);
        obList.Add(this.chave03);
        obList.Add(this.chave04);
        obList.Add(this.chave05);
        obList.Add(this.chave06);
        obList.Add(this.chave07);
        obList.Add(this.chave08);

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
    public List<Bypass> createListOfBypass()
    {
        List<Bypass> obList = new List<Bypass>();
        obList.Add(this.bypass01);
        obList.Add(this.bypass02);
        obList.Add(this.bypass03);
        obList.Add(this.bypass04);

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
    public Bypass findBypassName(string name)
    {
        return this.listOfBypass.Find(x => x.toString().Contains(name));
    }
    public int findBypassIndexByName(string name)
    {
        return this.listOfBypass.FindIndex(x => x.toString().Equals(name)); //if dont find return -1
    }
}
   