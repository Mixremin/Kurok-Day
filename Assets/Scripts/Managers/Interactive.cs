using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField] private float _MaxDistanceInteract = 1.5f;
    [SerializeField] private float _Lineika = 3.0f;
    
    private static int counter = 0;
    private int MaxKeysFound = 0;

    private GameObject Player;

    private Ray _ray;
    private RaycastHit _hit;

    [Header("Inventory")]
    public bool Shovel = false;
    public int KeyCount = 0;
    public bool HoldingBox = false;
    public bool Arti = false;

    void Start()
    { 
        if (counter > 0) {
            //Debug.Log(counter);
            counter--;
            Destroy(this.gameObject);
        }  else FindPlayer();
    }

    public void FindPlayer() {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        Ray();
        DrawRay();
    }

    void Ray() {
        if(Player == null) {
            FindPlayer();
            KeyCount = MaxKeysFound;
        } 
        else _ray = new Ray(Player.transform.position + new Vector3(0,1,0), Player.transform.forward);
    }
    
    void DrawRay() {
        if ( Physics.Raycast(_ray, out _hit, _MaxDistanceInteract) ) 
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _MaxDistanceInteract, Color.blue);
            Interact();
        }
        if (_hit.transform == null) {
            Debug.DrawRay(_ray.origin, _ray.direction * _Lineika, Color.red);
        }
    }

    void Interact() {
        if(Input.GetKeyDown(KeyCode.E)) {
            switch(_hit.transform.tag) {
                case "Shovel": {
                    if (!Shovel) {
                        _hit.transform.GetComponent<Shovel>().TakeShovel();
                        Shovel = true;
                    }
                    break;
                }
                case "Zaval": {
                    if(Shovel) {
                        _hit.transform.GetComponent<Zaval>().Clean();
                    } else Debug.Log("No Shovel");
                    break;
                }
                case "Door": {
                    if (KeyCount > 0 && !(_hit.transform.GetComponent<DoorScript>().GetOpen())) {
                        KeyCount--;
                        _hit.transform.GetComponent<DoorScript>().OpenDoor();
                    }
                    break;
                }
                case "Box": {
                    if (!HoldingBox) 
                    {
                        _hit.transform.GetComponent<Rigidbody>().isKinematic = true;

                        
                        _hit.transform.parent = Player.transform;
                        _hit.transform.rotation = new Quaternion(0,0,0,0);
                        _hit.transform.localPosition = new Vector3(0,1f,1f);
                        // _hit.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                        // _hit.transform.GetComponent<Rigidbody>().useGravity = false;
                        HoldingBox = true;
                        
                    } else {
                        _hit.transform.parent = null;
                        _hit.transform.GetComponent<Rigidbody>().isKinematic = false;
                        // _hit.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                        // _hit.transform.GetComponent<Rigidbody>().useGravity = true;
                        HoldingBox = false;
                    }
                    break;
                }
                case "Key": {
                    KeyCountPlus();
                    _hit.transform.GetComponent<Keys>().Kill();
                    break;
                }
                case "Arti": {
                    Arti = true;
                    _hit.transform.GetComponent<Keys>().Kill();
                    break;
                }
                
            }
        }
    }

    public void KeyCountPlus() {
        KeyCount++;
        MaxKeysFound++;
    }

    public bool CheckArti() {
        return Arti;
    }

    public void CountPlus() {
            counter++;
    }
}
