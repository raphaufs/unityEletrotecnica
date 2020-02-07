using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{
    public float Raydistance =1.5f;
    private Camera myCam;
    private Interactables currentInteractables;

    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        checkInteractables();
    }
    void checkInteractables()
    {
        RaycastHit hit; //essa variavel guarda as informaçoes do objeto que o raycast se colidiu 
        Vector3 rayOrigin = myCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));

        if(Physics.Raycast(rayOrigin,myCam.transform.forward,out hit, Raydistance))
        {
            // se o objeto tiver a o script Interactables vai colidir.
            Interactables interactable = hit.collider.GetComponent<Interactables>();
            if(interactable != null)
            {
                UIHudControl.instance.setHandCursor(true);
                //butao 0 seria o da esquerda .
                if (Input.GetMouseButtonDown(0))
                {
                    //o item atual da interaçao recebe do hit
                    currentInteractables = interactable;

                    //aqui no caso serve pra da play na animação ... 
                    currentInteractables.OnInteract.Invoke();

                    //se for a chave 1 vai ligar as luzes da casa 
                    if (currentInteractables.item.id == 1)
                    {
                        currentInteractables.LigandoLuz();
                    }

                    //aqui poderia verificar se o item e possivel usar ... acessando currentInteractables.item

                    Debug.Log("Item Ativado :" + currentInteractables.name);                    
                    
                }
            }
            else
            {
                UIHudControl.instance.setHandCursor(false);
            }
        }
        else
        {
            UIHudControl.instance.setHandCursor(false);
        }
    }
}
