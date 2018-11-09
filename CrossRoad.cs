using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossRoad : MonoBehaviour {

    public GameObject[] TLights;//Status of CrossRoad

    public void MenuInvoker()
    {
        ClearAll();
        CancelInvoke();
        InitializeTLights();
        InvokeRepeating("TrafficManager", 0.0f, 4.0f);
    }

    void ClearAll()
    {
        foreach (GameObject TLight in TLights) TLight.SetActive(false);
    }

    void InitializeTLights()
    {
        if (this.transform.GetComponent<Interactable>().ChosenOptionInt == 1)
        {
            InitializeJust(0, false);
            InitializeJust(2, false);
        }
        else if(this.transform.GetComponent<Interactable>().ChosenOptionInt == 2)
        {
            InitializeJust(0, false);
            InitializeJust(1, true);
            InitializeJust(2, false);
            InitializeJust(3, true);
        }
    }

    void InitializeJust(int TL, bool Status)
    {
        TLights[TL].SetActive(true);
        TLights[TL].GetComponent<TraficLight>().TrafStatus = Status;
    }

    public void TrafficManager()
    {
        foreach (GameObject TLight in TLights)
            if (TLight.activeSelf) TLight.GetComponent<TraficLight>().Invoker();
    }

}
