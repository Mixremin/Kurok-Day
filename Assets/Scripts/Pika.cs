using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pika : MonoBehaviour

{
    [SerializeField] private GameObject InventoryManager;
    [SerializeField] private GameObject HideManager;

    private void Start() {
        HideManager = GameObject.Find("HideManager");
        InventoryManager = GameObject.Find("InventoryManager");
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other) {
        if (other.transform.CompareTag("Player")) {
            HideManager.GetComponent<Reload>().CountPlus();
            InventoryManager.GetComponent<Interactive>().CountPlus();
            SceneManager.LoadScene(0);

            GameObject.DontDestroyOnLoad(HideManager);
            GameObject.DontDestroyOnLoad(InventoryManager);
        }
    }
}
