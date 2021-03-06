﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage1dController : MonoBehaviour
{
    private static Stage1Model elementosManobra;
    private GameObject transformador;
    private GameObject msgCuidado;
    private GameObject WinText;
    private GameObject msgOk;
    private GameObject txtStep;
    private int maxOjetivos; //2 state nessa fase , por enquanto so pensei nisso para simular o estado do objetivo , tipo como se fosse etapas 1/3 concluido ...
                             // soq aqui no caso e pensei em fazer o inverso , eu inicializo um valor , e vou reduzindo ate chegar em zero , quando chega em zero é pq todos objetivos foram concluido
    private static int scoreGame = 0;
    private float EndGameCooldown = 3.0f;

    public void setTextScore()
    {
        GameObject objScoreText = GameObject.Find("ScoreGame");
        TextMeshProUGUI scoreText = objScoreText.GetComponent<TextMeshProUGUI>();
        scoreText.SetText("Pontuação:" + scoreGame);
        if (scoreGame <= 60)
        {
            scoreText.color = new Color32(255, 0, 0, 255);
        }
    }
    public static void decrementScore(int value)
    {
        scoreGame -= value;
    }
    public static void incrementScore(int value)
    {
        scoreGame += value;
    }
    void Start()
    {
        iniciar();
    }

    void iniciar()
    {
        elementosManobra = new Stage1Model();
        this.msgCuidado = GameObject.Find("msgCuidado");
        this.msgCuidado.SetActive(true);
        this.transformador = GameObject.Find("transformador");
        this.transformador.SetActive(true);
        this.msgOk = GameObject.Find("msgOk");
        this.msgOk.SetActive(false);
        this.WinText = GameObject.Find("WinText");
        this.WinText.SetActive(false);
        this.txtStep = GameObject.Find("txtStep");
        this.txtStep.SetActive(false);
        this.maxOjetivos = 2;
    }

    private static bool isElementOfGoal(Chave chave = null, Disjuntor disjuntor = null)
    {
        if (chave == null && disjuntor == null)
        {
            return false;
        }
        else
        {
            Chave[] chavesList = Stage1dController.returnChavesObjective();
            Disjuntor[] disjuntoresList = Stage1dController.returnDisjuntoresObjective();

            bool result = true;
            if (chave != null)
            {
                foreach (Chave c in chavesList)
                {
                    result = (chave.getCodigo() == c.getCodigo()) ? true : false;
                    if (result)
                    {
                        break;
                    }
                }
            }
            else if (disjuntor != null)
            {
                foreach (Disjuntor d in disjuntoresList)
                {
                    result = (disjuntor.getCodigo() == d.getCodigo()) ? true : false;
                    if (result)
                    {
                        break;
                    }
                }
            }
            return result;
        }
    }

    private bool manobraDesenergizar()
    {
        return (
                elementosManobra.chave01.getStatus() &&
                elementosManobra.chave02.getStatus() &&
                elementosManobra.chave03.getStatus() &&
                elementosManobra.chave04.getStatus() &&
                elementosManobra.chave05.getStatus() &&
                elementosManobra.chave06.getStatus() &&
                elementosManobra.chave07.getStatus() &&
                elementosManobra.chave08.getStatus() &&
                elementosManobra.disjuntor01.getStatus() &&
                elementosManobra.disjuntor02.getStatus() &&
                elementosManobra.disjuntor03.getStatus() &&
                elementosManobra.disjuntor04.getStatus()
            );
    }
    private bool manobraEnergizar()
    {
        return (
                !elementosManobra.chave01.getStatus() &&
                !elementosManobra.chave02.getStatus() &&
                !elementosManobra.chave03.getStatus() &&
                !elementosManobra.chave04.getStatus() &&
                !elementosManobra.chave05.getStatus() &&
                !elementosManobra.chave06.getStatus() &&
                !elementosManobra.chave07.getStatus() &&
                !elementosManobra.chave08.getStatus() &&
                !elementosManobra.disjuntor01.getStatus() &&
                !elementosManobra.disjuntor02.getStatus() &&
                !elementosManobra.disjuntor03.getStatus() &&
                !elementosManobra.disjuntor04.getStatus()
            );
    }


    public static bool mudarStatus(Stage1dView botao)
    {
        string nome = botao.getNome();
        bool result = false;
        int indexOfElement = -1;
        if (nome.Contains("Disjuntor"))
        {
            indexOfElement = elementosManobra.findDisjuntorIndexByName(nome);
        }
        else if (nome.Contains("Chave"))
        {
            indexOfElement = elementosManobra.findChaveIndexByName(nome);
        }
        else //bypass
        {
            indexOfElement = elementosManobra.findBypassIndexByName(nome);
        }

        if (indexOfElement < 0) { print("Algum erro no codigo~, não ta conseguindo achar o elemento atual, verifique as suas chamadas."); }

        if ((nome.Contains("Disjuntor")) && (verificarDisjuntor(indexOfElement)))
        {
            elementosManobra.listOfDisjuntores[indexOfElement].setStatus(!elementosManobra.listOfDisjuntores[indexOfElement].getStatus());
            result = true;
        }
        if ((nome.Contains("Chave")) && (verificarChave(indexOfElement)))
        {
            elementosManobra.listOfChaves[indexOfElement].setStatus(!elementosManobra.listOfChaves[indexOfElement].getStatus());
            result = true;
        }
        if (nome.Contains("Bypass"))
        {
            result = true;

            int indexDisjuntor = elementosManobra.findDisjuntorIndexByName("Disjuntor" + elementosManobra.listOfBypass[indexOfElement].getDisjuntorCode());
            bool statusDisjuntor = elementosManobra.listOfDisjuntores[indexDisjuntor].getStatus();
            bool statusBypass = elementosManobra.listOfBypass[indexOfElement].getStatus();

            elementosManobra.listOfBypass[indexOfElement].setStatus(!elementosManobra.listOfBypass[indexOfElement].getStatus());
            if (!statusBypass && statusDisjuntor)
            {
                Debug.Log("Feche o disjuntor e suas chaves");
                elementosManobra.listOfBypass[indexOfElement].setStatus(false);
                result = false;
            }
        }

        return result;
    }
    bool verificaTransformadorOff()
    {
        return (elementosManobra.disjuntor01.getStatus() &&
                elementosManobra.disjuntor02.getStatus() &&
                elementosManobra.chave01.getStatus() &&
                elementosManobra.chave02.getStatus() &&
                elementosManobra.chave07.getStatus() &&
                elementosManobra.chave08.getStatus());
    }
    bool verificaTransformadorOn()
    {
        return (!elementosManobra.disjuntor01.getStatus() &&
                !elementosManobra.disjuntor02.getStatus() &&
                !elementosManobra.chave01.getStatus() &&
                !elementosManobra.chave02.getStatus() &&
                !elementosManobra.chave07.getStatus() &&
                !elementosManobra.chave08.getStatus());
    }

    static bool verificarDisjuntor(int indexDisjuntor)
    {
        Disjuntor disjuntor = elementosManobra.listOfDisjuntores[indexDisjuntor];
        bool disjuntorStatus = disjuntor.getStatus();
        bool hasBypass = elementosManobra.listOfDisjuntores[indexDisjuntor].getIsHasBypass();
        bool bypassStatus = false;
        if (hasBypass)
        {
            string nameBypass = "Bypass" + elementosManobra.listOfDisjuntores[indexDisjuntor].getBypassCode();
            int indexBypass = elementosManobra.findBypassIndexByName(nameBypass);
            bypassStatus = elementosManobra.listOfBypass[indexBypass].getStatus();
        }

        string nameKey1 = "Chave" + elementosManobra.listOfDisjuntores[indexDisjuntor].getKeycode1();
        int indexChave1 = elementosManobra.findChaveIndexByName(nameKey1);
        bool chave1Status = elementosManobra.listOfChaves[indexChave1].getStatus();

        bool result = false;

        // verifica se é disjuntor que so tem uma chave ou disjuntor que tem 2 chaves
        if (elementosManobra.listOfDisjuntores[indexDisjuntor].getIsDoubleKey())
        {

            string nameKey2 = "Chave" + elementosManobra.listOfDisjuntores[indexDisjuntor].getKeycode2();
            int indexChave2 = elementosManobra.findChaveIndexByName(nameKey2);
            bool chave2Status = elementosManobra.listOfChaves[indexChave2].getStatus();

            if ((!disjuntorStatus) || //se disjuntor estiver desligado
                (disjuntorStatus && !chave1Status && !chave2Status))
            {//se as chaves estiverem desligadas e o disjuntor estiver ligado
                result = true;
                if (Stage1dController.isElementOfGoal(disjuntor: disjuntor))
                { // verifica o elemento é parte do objetivo para poder ter pontuação
                    Debug.Log(disjuntor.toString());
                    Stage1dController.incrementScore(10);
                }
            }
            else
            {
                Stage1dController.decrementScore(5);
                Debug.Log("Desligue as Chaves!");
            }
        } // So tem uma chave
        else
        {
            if ((!disjuntorStatus) || //se disjuntor estiver desligado
                  (disjuntorStatus && !chave1Status))
            {//se a chave estiver desligada e o disjuntor estiver ligado
                result = true;
                if (Stage1dController.isElementOfGoal(disjuntor: disjuntor))
                { // verifica o elemento é parte do objetivo para poder ter pontuação
                    Debug.Log("este elemento pertence ao GOAL 2");
                    Stage1dController.incrementScore(10);
                }
            }
            else
            {
                Stage1dController.decrementScore(5);
                Debug.Log("Desligue a Chave!");
            }
        }

        if (hasBypass)
        {
            if (bypassStatus && !disjuntorStatus)
            {
                Stage1dController.decrementScore(5);
                Debug.Log("Feche o Bypass !");
                result = false;
            }
            else
            {
                //Stage1dController.incrementScore(10);
            }
        }

        return result;
    }

    static bool verificarChave(int indexChave)
    {
        Chave chave = elementosManobra.listOfChaves[indexChave];
        Debug.Log(chave.toString());
        string nameDisjuntor = "Disjuntor" + elementosManobra.listOfChaves[indexChave].getDisjuntorCode();
        int indexDisjuntor = elementosManobra.findDisjuntorIndexByName(nameDisjuntor);
        bool disjuntorStatus = elementosManobra.listOfDisjuntores[indexDisjuntor].getStatus();

        bool result = false;
        if (disjuntorStatus)
        {//se o disjuntor estiver desligado
            result = true;
        }
        else
        {
            Stage1dController.decrementScore(5);
            Debug.Log("Desligue o Disjutor!");
        }

        if (Stage1dController.isElementOfGoal(chave: chave))
        { // verifica o elemento é parte do objetivo para poder ter pontuação
            if (result)
            {
                Stage1dController.incrementScore(10);
            }
        }
        return result;
    }
    private static Chave[] returnChavesObjective()
    {
        return new Chave[] { elementosManobra.chave01, elementosManobra.chave02,elementosManobra.chave03,elementosManobra.chave04,
                                elementosManobra.chave05,elementosManobra.chave06,elementosManobra.chave07, elementosManobra.chave08 };
    }
    private static Disjuntor[] returnDisjuntoresObjective()
    {
        return new Disjuntor[] { elementosManobra.disjuntor01,elementosManobra.disjuntor02,elementosManobra.disjuntor03, elementosManobra.disjuntor04 };
    }

    void Update()
    {
        setTextScore();
        if (verificaTransformadorOff())
        {
            this.transformador.GetComponentInChildren<Image>().color = Color.green;
        }

        if (verificaTransformadorOn())
        {
            this.transformador.GetComponentInChildren<Image>().color = Color.red;
        }

        Debug.Log("Objetivos: " + this.maxOjetivos);
        if (this.maxOjetivos == 0)
        {
            this.msgCuidado.SetActive(true);
            Debug.Log("VOCE GANHOU!");
            this.WinText.SetActive(true);
            this.txtStep.SetActive(false);

            EndGameCooldown -= Time.deltaTime;

            if (EndGameCooldown < 0)
            {
                SceneManager.LoadScene("Stage1d");
            }

        }
        else
        {
            if (this.maxOjetivos == 1 && manobraEnergizar())
            {
                this.maxOjetivos--;
                
            }

            if (this.maxOjetivos == 2 && manobraDesenergizar())
            {
                
                --this.maxOjetivos;
                this.txtStep.SetActive(true);

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
}