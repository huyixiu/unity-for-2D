using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 *使UIPanel随Canvas而变换比例
 */
public class ScreenWH : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //获取canvas
        RectTransform canvasRectTransform = UIPanelManager.Instance.transform.GetComponent<RectTransform>();

        //获取canvas宽高
        float device_width = canvasRectTransform.rect.width;
        float device_height = canvasRectTransform.rect.height;

        //修改当前UIPanel的宽高
        this.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,device_width);//水平-宽
        this.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,device_height);//垂直-高
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
