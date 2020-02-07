using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Interactables : MonoBehaviour
{
    public ItemChave item;
    public UnityEvent OnInteract;


    

    void Start()
    {
        
        
    }

      public void LigandoLuz()
    {
        ligaLuz();
    }

    void ligaLuz()
    {
        GameObject lampadaX;
        Light point;
        if (item.getValue() == 0)
        {
            for(int i = 1; i <= 32; i++)
            {
                lampadaX = GameObject.Find("Classic fluorescent lamp Variant (" + i + ")");
                point = lampadaX.GetComponentInChildren<Light>();
                point.range = 6;
            }
            item.setValue(1);
        }
        else
        {
            for (int i = 1; i <= 32; i++)
            {
                lampadaX = GameObject.Find("Classic fluorescent lamp Variant (" + i + ")");
                point = lampadaX.GetComponentInChildren<Light>();
                point.range = 0;
            }
            item.setValue(0);
        }
    }

    }
