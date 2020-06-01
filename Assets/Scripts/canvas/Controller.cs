using System;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private static estage1 elementosManobra;
    private GameObject msgCuidado;
    private GameObject msgOk;

    void Start()
    {
        iniciar();
    }

    void iniciar()
    {
        elementosManobra = new estage1();
        this.msgCuidado = GameObject.Find("msgCuidado");
        this.msgCuidado.SetActive(true);
        this.msgOk = GameObject.Find("msgOk");
        this.msgOk.SetActive(false);
    }
    
    private bool fimManobraDesenergizar()
    {
        
        return (elementosManobra.disjuntor01.getStatus()
            && elementosManobra.chave01.getStatus()
            && elementosManobra.chave02.getStatus()
            && elementosManobra.disjuntor02.getStatus());
    }

    public static bool mudarStatus(View botao)
    {
        string nome = botao.getNome();
        bool result = false;
        int indexOfElement = nome.Contains("Disjuntor") ? elementosManobra.findDisjuntorIndexByName(nome) : elementosManobra.findChaveIndexByName(nome);
        if(indexOfElement < 0) { print("Algum erro no codigo~, não ta conseguindo achar o elemento atual, verifique as suas chamadas."); }
        if ((nome.Contains("Disjuntor")) && (verificarDisjuntor(indexOfElement)))
        {
            elementosManobra.listOfDisjuntores[indexOfElement].setStatus(!elementosManobra.listOfDisjuntores[indexOfElement].getStatus());
            result = true;
        }
        if ((nome.Contains("Chave")) && (verificarChave(indexOfElement)))
        {
            elementosManobra.listOfChaves[indexOfElement].setStatus(!elementosManobra.listOfChaves[indexOfElement].getStatus());
            result = true;
        }
        return result;
    }

    static bool verificarDisjuntor(int indexDisjuntor)
    {   
        bool disjuntorStatus = elementosManobra.listOfDisjuntores[indexDisjuntor].getStatus();

        string nameKey1 = "Chave"+ elementosManobra.listOfDisjuntores[indexDisjuntor].getKeycode1() ;
        int indexChave1 = elementosManobra.findChaveIndexByName(nameKey1);
        bool chave1Status = elementosManobra.listOfChaves[indexChave1].getStatus();

        bool result = false;
        
        // verifica se é disjuntor que so tem uma chave ou disjuntor que tem 2 chaves
        if(elementosManobra.listOfDisjuntores[indexDisjuntor].getIsDoubleKey()){
        
            string nameKey2 = "Chave"+ elementosManobra.listOfDisjuntores[indexDisjuntor].getKeycode2() ;
            int indexChave2 = elementosManobra.findChaveIndexByName(nameKey2);
            bool chave2Status = elementosManobra.listOfChaves[indexChave2].getStatus();

            if ((!disjuntorStatus) || //se disjuntor estiver desligado
                (disjuntorStatus && !chave1Status && !chave2Status))
            {//se as chaves estiverem desligadas e o disjuntor estiver ligado
                result = true;
            }
            else
            {
                Debug.Log("Desligue as Chaves!");
            }
	    }else{
          if ((!disjuntorStatus) || //se disjuntor estiver desligado
                (disjuntorStatus && !chave1Status))
            {//se a chave estiver desligada e o disjuntor estiver ligado
                result = true;
            }
            else
            {
                Debug.Log("Desligue a Chave!");
            }
		}
        
        return result;
    }

    static bool verificarChave(int indexChave)
    {
        string nameDisjuntor = "Disjuntor"+ elementosManobra.listOfChaves[indexChave].getDisjuntorCode() ;
        int indexDisjuntor = elementosManobra.findDisjuntorIndexByName(nameDisjuntor);
        bool disjuntorStatus = elementosManobra.listOfDisjuntores[indexDisjuntor].getStatus();

        bool result = false;
        if (disjuntorStatus)
        {//se o disjuntor estiver desligado
            result = true;
        }
        else
        {
            Debug.Log("Desligue o Disjutor!");
        }
        return result;
    }

    void Update()
    {
        if (fimManobraDesenergizar())
        {
            this.msgOk.SetActive(true);
            this.msgCuidado.SetActive(false);
        }
        else
        {
            this.msgOk.SetActive(false);
            this.msgCuidado.SetActive(true);
        }
    }
}