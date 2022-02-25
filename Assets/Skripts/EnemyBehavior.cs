using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class EnemyBehavior : MonoBehaviour
{
   
    [SerializeField] private Transform _player;
   
    private int _direction = 1;
    private TypeEnemy _hunter = new Hunter();  
    private TypeEnemy _verticalSpider = new VerticalSpider();  
    private TypeEnemy _horizontalSpider = new HorizontalSpider();
    private TypeEnemy[] Montrs= new TypeEnemy[3];
    private Rigidbody2D RBMonstr;

    public enum TypeMonstr
    {
        Hunter,
        VerticalSpider,
        HorisontalSpider
    }
    [SerializeField] private TypeMonstr typeMonstr;

    private void Start()
    {
        RBMonstr = GetComponent<Rigidbody2D>();
        Montrs[0] = _hunter;
        Montrs[1] = _verticalSpider;
        Montrs[2] = _horizontalSpider;
    }
    private void TypeMonsters(TypeEnemy typeMonstr)
    {
        typeMonstr.MainEnemy(gameObject, _direction, _player, RBMonstr);
    }

    void FixedUpdate()      // Движение монстар в зависимости от типа
    {    
        TypeMonsters(Montrs[(int)typeMonstr]);  
    }

    private void OnTriggerEnter2D(Collider2D col)  //изменение направления движения при ударе о стену
    {
        if (col.CompareTag("Trigger"))
        {
            _direction = _direction * -1;
        }
    }
}
