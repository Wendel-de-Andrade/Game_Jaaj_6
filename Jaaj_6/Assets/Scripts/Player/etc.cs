using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class etc : MonoBehaviour
{
    public GameObject alma;
    public GameObject inimigo;
    private Rigidbody2D rig;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = inimigo.GetComponent<Animator>();
        rig = inimigo.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Alma()
    {
        alma.SetActive(true);
    }

    void Inimigo()
    {
        inimigo.SetActive(true);
    }

    void FimDa_anim()
    {
        //anim.SetBool("Idle", true);
    }

}
