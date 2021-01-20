using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrBarril : MonoBehaviour
{
    [SerializeField] GameObject explosio;
    [SerializeField]
    Transform[] pickups;
    [SerializeField]
    GameObject powerUp;
    public int Spawns;

    public bool explosivo;

    public bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        Spawns = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == true) Destruccion();

        if (explosivo == false)
        {

            switch (Spawns)
            {
                case 1:
                    pickups[0].gameObject.SetActive(true);
                    pickups[1].gameObject.SetActive(false);
                    pickups[2].gameObject.SetActive(false);
                    pickups[3].gameObject.SetActive(false);
                    pickups[4].gameObject.SetActive(false);
                    break;

                case 2:
                    pickups[0].gameObject.SetActive(true);
                    pickups[1].gameObject.SetActive(true);
                    pickups[2].gameObject.SetActive(false);
                    pickups[3].gameObject.SetActive(false);
                    pickups[4].gameObject.SetActive(false);
                    break;
                case 3:
                    pickups[0].gameObject.SetActive(true);
                    pickups[1].gameObject.SetActive(true);
                    pickups[2].gameObject.SetActive(true);
                    pickups[3].gameObject.SetActive(false);
                    pickups[4].gameObject.SetActive(false);
                    break;
                case 4:
                    pickups[0].gameObject.SetActive(true);
                    pickups[1].gameObject.SetActive(true);
                    pickups[2].gameObject.SetActive(true);
                    pickups[3].gameObject.SetActive(true);
                    pickups[4].gameObject.SetActive(false);
                    break;
                case 5:
                    pickups[0].gameObject.SetActive(true);
                    pickups[1].gameObject.SetActive(true);
                    pickups[2].gameObject.SetActive(true);
                    pickups[3].gameObject.SetActive(true);
                    pickups[4].gameObject.SetActive(true);
                    break;
            }
        }
    }
    void Destruccion()
    {
        Instantiate(explosio, transform.position, transform.rotation);

        foreach (Transform Spawn in pickups)
            if (Spawn.gameObject.activeSelf)
            {
                Instantiate(powerUp, Spawn.position, Spawn.rotation);
            }
       

        Destroy(gameObject);
    }
}
