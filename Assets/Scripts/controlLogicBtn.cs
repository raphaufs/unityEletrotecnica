using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaveLogica : MonoBehaviour
{
    // Start is called before the first frame update
    private bool status;
    private string nome;
    private char id;
    private char type;
    private GameObject objAtual;

    void Start()
    {
        this.nome = this.gameObject.name;
        this.id = nome[nome.Length];
        this.type = nome[nome.Length - 1];
        this.status = false;
        this.objAtual = this.gameObject;

    }
    public bool getStatus()
    {
        return this.status;
    }

    public void alteraStatus()
    {
        status = !status;
        print(nome + "---" + status);

    }

    public void verifyBeforeActive()
    {
        bool statusResult = false;

        //GameObject s6 = GameObject.Find("Chave S6");


        /*
        da pra pegar todos os disjuntor e verificar se todos estão off

        GameObject i1 = GameObject.Find("Disjuntor I1");
        GameObject i2 = GameObject.Find("Disjuntor I2");
        GameObject i3 = GameObject.Find("Disjuntor I3");
        GameObject i4 = GameObject.Find("Disjuntor I4");
        */

        //da para por um if para verificar o nome do disjuntor atual e dai fazer as devidas operações
        print("Nome:" + this.nome + "\n STATUS:"+this.status);
        if (type == 'I')
        {
            GameObject s = GameObject.Find("Chave S" + this.id);
            if (s.GetComponentInChildren<ChaveLogica>().getStatus())
            {
                objAtual.GetComponentInChildren<Image>().color = Color.green;
                alteraStatus();
            }
        }

        /*
        if(c1.GetComponentInChildren<ChaveLogica>().getStatus() && c2.GetComponentInChildren<ChaveLogica>().getStatus())
        {
            objAtual.GetComponentInChildren<Image>().color = Color.green;
            alteraStatus();
        }
        else
        {
            objAtual.GetComponentInChildren<Image>().color = Color.red;
        }
        */
    }
}
