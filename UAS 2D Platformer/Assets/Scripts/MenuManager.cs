using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject GamePanel;
    public GameObject HowtoPanel;
    private GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<PlayerController>() = Vector3.zero;
        
        //gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
        MenuPanel.SetActive(true);
        GamePanel.SetActive(false);
        HowtoPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButtonClicked()
    {
        Application.LoadLevel("Gameplay");
        
    }
    public void MenuButtonClicked()
    {
        SceneManager.LoadScene("Menu");
    }
    public void QuitButtonClicked()
    {
        Application.Quit();
    }
    public void HowtoButton()
    {
        HowtoPanel.SetActive(true);
        MenuPanel.SetActive(false);
    }

}
