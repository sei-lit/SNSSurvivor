using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator playerAnimator;
    bool isRunning = false;
    public GameObject[] roads;
    public GameObject[] backgroundCities;
    float roadSpeed = 100;
    float backgroundCitySpeed = 30;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning) {
            MovebackgroundCities();
            MoveRoads();
        } else {

        }
    }

    public void Run() {
        isRunning = true;
        playerAnimator.SetBool("isRunning", true);
    }

    public void Stop() {
        isRunning = false;
        playerAnimator.SetBool("isRunning", false);
    }

    void MoveRoads() {
        for(int i = 0; i < roads.Length; i++) {
            roads[i].transform.position += new Vector3(-roadSpeed * Time.deltaTime, 0, 0);
        }

        if(roads[0].transform.position.x < -800) {
            roads[0].transform.position = new Vector3(800, -94, 0);
        } else if(roads[1].transform.position.x < -800) {
            roads[1].transform.position = new Vector3(800, -94, 0);
        }
    }

    void MovebackgroundCities() {
        for(int i = 0; i < backgroundCities.Length; i++) {
            backgroundCities[i].transform.position += new Vector3(-backgroundCitySpeed * Time.deltaTime, 0, 0);
        }

        if(backgroundCities[0].transform.position.x < -800) {
            backgroundCities[0].transform.position = new Vector3(800, -94, 0);
        } else if(backgroundCities[1].transform.position.x < -800) {
            backgroundCities[1].transform.position = new Vector3(800, -94, 0);
        }
    }
}
