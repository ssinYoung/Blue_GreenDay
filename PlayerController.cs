using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 5.0f;
    Vector3 _ClickPos;
    void Start()
    {
        MasterManager.Input.MouseAction -= OnMouseClick;
        MasterManager.Input.MouseAction += OnMouseClick;
        MasterManager.Input.KeyAction -= OnBtnDown;
        MasterManager.Input.KeyAction += OnBtnDown;
    }
    public enum PlayerState { Idle, Move, Attack, Die }
    PlayerState _State = PlayerState.Idle;

    void Idle()
    {
        Animator anime = GetComponent<Animator>();
    }
    void Move()
    {
        Vector3 dir = _ClickPos - transform.position;
        if (dir.magnitude < 0.00001f)
        {
            _State = PlayerState.Idle;
        }
        else
        {
            float moveDistance = Mathf.Clamp(speed * Time.deltaTime, 0, dir.magnitude);
            transform.position += dir.normalized * moveDistance;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
        }
        Animator anime = GetComponent<Animator>();

    }
    void Attack()
    {

    }
    void Die()
    {

    }
    void Update()
    {
        switch (_State)
        {
            case PlayerState.Idle:
                Idle();
                break;

            case PlayerState.Move:
                Move();
                break;

            case PlayerState.Attack:
                Attack();
                break;

            case PlayerState.Die:
                Die();
                break;
        }
    }
    void OnMouseClick(Define.MouseClick evt)
    {
        if (_State == PlayerState.Die)
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Fild")))
        {
            _ClickPos = hit.point;
            _State = PlayerState.Move;
        }
    }
    void OnBtnDown()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {

        }
        if (Input.GetKeyDown(KeyCode.S))
        {

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {

        }
        if (Input.GetKeyDown(KeyCode.W))
        {

        }
        if (Input.GetKeyDown(KeyCode.E))
        {

        }
        if (Input.GetKeyDown(KeyCode.R))
        {

        }
        if (Input.GetKeyDown(KeyCode.F))
        {

        }
    }
}
