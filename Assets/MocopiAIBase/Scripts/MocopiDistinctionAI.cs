using System;
using Unity.Sentis;
using UnityEngine;

namespace MocopiDistinction
{
    /// <summary>
    /// AIの演算を行うクラス
    /// </summary>
    internal class MocopiDistinctionAI : MonoBehaviour
    {
        [Header("ONNXモデル"),SerializeField] 
        private ModelAsset nnModel = null;
        private Model _runtimeModel;
        private TensorFloat _inputTensor;
        private IWorker _engine;
        private TensorShape shape = new(1, 2610);

        public class MotionData
        {
            public float[] data;
        }
        
        private void Awake()
        {
            if (nnModel == null)
            {
                Debug.LogError("ONNXモデルを設定してください");
            }
            
            _runtimeModel = ModelLoader.Load(nnModel);
        }
        
        public float[] RunAI(MotionData motionData)
        {
            _engine = WorkerFactory.CreateWorker(BackendType.CPU, _runtimeModel);
            TensorFloat tensor = new TensorFloat(shape, motionData.data);
            _inputTensor = tensor.ShallowReshape(shape) as TensorFloat;
            _engine.Execute(_inputTensor);
            
            TensorFloat outputTensor = _engine.PeekOutput() as TensorFloat;
            outputTensor.MakeReadable();
            var results = outputTensor.ToReadOnlyArray() ?? throw new ArgumentNullException("outputTensor.ToReadOnlyArray()");
            _engine.Dispose();
            _inputTensor.Dispose();
            outputTensor.Dispose();
            return results;
        }

        private void OnDestroy()
        {
            _engine?.Dispose();
            
        }
    }
}
