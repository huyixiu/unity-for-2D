using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 新建牌局一级菜单
 */
public class UINewPanel : UIBasePanel
{
    private Button enterThePassword;

    public override void OnInit()
    {
        //UI的ID
        this.id = UIPanelID.ID_NewPanel;
        this.beforeID = UIPanelID.ID_None;
        //UI的显示规则
        IsAlwaysAbove = false;
        showMode = UIShowMode.M_HideAllExceptAbove;

        //
        enterThePassword = UIUtils.findChild(this.gameObject, "EnterThePassword").GetComponent<Button>();

        //
        enterThePassword.onClick.AddListener(OnEnterPassword);
    }

    #region MyRegion

    private void OnEnterPassword()
    {
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_EnterPasswordIntoTheOfficePanel);
    }

    #endregion
}
