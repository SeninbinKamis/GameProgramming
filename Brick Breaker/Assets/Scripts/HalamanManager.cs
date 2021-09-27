using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class HalamanManager : MonoBehaviour
{
    public bool isEscapeToExit;
    public GameObject MenuPanel;
    public GameObject SettingsPanel;
    public AudioMixer audioMixer;
    int newIndex;
    public int index;
    public int level;
    BallController ballController;
    // Start is called before the first frame update
    void Start()
    {
        /*MenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);*/
    }
    void OnDisable()
    {
        PlayerPrefs.SetInt("level", index);
    }
    void OnEnable()
    {
         newIndex = PlayerPrefs.GetInt("level");

    }
    // Update is called once per frame
    void Update()
    {
       
        
    }
    public void MulaiPermainan()
    {
        BallController.health = 0;
        SceneManager.LoadScene("Main");
        
    }
    public void KembaliKeMenu()
    {
        SceneManager.LoadScene("Menu");
        /*MenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);*/
    }
    public void MasukPengaturan()
    {
        MenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void LanjutLevel()
    {
        
        index = newIndex + 1;
        Debug.Log("index :" + index);
        level = index + 1;
        SceneManager.LoadScene(level);
        //index = level;
        
    }
}

