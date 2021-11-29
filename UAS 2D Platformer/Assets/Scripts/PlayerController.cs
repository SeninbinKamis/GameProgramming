using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    GameObject[] cherryList;
    public bool isJump = true;
    bool isDash = false;
    bool isDead = false;
    public bool isMove;
    int idMove = 0;
    int speed = 1;
    Animator anim;
    //public GameObject MenuPanel;
    public GameObject GamePanel;
    public GameObject MenangPanel;
    public GameObject KalahPanel;
    public GameObject CherryPanel;
    public bool isFacingRight = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        //MenuPanel.SetActive(true);
        //GamePanel.SetActive(false);
        MenangPanel.SetActive(false);
        KalahPanel.SetActive(false);
        CherryPanel.SetActive(false);
        Data.score = 0;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        cherryList = GameObject.FindGameObjectsWithTag("Coin");
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Dash();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Idle();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Idle();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            
            Idle();
        }
        Move();
        Dead();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isJump)
        {
            anim.ResetTrigger("jump");
            if (idMove == 0) anim.SetTrigger("idle");
            isJump = false;
        }
        if (isDash)
        {
            anim.ResetTrigger("dash");
            if (idMove == 0) anim.SetTrigger("idle");
            isDash = false;
        }
        if (collision.transform.tag.Equals("Batas"))
        {
            isJump = true;
        }
        if (collision.transform.tag.Equals("Enemy") && isDash)
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetTrigger("jump");
        anim.ResetTrigger("run");
        anim.ResetTrigger("idle");
        anim.ResetTrigger("dash");
        isJump = true;
        isDash = true;
        if (collision.transform.tag.Equals("Enemy") && isDash)
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Batas"))
        {
            Debug.Log("Batas");
        }
        if (collision.transform.tag.Equals("Enemy") && !isDash)
        {
            isDead = true;
            Dead();
        }
        if (collision.transform.tag.Equals("Enemy") && isDash)
        {
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag.Equals("Obstacle") && !isDash)
        {
            isDead = true;
            Dead();
            KalahPanel.SetActive(true);
        }
    }
    public void MoveRight()
    {
        idMove = 1;
    }
    public void MoveLeft()
    {
        idMove = 2;
    }
    private void Move()
    {
        if (idMove == 1 && !isDead && isMove)
        {
            if (!isJump) anim.SetTrigger("run");
            transform.Translate(speed * Time.deltaTime * 5f, 0, 0);
            transform.localScale = new Vector3(4f, 4f, 1f);
            isFacingRight = true;
        }
        if (idMove == 2 && !isDead && isMove)
        {
            if (!isJump) anim.SetTrigger("run");
            transform.Translate(-1 * speed * Time.deltaTime * 5f, 0, 0);
            transform.localScale = new Vector3(-4f, 4f, 1f);
            isFacingRight = false;
        }
        //if (MenuPanel.SetActive(true))
        
    }
    public void Jump()
    {
        if (!isJump && isMove && !isDead)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
        }
    }
    public void Dash()
    {
        if (!isDash && isMove && !isJump && isFacingRight)
        {
            idMove = 1;
            speed = 3;
            isDash = true;
            anim.ResetTrigger("jump");
            anim.ResetTrigger("run");
            anim.ResetTrigger("idle");
            anim.SetTrigger("dash");
            transform.Translate(speed * Time.deltaTime * 5f, 0, 0);
            transform.localScale = new Vector3(4f, 4f, 1f);
            
        }
        if (!isDash && isMove && !isJump && !isFacingRight)
        {
            idMove = 2;
            speed = 3;
            isDash = true;
            anim.ResetTrigger("jump");
            anim.ResetTrigger("run");
            anim.ResetTrigger("idle");
            anim.SetTrigger("dash");
            transform.Translate(-1 * speed * Time.deltaTime * 5f, 0, 0);
            transform.localScale = new Vector3(-4f, 4f, 1f);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Coin"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);
            
        }
        if (collision.transform.tag.Equals("Door") && cherryList.Length >= 1)
        {
            CherryPanel.SetActive(true);
        }
        if (collision.transform.tag.Equals("Door") && cherryList.Length < 1)
        {
            MenangPanel.SetActive(true);
        }
      
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Door") && cherryList.Length >= 1)
        {
            CherryPanel.SetActive(false);
        }
    }
    public void Idle()
    {
        if (!isJump && !isDash)
        {
            anim.ResetTrigger("jump");
            anim.ResetTrigger("run");
            anim.ResetTrigger("dash");
            anim.SetTrigger("idle");
        }
        idMove = 0;
        speed = 1;
    }
    private void Dead()
    {
        if (!isDead && !isDash)
        {

            if (transform.position.y < -10f)
            {
                
                anim.ResetTrigger("jump");
                anim.ResetTrigger("run");
                anim.ResetTrigger("idle");
                anim.ResetTrigger("dash");
                anim.SetTrigger("dead");
                isDead = true;
            }
        }
        if (isDead && !isDash)
        {
            anim.ResetTrigger("jump");
            anim.ResetTrigger("run");
            anim.ResetTrigger("idle");
            anim.ResetTrigger("dash");
            anim.SetTrigger("dead");
        }
    }
    /*public void PlayButtonClicked()
    {
        //Application.LoadLevel("Gameplay");
        MenuPanel.SetActive(false);
        GamePanel.SetActive(true);
        isMove = true;
    }
    public void QuitButtonClicked()
    {
        Application.Quit();
    }*/

}
