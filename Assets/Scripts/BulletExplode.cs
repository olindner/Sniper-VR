using UnityEngine;

public class BulletExplode : MonoBehaviour
{
    public GameObject ExplosionOnMetal = null;
    public GameObject ExplosionOnStone = null;
    public GameObject ExplosionOnWood = null;
    public GameObject ExplosionOnEnemy = null;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject localExplosion = null;
        float duration = 5f;
        switch (collision.gameObject.tag)
        {
            case "Metal":
                localExplosion = Instantiate(ExplosionOnMetal, transform.position, ExplosionOnMetal.transform.rotation);
                break;
            case "Stone":
                localExplosion = Instantiate(ExplosionOnStone, transform.position, ExplosionOnStone.transform.rotation);
                break;
            case "Wood":
                localExplosion = Instantiate(ExplosionOnWood, transform.position, ExplosionOnWood.transform.rotation);
                break;
            case "Enemy":
                localExplosion = Instantiate(ExplosionOnEnemy, transform.position, ExplosionOnEnemy.transform.rotation);
                duration = 1f;
                break;
            default:
                break;
        }

        if (localExplosion != null)
        {
            Destroy(localExplosion, duration);
        }

        Destroy(gameObject);
    }
}
