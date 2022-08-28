using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjPhysics : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 1.0f;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameObject HideManager;
    [SerializeField] private GameObject pfTakeBullet;
    private Vector3 shootDir;

    public void Setup() {
        shootDir = transform.forward;
        _rb.AddForce(shootDir*bulletSpeed,ForceMode.Impulse);
    }

    private void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Hit");
        _rb.velocity =  Vector3.zero;
        
        if (other.CompareTag("Destroyable"))
        {
            HideManager = GameObject.Find("HideManager");
            //transform.position = new Vector3(0,-10,0);
            //Destroy(other.gameObject);

            if(HideManager.transform.childCount > 0) {
                Destroy(HideManager.transform.GetChild(0).gameObject);
            }
            
            other.transform.parent = HideManager.transform;

            HideManager.GetComponent<Reload>().CountPlus();
            SceneManager.LoadScene(0);

            GameObject.DontDestroyOnLoad(HideManager);

            
        } else {
            GameObject push = Instantiate(pfTakeBullet, transform.position, transform.rotation);
            Vector3 NewDir = Vector3.Reflect(push.transform.forward, other.transform.forward);
            GameObject Player = GameObject.Find("Player");
            //NewDir.x = -NewDir.x;
            push.transform.rotation = Quaternion.Euler(0, 0, 0);

            //push.transform.rotation = new Quaternion(0,-135,0,0);
            push.transform.rotation = Quaternion.FromToRotation(push.transform.forward, NewDir);
            push.GetComponent<Rigidbody>().AddForce(push.transform.forward*40.0f, ForceMode.Impulse);
        }
        Destroy(gameObject);
    }
}