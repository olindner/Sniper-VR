using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Sniper : MonoBehaviour
{
    public GameObject bullet = null;
    public float speed = 30f;
    public GameObject reloadingImage = null;
    public Transform muzzleExit = null;
    public AudioClip sniperSound = null;

    private XRGrabInteractable grabInteractable = null;
    private AudioSource audioSource = null;
    private float sniperVolume = 0.7f;
    private bool reloading = false;
    private float reloadingTime = 2f;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        audioSource = GetComponent<AudioSource>();

        reloadingImage.SetActive(false);

        grabInteractable.onActivate.AddListener(FireBullet);
        grabInteractable.onDeactivate.RemoveListener(FireBullet);
    }

    private void FireBullet(XRBaseInteractor interactor)
    {
        if (!reloading) 
        {
            audioSource.PlayOneShot(sniperSound, sniperVolume);

            GameObject instantiatedBullet = Instantiate(bullet, transform.position + Vector3.forward*0.3f, transform.rotation);
            instantiatedBullet.GetComponent<Rigidbody>().velocity = transform.forward * speed;

            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        reloading = true;
        reloadingImage.SetActive(true);

        yield return new WaitForSeconds(reloadingTime);

        reloadingImage.SetActive(false);
        reloading = false;
    }
}
