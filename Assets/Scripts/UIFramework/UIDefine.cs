using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum UIPanelID//所有UI的ID定义
{
    ID_None,
    ID_RegisterPanel, //注册面板
    ID_LoginPanel,    //登录面板
    ID_LoadPanel,    //加载面板
    ID_WelcomePanel,  //欢迎面板
    ID_MainUIPanel,   //主面板
    ID_BagPanel,      //背包面板
    ID_RolePanel,     //人物属性面板
    ID_SettingPanel,  //设置面板
    ID_ShopPanel,     //商店面板
    ID_TaskPanel,     //任务面板
    ID_SkillPanel,    //技能面板
    ID_PickItemPanel, //物品面板
    ID_ToolTipPanel,  //物品信息面板
    ID_ShopToolTipPanel,//购买信息面板
    ID_RevivePanel,   //复活面板
    ID_GameOverPanel, //游戏结束面板
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
        {UIPanelID.ID_LoginPanel,"Prefabs/LoginPanel"},
        {UIPanelID.ID_RegisterPanel,"Prefabs/RegisterPanel"}
//        {UIPanelID.ID_MainUIPanel,"Prefab/UIPrefabs/UIPanelPrefab/MainPanel"},
//        {UIPanelID.ID_BagPanel,"Prefab/UIPrefabs/UIPanelPrefab/BagPanel"},
//        {UIPanelID.ID_RolePanel,"Prefab/UIPrefabs/UIPanelPrefab/RolePanel"},
//        {UIPanelID.ID_SettingPanel,"Prefab/UIPrefabs/UIPanelPrefab/SettingPanel"},
//        {UIPanelID.ID_ShopPanel,"Prefab/UIPrefabs/UIPanelPrefab/StorePanel"},
//        {UIPanelID.ID_TaskPanel,"Prefab/UIPrefabs/UIPanelPrefab/TaskPanel"},
//        {UIPanelID.ID_SkillPanel,"Prefab/UIPrefabs/UIPanelPrefab/SkillPanel"},
//        {UIPanelID.ID_PickItemPanel,"Prefab/UIPrefabs/UIPanelPrefab/PickItemPanel"},
//        {UIPanelID.ID_ToolTipPanel,"Prefab/UIPrefabs/UIPanelPrefab/ToolTipPanel"},
//        {UIPanelID.ID_ShopToolTipPanel,"Prefab/UIPrefabs/UIPanelPrefab/ShopToolTipPanel"},
//        {UIPanelID.ID_RevivePanel,"Prefab/UIPrefabs/UIPanelPrefab/RevivePanel"},
//        {UIPanelID.ID_GameOverPanel,"Prefab/UIPrefabs/UIPanelPrefab/GameOverPanel"}
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