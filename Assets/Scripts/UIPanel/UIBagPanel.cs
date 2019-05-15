using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using DG.Tweening;//引入动画控制的命名空间

//Bag UI面板属性和行为 的脚本, 实现 基类定义的属性和行为 
//和 和补充 自己的属性和行为
class UIBagPanel : UIBasePanel
{
    //private GameObject closeBtn;
    public override void OnInit()
    {
        //1:必须给定ID
        this.id = UIPanelID.ID_BagPanel;

        IsAlwaysAbove = false;
        showMode = UIShowMode.M_HideAllExceptAbove;

        //2：获取组件,如果有事件添加事件
        //closeBtn = UIUtils.findChild(this.gameObject, "CloseButton").gameObject;
        ////通过代码添加事件回调
        //closeBtn.GetComponent<Button>().onClick.AddListener(OnBtnClose);
    }

    //#region 事件回调函数
    //void OnBtnClose()
    //{
    //    //调用UIPanelManager来关闭Panel，为了保证 xxxIPanelDic的一致性
    //    UIPanelManager.Instance.HideUIPanel(this.id);
    //}
    //#endregion

}

