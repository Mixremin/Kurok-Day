using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatePress : MonoBehaviour
{   
    [SerializeField] private string id;
    [SerializeField] private GameObject DoorManager;
    public bool pressed = false;

    void Start() {
        DoorManager = GameObject.Find("DoorManager");
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other) {
        if(other.transform.CompareTag("Box")) {
            pressed = true;
            DoorManager.GetComponent<DoorManager>().SetState(id, pressed);
        }
    }
    private void OnCollisionExit(Collision other) {
        if(other.transform.CompareTag("Box")) {
            pressed = false;
            DoorManager.GetComponent<DoorManager>().SetState(id, pressed);
        }
    }
}
