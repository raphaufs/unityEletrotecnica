using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public List<GameObject> cutScenes = new List<GameObject>();
    public Camera main;

    public void startCutscene(int id)
    {
        main.gameObject.SetActive(false);
        cutScenes[id].SetActive(true);
    }

    public void StopCutscene(int id)
    {
        main.gameObject.SetActive(true);
        cutScenes[id].SetActive(false); 
    }
}
