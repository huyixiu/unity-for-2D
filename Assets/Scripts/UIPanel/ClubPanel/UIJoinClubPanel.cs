using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * 加入俱乐部
 */
public class UIJoinClubPanel : UIBasePanel
{
    private Button cancelButton;
    private Button clearButton;
    private Button deleteButton;
    public Button[] key;

    public Text[] number;

    public override void OnInit()
    {
        //UI的ID
        this.id = UIPanelID.ID_JoinClubPanel;
        this.beforeID = UIPanelID.ID_ClubPanel;
        //UI的显示规则
        IsAlwaysAbove = false;
        showMode = UIShowMode.M_HideAll;

        //
        cancelButton = UIUtils.findChild(this.gameObject, "Cancel").GetComponent<Button>();
        deleteButton = UIUtils.findChild(this.gameObject, "Delete").GetComponent<Button>();
        clearButton = UIUtils.findChild(this.gameObject, "Clear").GetComponent<Button>();

        //
        cancelButton.onClick.AddListener(OnCancel);
        clearButton.onClick.AddListener(OnClear);
        deleteButton.onClick.AddListener(OnDelete);
        foreach (var VARIABLE in key)
        {
            VARIABLE.onClick.AddListener(() => { OnKeyButton(VARIABLE.gameObject); });
        }
       
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    #region MyRegion

    private void OnCancel()
    {
        UIPanelManager.Instance.showUIPanel(UIPanelID.ID_MainUIPanel);
        UIPanelManager.Instance.showUIPanel(this.beforeID);
    }

    private void OnKeyButton(GameObject key)
    {
        foreach (var VARIABLE in number)
        {
            if (VARIABLE.text == "")
            {
                VARIABLE.text = UIUtils.findChild(key,"Text").GetComponent<Text>().text;
                return;
            }
        }
    }

    private void OnClear()
    {
        foreach (var VARIABLE in number)
        {
            if (VARIABLE.text != null)
            {
                VARIABLE.text = null;
            }
        }
    }

    private void OnDelete()
    {
        for (int i = number.Length - 1; i >= 0; i--)
        {
            if (number[i].text != "")
            {
                number[i].text = null;
                return;
            }
        }
    }
    #endregion
}
