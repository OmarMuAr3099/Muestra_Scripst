using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrToken : MonoBehaviour
{
    [SerializeField] GameObject explosio;
    public bool token = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (token == true) Destruccion();
    }
    void Destruccion()
    {
        Instantiate(explosio, transform.position, transform.rotation);


        Destroy(gameObject);
    }
}
