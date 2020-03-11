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
