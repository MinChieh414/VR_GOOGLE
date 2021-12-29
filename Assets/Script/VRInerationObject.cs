using UnityEngine;
using UnityEngine.Events; 

public class VRInerationObject : MonoBehaviour
{
    [Header("事件 : 看到、離開與點擊")]
    public UnityEvent onEnter;
    public UnityEvent onExit;
    public UnityEvent onClick;
    public void OnPointerEnter()
    {
        onEnter.Invoke(); 
    }
    public void OnPointerExit()
    {
        onExit.Invoke();
    }
    public void OnPointerClick()
    {
        onClick.Invoke();
    }
}
