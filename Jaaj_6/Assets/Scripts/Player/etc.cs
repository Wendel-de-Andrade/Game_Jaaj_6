using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class etc : MonoBehaviour
{
    public GameObject alma;
    public GameObject inimigo;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
