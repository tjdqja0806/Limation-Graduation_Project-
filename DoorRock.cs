using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorRock : MonoBehaviour
{
    //로직에 사용되는 변수
    public Button number1;
    public Button number2;
    public Button number3;
    public Button number4;
    public Button number5;
    public Button number6;
    public Button number7;
    public Button number8;
    public Button number9;
    public Button cancel;
    public Button ok;
    public Text password1;
    public Text password2;
    public Text password3;
    public Text password4;
    public GameObject doorRock;
    public GameObject Keypad;
    public GameObject cabinetA;
    public GameObject cabinetB;
    public GameObject secretDoor;
    bool isOpen;
    public GameObject cabinetVec;
    public GameObject Jabeez;

    AudioSource source;

    //AudioSource를 사용하기 위하여 Awake함수에서 컴포넌트 초기화
    void Awake()
    {
        source = cabinetA.GetComponent<AudioSource>();
    }

    //버튼을 클릭할 시 AudioSource를 플레이하는 로직
    public void Clicky()
    {
        GetComponent<AudioSource>().Play();
    }

    //키패드의 버튼을 누르면 4자리 숫자의 텍스트를 순서대로 해당 버튼의 숫자로 설정하는 로직(Unity의 Click기능을 사용하여 버튼에 함수를 이식)
    //ex) 숫자 1 버튼을 누르면 텍스트가 1로 설정되고 숫자 7 버튼을 누르면 텍스트가 숫자 7로 설정
    public void btn1()
    {        
        if (password1.text == "0")
            password1.text = "1";
        else if (password1.text != "0" && password2.text == "0")
            password2.text = "1";
        else if(password2.text != "0" && password3.text == "0")
            password3.text = "1";
        else if (password3.text != "0" && password4.text == "0")
            password4.text = "1";
    }
    public void btn2()
    {
        if (password1.text == "0")
            password1.text = "2";
        else if (password1.text != "0" && password2.text == "0")
            password2.text = "2";
        else if (password2.text != "0" && password3.text == "0")
            password3.text = "2";
        else if (password3.text != "0" && password4.text == "0")
            password4.text = "2";
    }
    public void btn3()
    {
        if (password1.text == "0")
            password1.text = "3";
        else if (password1.text != "0" && password2.text == "0")
            password2.text = "3";
        else if (password2.text != "0" && password3.text == "0")
            password3.text = "3";
        else if (password3.text != "0" && password4.text == "0")
            password4.text = "3";
    }
    public void btn4()
    {
        if (password1.text == "0")
            password1.text = "4";
        else if (password1.text != "0" && password2.text == "0")
            password2.text = "4";
        else if (password2.text != "0" && password3.text == "0")
            password3.text = "4";
        else if (password3.text != "0" && password4.text == "0")
            password4.text = "4";
    }
    public void btn5()
    {
        if (password1.text == "0")
            password1.text = "5";
        else if (password1.text != "0" && password2.text == "0")
            password2.text = "5";
        else if (password2.text != "0" && password3.text == "0")
            password3.text = "5";
        else if (password3.text != "0" && password4.text == "0")
            password4.text = "5";
    }
    public void btn6()
    {
        if (password1.text == "0")
            password1.text = "6";
        else if (password1.text != "0" && password2.text == "0")
            password2.text = "6";
        else if (password2.text != "0" && password3.text == "0")
            password3.text = "6";
        else if (password3.text != "0" && password4.text == "0")
            password4.text = "6";
    }
    public void btn7()
    {
        if (password1.text == "0")
            password1.text = "7";
        else if (password1.text != "0" && password2.text == "0")
            password2.text = "7";
        else if (password2.text != "0" && password3.text == "0")
            password3.text = "7";
        else if (password3.text != "0" && password4.text == "0")
            password4.text = "7";
    }
    public void btn8()
    {
        if (password1.text == "0")
            password1.text = "8";
        else if (password1.text != "0" && password2.text == "0")
            password2.text = "8";
        else if (password2.text != "0" && password3.text == "0")
            password3.text = "8";
        else if (password3.text != "0" && password4.text == "0")
            password4.text = "8";
    }
    public void btn9()
    {
        if (password1.text == "0")
            password1.text = "9";
        else if (password1.text != "0" && password2.text == "0")
            password2.text = "9";
        else if (password2.text != "0" && password3.text == "0")
            password3.text = "9";
        else if (password3.text != "0" && password4.text == "0")
            password4.text = "9";
    }

    //키패트의 빨간 버튼을 누르면 4자리의 모든 Text를 0으로 설정하는 로직
    public void btnCancle()
    {
        password1.text = "0";
        password2.text = "0";
        password3.text = "0";
        password4.text = "0";
    }

    //키패드의 녹색 확인 버튼을 누르면 답을 확인하는 로직
    public void btnOk()
    {
        //4자리의 숫자 답이 맞다면 다음 이벤트가 자동으로 실행
        if (password1.text == "2" && password2.text == "4" && password3.text == "3" && password4.text == "6")
        {
            if (isOpen) //불값 isOpen이 true일때만 실행된다. 키패트가 SetActive(false) 상태가 되고 Invoke 함수를 이용하여 2초 뒤에 그 다음 이벤트가 자동으로 실행된다.
            {
                doorRock.SetActive(false);
                Keypad.SetActive(false);
                cabinetA.transform.position = cabinetVec.transform.position;
                secretDoor.SetActive(false);
                password1.text = "0";
                password2.text = "0";
                password3.text = "0";
                password4.text = "0";
                isOpen = true;
                Time.timeScale = 1;

                Invoke("appear", 2);

            }
            else//키패트가 SetActive(false) 상태가 되고, 불값 isOpen이 true로 설정된다.  4자리의 답은 모두 0으로 설정된다.
            {
                Keypad.SetActive(false);
                cabinetA.transform.position = cabinetB.transform.position;
                secretDoor.SetActive(true);
                isOpen = true;
                password1.text = "0";
                password2.text = "0";
                password3.text = "0";
                password4.text = "0";
                Time.timeScale = 1;
            }
        }
        else //답이 틀렸다면 4자리 숫자를 0으로 설정한다.
        {
            password1.text = "0";
            password2.text = "0";
            password3.text = "0";
            password4.text = "0";
        }
    }

    void appear()//위의 Invoke에 사용되는 함수로 다음 스토리를 진행하기 위한 NPC를 나타나게 하는 로직
    {
        Jabeez.SetActive(true);
    }
}
