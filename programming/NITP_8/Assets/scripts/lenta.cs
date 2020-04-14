using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lenta : MonoBehaviour {
    static Animation anim;
    static SpriteRenderer sr;
    void Start()
    {
        anim = GetComponent<Animation>();
        sr = GetComponent<SpriteRenderer>();
    }
    public static void lentaAnimation(int num)
    {
        sr.sprite = mas.pLentaSprites[num];
        anim.Play("lenta");
    }
}
