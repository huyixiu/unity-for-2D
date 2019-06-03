using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 输入俱乐部的介绍
 */
public class UIEnterClubIntroducePanel : UIBasePanel {
    private Button cancelButton;        //
    private Button finishButton;        //
    private Text numberText;            //
    private InputField clubIntroduce;

    public override void OnInit()
    {
        //UI的ID
        this.id = UIPanelID.ID_EnterClubIntroducePanel;
        this.beforeID = UIPanelID.ID_NewClubPanel;
        //UI的显示规则
        IsAlwaysAbove = false;
        showMode = UIShowMode.M_HideAll;

        //
        cancelButton = UIUtils.findChild(this.gameObject, "Cancel").GetComponent<Button>();
        finishButton = UIUtils.findChild(this.gameObject, "Finish").GetComponent<Button>();
        clubIntroduce = UIUtils.findChild(this.gameObject, "ClubIntroduce").GetComponent<InputField>();
        numberText = UIUtils.findChild(this.gameObject, "NumberText").GetComponent<Text>();

        //
        cancelButton.onClick.AddListener(OnCancel);
        finishButton.onClick.AddListener(OnFinish);
    }
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        numberText.text = clubIntroduce.text.ToString().Length + "/100";

        if (!clubIntroduce.text.Equals("") && clubIntroduce.text.ToString().Length > 0)
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
        UINewClubPanel.enterTheIntroduce.text = clubIntroduce.text;
        UIPanelManager.Instance.showUIPanel(this.beforeID);
    }


    #endregion
}
