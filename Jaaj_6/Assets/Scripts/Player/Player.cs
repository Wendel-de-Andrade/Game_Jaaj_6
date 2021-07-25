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

    // Start is called before the first frame update
    void Start()
    {
        aanimTumulo = tumulo.GetComponent<Animator>();
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
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





}
