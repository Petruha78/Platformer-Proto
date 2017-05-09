using UnityEngine;
using System.Collections;
using System;

public class GetHealthBonus : GameElement, IGetBonus  {

    public static bool isGet;

    public void GetBonus()
    {
        int bonus = 10;
        if (App.knight.CurrentHealth <= App.knightModel.Health - bonus)
            App.knight.CurrentHealth += 10;

        else if (App.knightModel.Health >= App.knightModel.Health - bonus && App.knightModel.Health <= App.knightModel.Health)
            App.knight.CurrentHealth = 100;
        isGet = true;
    }

    
}
