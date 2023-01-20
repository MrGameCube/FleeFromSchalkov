using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2D;

    private Vector2 velocity;

    public Camera mainCamera;

    private float angle;
    
    
    public float movementSpeed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        this._rigidbody2D = GetComponent<Rigidbody2D>();
        this._boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.velocity = new Vector2(
            Input.GetAxis("Vertical") * movementSpeed, 
            Input.GetAxis("Horizontal") * movementSpeed) ;
    }

    void FixedUpdate()
    {
        PointToMouse(this.transform);
        this._rigidbody2D.velocity = this.velocity[0] * (this.transform.up) + this.velocity[1] *this.transform.right;

    }
    /**
     * Ganz sicher nicht von Medium geklaut!
     *  Zufall:
     * https://antonio-valentini.medium.com/unity-rotate-an-object-towards-the-mouse-position-2d-eb92a8cdd64f
     */
    private void PointToMouse(Transform player)
    {
        var mouseScreenPos = Input.mousePosition;
        var startingScreenPos = mainCamera.WorldToScreenPoint(player.position);
        mouseScreenPos.x -= startingScreenPos.x;
        mouseScreenPos.y -= startingScreenPos.y;
        angle = Mathf.Atan2(mouseScreenPos.y, mouseScreenPos.x) * Mathf.Rad2Deg;
        player.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
    }
}
