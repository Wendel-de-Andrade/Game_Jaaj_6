using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Animator anim;
    public GameObject tumulo;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Debug.Log(speed);
    
    }
    
    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
         
        //direita   
        if (Input.GetAxis("Horizontal") > 0f)
        {

        anim.SetBool("Walk", true);
        transform.eulerAngles = new Vector3(0f, 0f, 0f);

        }

        //esquerda
        if (Input.GetAxis("Horizontal") < 0f)
        {

        anim.SetBool("Walk", true);
        transform.eulerAngles = new Vector3(0f, 180f, 0f);
        
        }

        //parado
        if (Input.GetAxis("Horizontal") == 0f)
        {

        anim.SetBool("Walk", false);
        
        }      
        
    }





}
