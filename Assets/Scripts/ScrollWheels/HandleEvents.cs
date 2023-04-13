using System;

public class HandleEvents {
    public static event Action RightHandlePulled; 
    public static event Action LeftHandlePulled; 
    public static event Action EquationSolved;

    public static void OnRightHandlePulled() => RightHandlePulled?.Invoke();
    public static void OnLeftHandlePulled() => LeftHandlePulled?.Invoke();
}
