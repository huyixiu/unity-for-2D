using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
/**
 * 一级主菜单
 */
public class UIMainPanel : UIBasePanel
{
    private Button careerButton;    //生涯

    private Button cluButton;       //俱乐部

    private Button newButton;       //创建新游戏

    private Button messageButton;   //消息

    private Button moreButton;      //更多

    public override void OnInit()
    {
        //UI的ID
        this.id = UIPanelID.ID_MainUIPanel;
        this.beforeID = UIPanelID.ID_None;
        //UI的显示规则
        IsAlwaysAbove = true;
        showMode = UIShowMode.M_HideAll;

        //查找UI对象
        careerButton = UIUtils.findChild(this.gameObject, "CareerButton").GetComponent<Button>();
        cluButton = UIUtils.findChild(this.gameObject, "ClubButton").GetComponent<Button>();
        newButton = UIUtils.findChild(this.gameObject, "NewButton").GetComponent<Button>();
        messageButton = UIUtils.findChild(this.gameObject, "MessageButton").GetComponent<Button>();
        moreButton = UIUtils.findChild(this.gameObject, "MoreButton").GetComponent<Button>();

        //挂载事件
        careerButton.onClick.AddListener(OnCareer);
        cluButton.onClick.AddListener(OnClub);
        newButton.onClick.AddListener(OnNew);
        messageButton.onClick.AddListener(OnMessage);
        moreButton.onClick.AddListener(OnMore);
        careerButton.onClick.AddListener(() => { ButtonClick(careerButton); });
        cluButton.onClick.AddListener(() => { ButtonClick(cluButton); });
        newButton.onClick.AddListener(() => { ButtonClick(newButton); });
        messageButton.onClick.AddListener(() => { ButtonClick(messageButton); });
        moreButton.onClick.AddListener(() => { ButtonClick(moreButton); });
    }

    //初始化所有按钮的颜色
    private void Invit()
    {
        careerButton.GetComponent<Image>().color = Color.white;
        cluButton.GetComponent<Image>().color = Color.white;
        newButton.GetComponent<Image>().color = Color.white;
        messageButton.GetComponent<Image>().color = Color.white;
        moreButton.GetComponent<Image>().color = Color.white;
    }


    #region MyRegion
    //修改按钮的颜色
    private void ButtonClick(Object sender)
    {
        Invit();
        ((Button)sender).GetComponent<Image>().color = new Color(0.04f,0.77f,0.74f,1f);
    }

    private void OnCareer()
    {
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_CareerPanel);
    }
    private void OnClub()
    {
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_ClubPanel);
    }
    private void OnNew()
    {
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_NewPanel);
    }
    private void OnMessage()
    {
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_MessagePanel);
    }
    private void OnMore()
    {
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_MorePanel);
    }

    #endregion
}
