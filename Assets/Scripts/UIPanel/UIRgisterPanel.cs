using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRgisterPanel : UIBasePanel {
    private InputField email;//输入邮件
    private InputField password;//输入密码
    private InputField passwordAgain;//再次输入密码
    private Button putIn;//提交按钮
    private Button cancel;//取消


    public override void OnInit()
    {
        //UI的ID
        this.id = UIPanelID.ID_RegisterPanel;
        this.beforeID = UIPanelID.ID_LoginPanel;
        //UI的显示规则
        IsAlwaysAbove = false;
        showMode = UIShowMode.M_HideAll;

        //查找UI对象
        email = UIUtils.findChild(this.gameObject, "Email").GetComponent<InputField>();
        UIUtils.findChild(email.gameObject, "Placeholder").GetComponent<Text>().text = "请输入电子邮件";
        password = UIUtils.findChild(this.gameObject, "Password").GetComponent<InputField>();
        UIUtils.findChild(email.gameObject, "Placeholder").GetComponent<Text>().text = "请输入密码（6-12字节）";
        passwordAgain = UIUtils.findChild(this.gameObject, "PasswordAgain").GetComponent<InputField>();
        UIUtils.findChild(email.gameObject, "Placeholder").GetComponent<Text>().text = "确认密码";
        putIn = UIUtils.findChild(this.gameObject, "PutIn").GetComponent<Button>();
        cancel = UIUtils.findChild(this.gameObject, "Cancel").GetComponent<Button>();

        //挂载事件
        cancel.onClick.AddListener(OnCancel);
    }

    #region MyRegion
    //取消
    private void OnCancel()
    {
        UIPanelManager.Instance.showUIPanel(beforeID);
    }
    

    #endregion
}
