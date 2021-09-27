using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    GameObject[] obstacleList;
    public int force;
    Rigidbody2D rigid;
    public int score;
    public int highscore;
    string newHighscore = "Data";
    Text highscorePoint;
    public static int health;
    public static int newHealth;
    int HighscoreCetak;
    int index;
    int level;
    Text scorePoint;
    Text healthPoint;
    GameObject panelSelesai;
    GameObject panelLanjut;

    // Start is called before the first frame update
    private void Awake()
    {
        score = 0;
    }
    void Start()
    {
        
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(0, -2).normalized;
        rigid.AddForce(arah * force);       
        scorePoint = GameObject.Find("ScorePoint").GetComponent<Text>();
        
        healthPoint = GameObject.Find("HealthPoint").GetComponent<Text>();
        
        
        
        highscorePoint = GameObject.Find("HighscorePoint").GetComponent<Text>();
        
        //highscore = PlayerPrefs.GetInt("highscore", highscore);
        panelSelesai = GameObject.Find("PanelSelesai");
        panelSelesai.SetActive(false);
        panelLanjut = GameObject.Find("PanelLanjut");
        panelLanjut.SetActive(false);
        TampilkanHealth();
    }
    void OnDisable()
    {
        //highscore = PlayerPrefs.GetInt(newHighscore, 0);
        //PlayerPrefs.SetInt("health", health);
        PlayerPrefs.SetInt(newHighscore, highscore);
    }
    void OnEnable()
    {
        newHealth = PlayerPrefs.GetInt("health");
        highscore = PlayerPrefs.GetInt(newHighscore);
        
    }

    // Update is called once per frame
    void Update()
    {
        newHealth = PlayerPrefs.GetInt("health");
        //HighscoreCetak = PlayerPrefs.GetInt(newHighscore);
        //TampilkanHealth();
        obstacleList = GameObject.FindGameObjectsWithTag("Brick");
        highscorePoint.text = highscore.ToString();


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Brick"))
        {
            float sudut = (transform.position.x - collision.transform.position.x) * 5f;
            Vector2 arah = new Vector2(sudut, rigid.velocity.y).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * force * 1);
            collision.gameObject.SetActive(false);
            score += 1;
            //highscore += 1;
            TampilkanScore();
            //highscore += 1;
            if (score >= highscore)
            {
                highscore += 1;

                PlayerPrefs.SetInt(newHighscore, highscore);
            }
            if (score < highscore )
            {
                highscore += 1;

                PlayerPrefs.SetInt(newHighscore, highscore);
            }
            //PlayerPrefs.SetInt("highscore", highscore);
            /*if (score < highscore)
            {
                highscore += 1;
                PlayerPrefs.SetInt(newHighscore, highscore);
            }
            if (score > highscore )
            {
                highscore += 1;
                
                PlayerPrefs.SetInt(newHighscore, highscore);
            }
            if (score == highscore)
            {
                highscore += 1;
                PlayerPrefs.SetInt(newHighscore, highscore);
            }*/
            if (obstacleList.Length <= 1)
            {
                panelLanjut.SetActive(true);
                //Time.timeScale = 0;
                Destroy(gameObject);
                return;
            }
                        
        }
        if (collision.gameObject.name == "TepiBawah")
        {
            newHealth = PlayerPrefs.GetInt("health");
            health = newHealth + 1;
            TampilkanHealth();
            PlayerPrefs.SetInt("health", health);
            
            
            if (health >= 3)
            {
                panelSelesai.SetActive(true);
                //Time.timeScale = 0;
                health = 0;
                PlayerPrefs.SetInt("health", health);
                Destroy(gameObject);
                return;
            }
            ResetBall();
            Vector2 arah = new Vector2(0, -2).normalized;
            rigid.AddForce(arah * force);
        }
        if (collision.gameObject.name == "Player")
        {
            float sudut = (transform.position.x - collision.transform.position.x) * 5f;
            Vector2 arah = new Vector2(sudut, rigid.velocity.y).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * force * 1);
        }
    }
   
    void ResetBall()
    {
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
    }
    void TampilkanHealth()
    {
        //nextHealth = health - idHealth;
        Debug.Log("Health: " + health);
        healthPoint.text = health + " ";
        //health = PlayerPrefs.GetInt("health", health);
    }
    void TampilkanScore()
    {
        Debug.Log("Score: " + score);
        scorePoint.text = score + " ";
    }
    
}
