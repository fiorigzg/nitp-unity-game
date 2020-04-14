using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cart : MonoBehaviour
{
    //Fields
    private Animation anim = new Animation();
    private SpriteRenderer sr = new SpriteRenderer();
    private Touch touch = new Touch();
    private Vector2 startPosition;
    private Vector3 startRotation;
    private Vector2 touchPosition;
    private Vector3 touchRotation;
    private Vector2 touchCartPosition;
    private Vector3 touchCartRotation;
    private static Vector2 position;
    private static Vector3 rotation;
    private bool anima = false;
    private int ch = 0;
    private int endDirection;
    private int cartNum = 0;
    public Sprite sprite;

    //Start
    void Start()
    {
        //startPosition.x = 0.15f;
        //startPosition.y = -1f;
        startPosition = transform.position;
        startRotation = transform.eulerAngles;

        anim = GetComponent<Animation>();
        sr = GetComponent<SpriteRenderer>();

        anim["toRight"].speed = 2f;
        anim["toLeft"].speed = 2f;
    }

    //Update
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
                    touchRotation = rotation;
                    touchCartPosition = transform.position;
                    touchCartRotation = transform.eulerAngles;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    position.x = ((touch.position.x - touchPosition.x - -20f) / 300);
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
                    if (ch == 20)
                    {
                        rotation = startRotation;
                        sr.sortingOrder = 1;
                        cartNum++;
                        sr.sprite = mas.pSprites[mas.cartSequence[cartNum]];
                        //controller.textChange(mas.texts[cartNum]);

                        if (endDirection == 1)
                            anim.Play("toLeft");
                        if (endDirection == -1)
                            anim.Play("toRight");
                    }
                }
                else
                {
                    position.x = (position.x - ((position.x - startPosition.x) / 5));
                    position.y = (position.y - ((position.y - startPosition.y) / 5));

                    if (position.x > 0.1)
                        rotation.z = rotation.z + ((360 - rotation.z) / 4);
                    else
                        rotation.z = rotation.z - ((rotation.z - startRotation.z) / 4);

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

    // =============== methods ================
    public void animEnter()
    {
        anima = false;
    }
    public void animMiddle()
    {
        sr.sortingOrder = 3;
    }

    public static Vector2 getPos()
    {
        return position;
    }
    public static Vector3 getRot()
    {
        return rotation;
    }
}
