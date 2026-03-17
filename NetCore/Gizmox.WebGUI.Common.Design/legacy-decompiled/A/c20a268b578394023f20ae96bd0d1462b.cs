using System.ComponentModel.Design;

namespace A;

internal class c20a268b578394023f20ae96bd0d1462b : DesignerTransaction
{
	private ccc53407af8f11baecaaada159429c8fa c49b0831076ca879d1f1e580ef82dd5cf;

	public c20a268b578394023f20ae96bd0d1462b(ccc53407af8f11baecaaada159429c8fa host)
	{
		c49b0831076ca879d1f1e580ef82dd5cf = host;
	}

	public c20a268b578394023f20ae96bd0d1462b(ccc53407af8f11baecaaada159429c8fa host, string description)
		: base(description)
	{
		c49b0831076ca879d1f1e580ef82dd5cf = host;
	}

	protected override void OnCommit()
	{
		c49b0831076ca879d1f1e580ef82dd5cf.OnTransactionClosing(commit: true);
		c49b0831076ca879d1f1e580ef82dd5cf.OnTransactionClosed(commit: true);
	}

	protected override void OnCancel()
	{
		c49b0831076ca879d1f1e580ef82dd5cf.OnTransactionClosing(commit: false);
		c49b0831076ca879d1f1e580ef82dd5cf.OnTransactionClosed(commit: false);
	}
}
