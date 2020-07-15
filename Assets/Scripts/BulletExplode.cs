using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SearchService;

public class BulletExplode : MonoBehaviour
{
    public GameObject ExplosionOnMetal = null;
    public GameObject ExplosionOnStone = null;
    public GameObject ExplosionOnWood = null;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject localExplosion = null;
        Vector3 normal = collision.contacts[0].normal;
        normal.y *= -1;

        switch (collision.gameObject.tag)
        {
            case "Metal":
                localExplosion = Instantiate(ExplosionOnMetal, transform.position, ExplosionOnStone.transform.rotation);
                break;
            case "Stone":
                localExplosion = Instantiate(ExplosionOnStone, transform.position, ExplosionOnStone.transform.rotation);
                break;
            case "Wood":
                localExplosion = Instantiate(ExplosionOnWood, transform.position, ExplosionOnStone.transform.rotation);
                break;
            default:
                break;
        }

        if (localExplosion != null) Destroy(localExplosion, 5f);
        Destroy(gameObject);
    }
}
