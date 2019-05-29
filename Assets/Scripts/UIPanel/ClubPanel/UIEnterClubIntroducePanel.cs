using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 输入俱乐部的介绍
 */
public class UIEnterClubIntroducePanel : UIBasePanel {
    public override void OnInit()
    {
        //UI的ID
        this.id = UIPanelID.ID_EnterClubIntroducePanel;
        this.beforeID = UIPanelID.ID_NewClubPanel;
        //UI的显示规则
        IsAlwaysAbove = false;
        showMode = UIShowMode.M_HideAll;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
