using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public GameObject player;
    PlayerController playerController;
    public GameObject[] roads;
    public GameObject[] backgroundCities;
    public GameObject[] snsCityImages;

    public GameObject canvasOffset;
    public float roadSpeed = 150;
    public float backgroundCitySpeed = 40;
    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isRunning) {
            MovebackgroundCities();
            MoveRoads();
        } 

        if (playerController.isDead) {
            roadSpeed = 0;
            backgroundCitySpeed = 0;
        }

        if (playerController.isSNSMode) {
            snsCityImages[0].SetActive(true);
            snsCityImages[1].SetActive(true);
        } else {
            snsCityImages[0].SetActive(false);
            snsCityImages[1].SetActive(false);
        }
    }

    void MoveRoads() {
        for(int i = 0; i < roads.Length; i++) {
            roads[i].transform.position += new Vector3(-roadSpeed * Time.deltaTime, 0, 0);
        }

        for(int i = 0; i < roads.Length; i++) {
            if(roads[i].transform.position.x < -720 + canvasOffset.transform.position.x) {
                roads[i].transform.position = new Vector3(800 - 88 + canvasOffset.transform.position.x, canvasOffset.transform.position.y, 1);
            }
        }
    }

    void MovebackgroundCities() {
        for(int i = 0; i < backgroundCities.Length; i++) {
            backgroundCities[i].transform.position += new Vector3(-backgroundCitySpeed * Time.deltaTime, 0, 0);
        }

        for(int i = 0; i < backgroundCities.Length; i++) {
            if(backgroundCities[i].transform.position.x < -720 + canvasOffset.transform.position.x) {
                backgroundCities[i].transform.position = new Vector3(800 - 88 + canvasOffset.transform.position.x, canvasOffset.transform.position.y, 1);
            }
        }
    }
}
