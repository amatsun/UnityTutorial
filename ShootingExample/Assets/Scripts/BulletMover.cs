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
        //弾の並進移動を経過時間に応じて処理
        float duration = Time.time - lastTime;
        transform.position = duration * velocity + transform.position;
        
        //一定時間を経過したら弾を削除
        if(Time.time - initialTime > eraseDuration)
        {
            Destroy(this.gameObject);
        }
    }
    //弾のパラメータの初期化
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
    //弾が衝突を検知した時に実行
    private void OnCollisionEnter(Collision collision)
    {
        //既にtargetLayerのオブジェクトに衝突していたら処理をしない
        if (hasCollided)
        {
            Debug.Log("Already collided!");
            return;
        }

        //衝突したオブジェクトのレイヤー確認
        Debug.Log($"Hit!, hit tag is {LayerMask.LayerToName(collision.gameObject.layer)}");
        if (collision.gameObject.layer != targetLayer)
            return;

        hasCollided = true;
        
        //衝突したオブジェクトの一番最初の親オブジェクトの取得
        Transform root = collision.gameObject.transform;
        while(root.parent != null)
        {
            root = root.parent;
        }
        //HitCounterコンポーネントの取得
        HitCounter hitCounter = root.GetComponent<HitCounter>();
        if(hitCounter == null)
        {
            Debug.LogError($"Target tagged object without HitCounter exists");
            return;
        }
        
        //Hitカウントの増加
        hitCounter.AddCnt();
        
        //弾の削除
        Destroy(this.gameObject);
    }
}
