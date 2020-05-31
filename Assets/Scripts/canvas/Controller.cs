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
        // Precisa refatorar pra um switch
        if ((nome == "Disjuntor01") && (verificarDisjuntor()))
        {
            elementosManobra.setDisjuntor01(!elementosManobra.getDisjuntor01());
            result = true;
        }
        if ((nome == "Chave01") && (verificarChave()))
        {
            elementosManobra.setChave01(!elementosManobra.getChave01());
            result = true;
        }
        if ((nome == "Chave02") && (verificarChave()))
        {
            elementosManobra.setChave02(!elementosManobra.getChave02());
            result = true;
        }
        if ((nome == "Disjuntor02") && (verificarDisjuntor()))
        {
            elementosManobra.setDisjuntor02(!elementosManobra.getDisjuntor02());
            result = true;
        }
        return result;
    }

    static bool verificarDisjuntor()
    {
        bool result = false;
        if ((!elementosManobra.getDisjuntor01()) || //se disjuntor estiver desligado
            (elementosManobra.getDisjuntor01() && !elementosManobra.getChave01() && !elementosManobra.getChave02()))
        {//se as chaves estiverem desligadas e o disjuntor estiver ligado
            result = true;
        }
        else
        {
            Debug.Log("Desligue as Chaves!");
        }
        return result;
    }

    static bool verificarChave()
    {
        bool result = false;
        if (elementosManobra.getDisjuntor01())
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