using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{
    #region Fields
    private static Text text;
    #endregion

    #region Start
    void Start()
    {
        text = GetComponent<Text>();
    }
    #endregion

    #region Methods
    public static void textChange(string t)
    {
        text.text = t;
    }
    #endregion
}
