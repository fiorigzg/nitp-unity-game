using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obuch : MonoBehaviour
{

    static bool one = false;
    private static Animation anim = new Animation();
    void Start()
    {
        anim = GetComponent<Animation>();
    }
    void Update()
    {
        if(anim.isPlaying == false)
        {
            if (Input.GetMouseButtonDown(0) && one)
            {
                one = false;
                anim.Play("obuchEnd");
                Destroy(this);
            }
        }
    }
    public static void first()
    {
        if (cart.getCartNum() == 2)
        {
            anim.Play("obuch");
            one = true;
        }
    }
}
