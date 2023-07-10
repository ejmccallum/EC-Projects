using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace EC
{
    public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private Canvas canvas;
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;

        public static GameObject itemBeingDragged;
        private Vector3 startPosition;
        private Transform startParent;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnBeginDrag");
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
            startPosition = transform.position;
            startParent = transform.parent;
            itemBeingDragged = gameObject;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("OnDrag");
            rectTransform.anchoredPosition += eventData.delta;
        }

        public void OnEndDrag(PointerEventData eventData)
        {

            itemBeingDragged = null;
            if(transform.parent == startParent || transform.parent == transform.root)
            {
                transform.position = startPosition;
                transform.SetParent(startParent);
            }
            
            Debug.Log("OnEndDrag");

            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }



    }


}