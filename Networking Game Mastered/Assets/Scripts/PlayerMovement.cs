using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviourPunCallbacks
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Animator myAnimator;
    [SerializeField] private Transform weaponTransform;
    [SerializeField] private Transform bulletSpawnPosition;
    [SerializeField] private GameObject bulletPrefab;
    
    private float moveX;
    private float moveY;
    private static readonly int IsIdle = Animator.StringToHash("isIdle");
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    private void Update()
    {
        if (photonView.IsMine)
        {
            HandleMovement();
            HandleWeaponRotation();

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ShootWeapon();
            }
        }
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            moveY = 0f;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            moveX = 0f;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            moveY = 0f;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            moveX = 0f;
        }

        bool isIdle = moveX == 0 && moveY == 0;
        if (isIdle)
        {
            myAnimator.SetBool(IsIdle,true);
            myAnimator.SetBool(IsWalking,false);
            
        }
        else
        {
            myAnimator.SetBool(IsIdle,false);
            myAnimator.SetBool(IsWalking,true);

            var moveDir = new Vector3(moveX, moveY).normalized;
            transform.position += moveDir * (movementSpeed * Time.deltaTime);
        }
    }

    private void HandleWeaponRotation()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 5.23f;
 
        var objectPos = Camera.main.WorldToScreenPoint (transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
 
        var angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        weaponTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void ShootWeapon()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, Quaternion.identity);
        var mousePos = Input.mousePosition;
        var objectPos = Camera.main.WorldToScreenPoint (transform.position);
        bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.MoveTowards(bullet.transform.position,objectPos,bulletSpeed * Time.deltaTime));
    }
}
