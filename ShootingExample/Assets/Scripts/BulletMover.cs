using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    Vector3 initialPos;
    Vector3 velocity;
    float lastTime;
    float initialTime;
    float eraseDuration;
    int targetLayer;
    bool hasCollided;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�e�̕��i�ړ����o�ߎ��Ԃɉ����ď���
        float duration = Time.time - lastTime;
        transform.position = duration * velocity + transform.position;
        
        //��莞�Ԃ��o�߂�����e���폜
        if(Time.time - initialTime > eraseDuration)
        {
            Destroy(this.gameObject);
        }
    }
    //�e�̃p�����[�^�̏�����
    public void Initialize(Vector3 _initialPos, Vector3 _initalVelocity, float _eraseDuration, int _targetLayer)
    {
        initialPos = _initialPos;
        velocity = _initalVelocity;
        transform.position = initialPos;
        transform.rotation = Quaternion.identity;
        lastTime = Time.time;
        initialTime = Time.time;
        eraseDuration = _eraseDuration;
        targetLayer = _targetLayer;
        hasCollided = false;
    }
    //�e���Փ˂����m�������Ɏ��s
    private void OnCollisionEnter(Collision collision)
    {
        //����targetLayer�̃I�u�W�F�N�g�ɏՓ˂��Ă����珈�������Ȃ�
        if (hasCollided)
        {
            Debug.Log("Already collided!");
            return;
        }

        //�Փ˂����I�u�W�F�N�g�̃��C���[�m�F
        Debug.Log($"Hit!, hit tag is {LayerMask.LayerToName(collision.gameObject.layer)}");
        if (collision.gameObject.layer != targetLayer)
            return;

        hasCollided = true;
        
        //�Փ˂����I�u�W�F�N�g�̈�ԍŏ��̐e�I�u�W�F�N�g�̎擾
        Transform root = collision.gameObject.transform;
        while(root.parent != null)
        {
            root = root.parent;
        }
        //HitCounter�R���|�[�l���g�̎擾
        HitCounter hitCounter = root.GetComponent<HitCounter>();
        if(hitCounter == null)
        {
            Debug.LogError($"Target tagged object without HitCounter exists");
            return;
        }
        
        //Hit�J�E���g�̑���
        hitCounter.AddCnt();
        
        //�e�̍폜
        Destroy(this.gameObject);
    }
}
