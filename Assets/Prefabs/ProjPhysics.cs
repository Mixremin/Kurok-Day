using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjPhysics : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 1.0f;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameObject HideManager;

    private Vector3 shootDir;

    public void Setup() {
        shootDir = transform.forward;
        _rb.AddForce(shootDir*bulletSpeed,ForceMode.Impulse);
    }

    private void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Hit");
        Destroy(gameObject);
        
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

            
        }
    }
}
