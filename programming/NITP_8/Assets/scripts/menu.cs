using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    private Touch touch = new Touch();
    private bool isVisible = false;
    private Animation anim;
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        if (anim.isPlaying == false)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && touch.position.x >= 900 && touch.position.y >= 1750)
            {
                if (!isVisible)
                {
                    anim.Play("settingsUp");
                    controller.textDisappear();
                    //cart.getAudio().PlayOneShot(mas.pAudios[2]);
                }
                else
                {
                    anim.Play("settingsDown");
                    controller.textAppear();
                    //cart.getAudio().PlayOneShot(mas.pAudios[1]);
                }
                isVisible = !isVisible;
            }
        }
    }
}
