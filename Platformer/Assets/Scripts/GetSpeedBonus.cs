using UnityEngine;
using System.Collections;
using System;

public class GetSpeedBonus : GameElement, IGetBonus
{
    public static bool isGet;

    public void GetBonus()
    {
        float bonus = 0.5f;

        App.knightModel.Speed += bonus;
        isGet = true;
    }
}
