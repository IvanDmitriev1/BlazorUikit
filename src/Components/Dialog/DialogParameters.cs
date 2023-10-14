using System.Linq.Expressions;

namespace BlazorUiKit.Components;

public class DialogParameters<TDialog> : Dictionary<string, object> where TDialog : DialogBase
{
	public void Add<TParam>(Expression<Func<TDialog, TParam>> propertyExpression, TParam value)
		where TParam : notnull
	{
		if (propertyExpression.Body is not MemberExpression memberExpression)
		{
			throw new ArgumentException($"Argument '{nameof(propertyExpression)}' must be a '{nameof(MemberExpression)}'");
		}

		Add(memberExpression.Member.Name, value);
	}
}