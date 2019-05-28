﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMorePanel : UIBasePanel {
    public override void OnInit()
    {
        //UI的ID
        this.id = UIPanelID.ID_MorePanel;
        this.beforeID = UIPanelID.ID_None;
        //UI的显示规则
        IsAlwaysAbove = false;
        showMode = UIShowMode.M_HideAllExceptAbove;
    }
}