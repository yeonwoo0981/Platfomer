using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerMovement MoveCompo { get; private set; }

    public Transform _target;
    
    public Transform _visualTrm;
    
    private void Awake()
    {
        MoveCompo = GetComponent<PlayerMovement>();
        _visualTrm = transform.Find("Visual");
    }
    
    public void FlipX(float moveX)
    {
        if (moveX < 0)  // 왼쪽을 바라본다면
        {
            _visualTrm.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if (moveX > 0)
        {
            _visualTrm.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }
}
