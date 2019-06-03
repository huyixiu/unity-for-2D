using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum UIPanelID//所有UI的ID定义
{
    ID_None,
    ID_RegisterPanel,   //注册
    ID_LoginPanel,      //登录
    ID_MainUIPanel,     //主UI
    ID_CareerPanel,     //生涯
    ID_ClubPanel,       //俱乐部
    ID_NewPanel,        //创建游戏
    ID_MessagePanel,    //消息
    ID_MorePanel,       //更多

    //俱乐部下级菜单
    ID_NewClubPanel,            //新建俱乐部
    ID_EnterClubNamePanel,      //输入俱乐部名称
    ID_EnterClubIntroducePanel, //输入俱乐部介绍
    ID_JoinClubPanel,           //加入俱乐部

}

public enum UIShowMode
{
    M_Nothing,            //当前UI显示出来的时,其它UI不做任何操作
    M_HideAllExceptAbove, //当前UI显示出来的时,除了最前面的主UI外，都隐藏
    M_HideAll             //当前UI显示出来的时,隐藏所有的UI，包括最前面的
}

public class UIPrefabPath
{
    public static Dictionary<UIPanelID, string> prefabPathDict = new Dictionary<UIPanelID, string>
    {
        {UIPanelID.ID_LoginPanel,"Prefabs/Panels/LoginPanel"},
        {UIPanelID.ID_RegisterPanel,"Prefabs/Panels/RegisterPanel"},
        {UIPanelID.ID_MainUIPanel,"Prefabs/Panels/MainPanel"},
        {UIPanelID.ID_CareerPanel,"Prefabs/Panels/CareerPanel"},
        {UIPanelID.ID_ClubPanel,"Prefabs/Panels/ClubPanel"},
        {UIPanelID.ID_NewPanel,"Prefabs/Panels/NewPanel"},
        {UIPanelID.ID_MessagePanel,"Prefabs/Panels/MessagePanel"},
        {UIPanelID.ID_MorePanel,"Prefabs/Panels/MorePanel"},
        //俱乐部下级菜单
        {UIPanelID.ID_NewClubPanel,"Prefabs/Panels/Club/NewClubPanel"},
        {UIPanelID.ID_EnterClubNamePanel,"Prefabs/Panels/Club/EnterClubNamePanel"},
        {UIPanelID.ID_EnterClubIntroducePanel,"Prefabs/Panels/Club/EnterClubIntroducePanel"},
        {UIPanelID.ID_JoinClubPanel,"Prefabs/Panels/Club/JoinClubPanel"}
    };

    public static string getUIPrefabPath(UIPanelID id)
    {
        if (prefabPathDict.ContainsKey(id))
        {
            return prefabPathDict[id];
        }
        return null;
    }
}