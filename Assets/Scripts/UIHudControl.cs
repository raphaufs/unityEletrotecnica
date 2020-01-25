using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//os objetos vao usar esta intancia , padrao single
public class UIHudControl : MonoBehaviour
{
    public static UIHudControl instance;
    public GameObject handCursor;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setHandCursor(bool state){
        handCursor.SetActive(state);
    }

}
