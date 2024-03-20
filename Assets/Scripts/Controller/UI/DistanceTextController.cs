using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceTextController : MonoBehaviour
{
    Player player = Player.Current;
    int distance;
    public Text distanceText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = (int)player.GetDistance();
        distanceText.text = distance.ToString() + "km";
    }
}
