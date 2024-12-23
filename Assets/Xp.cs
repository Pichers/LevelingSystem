using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xp : MonoBehaviour
{
    
    void Update()
    {
        if(transform.position.y <= -5.5){
            Destroy(gameObject);
        }
    }
}
