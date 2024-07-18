using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    //弾の発生する初期位置
    [SerializeField]
    Transform bullterSpawner;
    //カメラのTransform
    [SerializeField]
    Transform cameraTransform;
    //弾を当てる目標のTransform
    [SerializeField]
    Transform targetTransform;
    //弾のプレハブ
    [SerializeField]
    GameObject bulletPrefab;
    //弾速の係数
    [SerializeField]
    float bulletSpeedRate;
    //弾を当てる目標のレイヤ
    [SerializeField]
    string targetLayerName;
    int targetLayer;
    Plane plane;
    // Start is called before the first frame update
    void Start()
    {
        //弾の当たり判定を行うオブジェクトのレイヤを名前から指定
        targetLayer = LayerMask.NameToLayer(targetLayerName);        
    }

    // Update is called once per frame
    void Update()
    {
        //マウスの左ボタンを押したら弾を発射
        if (Input.GetMouseButtonDown(0))
        {
            CreateBullet();
        }
    }
    void CreateBullet()
    {
        //ターゲット位置に平面を作成        
        Vector3 planePos = targetTransform.position;
        //平面の法線はカメラの向いている方向（カメラの視線と直交する平面）
        plane = new Plane(cameraTransform.forward, planePos);

        //現在のカーソル位置からレイ（光線）を作成
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //平面とレイが平行の場合は弾を作成しない（平面とレイの作り方から交差しないことはないが安全のため）
        if(plane.Raycast(ray, out float enter))
        {
            //レイと平面の交点を取得
            Vector3 createPoint = ray.GetPoint(enter);

            //弾をプレハブから複製
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(true);

            //弾にBulletMoverコンポーネントを追加
            BulletMover bulletMover = bullet.AddComponent<BulletMover>();

            //弾の速度を計算
            Vector3 velocity = createPoint - bullterSpawner.transform.position;
            velocity *= bulletSpeedRate;

            //弾の初期値を代入（初期位置、速度、消去する経過時間、目標オブジェクトのレイヤ）
            bulletMover.Initialize(bullterSpawner.transform.position, velocity, 5, targetLayer);
        }
    }
}
