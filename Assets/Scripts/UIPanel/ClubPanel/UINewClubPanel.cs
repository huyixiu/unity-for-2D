using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 新建俱乐部二级菜单
 */
public class UINewClubPanel : UIBasePanel
{
    private Button cancelButton;        //取消
    private Button logoButton;          //logo
    private Button clubNameButton;      //俱乐部名字
    private Button clubIntroduceButton; //俱乐部介绍
    private Button establishButton;     //创建

    public static Text enterTheClubNane;      //俱乐部名称
    public static Text enterTheIntroduce;     //俱乐部介绍

    public override void OnInit()
    {
        //UI的ID
        this.id = UIPanelID.ID_NewClubPanel;
        this.beforeID = UIPanelID.ID_ClubPanel;
        //UI的显示规则
        IsAlwaysAbove = false;
        showMode = UIShowMode.M_HideAll;

        //查找对象
        cancelButton = UIUtils.findChild(this.gameObject, "Cancel").GetComponent<Button>();
        logoButton = UIUtils.findChild(this.gameObject, "LogoButton").GetComponent<Button>();
        clubNameButton = UIUtils.findChild(this.gameObject, "ClubNameButton").GetComponent<Button>();
        clubIntroduceButton = UIUtils.findChild(this.gameObject, "ClubIntroduceButton").GetComponent<Button>();
        establishButton = UIUtils.findChild(this.gameObject, "EstablishButton").GetComponent<Button>();

        enterTheClubNane = UIUtils.findChild(this.gameObject, "EnterTheClubName").GetComponent<Text>();
        enterTheIntroduce = UIUtils.findChild(this.gameObject, "EnterTheIntroduce").GetComponent<Text>();

        //挂载事件

        enterTheClubNane.text = "请输入俱乐部名称";
        enterTheIntroduce.text = "请输入俱乐部介绍";
        cancelButton.onClick.AddListener(OnCancel);
        logoButton.onClick.AddListener(OnLogo);
        clubNameButton.onClick.AddListener(OnEnterTheClubName);
        clubIntroduceButton.onClick.AddListener(OnEnterTheIntroduce);
        establishButton.onClick.AddListener(OnEstablish);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (!enterTheClubNane.text.Equals("请输入俱乐部名称") && enterTheClubNane.text.ToString().Length > 0)
        {
            establishButton.interactable = true;
        }
        else
        {
            establishButton.interactable = false;
        }
	}

    #region MyRegion

    private void OnCancel()
    {
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_MainUIPanel);
        UIPanelManager.Instance.showUIPanel(this.beforeID);
        enterTheClubNane.text = "请输入俱乐部名称";
        enterTheIntroduce.text = "请输入俱乐部介绍";
    }

    private void OnLogo()
    {

    }
    private void OnEnterTheClubName()
    {
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_EnterClubNamePanel);
    }

    private void OnEnterTheIntroduce()
    {
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_EnterClubIntroducePanel);
    }

    private void OnEstablish()
    {

    }
    #endregion
}
