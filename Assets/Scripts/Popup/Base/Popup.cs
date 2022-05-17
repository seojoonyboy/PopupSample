using UnityEngine;

public class Popup : MonoBehaviour
{
    #region const var
    private const string basePath = "Prefabs/Popup/";
    #endregion

    public delegate void OnResultCallback(Popup popup, Result result);
    public OnResultCallback ResultCallback { protected set; get; }

    #region protected var
    protected Result result;
    protected Params paramBuffer = null;
    #endregion
    
    public Params GetParam()
    {
        return this.paramBuffer;
    }

    private void Awake()
    {
        this.result = new Result();
    }

    #region Inner Classs
    public class Params { }
    
    public class Result
    {
        public bool isOnOk;
        public bool isOnX;
    }
    #endregion

    /// <summary>
    /// Entry Point. 팝업을 생성한다.
    /// </summary>
    /// <param name="popupName">팝업 프리팹 이름</param>
    /// <param name="parms">팝업 관련 파라미터</param>
    /// <param name="callback">팝업 완료 콜백</param>
    /// <returns></returns>
    public static Popup Load(string popupName, Params parms, OnResultCallback callback = null)
    {
        if (PopupRoot.Instance == null)
        {
            return null;
        }

        string path = basePath + popupName;
        Popup prefab = Resources.Load<Popup>(path);
        if (prefab == null)
        {
            return null;
        }
        
        GameObject instance = (GameObject)GameObject.Instantiate(prefab.gameObject, PopupRoot.Instance.transform, true);
        instance.transform.localPosition = Vector3.zero;
        
        if (null == instance)
        {
            UnityEngine.Object.Destroy(prefab);
            return null;
        }

        Popup popup = instance.GetComponent<Popup>();
        if (popup == null)
        {
            GameObject.Destroy(instance);
            UnityEngine.Object.Destroy(prefab);
        }

        PopupRoot.Instance.AddPopup(popup);
        popup.Open(parms, callback);
        
        return popup;
    }

    private void Open(Params parm, OnResultCallback resultCallback)
    {
        this.paramBuffer = parm;
        this.ResultCallback = resultCallback;
    }

    #region Inspector connect functions
    //(확인)팝업 닫기
    //Inspector 상으로 버튼 연결용 함수
    public virtual void OnTriggerOk()
    {
        this.result.isOnOk = true;
        this.result.isOnX = false;
        
        this.Close();
    }

    //(취소)팝업 닫기
    //Inspector 상으로 버튼 연결용 함수
    public virtual void OnTriggerX()
    {
        this.result.isOnOk = false;
        this.result.isOnX = true;
        
        this.Close();
    }
    #endregion
    
    public virtual void Close()
    {
        this.ResultCallback?.Invoke(this, this.result);
        PopupRoot.Instance.RemovePopup(this);
    }
}
