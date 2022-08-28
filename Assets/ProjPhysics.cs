using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjPhysics : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 15.0f;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameObject HideManager;
    [SerializeField] private GameObject InventoryManager;
    [SerializeField] private GameObject pfTakeBullet;
    static bool spawned = false;
    private Vector3 shootDir;

    public void Setup() {
        shootDir = transform.forward;
        _rb.AddForce(shootDir*bulletSpeed,ForceMode.Impulse);
    }

    public void SpawnReset() {
        spawned = false;
    }

    private void OnTriggerEnter(Collider other) {
        //Debug.Log("Hit");
        _rb.velocity =  Vector3.zero;
        
        if (other.gameObject.layer == 3)
        {
            HideManager = GameObject.Find("HideManager");
            InventoryManager = GameObject.Find("InventoryManager");
            //transform.position = new Vector3(0,-10,0);
            //Destroy(other.gameObject);

            if(HideManager.transform.childCount > 0) {
                Destroy(HideManager.transform.GetChild(0).gameObject);
            }
            
            other.transform.parent = HideManager.transform;

            HideManager.GetComponent<Reload>().CountPlus();
            InventoryManager.GetComponent<Interactive>().CountPlus();
            SceneManager.LoadScene(0);

            GameObject.DontDestroyOnLoad(HideManager);
            GameObject.DontDestroyOnLoad(InventoryManager);
        } else {
            if(!spawned) {
                spawned = true;
                GameObject push = Instantiate(pfTakeBullet, transform.position, transform.rotation);
                //Vector3 NewDir = Vector3.Reflect(push.transform.forward, other.transform.forward);
                //push.transform.rotation = Quaternion.Euler(0, 0, 0);
                //push.transform.rotation = Quaternion.FromToRotation(push.transform.forward, NewDir);
                //push.transform.Translate(other.transform.forward*2); 
                push.GetComponent<Rigidbody>().AddForce(other.transform.forward*15.0f, ForceMode.Impulse);
            }
            
        }
        Destroy(gameObject);
    }
}
