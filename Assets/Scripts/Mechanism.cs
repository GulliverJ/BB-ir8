using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mechanism : MonoBehaviour
{
    public string deviceName;
    public bool isBroken = false;
    public Text pressF;
    public BreakageManager manager;
    public Highlighter icon;

    public void BreakMechanism()
    {
        isBroken = true;
    }

    void FixMechanism()
    {
        isBroken = false;
        pressF.enabled = false;
        manager.HasBeenFixed();
        icon.SetTarget(null);
    }

    void OnTriggerStay(Collider other)
    {
        if(isBroken)
        {
            if (other.gameObject.name == "BB-8")
            {
                pressF.enabled = true;

                if (Input.GetKeyDown(KeyCode.F))
                    FixMechanism();
            }
        }
    }

    void OnTriggerExit()
    {
        if(isBroken)
            pressF.enabled = false;
    }
}
