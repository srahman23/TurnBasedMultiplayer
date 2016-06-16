using UnityEngine;
using System.Collections;

public class Forests : MonoBehaviour {
    public int xPos;
    public int zPos;
    public int forestLength;
    public int forestHeight;

    public void SetUpForests(int x, int z, int _forestLength, int _forestHeight)
    {
        xPos = x;
        zPos = z;

        forestLength = _forestLength;
        forestHeight = _forestHeight;
    }
}
