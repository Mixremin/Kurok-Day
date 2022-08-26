using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
    [SerializeField] public static int counter = 0;

    void Start() {
        if (counter > 0) {
            Debug.Log(counter);
            counter--;
            Destroy(this.gameObject);
        }
        
    }

    // void FindBullet() {
    //     if(Input.GetButtonDown("Fire1"))
    //         Bullet = GameObject.Find("Projectile(clone)");
    // }

    public void DestroyCopy() { 
        if (transform.childCount > 0) {
            string realName;
            realName = transform.GetChild(0).name;
            transform.GetChild(0).name += "(Hidden)";
            Destroy(GameObject.Find(realName));

            MeshRenderer render = gameObject.GetComponentInChildren<MeshRenderer>();
            BoxCollider coll = gameObject.GetComponentInChildren<BoxCollider>();

            coll.enabled = false;
            render.enabled = false;
        } 
    }

    public void CountPlus() {
            counter++;
    }
    // Update is called once per frame
    void Update()
    {
        //FindBullet();       
    }
}
