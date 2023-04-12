using UnityEngine;
using UnityEngine.EventSystems;

public class HandleInteraction : MonoBehaviour, IDragHandler, IEndDragHandler {
    [SerializeField] bool isLeftHandle;
    [SerializeField] int dragStabilizer = 10;
    [SerializeField] float returnSpeed = 200f;
    [SerializeField] int maxRotation = 60;
    [SerializeField] int minRotation = 0;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip[] audioClip;
    
    RectTransform handle;
    float mousePos;
    bool dragEnded;
    void Start() {
        handle = GetComponent<RectTransform>();
    }

    void Update() {
        ResetHandlePosition();
    }
    
    public void OnDrag(PointerEventData eventData) {
        RightHandle(eventData);
        LeftHandle(eventData);
    }
    
    public void OnEndDrag(PointerEventData eventData) {
        dragEnded = true;
        HandleAction();
    }
    
    void ResetHandlePosition() {
        Quaternion curPos = handle.rotation;
        if(!dragEnded) return;
        Quaternion newPos = Quaternion.Euler(0, 0, 0);
        handle.rotation = Quaternion.RotateTowards(curPos,newPos, Time.deltaTime * returnSpeed);
        if (handle.rotation != Quaternion.Euler(0, 0, 0)) return;
        audioSource.PlayOneShot(audioClip[0]);
        dragEnded = false;
    }

    void HandleAction() {
        if (handle.rotation == Quaternion.Euler(0, 0, maxRotation))
            HandleEvents.OnLeftHandlePulled();
        if (handle.rotation == Quaternion.Euler(0, 0, -maxRotation))
            HandleEvents.OnRightHandlePulled();
    }
    
    void RightHandle(PointerEventData eventData) {
        if (isLeftHandle) return;
        if (eventData.delta.y < 0)
            mousePos = -eventData.delta.magnitude / dragStabilizer;
        if (eventData.delta.y > 0)
            mousePos = eventData.delta.magnitude / dragStabilizer;

        handle.Rotate(0,0,mousePos);
        
        if (handle.rotation.z < Quaternion.Euler(0,0,-maxRotation).z)
            handle.rotation = Quaternion.Euler(0, 0, -maxRotation);
        if (handle.rotation.z > Quaternion.Euler(0,0,minRotation).z)
            handle.rotation = Quaternion.Euler(0, 0, minRotation);
    }
    
    void LeftHandle(PointerEventData eventData) {
        if (!isLeftHandle) return;
        if (eventData.delta.y > 0)
            mousePos = -eventData.delta.magnitude / dragStabilizer;
        if (eventData.delta.y < 0)
            mousePos = eventData.delta.magnitude / dragStabilizer;

        handle.Rotate(0,0,mousePos);
        
        if (handle.rotation.z > Quaternion.Euler(0,0,maxRotation).z)
            handle.rotation = Quaternion.Euler(0, 0, maxRotation); 
        if (handle.rotation.z < Quaternion.Euler(0,0,minRotation).z)
            handle.rotation = Quaternion.Euler(0, 0, minRotation);
    }
}
