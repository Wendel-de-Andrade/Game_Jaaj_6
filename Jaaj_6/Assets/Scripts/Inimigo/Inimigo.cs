using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private Animator anim;
    public float speed;
    public float distanciaParar;
    public bool ladoDireito = false;
    private Transform alvo;
    public bool seguir = true;

    public float vida;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        alvo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, alvo.position) > distanciaParar)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(alvo.position.x, transform.position.y), speed * Time.deltaTime);
            seguir = true;
            anim.SetBool("WalkE", seguir);
        }
        else
        {
            seguir = false;
            anim.SetBool("WalkE", seguir);

        }

        if ((transform.position.x - alvo.position.x) < 0 && !ladoDireito)
        {
            vire();
        }

        if ((transform.position.x - alvo.position.x) > 0 && ladoDireito)
        {
            vire();
        }



        //VIDA
        if (vida <= 0f)
        {
            Destroy(gameObject);
        }
    }  

    void vire()
    {
        ladoDireito =! ladoDireito;
        Vector2 novoScale = new Vector2(transform.localScale.x * - 1, transform.localScale.y);
        transform.localScale = novoScale;
    }

}
