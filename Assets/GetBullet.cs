using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBullet : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Collider>().enabled = false;
        StartCoroutine(ToggleColl(0.4f));
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<ShootingStar>().BulletReset();
            Bullet.GetComponent<ProjPhysics>().SpawnReset();
            Destroy(this.gameObject);
        }
    }

    private IEnumerator ToggleColl(float value)
    {
            yield return new WaitForSeconds(value);
            Debug.Log("Toggle");
            GetComponent<Collider>().enabled = true;
    }
}
