using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent( typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public float moveSpeed = 10;
    public float rotationSpeed = 16;

    //Components
    private new Rigidbody rigidbody;

    private int point;

    private Vector3 direction;
    bool isTouched;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        GameEvents.instance.onObjectCollected += OnObjectCollected;
        TouchManager.instance.onTouchBegan += TouchBegan;
        TouchManager.instance.onTouchMoved += TouchMoved;
        TouchManager.instance.onTouchEnded += TouchEnded;
    }


    private void OnObjectCollected(ICollectable collectable)
    {
        point += collectable.collectablePoint;
        UIManager.instance.SetCurrentScoreText(point);
        if (point > 99)
        {
            isTouched = false;
            rigidbody.velocity = Vector3.zero;
            UIManager.instance.SetTotalScoreText(point);
            GameManager.instance.UpdateGameState(GameState.Finish);
        }
    }

    private void TouchBegan(TouchInput touch)
    {
        isTouched = true;
    }
    
    private void TouchMoved(TouchInput touch)
    {
        direction = ConvertVector3((touch.ScreenPosition - touch.FirstScreenPosition).normalized);
        
        LookAtDirection(direction);
    }

    private void TouchEnded(TouchInput touch)
    {
        isTouched = false;
        rigidbody.velocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if (isTouched)
        {
            rigidbody.velocity = (direction * moveSpeed);
        }
    }

    private void LookAtDirection(Vector3 dir)
    {
        var lookPos = dir;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
    }

    private Vector3 ConvertVector3(Vector2 vec2)
    {
        return new Vector3(vec2.x, 0, vec2.y);
    }

    public void SetNewPoint(ICollectable collectableItem)
    {
        point += collectableItem.collectablePoint;
        UIManager.instance.SetCurrentScoreText(point);
    }
}