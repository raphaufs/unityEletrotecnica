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
    public GameObject[] connectionsBypass;

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
            Debug.Log("PRESSED");
            if (this.connected)
            {
                objAtual.GetComponentInChildren<Image>().sprite = sprites[1];
                if (nome.Contains("Bypass"))
                {
                    foreach(GameObject obj in this.connectionsBypass)
                    {
                        obj.GetComponentInChildren<Image>().sprite = sprites[3];
                    }
                }
            }
            else
            {
                objAtual.GetComponentInChildren<Image>().sprite = sprites[0];
                if (nome.Contains("Bypass"))
                {
                    foreach (GameObject obj in this.connectionsBypass)
                    {
                        obj.GetComponentInChildren<Image>().sprite = sprites[2];
                    }
                }
            }
            this.connected = !this.connected;

        }
    }
}
