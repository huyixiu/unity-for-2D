#if UNITY_ANDROID && !UNITY_EDITOR
#define ANDROID
#endif

#if UNITY_IPHONE && !UNITY_EDITOR
#define IPHONE
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIBaseButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0)||(Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
#if IPHONE || ANDROID
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#else
            if (EventSystem.current.IsPointerOverGameObject())
#endif
                Debug.Log("当前触摸在UI上");

            else
                this.gameObject.SetActive(false);

        }
	}
}
