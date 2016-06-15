using UnityEngine;
using System.Collections;

public class guiEvent : MonoBehaviour {

	// Use this for initialization
	public GameObject myButtonObj;
	public Texture2D texture2d;
	public string textFieldText;
	public bool toggleValue;
	public float sliderValue;
	public int toolBarValue;
	public int selectionGridValue;

	public GUIStyle customStyle;
	public GUISkin mySkin;

	public Rect window01 = new Rect(20,20,150,100);   //定义窗体初始状态：X、Y位置及长宽
	public bool showWindow = true;

	void Start () {
		myButtonObj = GameObject.Find ("myButton");
		var myButtonCompo = this.myButtonObj.GetComponent<UnityEngine.UI.Button> ();
		myButtonCompo.onClick.AddListener (delegate() {
			this.onButtonClick(this.myButtonObj);
		});

		texture2d = Resources.Load("jpg_r") as Texture2D;// 动态加载纹理，也可以外部指定
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onButtonClick(GameObject sender){
		print("on button clicked!");

		var textObj = GameObject.Find("myText");
		var textCompo = textObj.GetComponent<UnityEngine.UI.Text> ();
		textCompo.text = "hello";

		//var imageObj = GameObject.Find("myImage");
		//var imageCompo = imageObj.GetComponent<UnityEngine.UI.Image> ();
		//var spr = Resources.Load("jpg_r");// 为毛总是null
	}

	public void OnGUI(){
		if (GUI.Button (new Rect (300, 10, 100, 30), "Click")) {
			print("Clicked !");
		}
		if(GUI.Button(new Rect(300, 50, 200, 200), texture2d)){
			print("image button");
		}
		GUI.Label (new Rect(300, 260, 100, 30),"this is a label");
		
		if(GUI.RepeatButton(new Rect(300, 300, 100, 30), "repeat button")){
			print("repeat button clicked!");
		}

		this.textFieldText = GUI.TextField(new Rect(300, 340, 100, 30), this.textFieldText);//注：返回的是string
		this.toggleValue = GUI.Toggle (new Rect (300, 380, 100, 30), this.toggleValue, "toggleText");// return bool 
		this.sliderValue = GUI.HorizontalSlider (new Rect (600, 10, 200, 30), 30, 0, 100);
		this.toolBarValue = GUI.Toolbar (new Rect (600, 50, 200, 30), 1, new string[]{"tool1", "tool2", "tool3"});

		this.selectionGridValue = GUI.SelectionGrid (new Rect (600, 90, 200, 200), 2, 
		                                             new string[] {"t00","t10","t20","t01","t11","t21","t02","t12"}, 3);
		GUI.skin = this.mySkin;// 自定义皮肤
		GUI.Label (new Rect(600, 300, 300, 30),"this is a label with custom skin");


		GUI.BeginGroup (new Rect (900, 10, 200, 500));// 可嵌套
		GUI.Button(new Rect(0,0,50,30), "hello");
		GUI.Button(new Rect(0,40,300,30), "这是一个应用toggle风格的button", "toggle");
		GUI.Button (new Rect (0, 80, 200, 30), "customStyleBtn", this.customStyle);// 自定义 style，前端编辑customStyle

		GUI.BeginGroup (new Rect(0, 120, 200, 200));
		GUILayout.Label ("layout label");
		if (GUILayout.Button ("窗口控制")) {
			this.showWindow = !this.showWindow;
		}
		GUILayout.Space (50);
		GUILayout.Button("layout button2");
		GUI.EndGroup ();

		GUI.EndGroup ();

		if (showWindow) {
			window01 = GUI.Window(0,window01,DoMyWindow,"可以拖动哦");    //定义为window窗体，”My Windows”为窗体标题
		}

		if (GUI.changed) {
			print("某些控件更新了");
			if(this.toolBarValue == 2){
				print("tool3 clicked!");
			}
		}
	}
	void DoMyWindow(int windowID)
	{
		if (GUI.Button (new Rect (25, 50, 100, 30), "关闭窗口")) {
			this.showWindow = false;
		}
		GUI.DragWindow(new Rect(0, 0, 150,20));  //使用DragWindow设置window窗体为可被鼠标拖动移动，参数表示可拖拽的区域。	
	}
}
