﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchHandlerWeap : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    public Vector2 originalPosition;
    public float moveSpeed;
    public float MinBoundX, MinBoundY, MaxBoundX, MaxBoundY;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        //  originalPosition = rectTransform.anchoredPosition;

        LoadPosition();
    }

    public void OnBeginDrag(PointerEventData eventdata)
    {
        // for when dragging begins

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 newPosition = rectTransform.anchoredPosition + eventData.delta * moveSpeed;
        newPosition.x = Mathf.Clamp(newPosition.x, MinBoundX, MaxBoundX);
        newPosition.y = Mathf.Clamp(newPosition.y, MinBoundY, MaxBoundY);
        rectTransform.anchoredPosition = newPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // for when dragging ends
        SavePosition();
    }

    public void SavePosition()
    {
        PlayerPrefs.SetFloat("UIPositionXW", rectTransform.anchoredPosition.x);
        PlayerPrefs.SetFloat("UIPositionYW", rectTransform.anchoredPosition.y);
        PlayerPrefs.Save();
    }
    private void LoadPosition()
    {
        if (PlayerPrefs.HasKey("UIPositionXW") && PlayerPrefs.HasKey("UIPositionYw"))
        {
            float posX = PlayerPrefs.GetFloat("UIPositionXW");
            float posY = PlayerPrefs.GetFloat("UIPositionYW");
            rectTransform.anchoredPosition = new Vector2(posX, posY);
        }
    }
    public void Reset()
    {
        PlayerPrefs.SetFloat("UIPositionXW", originalPosition.x);
        PlayerPrefs.SetFloat("UIPositionYW", originalPosition.y);
        PlayerPrefs.Save();
        float posX = PlayerPrefs.GetFloat("UIPositionXW");
        float posY = PlayerPrefs.GetFloat("UIPositionYW");
        rectTransform.anchoredPosition = new Vector2(posX, posY);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
