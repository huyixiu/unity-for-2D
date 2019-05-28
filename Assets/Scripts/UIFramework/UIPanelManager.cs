using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
UI面板管理类 --- 单例模式，且不被随场景的切换而被销毁
 * 功能和属性
 * 1、当前正在显示UI面板
 * 1、所有UI面板对象（包括显示和不显示）的缓存
 * 2、管理 - 当前正在显示的所有UI面板

 * 4、UI(Canvas)根节点
 * 5、Canvas下保持显示始终在前 的根节点
 * 5、Canvas下普通UI根节点
 * 
 * 2、显示 - 指定UI面板
 * 3、隐藏 - 指定UI面板
 * 4、获取 - 指定UI面板的引用
 * 5、添加 - 指定UI面板到缓存
 * 6、删除 - 指定UI面板到缓存
 * 7、获取 - 此UI所在的根节点 //？

 
 */
public class UIPanelManager : MonoSingleton<UIPanelManager> 
{
    //当前正在显示UI面板
    [HideInInspector]
    public UIBasePanel curDisplayUIPanel;

    //管理 - 所有UIPanel面板对象,不用来缓冲对象，慢慢收集出现的UIPanel对象
    public Dictionary<UIPanelID, UIBasePanel> allUIPanelDict = new Dictionary<UIPanelID, UIBasePanel>();

    //管理 - 当前正在显示的所有UI面板
    public Dictionary<UIPanelID, UIBasePanel> showedUIPanelDict = new Dictionary<UIPanelID, UIBasePanel>();

    //为了实现主UIPanel能始终显示在最前面,需要进行设计Canvas UI对象结构
    public Transform transUIRoot;                 //UI根节点---- 当前Canvas

    private Transform transUIRootForKeepAbove;   //保持在最上面UI的根节点
    private Transform transUIRootForNormal;      //普通UI的根节点


    //在Mono类下, 实现类似构造函数,初始化的逻辑
    protected override void Awake()
    {
        base.Awake();

        transUIRoot = this.transform;

        onInit();
    }

    void onInit()
    {
        DontDestroyOnLoad(this.gameObject);//场景切换时,不销毁脚本所在的对象

        if (allUIPanelDict != null) allUIPanelDict.Clear();
        if (showedUIPanelDict != null) showedUIPanelDict.Clear();

        //Canvas下保持显示始终在前 的根节点
        if (transUIRootForKeepAbove == null)
        {
            transUIRootForKeepAbove = new GameObject("UIRootForKeepAbove").transform;
            UIUtils.addChildToParent(transUIRoot, transUIRootForKeepAbove);//把此对象放在父对象下面
        }

        //Canvas下普通UI元素的 根节点
        if (transUIRootForNormal == null)
        {
            transUIRootForNormal = new GameObject("UIRootForNormal").transform;
            UIUtils.addChildToParent(transUIRoot, transUIRootForNormal);
        }

        //来缓冲对象， panel对象创建后就会直接出现在场景中
        foreach (var tmp in UIPrefabPath.prefabPathDict)
        {
            UIPanelID id = tmp.Key;
            string prefabPath = tmp.Value;

            if (!string.IsNullOrEmpty(prefabPath))
            {
                GameObject prefab = Resources.Load<GameObject>(prefabPath);//加载资源

                if (prefab != null)//资源加载成功
                {
                    GameObject storedUIPanelObj = GameObject.Instantiate(prefab);
                    storedUIPanelObj.SetActive(false);

                    UIBasePanel uiPanel = storedUIPanelObj.GetComponent<UIBasePanel>();//获取此对象上的UI
                    allUIPanelDict.Add(id, uiPanel);

                    if (uiPanel != null)
                    {
                        Transform root = getRootNodeOfPanel(uiPanel);//获取UI所对应的根节点

                        //放入根节点下面
                        UIUtils.addChildToParent(root, storedUIPanelObj.transform);//放入根节点下面

                        prefab = null;//清空预制体对象
                    }
                }
            }
            else
            {
                Debug.LogError("资源" + prefabPath + "不存在");
            }
        }

        //默认显示
        showUIPanel(UIPanelID.ID_LoginPanel);//显示主界面UI
    }

    public void showUIPanel(UIPanelID id)           
    {
        //1：判断是否是已显示的UI面板
        if (showedUIPanelDict.ContainsKey(id))//当前UI已经在显示列表中了，就直接返回
        {
            //HideUIPanel(id);
            return;
        }

        //2：判断此面板是否已创建,没有则加载 预置体，创建面板，显示+管理起来

        //通过ID获取需要显示的UI，从 AllUIdict 容器中获取(打开过的面板,会在 AllUIdict 引用)
        UIBasePanel tmpUIPanel = getUIPanelFromAllDict(id);

        if (tmpUIPanel == null)//如果在容器中没有此UI，就从资源中读取ui预制体,并创建
        {
            string prefabPath = UIPrefabPath.getUIPrefabPath(id);//通过ID，获取对应的路径

            if (!string.IsNullOrEmpty(prefabPath))
            {
                GameObject prefab = Resources.Load<GameObject>(prefabPath);//加载资源

                if (prefab != null)//资源加载成功
                {
                    GameObject goWillShowUIPanelObj = GameObject.Instantiate(prefab);//克隆游戏对象到层次面板上

                    tmpUIPanel = goWillShowUIPanelObj.GetComponent<UIBasePanel>();//获取此对象上的UI

                    if (tmpUIPanel != null)
                    {
                        Transform root = getRootNodeOfPanel(tmpUIPanel);//获取UI所对应的根节点

                        //放入根节点下面
                        UIUtils.addChildToParent(root, goWillShowUIPanelObj.transform);//放入根节点下面

                        prefab = null;//清空预制体对象
                    }
                }
                else
                {
                    Debug.LogError("资源" + prefabPath + "不存在");
                }
            }
        }

        //3:更新显示其它的UI
        UpdateOtherUIPanelState(tmpUIPanel);

        //4:显示当前UI
        allUIPanelDict[id] = tmpUIPanel;
        showedUIPanelDict[id] = tmpUIPanel;

        tmpUIPanel.Show();

        curDisplayUIPanel = tmpUIPanel;
    }

    public void HideUIPanel(UIPanelID id)
    {
        var tmpUIPanel = getUIPanelFromShowedDict(id);

        if (tmpUIPanel != null)
        {
            showedUIPanelDict.Remove(id);
            tmpUIPanel.Hide();

        }
        else
        {
            Debug.LogError(tmpUIPanel.id + "没有显示，无法隐藏");
            return;
        }
    }

    private void UpdateOtherUIPanelState(UIBasePanel tmpUIPanel)//更新其它UI的状态（显示或者隐藏）
    {
        if (tmpUIPanel == null)
        {
            return;
        }

        if (tmpUIPanel.showMode == UIShowMode.M_HideAll)
        {
            foreach (KeyValuePair<UIPanelID, UIBasePanel> item in showedUIPanelDict)//遍历所有正在显示的UI
            {
                item.Value.Hide();
            }

            showedUIPanelDict.Clear();
        }
        else if (tmpUIPanel.showMode == UIShowMode.M_HideAllExceptAbove)//剔除最前面UI
        {
            foreach (KeyValuePair<UIPanelID, UIBasePanel> item in showedUIPanelDict)
            {
                if (item.Value.IsAlwaysAbove)
                {
                    continue;
                }

                item.Value.Hide();
                showedUIPanelDict.Remove(item.Key);
                break;

                //注意
            }
        }
    }

    private UIBasePanel getUIPanelFromAllDict(UIPanelID id)
    {
        if (allUIPanelDict.ContainsKey(id))
        {
            return allUIPanelDict[id];
        }
        else
        {
            return null;
        }

    }

    private UIBasePanel getUIPanelFromShowedDict(UIPanelID id)
    {
        if (showedUIPanelDict.ContainsKey(id))
        {
            return showedUIPanelDict[id];
        }
        else
        {
            return null;
        }

    }

    //获取此UIPanel所在的根节点
    private Transform getRootNodeOfPanel(UIBasePanel UIPanel)
    {
        if (UIPanel.IsAlwaysAbove)
        {
            return transUIRootForKeepAbove;
        }
        else
        {
            return transUIRootForNormal;
        }
    }

    //获取根节点下的子物体
    public Transform getChildOfRootNode(string ChildName)
    {
        return UIUtils.findChild(transUIRootForNormal.gameObject, ChildName);
    }
}
