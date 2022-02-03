using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    [SerializeField] private Canvas canvas;
    
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    Vector3 pos;
    Letter letter;

    private GameObject[] frame; //eventData.PointerDrag에 있는 것이 무슨 frame 이미지인지 비교하기 위해
    private Sprite[] decoframe; //Letter Component에 있는 image source 바꿀려고
    GameObject findletter;

    bool isCheckingFirst = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        letter = GameObject.FindObjectOfType<Letter>().GetComponent<Letter>();

        findletter = GameObject.Find("Letter");
        frame = GameObject.FindGameObjectsWithTag("DecoFrame"); //frame 배열에 프레임 이미지들 넣기.
        decoframe = Resources.LoadAll<Sprite>("MiniGame/CardMaking/DecoFrame"); //변수에 이미지 sprite 저장.
        Debug.Log(decoframe.Length);

        pos = this.gameObject.transform.position; //처음 위치
    }

    
    //잡고 움직이기 시작하면 카운트됨.
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    //드래그 ing. 드래그 중일 때 카운트 무한
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");

        if ((this.gameObject.CompareTag("DecoItem")) || (this.gameObject.CompareTag("DecoFrame"))) 
        {
            transform.position = eventData.position;
        }
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;   
    }

    //편지지 밖에서 드랍 시 카운트. --> 편지지에서 드롭 시(Letter 스크립트의 OnDrop)
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");

        if (eventData.pointerDrag.CompareTag("DecoItem")) 
        {
            Flower(eventData);
        }
        else if(eventData.pointerDrag.CompareTag("DecoFrame"))
        {
            BackFrame(eventData);
        }
        else if (eventData.pointerDrag.CompareTag("DecoSentence"))
        {
            Sentence(eventData);
        }

        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }


    //드래그하지 않고 클릭만 할 때
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
    }


    public void SetChecking(bool check)
    {
        isCheckingFirst = check;
    }

    void Flower(PointerEventData flower)
    {
        bool isEnter = letter.GetEnter();

        // isEnter = 편지지 위치여부 변수, isCheckingFirst = 처음 편지지 들어갔을때 확인 변수
        if (flower.pointerDrag != null && isEnter && !isCheckingFirst)  // 현재 Drag이벤트 중인 gameObject를 받을때
        {
            GameObject fbox = Instantiate(flower.pointerDrag.gameObject, pos, Quaternion.identity);
            fbox.name = this.name;
            fbox.transform.SetParent(canvas.transform.Find("DecoItem").transform);
            fbox.GetComponent<CanvasGroup>().alpha = 1.0f;
            fbox.GetComponent<CanvasGroup>().blocksRaycasts = true;

            isCheckingFirst = true;
        }
    }

    void Sentence(PointerEventData sentence)
    {
        bool isEnter = letter.GetEnter();
        transform.rotation = Quaternion.Euler(0,0,0);
        // isEnter = 편지지 위치여부 변수, isCheckingFirst = 처음 편지지 들어갔을때 확인 변수
        if (sentence.pointerDrag != null && isEnter && !isCheckingFirst)  // 현재 Drag이벤트 중인 gameObject를 받을때
        {
            GameObject sbox = Instantiate(sentence.pointerDrag.gameObject, pos, sentence.pointerDrag.gameObject.transform.rotation);
            sbox.name = this.name;
            sbox.transform.SetParent(canvas.transform.Find("DecoItem").transform);
            sbox.GetComponent<CanvasGroup>().alpha = 1.0f;
            sbox.GetComponent<CanvasGroup>().blocksRaycasts = true;

            isCheckingFirst = true;
        }
    }

    void BackFrame(PointerEventData backframe)
    {
        Debug.Log(frame.Length);
        for (int i = 0; i < frame.Length; i++)
        {
            if (frame[i].gameObject == backframe.pointerDrag.gameObject) 
            {
                Debug.Log(decoframe[i].name);
                findletter.GetComponent<Image>().sprite = decoframe[i]; 

                break;
            }
        }
        backframe.pointerDrag.gameObject.transform.position = pos; //아이템 다시 원래 자리로 돌아가기.
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        bool isEnter = letter.GetEnter();
        if (eventData.pointerDrag.CompareTag("DecoItem") && eventData.pointerDrag !=isEnter && isCheckingFirst)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                Destroy(eventData.pointerDrag.gameObject);
            }
        }
        else if (eventData.pointerDrag.CompareTag("DecoSentence") && eventData.pointerDrag != isEnter && isCheckingFirst)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                Destroy(eventData.pointerDrag.gameObject);
            }
        }
    }
}
