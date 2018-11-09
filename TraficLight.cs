using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraficLight : MonoBehaviour {

    public bool TrafStatus; //True = Drive, False = Stop
    public void Invoker()
    {
        TrafStatus = !TrafStatus;
        ChangeColor(TrafStatus);
    }
    void ChangeColor(bool Status)
    {
        this.transform.Find("RedLight").gameObject.SetActive(!TrafStatus);
        this.transform.Find("GreenLight").gameObject.SetActive(TrafStatus);
    }
}
