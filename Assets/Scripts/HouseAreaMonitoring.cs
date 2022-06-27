using UnityEngine;
using UnityEngine.Events;

public class HouseAreaMonitoring : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> _onSomebodyInside;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerMovement playerMovement) == false) return;
        
        _onSomebodyInside?.Invoke(true);
    }
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerMovement playerMovement) == false) return;
        
        _onSomebodyInside?.Invoke(false);
    }
}

