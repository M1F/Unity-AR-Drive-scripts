using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{

    public int direction = 0; //-1 - Left, 0 - Forward, 1 - Right
    public Vector3 InitPosition;
    public int CurrentCarStatus = 1;
    public GameObject CurrentCollider;
    public Interactable inter;
    public int dir;
    public string zalupa;
    int TurnPoint = 0;
    float krugach = 0;
    float krugach_temp = 0;

    void Start()
    {

    }

    IEnumerator Go()
    {
        transform.position -= this.transform.up * Time.deltaTime * 2;
        yield return null;
    }

    void Update()
    {
        if (Main.AppStatus == 1 && CurrentCarStatus == 1)
        {
            transform.position -= this.transform.up * Time.deltaTime * 2;

            if (direction == -1 && TurnPoint == 1)
            {
                if (krugach_temp > krugach - 90)
                {
                    transform.RotateAround(transform.position, Vector3.up, -Time.deltaTime * 40);
                    krugach_temp = krugach_temp - 0.65f;
                }
            }

            if (direction == 1 && TurnPoint == 1)
            {
                if (krugach_temp < krugach + 90)
                {
                    transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * 40);
                    krugach_temp = krugach_temp + 0.65f;
                }
            }
        }


        if (CurrentCollider != null)
        {
            if (CurrentCollider.GetComponent<Collider>().enabled != true)
            {
                CurrentCarStatus = 1;
            }
        }
    }

    public void CarDriveStatus()
    {
        //return 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Contains("TraficLight"))
        {
            CurrentCarStatus = 0;
            CurrentCollider = other.gameObject;
        }
    }

    string name;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("TraficLight"))
        {
            name = other.gameObject.name;
            //other.gameObject.GetComponent("name") as string;
            CurrentCarStatus = 0;
            CurrentCollider = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "turnCol")
        {
            TurnPoint = 1;
            krugach = this.transform.eulerAngles.y + 500;
            krugach_temp = this.transform.eulerAngles.y + 500;
        }
    }
}
