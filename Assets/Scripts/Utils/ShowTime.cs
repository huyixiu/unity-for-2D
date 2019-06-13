using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 *
 */
public class ShowTime : MonoBehaviour
{
    public GameObject[] HideGameObjects;
    public GameObject[] ShowGameObjects;

    public Slider timeSlider;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i <= timeSlider.maxValue; i++)
        {
            HideGameObjects[i].SetActive(false);
            ShowGameObjects[i].SetActive(true);

            if ((int)timeSlider.value == i)
            {
                HideGameObjects[i].SetActive(true);
                ShowGameObjects[i].SetActive(false);
            }
        }
	}
}
