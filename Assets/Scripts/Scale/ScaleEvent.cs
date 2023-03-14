using System;
public class ScaleEvent
{
    public static event Action ItemSlotFull;
    public static void OnItemSlotFull() => ItemSlotFull?.Invoke();
}
