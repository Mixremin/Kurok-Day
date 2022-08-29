using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlate : MonoBehaviour

{
    [SerializeField] private GameObject InventoryManager;

    private void Start() {
        InventoryManager = GameObject.Find("InventoryManager");
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other) {
        if (other.transform.CompareTag("Player") && !InventoryManager.GetComponent<Interactive>().CheckArti()) {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Collider>().enabled = false;
        }
    }
}
