using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]private bool isOpened = false;
    [SerializeField]private Animator _anim;

    public bool GetOpen() 
    {
       return isOpened;
    }
    // Start is called before the first frame update
    public void OpenDoor() 
    {
        isOpened = !isOpened;
        _anim.SetBool("isOpened", isOpened);
    }
}
