﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileDataUpdater : MonoBehaviour
{
    public Text pointsText, coinstText, percentageText, profileName;

    public GameObject selectProfilePanel;


    // Start is called before the first frame update
    void Start()
    {
        selectProfilePanel.transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("InputNick").transform.localScale = new Vector3(0, 0, 0);
        Profiles.LoadProfiles();
        if (Profiles.GetNumberOfProfiles() != 0)
        {
            selectProfilePanel.transform.localScale = new Vector3(0, 0, 0);
            GameObject.Find("Profile").GetComponent<ProfileDataUpdater>().UpdateData();
        }
        else selectProfilePanel.transform.localScale = new Vector3(1, 1, 1);
        

    }

    public void UpdateData()
    {
        pointsText.text = Profiles.GetPoints().ToString();
        coinstText.text = Profiles.GetCoins().ToString();
        percentageText.text = Profiles.GetPercentage().ToString();
        profileName.text = Profiles.GetName();
    }



    public void NewProfileInputField(Text name)
    {
        GameObject.Find("InputNick").transform.localScale = new Vector3(0, 0, 0);
        Debug.Log(name.text);
        foreach(ButtonScript bs in selectProfilePanel.GetComponentsInChildren<ButtonScript>())
        {
            if (bs.IsSelected())
            {
                Profiles.AddNewProfile(name.text, int.Parse(bs.transform.gameObject.name[7]+"")-1);
                Profiles.SetProfileSelected(name.text);
            }
        }

        
        foreach(Button b in selectProfilePanel.GetComponentsInChildren<Button>())
        {
            if (b.GetComponent<ButtonScript>().IsSelected())
            {
                b.GetComponentInChildren<Text>().text = name.text;
                b.GetComponentInParent<PermanentButtonsAdmin>().NewSelection(gameObject.name);
            }
        }


        selectProfilePanel.transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Profile").GetComponent<ProfileDataUpdater>().UpdateData();

    }


    public void OnClickButton()
    {
       
        selectProfilePanel.transform.localScale = new Vector3(1, 1, 1);
    }

}
