using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    private Animator anim;
    private Animator aanimTumulo;
    public GameObject tumulo;

    //attack
    public Transform attackCheck;
    public LayerMask layerEnemy;
    public float radiusAttack;
    float timeNextAttack;
    private Inimigo inimigo_variavel;
    public GameObject inimigo;
    public float dano;

    // Start is called before the first frame update
    void Start()
    {
        aanimTumulo = tumulo.GetComponent<Animator>();
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        inimigo_variavel = inimigo.GetComponent<Inimigo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (speed >= 0.1f)
        {
            Move();
        }
        else
        {
            NaoTrocarAngulo();
        }



        //ATTACK
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("AttackFRACO");
        }
        if (timeNextAttack <= 0)
        {
            if (Input.GetButtonDown ("Fire1") && rig.velocity == new Vector2 (0, 0))
            {
                anim.SetTrigger("AttackFRACO");
                timeNextAttack = 0.4f;
                //PlayerAttack ();
            }
        }   else
            {
                timeNextAttack -= Time.deltaTime;
            }


    }
    
    public void Move()
    {
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector3(movement * speed, rig.velocity.y);
        //transform.position += movement * Time.deltaTime * speed;
         
        //direita   
        if (movement > 0f)
        {

        anim.SetBool("Walk", true);
        transform.eulerAngles = new Vector3(0f, 0f, 0f);

        }

        //esquerda
        if (movement < 0f)
        {

        anim.SetBool("Walk", true);
        transform.eulerAngles = new Vector3(0f, 180f, 0f);
        
        }

        //parado
        if (movement == 0f)
        {

        anim.SetBool("Walk", false);
        
        }  
        
    }

    void AnimTermino()
    {
        speed = 2.5f;
    } 

    public void NaoTrocarAngulo()
    {
       speed = 0f;
    }

    void animTumulo()
    {
        aanimTumulo.SetTrigger("covaDestruida");
    }

    void Voltar_Idle()
    {
        anim.SetBool("Idle", true);
    }

    void Flip()
    {
        attackCheck.localPosition = new Vector2 (-attackCheck.localPosition.x, attackCheck.localPosition.y);
    }

    void PlayerAttack()
    {
        Collider2D[] enemiesAttack = Physics2D.OverlapCircleAll (attackCheck.position, radiusAttack, layerEnemy);
        for (int i = 0; i < enemiesAttack.Length; i++) 
        {
            Debug.Log (enemiesAttack [i] .name);
            inimigo_variavel.vida -= dano;
           //enemiesAttack [i].SendMessage ("EnemyHit", "-6");

                
        }  
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackCheck.position, radiusAttack);

    }





}
