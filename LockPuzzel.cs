using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockPuzzel : MonoBehaviour
{
    //4방향 자물쇠 퍼즐 로직을 위한 변수
    public Button centerBtn;
    public Button rightBtn;
    public Button leftBtn;
    public Button upBtn;
    public Button downBtn;

    //7자리의 답을 Text로 설정하고 변수화 
    public Text answerA;
    public Text answerB;
    public Text answerC;
    public Text answerD;
    public Text answerE;
    public Text answerF;
    public Text answerG;

    public GameObject lockImage;
    public GameObject cabinetA;
    public GameObject cabinetB;

    //Start 함수를 통해 로직이 처음 실행되었을 때 Text를 0으로 초기화
    void Start()
    {
        answerA.text = "0";
        answerB.text = "0";
        answerC.text = "0";
        answerD.text = "0";
        answerE.text = "0";
        answerF.text = "0";
        answerG.text = "0";
    }
    //자물쇠의 오른쪽 방향의 버튼을 누를 시 7자리의 Text가 한자리씩 1로 설정되도록 하는 로직(Unity의 Click기능을 사용하여 버튼에 함수를 이식)
    public void RightBtn()
    {
        if(answerA.text == "0")
            answerA.text = "1";
        else if (answerA.text != "0" && answerB.text =="0")
            answerB.text = "1";
        else if (answerB.text != "0" && answerC.text == "0")
            answerC.text = "1";
        else if (answerC.text != "0" && answerD.text == "0")
            answerD.text = "1";
        else if (answerD.text != "0" && answerE.text == "0")
            answerE.text = "1";
        else if (answerE.text != "0" && answerF.text == "0")
            answerF.text = "1";
        else if (answerF.text != "0" && answerG.text == "0")
            answerG.text = "1";
    }
    //자물쇠의 왼쪽 방향의 버튼을 누를 시 7자리의 Text가 한자리씩 2로 설정되도록 하는 로직(Unity의 Click기능을 사용하여 버튼에 함수를 이식)
    //위의 RightBtn() 함수의 변형
    public void LeftBtn()
    {
        if (answerA.text == "0")
            answerA.text = "2";
        else if (answerA.text != "0" && answerB.text == "0")
            answerB.text = "2";
        else if (answerB.text != "0" && answerC.text == "0")
            answerC.text = "2";
        else if (answerC.text != "0" && answerD.text == "0")
            answerD.text = "2";
        else if (answerD.text != "0" && answerE.text == "0")
            answerE.text = "2";
        else if (answerE.text != "0" && answerF.text == "0")
            answerF.text = "2";
        else if (answerF.text != "0" && answerG.text == "0")
            answerG.text = "2";
    }

    //자물쇠의 위쪽 방향의 버튼을 누를 시 7자리의 Text가 한자리씩 3로 설정되도록 하는 로직(Unity의 Click기능을 사용하여 버튼에 함수를 이식)
    //위의 RightBtn() 함수의 변형
    public void UpBtn()
    {
        if (answerA.text == "0")
            answerA.text = "3";
        else if (answerA.text != "0" && answerB.text == "0")
            answerB.text = "3";
        else if (answerB.text != "0" && answerC.text == "0")
            answerC.text = "3";
        else if (answerC.text != "0" && answerD.text == "0")
            answerD.text = "3";
        else if (answerD.text != "0" && answerE.text == "0")
            answerE.text = "3";
        else if (answerE.text != "0" && answerF.text == "0")
            answerF.text = "3";
        else if (answerF.text != "0" && answerG.text == "0")
            answerG.text = "3";
    }

    //자물쇠의 아래쪽 방향의 버튼을 누를 시 7자리의 Text가 한자리씩 4로 설정되도록 하는 로직(Unity의 Click기능을 사용하여 버튼에 함수를 이식)
    //위의 RightBtn() 함수의 변형
    public void DownBtn()
    {
        if (answerA.text == "0")
            answerA.text = "4";
        else if (answerA.text != "0" && answerB.text == "0")
            answerB.text = "4";
        else if (answerB.text != "0" && answerC.text == "0")
            answerC.text = "4";
        else if (answerC.text != "0" && answerD.text == "0")
            answerD.text = "4";
        else if (answerD.text != "0" && answerE.text == "0")
            answerE.text = "4";
        else if (answerE.text != "0" && answerF.text == "0")
            answerF.text = "4";
        else if (answerF.text != "0" && answerG.text == "0")
            answerG.text = "4";
    }

    //자물쇠의 가운대 버튼을 누를 시 7자리의 답을 확인하는 로직(Unity의 Click기능을 사용하여 버튼에 함수를 이식)
    //답이 맞다면 자물쇠 퍼즐은 SetActive(false)가 되고 다음 이벤트가 자동으로 진행된다.
    //답이 틀리다면 모든 변수를 다시 0으로 설정한다.
    public void CenterBtn()
    {
        if(answerA.text == "1" && answerB.text == "4"
            && answerC.text == "4" && answerD.text == "1"
            && answerE.text == "1" && answerF.text == "2" && answerG.text == "4")
        {

            lockImage.SetActive(false);
            cabinetA.SetActive(false);
            cabinetB.SetActive(true);
            Clicky();
            Time.timeScale = 1;
        }
        else
        {
            answerA.text = "0";
            answerB.text = "0";
            answerC.text = "0";
            answerD.text = "0";
            answerE.text = "0";
            answerF.text = "0";
            answerG.text = "0";
        }
    }
    // 버튼을 클릭할시 AudioSource를 플레이 하는 로직
    public void Clicky()
    {
        cabinetB.GetComponent<AudioSource>().Play();
    }
}
