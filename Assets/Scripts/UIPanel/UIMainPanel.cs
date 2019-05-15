using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using DG.Tweening;//引入动画控制的命名空间

//Bag UI面板属性和行为 的脚本, 实现 基类定义的属性和行为 和 和补充 自己的属性和行为

class UIMainPanel : UIBasePanel
{
    //面板
    private GameObject RoleBtn;
    private GameObject SettingBtn;
    private GameObject BagBtn;
    private GameObject StoreBtn;
    private GameObject TaskBtn;
    private GameObject SkillBtn;
    //技能
    private GameObject SkillNorm;
    private GameObject SkillBtn1;
    private GameObject SkillBtn2;
    private GameObject SkillBtn3;

    public override void OnInit()
    {
        //1:必须给定ID
        this.id = UIPanelID.ID_MainUIPanel;
        //
        IsAlwaysAbove = true;
        showMode = UIShowMode.M_HideAllExceptAbove;

        //用于查找游戏对象
        RoleBtn = UIUtils.findChild(this.gameObject, "RoleBut").gameObject;
        SettingBtn = UIUtils.findChild(this.gameObject, "SetBut").gameObject;
        BagBtn = UIUtils.findChild(this.gameObject, "BagBut").gameObject;
        StoreBtn = UIUtils.findChild(this.gameObject, "StoreBut").gameObject;
        TaskBtn = UIUtils.findChild(this.gameObject, "TaskBut").gameObject;
        SkillBtn = UIUtils.findChild(this.gameObject,"SkillBut").gameObject;
        SkillNorm = UIUtils.findChild(this.gameObject, "NormalAttackBut").gameObject;
        SkillBtn1 = UIUtils.findChild(this.gameObject, "Attack1But").gameObject;
        SkillBtn2 = UIUtils.findChild(this.gameObject, "Attack2But").gameObject;
        SkillBtn3 = UIUtils.findChild(this.gameObject, "Attack3But").gameObject;

        RoleBtn.GetComponent<Button>().onClick.AddListener(OnRoleBtn);
        SettingBtn.GetComponent<Button>().onClick.AddListener(OnSettingBtn);
        BagBtn.GetComponent<Button>().onClick.AddListener(OnBagBtn);
        StoreBtn.GetComponent<Button>().onClick.AddListener(OnStoreBtn);
        TaskBtn.GetComponent<Button>().onClick.AddListener(OnTaskBtn);
        SkillBtn.GetComponent<Button>().onClick.AddListener(OnSkillBtn);
    }

    #region 事件回调函数
    private void OnRoleBtn()
    {
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_RolePanel);
    }

    private void OnSettingBtn()
    {
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_SettingPanel);
    }

    private void OnBagBtn()
    {
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_BagPanel);
    }
    private void OnStoreBtn()
    {
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_ShopPanel);
    }
    private void OnTaskBtn()
    {
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_TaskPanel);
    }
    private void OnSkillBtn()
    {
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_SkillPanel);
    }
    #endregion
}
