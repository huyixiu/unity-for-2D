using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * 俱乐部一级菜单
 */
public class UIClubPanel : UIBasePanel
{
    //按钮
    private Button newButton;       //新建
    private Button newClubButton;   //新建俱乐部
    private Button joinClubButton;  //加入俱乐部
    private Button newClub;         //新建俱乐部
    private Button joinClub;        //加入俱乐部

    //对象
    private GameObject noClub;      //没有俱乐部
    private GameObject clubList;    //俱乐部列表
    private GameObject buttonList;  //按钮列表

    public override void OnInit()
    {
        //UI的ID
        this.id = UIPanelID.ID_ClubPanel;
        this.beforeID = UIPanelID.ID_None;
        //UI的显示规则
        IsAlwaysAbove = false;
        showMode = UIShowMode.M_HideAllExceptAbove;

        //查找UI对象
        newButton = UIUtils.findChild(this.gameObject, "NewButton").GetComponent<Button>();
        newClubButton = UIUtils.findChild(this.gameObject, "NewClubButton").GetComponent<Button>();
        joinClubButton = UIUtils.findChild(this.gameObject, "JoinClubButton").GetComponent<Button>();
        newClub = UIUtils.findChild(this.gameObject, "NewClub").GetComponent<Button>();
        joinClub = UIUtils.findChild(this.gameObject, "JoinClub").GetComponent<Button>();

        noClub = UIUtils.findChild(this.gameObject, "NoClub").gameObject;
        clubList = UIUtils.findChild(this.gameObject, "ClubList").gameObject;
        buttonList = UIUtils.findChild(this.gameObject, "ButtonList").gameObject;

        //挂载事件
        newButton.onClick.AddListener(OnShow);
        newClubButton.onClick.AddListener(OnNewClub);
        joinClubButton.onClick.AddListener(OnJoinClub);
        newClub.onClick.AddListener(OnNewClub);
        joinClub.onClick.AddListener(OnJoinClub);
    }

    #region MyRegion
    //显示按钮
    private void OnShow()
    {
        if (buttonList.gameObject.active)
        {
            buttonList.SetActive(false);
        }
        else
        {
            buttonList.SetActive(true);
        }
        
    }

    //新建俱乐部
    private void OnNewClub()
    {
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_NewClubPanel);
    }

    //加入俱乐部
    private void OnJoinClub()
    {
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_JoinClubPanel);
    }
    #endregion
}
