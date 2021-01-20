using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrCamara : MonoBehaviour
{
    [SerializeField]
    Transform Erin;

   

    public Vector2 minCamPos, maxCamPos;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(Erin.position.x,minCamPos.x,maxCamPos.x),
            Mathf.Clamp(Erin.position.y+offset,minCamPos.y,maxCamPos.y), 
            transform.position.z);
        
       
    }
}
