using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;



public class Main : MonoBehaviour {

    public static int AppStatus = 0; // 1 - running, 0 - stopping
    public string txtAppStatus = "Drive";

    public static Vector3 CarCoord1;
    public static Vector3 CarCoord2;
    public static Vector3 CarCoord3;
    public static Vector3 CarCoord4;
    public GameObject DebugText;
    ObjectTracker imgTracker;
    public GameObject Car2;
    public GameObject Car3;

    public GameObject CrossRoad; 
    public GameObject[] Cars;//Cars



    void Start () {
        //imgTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
    }	
	void Update () {
		
	}
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 300, 150, 70), txtAppStatus)) StartStop();
    }

    public void StartStop()
    {
        if (AppStatus == 0) //Start
        {
            txtAppStatus = "Stop";
            AppStatus = 1;
            RememberCarsPosition();
            if (Cars == null) Cars = GameObject.FindGameObjectsWithTag("Car");
            foreach (GameObject Car in Cars)
            {
                //Car.GetComponent<Drive>().ChosenOption;
            }
            //DebugText.GetComponent<Text>().text = "123";
        }
        else //Stop
        {
            txtAppStatus = "Drive";
            AppStatus = 0;
            SetCarsPosition();
        }
    }

    private void RememberCarsPosition()
    {
        Cars = GameObject.FindGameObjectsWithTag("Car");
        foreach (GameObject Car in Cars)
        {
            Car.GetComponent<Drive>().InitPosition = Car.transform.position;
        }
    }
    private void SetCarsPosition()
    {
        Cars = GameObject.FindGameObjectsWithTag("Car");
        foreach (GameObject Car in Cars)
        {
            Car.transform.position = Car.GetComponent<Drive>().InitPosition;
        }
    }

}


