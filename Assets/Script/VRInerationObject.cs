using UnityEngine;
using UnityEngine.Events; 

public class VRInerationObject : MonoBehaviour
{
    [Header("�ƥ� : �ݨ�B���}�P�I��")]
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
