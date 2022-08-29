using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private GameObject Right_Door;
    [SerializeField] private GameObject Central_Door;
    [SerializeField] private GameObject Left_Door;
    
    public bool left_pressed = false;
    public bool central_pressed = false;
    public bool central2_pressed = false;
    public bool right_pressed = false;

    public void SetState(string plate, bool state) {
        switch(plate) {
            case "c": 
                central_pressed = state;
                break;
            case "c2":
                central2_pressed = state;
                break;
            case "l":
                left_pressed = state;
                break;
            case "r":
                right_pressed = state;
                break;
        }
        DoorCheck();

    }

    private void DoorCheck() {
        if(left_pressed && right_pressed && Central_Door != null) Central_Door.SetActive(false);
        else if (left_pressed && central_pressed && Left_Door != null) Left_Door.SetActive(false);
        else if (central2_pressed && right_pressed && Right_Door != null) Right_Door.SetActive(false);
        else {
            if(Central_Door != null) Central_Door.SetActive(true);
            if (Left_Door != null) Left_Door.SetActive(true);
            if (Right_Door != null) Right_Door.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
