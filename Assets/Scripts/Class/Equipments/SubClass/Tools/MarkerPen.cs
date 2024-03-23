using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerPen : Tool
{
    private static MarkerPen markerPen = new MarkerPen();

    public static MarkerPen Current => markerPen;
    private MarkerPen() {
        name = "マーカーペン";
        assets = 1;
        intelligence = 1;
    }
}
