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
                ActivateHint(hintIDs[UnityEngine.Random.Range(0,hintIDs.Count-1)]);
                ChangeText();
            } else {
                //spil error animation/lyd fordi vi ikke har nogen hints at give
            }
        }
    }

    public void SelectPossibleSolveHints(){
        Equation equation = LevelManager.ActiveLevel.equation.equation;

        if (ID1(equation))
            hintIDs.Add(1);
        if (ID2(equation))
            hintIDs.Add(2);
        if (ID3(equation))
            hintIDs.Add(3);
        if (ID4(equation))
            hintIDs.Add(4);
        if (ID5(equation))
            hintIDs.Add(5);
    }

    public void ActivateHint(int ID){
        // \n
        switch(ID){
            case 1:
                hintText = new List<string>{"Start med at samle de led, som indeholder \"x\", på en af siderne af lighedstegnet. Husk du kan altid fortryde ved at trækkke i venstre håndtag",
                "\"Led\" er opdelt af plusser (+) og minusser (-). Ligningen 2x+4=10-x består af fire led. \n 2x er et led. \n +4 er et led. \n 10 er et led. \n og -x er et led. \n "
                };
                break;
            case 2:
                hintText = new List<string>{"x'erne er samlet på den ene side af lighedstegnet. Saml nu de led som ikke indeholder x på den modsatte side af lighedstegnet."};
                break;
            case 3:
                hintText = new List<string>{"Du er der næsten! Du kan bruge division til finde talværdien af x."};
                break;
            case 4:
                hintText = new List<string>{"Du kan <b>flytte et positivt led</b> til den modsatte side af lighedstegnet, ved at trække det fra på begge sider. Et negativt led kan flyttes ved at plusse med det."};
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
        Math.Abs(equation.rightXTerm) > 0
        );
    }
    public bool ID2(Equation equation){
        return (equation.leftXTerm == 0 || equation.rightXTerm==0);
    }
    public bool ID3(Equation equation){
        return ((Math.Abs(equation.leftXTerm) > 1 && Math.Abs(equation.rightTerm) > 0 && Math.Abs(equation.leftTerm) == 0 && Math.Abs(equation.rightXTerm) == 0)
            || (Math.Abs(equation.rightXTerm) > 1 && Math.Abs(equation.leftTerm) > 0  && Math.Abs(equation.rightTerm) == 0 && Math.Abs(equation.leftXTerm) == 0)); 
    }
    public bool ID4(Equation equation){
        return (equation.leftTerm > 0 || equation.rightTerm > 0) || (equation.leftTerm < 0 || equation.rightTerm < 0) || (equation.leftXTerm > 0 || equation.rightXTerm > 0) || (equation.leftXTerm < 0 || equation.rightXTerm < 0);
    }
    public bool ID5(Equation equation){
        return (equation.leftTerm % 1 != 0 ||
            equation.leftXTerm % 1 != 0 ||
            equation.rightTerm % 1 != 0 ||
            equation.rightXTerm % 1 != 0
        );
    }
}