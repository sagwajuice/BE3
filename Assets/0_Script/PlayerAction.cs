using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float speed;
    public GameManager gManager;
    private float h;
    private float v;
    private bool isHorizontalMove;
    private Rigidbody2D rigid;
    private Animator anim;
    private Vector3 dirVec;
    private GameObject scanObj;

    void Start() {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update() {
        h = gManager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = gManager.isAction ? 0 : Input.GetAxisRaw("Vertical");
        bool hDown = gManager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = gManager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = gManager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = gManager.isAction ? false : Input.GetButtonUp("Vertical");
        if(hDown) {
            isHorizontalMove = true;
        }
        else if(vDown) {
            isHorizontalMove = false;
        }
        else if(vUp || hUp) {
            isHorizontalMove = h != 0;
        }
        //애니메이션
        if(anim.GetInteger("HAxis") != h) {
            anim.SetBool("isChange", true);
            anim.SetInteger("HAxis", (int)h);
        }
        else if(anim.GetInteger("VAxis") != v) {
            anim.SetBool("isChange", true);
            anim.SetInteger("VAxis", (int)v);
        }
		else { anim.SetBool("isChange", false); }
        //이동
        if(vDown && v == 1) {
            dirVec = Vector3.up;
        }
        else if(vDown && v == -1) {
            dirVec = Vector3.down;
        }
        else if(hDown && h == -1) {
            dirVec = Vector3.left;
        }
        else if(hDown && h == 1) {
            dirVec = Vector3.right;
        }
		//스캔 오브젝트
		if(Input.GetButtonDown("Jump") && scanObj != null) {
            gManager.Action(scanObj);
        }
    }
	private void FixedUpdate() {
        //이동
        Vector2 moveVec = isHorizontalMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;
        //레이캐스트
        Debug.DrawRay(rigid.position, dirVec * 1f, new Color(1, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Obj"));
        if(rayHit.collider != null) {
            scanObj = rayHit.collider.gameObject;
        }
        else {
            scanObj = null;
        }
	}
}
