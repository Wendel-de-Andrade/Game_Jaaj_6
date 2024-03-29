using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cercas : MonoBehaviour
{
    private Player player_variavel;
    public GameObject spaceButao;
    public GameObject player;
    public Animator anim;
    public LayerMask paLayer;
    public float radious;
    bool onRadiuos;
    // Start is called before the first frame update
    void Start()
    {
        anim = player.GetComponent<Animator>();
        player_variavel = player.GetComponent<Player>();
    }

    // Update is called once per frame
    public void Update()
    {

        if (onRadiuos)
        {
            spaceButao.SetActive(true);
        }
        else if (!onRadiuos)
        {
            spaceButao.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.Space) && onRadiuos)
        {
            anim.SetTrigger("PazadaT");
            //player_variavel.speed = 0;
            player_variavel.GetComponent<Rigidbody2D>().velocity = Vector2.zero;;
        }
        
            
        
        
    }


    private void FixedUpdate()
    {
        Interact();
    }
    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, paLayer);
        if (hit != null)
        {
           onRadiuos = true;
        }
        else
        {
           onRadiuos = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }


    void Destroy()
    {
        spaceButao.SetActive(false);
        gameObject.SetActive(false);
        Debug.Log("tumulo foi de base");
    }
}
