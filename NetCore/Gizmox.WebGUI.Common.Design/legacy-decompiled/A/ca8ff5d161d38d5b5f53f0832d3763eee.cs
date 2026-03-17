using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace A;

internal interface ca8ff5d161d38d5b5f53f0832d3763eee : IDesignerHost, IServiceContainer, IServiceProvider
{
	IComponent CreateComponent(IComponent objWebComponent);

	IComponent CreateComponent(IComponent objWebComponent, string name);

	void RenameComponent(IComponent objComponent, string name);
}
