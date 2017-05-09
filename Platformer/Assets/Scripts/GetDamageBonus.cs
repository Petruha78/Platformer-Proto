using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GetDamageBonus : GameElement, IGetBonus
{

    public static bool isGet;

    public void GetBonus()
    {
        int bonus = 15;

        App.knightModel.Damage += bonus;

        isGet = true;
    }
}
