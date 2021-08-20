using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prajurit : Manusia
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Start()
    {
        Debug.Log("Seorang Prajurit dapat : ");
        Makan();
        Tidur();
        Menyerang();
    }
    void Update()
    {
        
    }
    void Menyerang()
    {
        Debug.Log("Menyerang");
    }
}
