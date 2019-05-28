using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILoginPanel : UIBasePanel{
    private InputField email;//输入邮件
    private InputField password;//输入密码
    private Button login;//登陆按钮
    private Button lostPassword;//忘记密码按钮
    private Button register;//注册按钮 
    private Button weixin;//微信登陆按钮
    private Button weibo;//微博登陆按钮
    private Button touristLogin;//游客登陆按钮

    public override void OnInit()
    {
        //UI的ID
        this.id = UIPanelID.ID_LoginPanel;
        this.beforeID = UIPanelID.ID_None;
        //UI的显示规则
        IsAlwaysAbove = false;
        showMode = UIShowMode.M_HideAll;

        //查找UI对象
        email = UIUtils.findChild(this.gameObject, "Email").GetComponent<InputField>();
        UIUtils.findChild(email.gameObject, "Placeholder").GetComponent<Text>().text = "请输入电子邮件";
        password = UIUtils.findChild(this.gameObject, "Password").GetComponent<InputField>();
        UIUtils.findChild(email.gameObject, "Placeholder").GetComponent<Text>().text = "请输入您的密码";
        login = UIUtils.findChild(this.gameObject, "LoginButton").GetComponent<Button>();
        lostPassword = UIUtils.findChild(this.gameObject, "LostPasswordButton").GetComponent<Button>();
        register = UIUtils.findChild(this.gameObject, "RegisterButton").GetComponent<Button>();
        weibo = UIUtils.findChild(this.gameObject, "WeiBoButton").GetComponent<Button>();
        weixin = UIUtils.findChild(this.gameObject, "WeiXinButton").GetComponent<Button>();
        touristLogin = UIUtils.findChild(this.gameObject, "TouristLoginButton").GetComponent<Button>();

        //挂载事件
        login.onClick.AddListener(OnLogin);
        register.onClick.AddListener(OnRegister);
    }

    #region MyRegion
    //登陆
    private void OnLogin()
    {
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_MainUIPanel);
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_NewPanel);
    }

    //注册
    private void OnRegister()
    {
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_RegisterPanel);
    }

    #endregion
}
