using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaveLogica : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject canvas;
    private bool status;
    private string nome;
    private char id;
    private char type;
    private GameObject objAtual;

    void Start()
    {
        this.nome = this.gameObject.name;
        this.id = nome[nome.Length-1];
        this.type = nome[nome.Length - 2];
        /* O status começa em false , pois como se ja tivesse tudo ligado, no caso quando tiver em true quer dizer que não ha energia passando pelo componente*/
        this.status = false;
        this.objAtual = this.gameObject;
        this.canvas = GameObject.Find("Canvas");

    }
    public bool getStatus()
    {
        return this.status;
    }

    public void alteraStatus()
    {
        status = !status;
        print(nome + "---" + status);
        if (this.status)
        {
            objAtual.GetComponentInChildren<Image>().color = Color.red;
        }
        else {
            objAtual.GetComponentInChildren<Image>().color = Color.green;
        }
            
    }
    //dijuntor 
    public void verifyBeforeActive()
    {
        if (type == 'I')
        {
            GameObject s = GameObject.Find("Chave S" + this.id);
            if (!s.GetComponentInChildren<ChaveLogica>().getStatus())
            {
                alteraStatus();
                int statusLine = vefifyLine(this.canvas);
                print("Status line: "+ statusLine);
            }
            else
            {
                print("Manobra errada !");
            }
        }
    }
    //chave
    public void verifyCondition()
    {
        print("CHAMOU VERIFYCONDITIION");
        // da para por uma verificação(switch case) para qual tipo de manobra vai estar efetuando...(verificando o type do botão...)

        if (this.type == 'S')
        {
            GameObject i = GameObject.Find("Disjuntor I" + this.id);
            if (i.GetComponentInChildren<ChaveLogica>().getStatus())
            {
                alteraStatus();
            }
            else
            {
                print("Não é possivel usar esse botão!");
            }
        }
    }
    
