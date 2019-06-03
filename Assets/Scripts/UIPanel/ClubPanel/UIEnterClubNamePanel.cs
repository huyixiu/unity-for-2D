using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 输入俱乐部的名称
 */
public class UIEnterClubNamePanel : UIBasePanel
{
    private Button cancelButton;        //
    private Button finishButton;        //
    private Button clearButton;         //
    private InputField clubName;

    public override void OnInit()
    {
        //UI的ID
        this.id = UIPanelID.ID_EnterClubNamePanel;
        this.beforeID = UIPanelID.ID_NewClubPanel;
        //UI的显示规则
        IsAlwaysAbove = false;
        showMode = UIShowMode.M_HideAll;

        //
        cancelButton = UIUtils.findChild(this.gameObject, "Cancel").GetComponent<Button>();
        finishButton = UIUtils.findChild(this.gameObject, "Finish").GetComponent<Button>();
        clearButton = UIUtils.findChild(this.gameObject, "ClearButton").GetComponent<Button>();
        clubName = UIUtils.findChild(this.gameObject, "ClubName").GetComponent<InputField>();

        //
        cancelButton.onClick.AddListener(OnCancel);
        finishButton.onClick.AddListener(OnFinish);
        clearButton.onClick.AddListener(OnClear);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!clubName.text.Equals("") && clubName.text.ToString().Length > 0 )
        {
            finishButton.interactable = true;
        }
        else
        {
            finishButton.interactable = false;
        }
	}

    #region MyRegion

    private void OnCancel()
    {
        UIPanelManager.Instance.showUIPanel(this.beforeID);
    }

    private void OnFinish()
    {
        UINewClubPanel.enterTheClubNane.text = clubName.text;
        UIPanelManager.Instance.showUIPanel(this.beforeID);
    }

    private void OnClear()
    {
        clubName.text = null;
    }
    #endregion
}
