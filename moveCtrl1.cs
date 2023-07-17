using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class moveCtrl1 : MonoBehaviour
{
    //로직에 사용되는 변수 설정
    public Camera fpsCam;
    public GameObject submenu;
    public GameObject secondStoryBTN;
    public GameObject AIStoryBTN;
    public GameObject transformTarget;
    public GameObject transformTargetB;
    public GameObject transformTargetC;
    public GameObject doorLockHint;
    public GameObject lockHint;
    public GameObject Keypad;
    public GameObject KeypadUI;
    public GameObject lockImage;
    public GameObject clipboard;
    public GameObject finalStory;
    public GameObject FinalStoryBTN;
    public GameObject endStory;
    public GameObject endVideo;

    bool isClipboard;
    bool isLock;
    bool isDoorLockHint;
    bool isLockHint;
    bool isKeypad;
   public bool isEndStoryReady;

    Animator endAnim;

    void Awake()
    {
        //endAnim = GetComponent<Animator>();
    }
    void Start()
    {
        isEndStoryReady = false;
    }

    void Update()
    {
        Move();
        Click();
    }
    //Input을 이용하여 캐릭터를 움직이는 로직 TimedeltaTime을 이용하여 사양에 상관없이 같은 속도로 이동한다.
    void Move()
    {
        if (Input.GetKey(KeyCode.W))//w키가 입력되면 캐릭터가 앞쪽으로 5.0f의 속도로 움직인다.
        {
            this.transform.Translate(Vector3.forward * 5.0f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))//s키가 입력되면 캐릭터가 앞쪽으로 5.0f의 속도로 움직인다.
        {
            this.transform.Translate(Vector3.back * 5.0f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))//a키가 입력되면 캐릭터가 앞쪽으로 5.0f의 속도로 움직인다.
        {
            this.transform.Translate(Vector3.left * 5.0f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))//d키가 입력되면 캐릭터가 앞쪽으로 5.0f의 속도로 움직인다.
        {
            this.transform.Translate(Vector3.right * 5.0f * Time.deltaTime);
        }

        //SubMenu를 불러오기 위한 로직(ESC키를 누르면 SubMenu를 SetActive(treu)상태로 만들고 현재 캔버스에 켜져있는 다른 오브젝트들을 SetActive(false)로 만든다.
        if (Input.GetButtonDown("Cancel"))//sub menu.
        {
            if (isDoorLockHint)
            {
                doorLockHint.SetActive(false);
                isDoorLockHint = false;
                Time.timeScale = 1;
                return;
            }
            if (isLockHint)
            {
                lockHint.SetActive(false);
                isLockHint = false;
                Time.timeScale = 1;
                return;
            }
            if (isLock)
            {
                lockImage.SetActive(false);
                isLock = false;
                Time.timeScale = 1;
                return;
            }
            if (isKeypad)
            {
                KeypadUI.SetActive(false);
                isKeypad = false;
                Time.timeScale = 1;
                return;
            }
            if (isClipboard)
            {
                clipboard.SetActive(false);
                finalStory.SetActive(true);
                isClipboard = false;
                Time.timeScale = 1;
                return;
            }
            if (submenu.activeSelf)
            {
                submenu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                submenu.SetActive(true);
                Time.timeScale = 0;
            }

        }
        // 마우스 휠을 누르고 마우스를 돌리는 것으로 카메라의 각도를 바꾸는 로직
        //Input을 이용하여 마우스의 각도를 변수에 저장하고 그 각도를 변수로 저장한 카메라에 X와 Y좌표에 입력한다.
        if (Input.GetMouseButton(2))
        {
            float rotX = Input.GetAxis("Mouse Y") * 2.0f; //마우스의 움직임이 입력되면 x축 움직임에 3.0f속도를 곱한다.
            float rotY = Input.GetAxis("Mouse X") * 2.0f; //마우스의 움직임이 입력되면 y축 움직임에 3.0f속도를 곱한다.

            this.transform.localRotation *= Quaternion.Euler(0, rotY, 0); //위에서 계산된 float rotY값을 카메라 좌표에 입력한다.
            fpsCam.transform.localRotation *= Quaternion.Euler(-rotX, 0, 0); //위에서 계산된 float rotX값을 카메라 좌표에 입력한다.
        }
    }
    //플레이어가 다음 스토리를 이어가기 위한 로직(OnTrigerEnter함수를 사용하여 충돌시 스토리의 시작 버튼이 활성화 되도록 설정)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SecondStoryStartBox")
            secondStoryBTN.SetActive(true);

        if (other.gameObject.name == "AIStoryStart")
            AIStoryBTN.SetActive(true);

        if (other.gameObject.name == "FinalStoryStartBox")
        {
            FinalStoryBTN.SetActive(true);
            isEndStoryReady = true;
        }

        if(isEndStoryReady && other.gameObject.name == "EndStory")
        {
            StartCoroutine(Ending());
        }
    }
    //퍼즐을 풀기 위하여 힌트 또는 객체를 클릭할 시 오브젝트를 활성화 시키는 로직
    void Click()
    {
        //ScreenPointToRay함수를 이용하여 마우스의 클릭 위치를 Ray로 파악하고 그 위치에 해당 오브젝트가 있다면 활성화 되도록 설정
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
            if (hit.collider.gameObject.name == "DoorLockHint" && Input.GetMouseButton(0))
            {
                doorLockHint.SetActive(true);
                isDoorLockHint = true;
                Time.timeScale = 0;
            }
        {
            if (hit.collider.gameObject.name == "PenHolder_01_snaps001" && Input.GetMouseButton(0))
                Keypad.SetActive(true);
            if (hit.collider.gameObject.name == "KeyPad" && Input.GetMouseButton(0))
            {
                KeypadUI.SetActive(true);
                isKeypad = true;
                Time.timeScale = 0;
            }
            if (hit.collider.gameObject.name == "Lock" && Input.GetMouseButton(0))
            {
                lockImage.SetActive(true);
                isLock = true;
                Time.timeScale = 0;
            }
            if (hit.collider.gameObject.name == "LockHint" && Input.GetMouseButton(0))
            {
                lockHint.SetActive(true);
                isLockHint = true;
                Time.timeScale = 0;
            }
            if (hit.collider.gameObject.name == "Clipboard" && Input.GetMouseButton(0))
            {
                clipboard.SetActive(true);
                isClipboard = true;
                Time.timeScale = 0;
            }
            
        }
    }
    //마지막 장면의 동영상 파일을 보고 자연스러운 마무리를 위한 Coroutine 로직
    IEnumerator Ending()
    {
        yield return new WaitForSeconds(0.01f);
        endVideo.SetActive(true);
        yield return new WaitForSeconds(56f);
        endVideo.SetActive(false);
        endStory.SetActive(true);
        endAnim = endStory.GetComponent<Animator>();
        endAnim.SetTrigger("In");
        yield return new WaitForSeconds(0.01f);
    }
}
