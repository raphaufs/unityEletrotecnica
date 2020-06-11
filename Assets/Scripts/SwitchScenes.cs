using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    private GameObject objAtual;
    private string nameObjeto;
    void Start()
    {
        this.objAtual = this.gameObject;
        this.nameObjeto = objAtual.name;
    }

   public void switchScene()
    {
        SceneManager.LoadScene(this.nameObjeto);
    }

    public void backForStation() 
    {
        SceneManager.LoadScene("cena1");
        // SceneManager.LoadScene("cena1");
    }
}
