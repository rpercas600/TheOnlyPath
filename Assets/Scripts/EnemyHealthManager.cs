using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int currentHP;
    public int maxHP;

    private bool flashActive;
    private float flashLength = 0.5f;
    private float flashCounter = 0f;
    private SpriteRenderer enemySprite;
    void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flashActive) {
            if (flashCounter > flashLength*.99f){
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g,enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength*.82f){
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g,enemySprite.color.b, 1f);
            }
            else if (flashCounter > flashLength*.66f){
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g,enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength*.49f){
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g,enemySprite.color.b, 1f);
            }
            else if (flashCounter > flashLength*.33f){
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g,enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength*.16f){
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g,enemySprite.color.b, 1f);
            }
            else if (flashCounter > 0f){
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g,enemySprite.color.b, 0f);
            }
            else {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g,enemySprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }

    public void HurtEnemy(int dmgToDeal) {
        currentHP -= dmgToDeal;
        flashActive = true;
        flashCounter = flashLength;
        if (currentHP <=0) {
            Destroy(gameObject);
        }
    }
}
