using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    private static Animation anim = new Animation();
    void Start()
    {
        anim = GetComponent<Animation>();

        anim.Play("startBox");
    }
    void Update()
    {
        
    }
}
