using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRectSnap : MonoBehaviour
{
    public RectTransform contentRect;
    public List<GameObject> item;
    public float[] distance;
    public GameObject center;
    public float minDistance;
    public int minItemNum;
    public int menuSelect;

    private float itemDistance;
    private bool isDragging = false;
    private bool firstStart = true;

    // Start is called before the first frame update
    void Start()
    {
        int buttonLength = item.Count;
        distance = new float[buttonLength];
        
    }

    // Update is called once per frame
    void Update()
    {
        float item1Pos = item[1].GetComponent<RectTransform>().anchoredPosition.x;
        float item0Pos = item[0].GetComponent<RectTransform>().anchoredPosition.x;
        
        itemDistance = Mathf.Abs(item1Pos - item0Pos);

        if (itemDistance == 0)
            return;
        if(firstStart)
        {
            menuSelect = GameDataScript.instance.select;
            minItemNum = menuSelect;
            if (minItemNum != 0)
            {
                contentRect.anchoredPosition = new Vector3(minItemNum * -itemDistance, 0, 0);
            }
            firstStart = false;
        }
        

        for (int i = 0; i < item.Count; i++)
        {
            distance[i] = Mathf.Abs(center.transform.position.x - item[i].transform.position.x);
        }
        minDistance = Mathf.Min(distance);

        for(int i = 0; i < item.Count; i++)
        {
            if(minDistance == distance[i])
            {
                minItemNum = i;
            }
        }
        
        if(minItemNum != menuSelect)
        {
            GameDataScript.instance.select = minItemNum;
            menuSelect = minItemNum;

        }

        if(!isDragging)
        {
            float targetPos = minItemNum * -itemDistance;
            float newX = Mathf.Lerp(contentRect.anchoredPosition.x, targetPos, Time.deltaTime * 10);
            Vector2 newPosition = new Vector2(newX, contentRect.anchoredPosition.y);
            contentRect.anchoredPosition = newPosition;
        }

    }
    public void StartDrag()
    {
        isDragging = true;
    }
    public void EndDrag()
    {
        isDragging = false;
    }
}
