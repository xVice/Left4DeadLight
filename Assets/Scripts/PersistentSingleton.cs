using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentSingleton<T> : Singleton<T> where T : Singleton<T>
{
	// Token: 0x060001A9 RID: 425 RVA: 0x00003EB1 File Offset: 0x000020B1
	protected override void Initialize()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
	}
}
