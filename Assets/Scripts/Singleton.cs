using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
	// Token: 0x1700002C RID: 44
	// (get) Token: 0x060001B1 RID: 433 RVA: 0x00008138 File Offset: 0x00006338
	public static T Instance
	{
		get
		{
			if (Singleton<T>._instance == null)
			{
				Singleton<T>._instance = Singleton<T>.GetObjectOfType();
				if (Singleton<T>._instance == null)
				{
					Debug.LogError(string.Format("{0}:: Singleton instance not found.", typeof(T)));
				}
				else
				{
					Debug.LogWarning(string.Format("{0}:: Singleton instance not initialized yet, don't reference singletons in \"Awake\" or earlier. Calling \"{1}\" now, might have unintended effects...", typeof(T), "Initialize"));
					if (!Singleton<T>._instance._isInitialized)
					{
						Singleton<T>._instance._isInitialized = true;
						Singleton<T>._instance.Initialize();
					}
				}
			}
			return Singleton<T>._instance;
		}
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x000025D1 File Offset: 0x000007D1
	protected virtual void Initialize()
	{
	}

	// Token: 0x060001B3 RID: 435 RVA: 0x000025D1 File Offset: 0x000007D1
	protected virtual void Cleanup()
	{
	}

	// Token: 0x060001B4 RID: 436 RVA: 0x000081E4 File Offset: 0x000063E4
	protected void Awake()
	{
		if (Singleton<T>._instance == null)
		{
			Singleton<T>._instance = (this as T);
			if (!this._isInitialized)
			{
				this._isInitialized = true;
				this.Initialize();
				return;
			}
		}
		else if (Singleton<T>._instance != this)
		{
			Debug.LogError(string.Format("{0}:: Duplicate singleton instance! Destroying {1} on object [{2}] but object itself stays alive, leaving object [{3}] intact.", new object[]
			{
					typeof(T),
					typeof(T),
					base.name,
					Singleton<T>._instance.name
			}));
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x060001B5 RID: 437 RVA: 0x0000828B File Offset: 0x0000648B
	protected void OnDestroy()
	{
		if (Singleton<T>._instance == this)
		{
			this.Cleanup();
			Singleton<T>._instance = default(T);
			this._isInitialized = false;
		}
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x000082B8 File Offset: 0x000064B8
	private static T GetObjectOfType()
	{
		int sceneCount = SceneManager.sceneCount;
		for (int i = 0; i < sceneCount; i++)
		{
			GameObject[] rootGameObjects = SceneManager.GetSceneAt(i).GetRootGameObjects();
			for (int j = 0; j < rootGameObjects.Length; j++)
			{
				T t = Singleton<T>.FindTypeInChildren(rootGameObjects[j].transform);
				if (t != null)
				{
					return t;
				}
			}
		}
		return default(T);
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x00008324 File Offset: 0x00006524
	private static T FindTypeInChildren(Transform transformObject)
	{
		if (transformObject.GetComponent<T>() != null)
		{
			return transformObject.GetComponent<T>();
		}
		foreach (object obj in transformObject)
		{
			T t = Singleton<T>.FindTypeInChildren((Transform)obj);
			if (t != null)
			{
				return t;
			}
		}
		return default(T);
	}

	// Token: 0x04000142 RID: 322
	private static T _instance;

	// Token: 0x04000143 RID: 323
	private bool _isInitialized;
}
