using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    private string nome;
    private char id;
    private GameObject objAtual;

    void Start()
    {
        inicia();
    }

    void inicia()
    {
        this.nome = this.gameObject.name;
        this.id = nome[nome.Length - 1];
        this.objAtual = this.gameObject;
        objAtual.GetComponentInChildren<Image>().color = Color.red;
    }
    public string getNome()
    {
        return this.nome;
    }

    public void onClick()
    {

        if (Estage1Controller.mudarStatus(this))
        {
            if (objAtual.GetComponentInChildren<Image>().color == Color.green)
                objAtual.GetComponentInChildren<Image>().color = Color.red;
            else
                objAtual.GetComponentInChildren<Image>().color = Color.green;
        }
    }
}
