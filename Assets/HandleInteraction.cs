using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandleInteraction : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [HideInInspector] public MathInput mathInput;
    [SerializeField] bool isUndo;
    [SerializeField] int stabilizer = 10;
    [SerializeField] float rotSpeed = 0.5f;
    RectTransform handle;
    float mousePos;
    int minRot = 0;
    int maxRot = -60;
    bool dragEnded;
    void Start() {
        handle = GetComponent<RectTransform>();
    }

    void Update() {
        Quaternion curPos = handle.rotation;
        if(!dragEnded) return;
        Quaternion newPos = Quaternion.Euler(0, 0, 0);
        handle.rotation = Quaternion.RotateTowards(curPos,newPos, Time.deltaTime * rotSpeed);
        if (handle.rotation != Quaternion.Euler(0, 0, 0)) return;
        dragEnded = false;
    }

    public void OnDrag(PointerEventData eventData) {
        if (eventData.delta.y < 0) {
            mousePos = -eventData.delta.magnitude / stabilizer;
        }
        else if(eventData.delta.y > 0)
            mousePos = eventData.delta.magnitude / stabilizer;
        handle.Rotate(0,0,mousePos);
        
        if (handle.rotation.z < Quaternion.Euler(0, 0, maxRot).z) {
            Debug.Log("ding dong det fong");
            handle.rotation = Quaternion.Euler(0, 0, maxRot);
            
        }
        if (handle.rotation.z > Quaternion.Euler(0, 0, minRot).z) {
            handle.rotation = Quaternion.Euler(0, 0, minRot);
        }
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        if (handle.rotation != Quaternion.Euler(0, 0, maxRot)) return;
        HandleAction();
        dragEnded = true;
    }

    void HandleAction() { //får fejl her, maybe fix eller lav et event i stedet ¯\_(ツ)_/¯
        if(isUndo)
            mathInput.Undo();
        else
            mathInput.Send();
    }
}
