using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class TypeEnemy
{
    
    public float _speedX, _speedY;
    public int direction;
    public abstract void MainEnemy(GameObject MonstrPosition,  int _direction,Transform Player, Rigidbody2D RBMonstr);
}
class Hunter : TypeEnemy
{
    public override void MainEnemy(GameObject MonstrPosition, int _direction, Transform Player, Rigidbody2D RBMonstr)
    {
        if (MonstrPosition.transform.position.x < Player.position.x)
            
        _speedX = (SettingLVL.SpeedMonstr - SettingLVL.LVL);
        else
            _speedX = (-SettingLVL.SpeedMonstr + SettingLVL.LVL);
        if (MonstrPosition.transform.position.y < Player.position.y)
            _speedY = (SettingLVL.SpeedMonstr - SettingLVL.LVL);
        else          
        _speedY = (-SettingLVL.SpeedMonstr + SettingLVL.LVL);

        RBMonstr.velocity = new Vector2(_speedX, _speedY);
    }
}
class VerticalSpider : TypeEnemy
{
    public override void MainEnemy(GameObject MonstrPosition,  int _direction, Transform Player, Rigidbody2D RBMonstr)
    {
        RBMonstr.velocity = new Vector2(SettingLVL.SpeedMonstr * _direction, 0);
    }
}
class HorizontalSpider : TypeEnemy
{
    public override void MainEnemy(GameObject MonstrPosition, int _direction, Transform Player, Rigidbody2D RBMonstr)
    {
        RBMonstr.velocity = new Vector2(0, SettingLVL.SpeedMonstr * _direction);
    }
}
