using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace MocopiDistinction
{
    internal class InputJointAndGetResult : MonoBehaviour
    {
        [SerializeField] private MocopiDistinctionAI mocopiDistinctionAI = null;
        
        private Transform _rootTransform = null;
        private Transform _lUpLegTransform = null;
        private Transform _rUpLegTransform = null;
        private Transform _lLowLegTransform = null;
        private Transform _rLowLegTransform = null;
        private Transform _lFootTransform = null;
        private Transform _rFootTransform = null;
        private Transform _firstTorsoTransform = null;
        private Transform _thirdTorsoTransform = null;
        private Transform _fifthTorsoTransform = null;
        private Transform _seventhTorsoTransform = null;
        private Transform _rShoulderTransform = null;
        private Transform _lShoulderTransform = null;
        private Transform _firstNeckTransform = null;
        private Transform _secondNeckTransform = null;
        private Transform _rUpArmTransform = null;
        private Transform _lUpArmTransform = null;
        private Transform _rLowArmTransform = null;
        private Transform _lLowArmTransform = null;
        private Transform _rHandTransform = null;
        private Transform _lHandTransform = null;
        
        private List<float> _data = new();
        float timer = 0.0f;
        float interval = 0.1f;

        public InputJointAndGetResult(float[] results)
        {
            this.results = results;
        }

        public float[] results;
        
        void Start()
        {
            _rootTransform = GameObject.Find("human_low:_root").transform;
            _lUpLegTransform = GameObject.Find("human_low:_l_up_leg").transform;
            _rUpLegTransform = GameObject.Find("human_low:_r_up_leg").transform;
            _lLowLegTransform = GameObject.Find("human_low:_l_low_leg").transform;
            _rLowLegTransform = GameObject.Find("human_low:_r_low_leg").transform;
            _lFootTransform = GameObject.Find("human_low:_l_foot").transform;
            _rFootTransform = GameObject.Find("human_low:_r_foot").transform;
            _firstTorsoTransform = GameObject.Find("human_low:_torso_1").transform;
            _thirdTorsoTransform = GameObject.Find("human_low:_torso_3").transform;
            _fifthTorsoTransform = GameObject.Find("human_low:_torso_5").transform;
            _seventhTorsoTransform = GameObject.Find("human_low:_torso_7").transform;
            _rShoulderTransform = GameObject.Find("human_low:_r_shoulder").transform;
            _lShoulderTransform = GameObject.Find("human_low:_l_shoulder").transform;
            _firstNeckTransform = GameObject.Find("human_low:_neck_1").transform;
            _secondNeckTransform = GameObject.Find("human_low:_neck_2").transform;
            _rUpArmTransform = GameObject.Find("human_low:_r_up_arm").transform;
            _lUpArmTransform = GameObject.Find("human_low:_l_up_arm").transform;
            _rLowArmTransform = GameObject.Find("human_low:_r_low_arm").transform;
            _lLowArmTransform = GameObject.Find("human_low:_l_low_arm").transform;
            _rHandTransform = GameObject.Find("human_low:_r_hand").transform;
            _lHandTransform = GameObject.Find("human_low:_l_hand").transform;
            
            //Test
            if (mocopiDistinctionAI == null)
            {
                Debug.LogError("MocopiDistinctionAIを設定してください");
            }
            
            if (_data == null)
            {
                _data = new List<float>();
            }
            
            MocopiDistinctionAI.MotionData motionData = new MocopiDistinctionAI.MotionData();
            
            //UniRxを用いて0.1秒ごとに処理を行う
            Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    timer += Time.deltaTime;
                    if (timer >= interval)
                    {
                        // 0.1秒ごとの処理
                        // モーションデータを取得
                        motionData.data = GetMotionData();

                        if (motionData.data.Length < 2610)
                        {
                            Debug.Log("モーション取得中");
                            return;
                        }
                        // AIにモーションデータを渡して結果を受け取る
                        results = mocopiDistinctionAI.RunAI(motionData);

                        timer = 0.0f; // タイマーリセット
                    }
                })
                .AddTo(this);
        }

        private float[] GetMotionData()
        {
            _data.Add(_rootTransform.localPosition.x);
            _data.Add(_rootTransform.localPosition.y);
            _data.Add(_rootTransform.localPosition.z);
            _data.Add(_rootTransform.localRotation.x);
            _data.Add(_rootTransform.localRotation.y);
            _data.Add(_rootTransform.localRotation.z);
            _data.Add(_rootTransform.localRotation.w);
            _data.Add(_lUpLegTransform.localRotation.x);
            _data.Add(_lUpLegTransform.localRotation.y);
            _data.Add(_lUpLegTransform.localRotation.z);
            _data.Add(_lUpLegTransform.localRotation.w);
            _data.Add(_rUpLegTransform.localRotation.x);
            _data.Add(_rUpLegTransform.localRotation.y);
            _data.Add(_rUpLegTransform.localRotation.z);
            _data.Add(_rUpLegTransform.localRotation.w);
            _data.Add(_lLowLegTransform.localRotation.x);
            _data.Add(_lLowLegTransform.localRotation.y);
            _data.Add(_lLowLegTransform.localRotation.z);
            _data.Add(_lLowLegTransform.localRotation.w);
            _data.Add(_rLowLegTransform.localRotation.x);
            _data.Add(_rLowLegTransform.localRotation.y);
            _data.Add(_rLowLegTransform.localRotation.z);
            _data.Add(_rLowLegTransform.localRotation.w);
            _data.Add(_lFootTransform.localRotation.x);
            _data.Add(_lFootTransform.localRotation.y);
            _data.Add(_lFootTransform.localRotation.z);
            _data.Add(_lFootTransform.localRotation.w);
            _data.Add(_rFootTransform.localRotation.x);
            _data.Add(_rFootTransform.localRotation.y);
            _data.Add(_rFootTransform.localRotation.z);
            _data.Add(_rFootTransform.localRotation.w);
            _data.Add(_firstTorsoTransform.localRotation.x);
            _data.Add(_firstTorsoTransform.localRotation.y);
            _data.Add(_firstTorsoTransform.localRotation.z);
            _data.Add(_firstTorsoTransform.localRotation.w);
            _data.Add(_thirdTorsoTransform.localRotation.x);
            _data.Add(_thirdTorsoTransform.localRotation.y);
            _data.Add(_thirdTorsoTransform.localRotation.z);
            _data.Add(_thirdTorsoTransform.localRotation.w);
            _data.Add(_fifthTorsoTransform.localRotation.x);
            _data.Add(_fifthTorsoTransform.localRotation.y);
            _data.Add(_fifthTorsoTransform.localRotation.z);
            _data.Add(_fifthTorsoTransform.localRotation.w);
            _data.Add(_seventhTorsoTransform.localRotation.x);
            _data.Add(_seventhTorsoTransform.localRotation.y);
            _data.Add(_seventhTorsoTransform.localRotation.z);
            _data.Add(_seventhTorsoTransform.localRotation.w);
            _data.Add(_rShoulderTransform.localRotation.x);
            _data.Add(_rShoulderTransform.localRotation.y);
            _data.Add(_rShoulderTransform.localRotation.z);
            _data.Add(_rShoulderTransform.localRotation.w);
            _data.Add(_lShoulderTransform.localRotation.x);
            _data.Add(_lShoulderTransform.localRotation.y);
            _data.Add(_lShoulderTransform.localRotation.z);
            _data.Add(_lShoulderTransform.localRotation.w);
            _data.Add(_firstNeckTransform.localRotation.x);
            _data.Add(_firstNeckTransform.localRotation.y);
            _data.Add(_firstNeckTransform.localRotation.z);
            _data.Add(_firstNeckTransform.localRotation.w);
            _data.Add(_secondNeckTransform.localRotation.x);
            _data.Add(_secondNeckTransform.localRotation.y);
            _data.Add(_secondNeckTransform.localRotation.z);
            _data.Add(_secondNeckTransform.localRotation.w);
            _data.Add(_rUpArmTransform.localRotation.x);
            _data.Add(_rUpArmTransform.localRotation.y);
            _data.Add(_rUpArmTransform.localRotation.z);
            _data.Add(_rUpArmTransform.localRotation.w);
            _data.Add(_lUpArmTransform.localRotation.x);
            _data.Add(_lUpArmTransform.localRotation.y);
            _data.Add(_lUpArmTransform.localRotation.z);
            _data.Add(_lUpArmTransform.localRotation.w);
            _data.Add(_rLowArmTransform.localRotation.x);
            _data.Add(_rLowArmTransform.localRotation.y);
            _data.Add(_rLowArmTransform.localRotation.z);
            _data.Add(_rLowArmTransform.localRotation.w);
            _data.Add(_lLowArmTransform.localRotation.x);
            _data.Add(_lLowArmTransform.localRotation.y);
            _data.Add(_lLowArmTransform.localRotation.z);
            _data.Add(_lLowArmTransform.localRotation.w);
            _data.Add(_rHandTransform.localRotation.x);
            _data.Add(_rHandTransform.localRotation.y);
            _data.Add(_rHandTransform.localRotation.z);
            _data.Add(_rHandTransform.localRotation.w);
            _data.Add(_lHandTransform.localRotation.x);
            _data.Add(_lHandTransform.localRotation.y);
            _data.Add(_lHandTransform.localRotation.z);
            _data.Add(_lHandTransform.localRotation.w);
            
            if (_data.Count > 2610)
            {
                //2610個のデータを超えたら先頭から削除
                _data.RemoveRange(0, _data.Count - 2610);
            }

            return _data.ToArray();
        }
        
        private void OnDestroy()
        {
            _data.Clear();
        }
    }
}
