using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textp : MonoBehaviour
{
    #region Fields
    private static Text text;
    private static Vector2 position;
    #endregion

    #region Start
    void Start()
    {
        text = GetComponent<Text>();
        position = transform.position;
    }
    #endregion

    #region Update
    private void Update()
    {
        transform.position = position;
    }
    #endregion

    #region Methods
    public static void textChange(string t)
    {
        text.text = t;
    }
    public static void setPos(Vector2 pos)
    {
        pos.y = pos.y + 950;
        if (pos.x >= 0)
        {
            pos.x = (pos.x * 200) + 50;
            text.text = mas.textVarRight[cart.getCartNum()];
        }
        if (pos.x < 0)
        {
            pos.x = (pos.x * 200) + 1200;
            text.text = mas.textVarLeft[cart.getCartNum()];
        }
        position = pos;
    }
    #endregion
}
