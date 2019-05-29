using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 新建俱乐部二级菜单
 */
public class UINewClubPanel : UIBasePanel {
    public override void OnInit()
    {
        //UI的ID
        this.id = UIPanelID.ID_NewClubPanel;
        this.beforeID = UIPanelID.ID_ClubPanel;
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
