using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BreakageManager : MonoBehaviour
{
    public Mechanism[] mechanisms;
    Mechanism brokenMech;
    public int minimumCount;
    public int maximumCount;
    public int counter;
    public Text breakageText;
    public Slider healthSlider;
    public float sliderValue;
    public Highlighter icon;
    int currentBreaks = 0;

    // Use this for initialization
	void Start ()
    {
        foreach (Mechanism mech in mechanisms)
            mech.manager = this;

        counter = Random.Range(minimumCount, maximumCount);
        sliderValue = healthSlider.maxValue;
	}

    void FixedUpdate()
    {
        counter--;
        if (counter <= 0)
        {
            if(currentBreaks < mechanisms.Length)
            {
                Breakage();
            counter = Random.Range(minimumCount, maximumCount); 
            }
        }

        if (brokenMech != null)
            if (brokenMech.isBroken)
            {
                sliderValue -= 0.02f;
                healthSlider.value = sliderValue;
            }
    }

    void Breakage()
    {
        int randomNum;
        randomNum = Random.Range(0, mechanisms.Length);
        brokenMech = mechanisms[randomNum];
        if (brokenMech.isBroken)
            Breakage();

        if (!brokenMech.isBroken)
        {
            brokenMech.BreakMechanism();
            breakageText.text = "The " + mechanisms[randomNum].deviceName + " has broken!";
            breakageText.enabled = true;
            brokenMech.icon.SetTarget(brokenMech.gameObject);
            currentBreaks++;
        }
    }

    public void HasBeenFixed()
    {
        breakageText.enabled = false;
        brokenMech = null;
        currentBreaks--;
    }
}
