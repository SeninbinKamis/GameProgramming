using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class AIEnemyController : MonoBehaviour
{
    public float speed;
    public int EnemyHealth = 30;
    public static int EnemyDamage = 1;
    public static bool GiveDamage = false;
    Animator anim;
    GameObject target;
    public UnityEngine.AI.NavMeshAgent agent { get; private set; }
    public AudioSource EnemyAudio;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponentInChildren<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        agent.speed = speed;
        agent.updateRotation = true;
        agent.updatePosition = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.transform.position);
            anim.SetBool("isWalk", true);
        }
        /*if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            anim.SetBool("isDead", true);
        }*/
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Destroy"))
        {
            Debug.Log("mati boss");
            Destroy(gameObject);
        }
    }
    void TakeDamage(int damage)
    {
        EnemyHealth -= damage;
        if(EnemyHealth <= 0)
        {
            anim.SetBool("isDie", true);
            //Destroy(gameObject);
            UIManager.score += 10;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            anim.SetBool("isAttack", true);
            anim.SetBool("isWalk", false);
            GiveDamage = true;
            EnemyAudio.Play();
        }
    }
    private void OnTriggerExit(Collider col)
    {
        anim.SetBool("isAttack", false);
        anim.SetBool("isWalk", true);
        GiveDamage = false;
    }
}
