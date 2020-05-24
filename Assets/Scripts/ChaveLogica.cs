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
                int statusLine = vefifyLine(this.canvas);
                print("Status line: "+ statusLine);
                alteraStatus();
                
            }
            else
            {
                print("Não é possivel usar esse botão!");
            }
        }
    }
    //condiciton clear first stage
    public int vefifyLine(GameObject canvasGameObject){
        //precisa refartorar esse codigo é apenas uma "versao Beta"
        // allOff //-1
        // allOn  // 1
        // half   // 0
        GameObject[] lineComponents;
        lineComponents = new GameObject[4];
    
        lineComponents[0] = GameObject.Find("Disjuntor I" + 1);
        lineComponents[1] = GameObject.Find("Chave S" + 1);
        lineComponents[2] = GameObject.Find("Chave S" + 2);
        lineComponents[3] = GameObject.Find("Disjuntor I" + 2);

        int i,auxOff=0,auxON=0;
        for(i=0; i<4;i++){
         if(lineComponents[i].GetComponentInChildren<ChaveLogica>().getStatus()){
            auxON++;
	     }else{
            auxOff++;     
	     }
	    }

        if(auxOff==3){
            return -1;
	    }else if(auxON==3){
            return 1;
	    }
        return 0;
    }


    // add text in canvas
     public Text AddTextToCanvas(string textString, GameObject canvasGameObject)
     {
         Text text = canvasGameObject.AddComponent<Text>();
         text.text = textString;
 
         Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
         text.font = ArialFont;
         text.material = ArialFont.material;
 
         return text;
     }
    }
