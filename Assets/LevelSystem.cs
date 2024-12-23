using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelSystem
{
    int maxLevel;
    LevelingType type;
    Func<int, int> customFunction = null;
    int currentXp; //make priv
    int level; //make priv
    int levelXp; //make priv
    int baseLevelXp;

    PlayerController player;

    public LevelSystem(int baseLevelXp, int maxLevel = 10, LevelingType type = LevelingType.Constant) {
        this.maxLevel = maxLevel;
        this.type = type;
        this.baseLevelXp = baseLevelXp;

        levelXp = baseLevelXp;
        level = 1;
        currentXp = 0;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        Debug.Log("BaseLevelXp = " + baseLevelXp);
    }

    public void UpdateXp(int xp) {
        if(currentXp + xp >= levelXp) {
            if(IsMaxLevel())
                currentXp = levelXp;
            else {
                currentXp = currentXp + xp - levelXp;
                Debug.Log("CurrentXp on LevelUp = " + currentXp);
                LevelUp();
            }
        } else
            currentXp += xp;
    }

    private void LevelUp() {
        level++;

        switch (type) {
            case LevelingType.Linear:
                levelXp = baseLevelXp + (level); // * constant
                break;

            case LevelingType.Quadratic:
                levelXp = baseLevelXp + (level * level); // * constant
                break;

            case LevelingType.Exponential:
                levelXp = (int) Math.Pow(baseLevelXp, level);
                break;

            case LevelingType.Custom:
                levelXp = (int) customFunction(level);
                break;

            case LevelingType.Constant:
                levelXp = levelXp;
                break;

            default:
                break;
        }
        
        player.OnLevelUp();
    }

    public void SetCustom(Func<int, int> operation){
        customFunction = operation;
    }

    public int GetCurrentXp(){
        return currentXp;
    }
    public int GetCurrentLevel(){
        return level;
    }

    public bool IsMaxLevel(){
        return level == maxLevel;
    }
}
