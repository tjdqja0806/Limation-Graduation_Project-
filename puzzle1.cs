using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;


public class puzzle1 : MonoBehaviour
{
    //퍼즐 로직에 사용되는 변수
    public Text answer; // Inputfield의 텍스트를 사용하기 위한 변수
    public GameObject puzzle; // Puzzle GUI의 변수
    public string ans; // 답을 저장하기 위한 변수(대소문자 구분없이 답을 사용하기 위하여 3가지 변수를 사용)
    public string ansB;//답을 저장하기 위한 변수
    public string ansC; //답을 저장하기 위한 변수
    public GameObject afterStory; //퍼즐 다음에 자동으로 실행되는 스토리
    
    void Update()
    {
         
        if( Input.GetKeyDown(KeyCode.Return)) //키보드의 Enter버튼을 이용하여 답을 확인
        {
            if (answer.text == ans || answer.text == ansB || answer.text == ansC) //Inputfield에 적은 답이 변수에 저장된 답과 같다면 실행되는 로직. 
            {
                puzzle.SetActive(false);
                afterStory.SetActive(true);

            }
        }
    }
}
