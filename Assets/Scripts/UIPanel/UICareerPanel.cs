using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 生涯以及菜单
 */
public class UICareerPanel : UIBasePanel {

    public override void OnInit()
    {
        //UI的ID
        this.id = UIPanelID.ID_CareerPanel;
        this.beforeID = UIPanelID.ID_None;
        //UI的显示规则
        IsAlwaysAbove = false;
        showMode = UIShowMode.M_HideAllExceptAbove;
    }
}
