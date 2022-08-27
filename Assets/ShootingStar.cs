using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStar : MonoBehaviour
{
    [SerializeField] private GameObject Projectile;
    [SerializeField] private GameObject HideManager;
    [SerializeField] private bool HaveBullet = true;
    // Update is called once per frame
    void Awake() {
        HideManager = GameObject.Find("HideManager");
        HideManager.GetComponent<Reload>().DestroyCopy();
    }
    
    void Update()
    {
        Shoot();
    }

    public void BulletReset() {
        HaveBullet = true;
    }

    void Shoot() {
        if(HaveBullet) {
            if (Input.GetButtonDown("Fire1")) 
            {
                Vector3 StartPos = transform.position + transform.forward;
                GameObject bulletTrans = Instantiate(Projectile, StartPos, transform.rotation);

                bulletTrans.GetComponent<ProjPhysics>().Setup();
                HaveBullet = false;
                Destroy(bulletTrans, 2);
            }
        }
    }
}
