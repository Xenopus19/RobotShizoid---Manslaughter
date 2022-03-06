using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Math {
    public static float Length(float x1, float x2, float y1, float y2) 
        => (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
}
