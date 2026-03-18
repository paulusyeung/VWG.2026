using System;

namespace Gizmox.WebGUI.Common.Design.Skins.Forms;

public interface IWorkerItemContainer
{
	bool IsHandleCreated { get; }

	void WorkerItemProcessCompleted(object sender, ProcessCompletedArgs e);

	object Invoke(Delegate method);

	object Invoke(Delegate method, params object[] args);
}
