using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Material material;
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        material.color = Color.red;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
