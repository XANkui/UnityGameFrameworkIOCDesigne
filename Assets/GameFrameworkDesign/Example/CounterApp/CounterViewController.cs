using GameFrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CounterApp { 

	public class CounterViewController : MonoBehaviour,IController
	{
		private ICounterModel mCounterModel;
		// Start is called before the first frame update
		void Start()
		{
			mCounterModel = GetArchitecture().GetModel<ICounterModel>();

			mCounterModel.Count.RegisterOnValueChanged(OnValueChanged);
			transform.Find("AddButton").GetComponent<Button>().onClick.AddListener(()=> {
				GetArchitecture().SendCommand<AddCommand>();
			});

			transform.Find("SubButton").GetComponent<Button>().onClick.AddListener(() => {
				GetArchitecture().SendCommand<SubCommand>();
			});

			OnValueChanged(mCounterModel.Count.Value);

		}

		private void OnValueChanged(int count) {
			transform.Find("CountText").GetComponent<Text>().text = count.ToString();
		}

        private void OnDestroy()
        {
			mCounterModel.Count.UnRegisterOnValueChanged(OnValueChanged);
		}

        public IArchitecture GetArchitecture()
        {
			return CounterAppArchitecture.Interface;
        }
    }

	public interface ICounterModel:IModel
	{
		BindableProperty<int> Count { get; }
	}

	public class CounterModel : AbstractModel, ICounterModel,ICanGetUtility
	{
	
		public BindableProperty<int> Count { get; } = new BindableProperty<int>() {
			Value = 0
		};

        public override void OnInit()
        {
			ICounterStorage storage = this.GetUtility<ICounterStorage>();
			Count.Value = storage.LoadInt("COUNTER_COUNT", 0);
			Count.RegisterOnValueChanged((count) =>
			{
				storage.SaveInt("COUNTER_COUNT", count);
			});
		}
    }
}
