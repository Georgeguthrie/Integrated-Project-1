using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shotbar1 : MonoBehaviour
{
    public Slider slider;

    public void SetShots(int shots)
    {
        slider.value = shots;
    }
}
