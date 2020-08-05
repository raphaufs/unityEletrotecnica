using TMPro;
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
    private static int scoreGame = 1000;
    private float EndGameCooldown = 3.0f;

    public void setTextScore()
    {
        GameObject objScoreText = GameObject.Find("ScoreGame");
        TextMeshProUGUI scoreText = objScoreText.GetComponent<TextMeshProUGUI>();
        scoreText.SetText("Pontuação:" + scoreGame);
        if (scoreGame <= 500)
        {
            scoreText.color = new Color32(255, 0, 0, 255);
        }
    }
    public static void decrementScore(int value)
    {
        scoreGame -= value;
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

    private bool manobraDesenergizar()
    {
        return (
                elementosManobra.chave01.getStatus() &&
                elementosManobra.chave02.getStatus() &&
                elementosManobra.chave03.getStatus() &&
                elementosManobra.chave04.getStatus() &&
                elementosManobra.chave05.getStatus() &&
                elementosManobra.chave06.getStatus() &&
                elementosManobra.disjuntor01.getStatus() &&
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
                !elementosManobra.disjuntor01.getStatus() &&
                !elementosManobra.disjuntor03.getStatus() &&
                !elementosManobra.disjuntor04.getStatus()
            );
    }


    public static bool mudarStatus(Stage1dView botao)
    {
        string nome = botao.getNome();
        bool result = false;
        int indexOfElement = nome.Contains("Disjuntor") ? elementosManobra.findDisjuntorIndexByName(nome) : elementosManobra.findChaveIndexByName(nome);
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
        return result;
    }
    bool verificaTransformadorOff()
    {
        return (elementosManobra.disjuntor01.getStatus() &&
                elementosManobra.disjuntor02.getStatus() &&
                elementosManobra.chave01.getStatus() &&
                elementosManobra.chave02.getStatus());
    }
    bool verificaTransformadorOn()
    {
        return (!elementosManobra.disjuntor01.getStatus() &&
                !elementosManobra.disjuntor02.getStatus() &&
                !elementosManobra.chave01.getStatus() &&
                !elementosManobra.chave02.getStatus());
    }

    static bool verificarDisjuntor(int indexDisjuntor)
    {
        bool disjuntorStatus = elementosManobra.listOfDisjuntores[indexDisjuntor].getStatus();

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
            }
            else
            {
                Stage1dController.decrementScore(50);
                Debug.Log("Desligue as Chaves!");
            }
        }
        else
        {
            if ((!disjuntorStatus) || //se disjuntor estiver desligado
                  (disjuntorStatus && !chave1Status))
            {//se a chave estiver desligada e o disjuntor estiver ligado
                result = true;
            }
            else
            {
                Stage1dController.decrementScore(50);
                Debug.Log("Desligue a Chave!");
            }
        }

        return result;
    }

    static bool verificarChave(int indexChave)
    {
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
            Stage1dController.decrementScore(50);
            Debug.Log("Desligue o Disjutor!");
        }
        return result;
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