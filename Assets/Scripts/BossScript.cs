using System;
using UnityEngine;
using Random = UnityEngine.Random;
enum BossState
{
    Waiting = 1,
    Walking,
    Spawning
}

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(HealthSystem))]
[RequireComponent(typeof(Rigidbody2D))]

public class BossScript : MonoBehaviour
{
    #region 

    [SerializeField] private int _playerDamageAmt = 3;
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float _stateDelayMin = 0.1f;
    [SerializeField] private float _stateDelayMax = 1.5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 0.0625f;

    #endregion

    private BossState _state = BossState.Waiting;
    private float _timeLeftBeforeStateChange;

    #region 

    private HealthSystem _healthSystem;
    private BoxCollider2D _collider;

    #endregion

    private bool IsFacingRight
    {
        get
        {
            //the IsFacingRight property is tied directly to the x scale
            return transform.localScale.x > 0;
        }
        set
        {
            //setting IsFacingRight flips scale of our object in x, which also flips image
            Vector3 scale = transform.localScale; //copy unchangeable scale
            scale.x = value ? 1 : -1; //set x in copy based on IsFacingRight now set to true or false
            transform.localScale = scale; //replace scale with changed copy
        }
    }


 private void Awake()
    {
        //_rb = GetComponent<Rigidbody2D>();
        _healthSystem = GetComponent<HealthSystem>();
        _collider = GetComponent<BoxCollider2D>();
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        _state = BossState.Walking;
        _timeLeftBeforeStateChange = .01f;
    }

    public void FlipFacingDirection()
    {
        //IsFacingRight property is tied to x scale, so it flips it. (See IsFacingRight property definition above)
        IsFacingRight = !IsFacingRight; //if it's true set it to false, if it's false set it to true
    }





}
