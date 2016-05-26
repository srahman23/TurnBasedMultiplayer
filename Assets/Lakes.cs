using UnityEngine;
using System.Collections;

public class Lakes {
    public int xPos;
    public int zPos;
    public int lakeLength;
    public int lakeHeight;

    public void SetUpLakes(int x, int z, int _lakeLength, int _lakeHeight)
    {
        xPos = x;
        zPos = z;

        lakeLength = _lakeLength;
        lakeHeight = _lakeHeight;
    }
}
