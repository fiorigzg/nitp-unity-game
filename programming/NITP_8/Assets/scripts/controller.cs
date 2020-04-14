using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{
    #region Fields
    private static Text text;
    private static Animation anim;
    #endregion

    #region properties
    public static Text TextN
    {
        get { return text; }
        set { text = value; }
    }
    #endregion

    #region Start
    void Start()
    {
        text = GetComponent<Text>();
        anim = GetComponent<Animation>();
    }
    #endregion

    #region Methods
    public static void textDisappear()
    {
        anim.Play("textDisappears");
    }
    public static void textAppear()
    {
        anim.Play("textAppears");
    }
    #endregion
}
