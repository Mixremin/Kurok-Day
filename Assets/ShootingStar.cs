using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStar : MonoBehaviour
{
    [SerializeField] private GameObject Projectile;
    [SerializeField] private GameObject HideManager;
    // Update is called once per frame
    void Awake() {
        HideManager = GameObject.Find("HideManager");
        HideManager.GetComponent<Reload>().DestroyCopy();
    }
    
    void Update()
    {
        Shoot();
    }

    void Shoot() {
        if (Input.GetButtonDown("Fire1")) 
        {
            Vector3 StartPos = transform.position + transform.forward;
            GameObject bulletTrans = Instantiate(Projectile, StartPos, transform.rotation);

            bulletTrans.GetComponent<ProjPhysics>().Setup();
            Destroy(bulletTrans, 2);
        }
    }
}
