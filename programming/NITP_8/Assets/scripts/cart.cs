using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cart : MonoBehaviour
{
    //Класс карты  

    #region Fields
    private static Animation anim = new Animation();
    private static SpriteRenderer sr = new SpriteRenderer();
    private static AudioSource nAudio = new AudioSource();

    private static Touch touch = new Touch();
    private static Vector2 startPosition;
    private static Vector3 startRotation;
    private static Vector2 touchPosition;
    private static Vector2 position;
    private static Vector3 rotation;

    private static bool anima = false;
    private static int ch = 0;
    private static int endDirection;
    private static int cartNum = 0;
    #endregion

    #region properties 
    public static Vector2 Position
    {
        get { return position; }
        private set { position = value; }
    }
    public static Animation Animation
    {
        get { return anim; }
        private set { anim = value; }
    }
    public static int CartNum
    {
        get { return cartNum; }
        private set { CartNum = value; }
    }
    public static AudioSource NAudio
    {
        get { return nAudio; }
        private set { nAudio = value; }
    }
    #endregion

    #region Start
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.eulerAngles;

        anim = GetComponent<Animation>();
        sr = GetComponent<SpriteRenderer>();
        nAudio = GetComponent<AudioSource>();

        anim.Play("start");

        anim["toRight"].speed = 2f;
        anim["toLeft"].speed = 2f;
    }
    #endregion

    #region Update
    void Update()
    {
        if (anim.isPlaying == false)
        {
            position = transform.position;
            rotation = transform.eulerAngles;
            if (anima == false)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    touchPosition = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    position.x = ((touch.position.x - touchPosition.x - -20f) / 200);
                    position.y = ((touch.position.y - touchPosition.y - 1150) / 1100);
                    rotation.z = ((touch.position.x - touchPosition.x - 1.5f) / 50) * -1;

                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    anima = true;
                    ch = 0;
                }
            }
            else
            {
                if (position.x > 1.1f || position.x < -1.1f)
                {
                    if (position.x > 1.1f)
                        endDirection = 1;
                    if (position.x < -1.1f)
                        endDirection = -1;

                    position.x = position.x + endDirection * 1f;

                    ch++;
                    if(ch == 1)
                        nAudio.PlayOneShot(mas.pAudios[0]);
                    if (ch == 20)
                    {
                        cartChange();
                    }
                }
                else
                {
                    position.x = (position.x - ((position.x - startPosition.x) / 5));
                    position.y = (position.y - ((position.y - startPosition.y) / 5));

                    if (rotation.z > 300)
                    {
                        rotation.z = rotation.z + ((360 - rotation.z) / 4);
                    }
                    else 
                    {
                        rotation.z = rotation.z - ((rotation.z - startRotation.z) / 4);
                    }



                    ch++;
                    if (ch == 20)
                    {
                        position.x = startPosition.x;
                        position.y = startPosition.y;
                        rotation.z = startRotation.z;
                        anima = false;
                    }
                }
            }
            transform.position = position;
            transform.eulerAngles = rotation;
        }
    }
    #endregion

    #region Methods
    //public 
    public void animEnter()
    {
        anima = false;
    }
    public void animMiddle()
    {
        sr.sortingOrder = 3;
    }
    public static void cartChange()
    {
        rotation = startRotation;
        sr.sortingOrder = 1;
        cartNum = vebor.cartNum(cartNum, endDirection);
        sr.sprite = mas.pSprites[mas.cartSequence[cartNum]];
        controller.TextN.text = mas.texts[cartNum];

        vebor.playChange(cartNum);

        if (endDirection == 1)
            anim.Play("toLeft");
        if (endDirection == -1)
            anim.Play("toRight");
    }
    #endregion
}
