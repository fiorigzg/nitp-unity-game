using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vebor : MonoBehaviour
{
    #region Fields
    static bool allPlay = false;
    static int veb;
    Vector2 position;
    #endregion

    #region Start
    void Start()
    {
    }
    #endregion

    #region Update
    void Update()
    {
        if(cart.getAnim().isPlaying == false && allPlay)
        {
            if (cart.getPos().x > 0.1f && cart.getPos().x < 1.75f)
            {
                position.x = -((cart.getPos().x * 4) - 10f);
            }
            else if (cart.getPos().x < -0.1f && cart.getPos().x > -1.75f)
            {
                position.x = -((cart.getPos().x * 4) + 10f);
            }

            transform.position = position;
        }
        else 
        {
            if(position.x > 0)
                position.x = position.x + 0.2f;
            if (position.x <= 0)
                position.x = position.x - 0.2f;
            transform.position = position;
        }
        textp.setPos(position);
    }
    #endregion

    #region Methods
    public static void playChange(int a)
    {
        allPlay = false;
        if (mas.veborCarts[a] > 0)
            allPlay = true;
    }
    public static int cartNum(int lastCartNum, int a)
    {
        veb = lastCartNum;

        if (lastCartNum == 2 && a == 1f) veb = 29;
        else if (lastCartNum == 9 && a == 1f) veb = 17;
        else if (lastCartNum == 3) veb = 4;
        else if (lastCartNum == 28) veb = 0;
        else if (lastCartNum == 15) veb = 0;
        else veb++;

        return veb;
    }
    #endregion 
}
