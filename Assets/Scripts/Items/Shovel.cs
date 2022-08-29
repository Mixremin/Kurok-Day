using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    // Start is called before the first frame update
    public void TakeShovel() {
        Destroy(this.gameObject);
    }
}
