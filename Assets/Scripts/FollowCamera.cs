using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
 
       void LateUpdate()
    {
        //transform.position = thingToFollow.transform.position + new Vector3 (0,0,-10);
        Vector3 pos = thingToFollow.transform.position + new Vector3 (0,0,-10);
        pos.x = Mathf.Clamp(pos.x, -24.3f, 24.3f);
        pos.y = Mathf.Clamp(pos.y, -9.9f, 9.9f);
        transform.position = pos;
    }
}
