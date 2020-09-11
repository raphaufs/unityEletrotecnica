using System;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class Stage1aView : MonoBehaviour
{
    public Sprite[] sprites;
    private string nome;
    private char id;
    private GameObject objAtual;
    private Boolean connected;

    void Start()
    {
        inicia();
    }

    void inicia()
    {
        this.nome = this.gameObject.name;
        this.id = nome[nome.Length - 1];
        this.objAtual = this.gameObject;
        this.connected = true;
        if (nome.Contains("Bypass"))
        {
            objAtual.GetComponentInChildren<Image>().color = Color.green;
            this.connected = false;
        }
    }
    public string getNome()
    {
        return this.nome;
    }

    public void onClick()
    {

        if (Stage1aController.mudarStatus(this))
        {
            if (nome.Contains("Chave"))
            {
                Debug.Log("PRESSED");
                if (this.connected)
                {
                    objAtual.GetComponentInChildren<Image>().sprite = sprites[1];
                }
                else
                {
                    objAtual.GetComponentInChildren<Image>().sprite = sprites[0];
                }
            }
            else
            {
                if (objAtual.GetComponentInChildren<Image>().color == Color.green)
                    objAtual.GetComponentInChildren<Image>().color = Color.red;
                else
                    objAtual.GetComponentInChildren<Image>().color = Color.green;
            }
        }
    }
}
