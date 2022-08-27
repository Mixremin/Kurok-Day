using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Collider>().enabled = false;
        StartCoroutine(ToggleColl(1f));
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<ShootingStar>().BulletReset();
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
