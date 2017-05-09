using UnityEngine;
using System.Collections;

public class HitPointColor  {

    
        public static Gradient thisGradient = new Gradient();
        public static GradientColorKey[] gck;
        public static GradientAlphaKey[] gak;


        public static Color SetGradient(Color a, Color b, float t)
        {
            Color color;

            gck = new GradientColorKey[2];
            gck[0].color = a;
            gck[0].time = 0.0f;
            gck[1].color = b;
            gck[1].time = 1.0f;
            

            gak = new GradientAlphaKey[2];
            gak[0].alpha = 1.0f;
            gak[0].time = 0.0f;
            gak[1].alpha = 1.0f;
            gak[1].time = 1.0f;
            

            thisGradient.SetKeys(gck, gak);
            color = thisGradient.Evaluate(t);
            return color;
        }


    
}
