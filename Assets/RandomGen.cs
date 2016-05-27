using UnityEngine;
using System.Collections;

public class RandomGen  {
    int min;
    int max;
    public RandomGen(int _min, int _max)
    {
        min = _min;
        max = _max;
    }
    public int Randomize
    {
        get { return UnityEngine.Random.Range(min, max); }
    }

}
