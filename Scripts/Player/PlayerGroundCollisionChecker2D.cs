using UnityEngine;
using System.Collections;

public class PlayerGroundCollisionChecker2D : MonoBehaviour 
{
    [Header("Raycast Settings")]
    [Tooltip("The Layer that the Raycast checks.")][SerializeField]private LayerMask _groundLayer;
    [Tooltip("The length of the Raycast which the Raycast checks.")][SerializeField]private float _checkRange;
    [Tooltip("The offset of the Raycast.")][SerializeField]private Vector2 _checkOffset;

    
    private bool _canJump;
    public bool CanJump
    {
        get
        {
            return _canJump;
        }
    }

	void Update () 
    {
        Vector2 rayOrigin = new Vector2(transform.position.x - _checkOffset.x, transform.position.y - _checkOffset.y);
        Debug.DrawRay(rayOrigin, Vector2.right * _checkRange, Color.blue);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right, _checkRange, _groundLayer);

        if(hit.collider != null)
        {
            _canJump = true;
        }
        else
        {
            _canJump = false;
        }
	}
}
