using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region General
    private Rigidbody2D rb;
    private LevelSystem ls;
    
    #endregion

    #region Stats
    [Header("Stats")]
    public int maxHealth;
    private Vector2 moveVelocity;
    public int health;
    public float speed = 10;
    public int strength = 10;
    #endregion

    #region Level System
    [Header("Level System")]
    public LevelingType lvlType = LevelingType.Constant;
    public int maxLevel = 10;
    public int baseLevelXp = 5;
    public float speedMul = 1.1f;
    public float sizeAdd = 0.2f;
    #endregion
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        ls = new LevelSystem(baseLevelXp, maxLevel, lvlType);
    }    

    void FixedUpdate() {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = new Vector2(moveInput.normalized.x * speed, moveInput.normalized.y * speed);

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "XP"){
            ls.UpdateXp(1);
            Debug.Log("Current Level = " + ls.GetCurrentLevel());
            Debug.Log("Hit xp, current XP = " + ls.GetCurrentXp());

            Destroy(other.gameObject);
        }
    }

    public void OnLevelUp() {
        speed *= speedMul;
        
        Vector3 currentScale = transform.localScale;
        currentScale.x += sizeAdd;
        currentScale.y += sizeAdd;
        transform.localScale = currentScale;

        // ----------- EXAMPLES ------------
        health += 1;
        strength += 3;
    }

    public int GetLevel() {
        return ls.GetCurrentLevel();
    }

    public float GetSize() {
        return transform.localScale.x;
    }

    public float GetSpeed(){
        return speed;
    }

    public bool IsMaxLevel(){
        return ls.IsMaxLevel();
    }

}
