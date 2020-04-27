using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaveLogica : MonoBehaviour
{
    // Start is called before the first frame update
    private bool status;
    private string nome;
    private GameObject objAtual;
    
    void Start()
    {
        this.nome = this.gameObject.name;
        status = false;
        objAtual = this.gameObject;
    
    }
    public bool getStatus()
    {
        return this.status;
    }

    public void alteraStatus()
    {
        status = !status;
        print(nome+"---"+status);
        
    }
    
    public void verifyBeforeActive()
    {
        bool statusResult = false;

        GameObject c1 = GameObject.Find("Chave C1");
        GameObject c2 = GameObject.Find("Chave C2");
        GameObject c3 = GameObject.Find("Chave C3");
        GameObject c4 = GameObject.Find("Chave C4");
        GameObject c5 = GameObject.Find("Chave C5");
        GameObject c6 = GameObject.Find("Chave C6");
        
        /*
        da pra pegar todos os disjuntor e verificar se todos estão off

        GameObject i1 = GameObject.Find("Disjuntor I1");
        GameObject i2 = GameObject.Find("Disjuntor I2");
        GameObject i3 = GameObject.Find("Disjuntor I3");
        GameObject i4 = GameObject.Find("Disjuntor I4");
        */
        
        //da para por um if para verificar o nome do disjuntor atual e dai fazer as devidas operações

        if(c1.GetComponentInChildren<ChaveLogica>().getStatus() && c1.GetComponentInChildren<ChaveLogica>().getStatus())
        {
            objAtual.GetComponentInChildren<Image>().color = Color.green;
            alteraStatus();
        }
        else
        {
            objAtual.GetComponentInChildren<Image>().color = Color.red;
        }
    }
}
