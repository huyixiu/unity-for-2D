using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 新建牌局一级菜单
 */
public class UINewPanel : UIBasePanel {
    public override void OnInit()
    {
        //UI的ID
        this.id = UIPanelID.ID_NewPanel;
        this.beforeID = UIPanelID.ID_None;
        //UI的显示规则
        IsAlwaysAbove = false;
        showMode = UIShowMode.M_HideAllExceptAbove;
    }
}
