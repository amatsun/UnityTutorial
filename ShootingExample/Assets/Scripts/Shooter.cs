using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    //�e�̔������鏉���ʒu
    [SerializeField]
    Transform bullterSpawner;
    //�J������Transform
    [SerializeField]
    Transform cameraTransform;
    //�e�𓖂Ă�ڕW��Transform
    [SerializeField]
    Transform targetTransform;
    //�e�̃v���n�u
    [SerializeField]
    GameObject bulletPrefab;
    //�e���̌W��
    [SerializeField]
    float bulletSpeedRate;
    //�e�𓖂Ă�ڕW�̃��C��
    [SerializeField]
    string targetLayerName;
    int targetLayer;
    Plane plane;
    // Start is called before the first frame update
    void Start()
    {
        //�e�̓����蔻����s���I�u�W�F�N�g�̃��C���𖼑O����w��
        targetLayer = LayerMask.NameToLayer(targetLayerName);        
    }

    // Update is called once per frame
    void Update()
    {
        //�}�E�X�̍��{�^������������e�𔭎�
        if (Input.GetMouseButtonDown(0))
        {
            CreateBullet();
        }
    }
    void CreateBullet()
    {
        //�^�[�Q�b�g�ʒu�ɕ��ʂ��쐬        
        Vector3 planePos = targetTransform.position;
        //���ʂ̖@���̓J�����̌����Ă�������i�J�����̎����ƒ������镽�ʁj
        plane = new Plane(cameraTransform.forward, planePos);

        //���݂̃J�[�\���ʒu���烌�C�i�����j���쐬
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //���ʂƃ��C�����s�̏ꍇ�͒e���쐬���Ȃ��i���ʂƃ��C�̍�������������Ȃ����Ƃ͂Ȃ������S�̂��߁j
        if(plane.Raycast(ray, out float enter))
        {
            //���C�ƕ��ʂ̌�_���擾
            Vector3 createPoint = ray.GetPoint(enter);

            //�e���v���n�u���畡��
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(true);

            //�e��BulletMover�R���|�[�l���g��ǉ�
            BulletMover bulletMover = bullet.AddComponent<BulletMover>();

            //�e�̑��x���v�Z
            Vector3 velocity = createPoint - bullterSpawner.transform.position;
            velocity *= bulletSpeedRate;

            //�e�̏����l�����i�����ʒu�A���x�A��������o�ߎ��ԁA�ڕW�I�u�W�F�N�g�̃��C���j
            bulletMover.Initialize(bullterSpawner.transform.position, velocity, 5, targetLayer);
        }
    }
}
