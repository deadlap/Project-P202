using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HintManager : MonoBehaviour {
    [SerializeField] TextMeshProUGUI textDisplay;
    [SerializeField] GameObject hintPanel;
    List<string> hintText;
    List<int> hintIDs;
    int index;
    bool IsScaleScene;
    void Start(){
        IsScaleScene = ("Scale"==SceneManager.GetActiveScene().name);
    }
    // \n
    public void PickHint(){
        hintIDs = new List<int>();
        hintText = new List<string>();
        index = -1;
        if (IsScaleScene){
            hintText = new List<string>{"Husk reglen for lighedstegnet: talværdien af det, som står på begge sider af lighedstegnet, skal være den samme.", 
            "Der kan stå et regnestykke på hver side af lighedstegnet, hvis blot de begge giver det samme resultat. For eksempel er \n 4 + 2 * 3 = 3 * 3 + 1 \n da begge sider giver talværdien 10"};
            hintPanel.SetActive(true);
            ChangeText();
        } else {
            SelectPossibleSolveHints();
            if (hintIDs.Count > 0) {
                hintPanel.SetActive(true);
                ActivateHint(hintIDs[UnityEngine.Random.Range(0,hintIDs.Count)]);
                ChangeText();
            } else {
                //spil error animation/lyd fordi vi ikke har nogen hints at give
            }
        }
    }

    public void SelectPossibleSolveHints(){
        Equation equation = LevelManager.ActiveLevel.equation.equation;

        if (ID1(equation))
        {
            hintIDs.Add(1);
            Debug.Log("ID1 active");

        }
        if (ID2(equation))
        {
            Debug.Log("ID2 active");
            hintIDs.Add(2);
        }
           
        if (ID3(equation))
        {
            hintIDs.Add(3);
            Debug.Log("ID3 active");
        }
        if (ID4(equation))
        {
            hintIDs.Add(4);
            Debug.Log("ID4 active");
        }
        if (ID5(equation))
        {
            hintIDs.Add(5);
            Debug.Log("ID5 active");
        }
            
    }

    public void ActivateHint(int ID){
        // \n
        switch(ID){
            case 1:
                hintText = new List<string>{"Start med at <b>samle de led, som indeholder \"x\"</b>,<br> på en af siderne af lighedstegnet.<br>",
                "<b>\"Led\"</b> er opdelt af plusser (+) og minusser (-).<br> Ligningen 2x+4=10-x består af fire led. \n 2x er et led. +4 er et led. \n 10 er et led.  og -x er et led."
                };
                break;
            case 2:
                hintText = new List<string>{"X'erne er samlet på den ene side af lighedstegnet.<br> <b>Saml nu de led som ikke indeholder x</b> på den <br> modsatte side af lighedstegnet.",
                 "\"Led\" er opdelt af plusser (+) og minusser (-).<br> Ligningen 2x+4=10-x består af fire led. \n 2x er et led. +4 er et led. \n 10 er et led.  og -x er et led."};
                break;
            case 3:
                hintText = new List<string>{"Du kan bruge <b>division</b> til at fjerne <br> et tal som ganges på x."};
                break;
            case 4:
                hintText = new List<string>{"Du kan <b>flytte et positivt led</b> til den modsatte<br> side af lighedstegnet, ved at <b>trække det fra på <br>begge sider</b>. Et <b>negativt led</b> kan <br><b>flyttes ved at plusse med det</b>."};
                break;           
            case 5:
                hintText = new List<string>{"Ligningen indeholder en eller flere brøker. Brøker kan \"fjernes\" ved at gange med tallet i nævneren på begge sider af lighedstegnet."};
                break;
        }
    }

    public void ChangeText(){
        index++;
        if(index == hintText.Count) {
            hintPanel.SetActive(false);
            index = 0;
        } else {
            textDisplay.text = hintText[index];
        }
    }
    public bool ID1(Equation equation){
        return (Math.Abs(equation.leftTerm) > 0 &&
        Math.Abs(equation.leftXTerm) > 0 &&
        Math.Abs(equation.rightTerm) > 0 &&
        Math.Abs(equation.rightXTerm) > 0);
    }
    public bool ID2(Equation equation){
        return (equation.leftXTerm == 0 && equation.rightTerm != 0 || equation.rightXTerm==0 && equation.leftTerm != 0);
    }
    public bool ID3(Equation equation){
        return ((Math.Abs(equation.leftXTerm) > 1 && Math.Abs(equation.rightTerm) > 0 && Math.Abs(equation.leftTerm) == 0 && Math.Abs(equation.rightXTerm) == 0)
            || (Math.Abs(equation.rightXTerm) > 1 && Math.Abs(equation.leftTerm) > 0  && Math.Abs(equation.rightTerm) == 0 && Math.Abs(equation.leftXTerm) == 0));
    }
    public bool ID4(Equation equation){
        return (equation.leftXTerm == 0 && equation.rightTerm != 0 || equation.rightXTerm == 0 && equation.leftTerm != 0) ||
            (Math.Abs(equation.leftTerm) > 0 &&
        Math.Abs(equation.leftXTerm) > 0 &&
        Math.Abs(equation.rightTerm) > 0 &&
        Math.Abs(equation.rightXTerm) > 0);
            //(equation.leftTerm > 0 || equation.rightTerm > 0) || (equation.leftTerm < 0 || equation.rightTerm < 0) || (equation.leftXTerm > 0 || equation.rightXTerm > 0) || (equation.leftXTerm < 0 || equation.rightXTerm < 0);
    }
    public bool ID5(Equation equation){
        return (equation.leftTerm % 1 != 0 ||
            equation.leftXTerm % 1 != 0 ||
            equation.rightTerm % 1 != 0 ||
            equation.rightXTerm % 1 != 0);
    }
}