
//     http://www.apache.org/licenses/LICENSE-2.0

using System.Collections;
using UnityEngine;


public class CameraPointer : MonoBehaviour
{
    private const float _maxDistance = 10;
    private GameObject _gazedAtObject = null;

  
    public void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance, 1 << 3))
        {
          
            if (_gazedAtObject != hit.transform.gameObject)
            {     
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter");
            }
        }
        else
        {  
            _gazedAtObject?.SendMessage("OnPointerExit");
            _gazedAtObject = null; 
        }

        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            _gazedAtObject?.SendMessage("OnPointerClick");
        }
    }
}
