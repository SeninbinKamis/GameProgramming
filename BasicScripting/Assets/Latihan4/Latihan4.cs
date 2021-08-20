using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latihan4 : MonoBehaviour
{
    Karakter player1;
    // Start is called before the first frame update
    void Start()
    {
        player1 = new Karakter();
        player1.Name = "Kirito";
        player1.Health = 100;
        player1.Damage = 30;

        Debug.Log("Name: " + player1.Name + ", Health: " + player1.Health + ", Damage: " + player1.Damage);

        player1.Jump();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
