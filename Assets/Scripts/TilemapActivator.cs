using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapActivator : MonoBehaviour
{
    [SerializeField] private Tilemap _openedDoor;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerMovement playerMovement) == false) return;
        
        _openedDoor.gameObject.SetActive(true);
    }
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerMovement playerMovement) == false) return;
        
        _openedDoor.gameObject.SetActive(false);
    }
}
