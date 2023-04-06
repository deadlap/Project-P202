using UnityEngine;

public class LimitChildAmount : MonoBehaviour
{
    //The way Gameobjects with the ItemDrag script finds it's original parent is through tags.
    //There could be instances of parents with the same tags exists.
    
    //Code by HiddenMonk: https://forum.unity.com/threads/set-a-parents-child-to-allow-only-one-child-per-object.341296/
    //Very slightly modified. Instead of setting parent to null, a step parent has been made.

    [SerializeField] int maxChildAmount = 1;
    [SerializeField] GameObject stepParent; 
    void Update()
    {
        if(transform.childCount > maxChildAmount)
        {
            for(int i = maxChildAmount; i < transform.childCount; i++)
            {
                transform.GetChild(i).SetParent(stepParent.transform);
            }
        }
    }
}
