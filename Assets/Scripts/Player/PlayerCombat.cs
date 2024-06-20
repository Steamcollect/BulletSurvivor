using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Statistics")]
    [SerializeField] int attackDamage;
    public float bulletSpeed;
    [SerializeField] float attackCooldown;
    bool canAttack = true, isAttacking;

    [Header("Statistics")]
    public int ultDamage;
    public float ultSpeed;


    [Header("References")]
    [SerializeField] Transform attackPoint;

    [SerializeField] Transform weapon;
    SpriteRenderer weaponGraphics;
    Animator weaponAnim;

    public GameObject bulletPrefab;
    [SerializeField] GameObject weaponFlashPrefabs;

    Vector2 mousePos;

    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        weaponGraphics = weapon.GetComponent<SpriteRenderer>();
        weaponAnim = weapon.GetComponent<Animator>();
    }

    private void Update()
    {
        AttackSystem();
        Rotate();
    }

    void AttackSystem()
    {
        isAttacking = Input.GetKey(KeyCode.Mouse0);
        if (isAttacking && canAttack) Attack();
    }
    void Attack()
    {
        StartCoroutine(AttackCooldown());

        weaponAnim.SetTrigger("Shoot");
        SetWeaponFlashParticle();

        GameObject currentBullet = Instantiate(bulletPrefab, attackPoint.position , attackPoint.rotation);
        PlayerBullet bullet = currentBullet.GetComponent<PlayerBullet>();
        bullet.playerBulletSpeed = bulletSpeed;
        bullet.damage = attackDamage;
        

        Destroy(currentBullet, 5f);
    }
    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    void SetWeaponFlashParticle()
    {
        GameObject weaponFlash = Instantiate(weaponFlashPrefabs, attackPoint.position, attackPoint.rotation);
        weaponFlash.GetComponent<Animator>().SetFloat("AnimIndex", Random.Range(6, 11));
        Destroy(weaponFlash, .04f);
    }

    void Rotate()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - (Vector2)weapon.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0, 0, angle);

        if (angle < 90 && angle > -90)
        {
            weaponGraphics.flipY = false;
            attackPoint.localPosition = new Vector2(attackPoint.localPosition.x, .14f);
        }
        else
        {
            weaponGraphics.flipY = true;
            attackPoint.localPosition = new Vector2(attackPoint.localPosition.x, -.14f);
        }
    }
}