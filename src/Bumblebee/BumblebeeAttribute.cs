using System;

namespace Bumblebee
{
	/// <summary>
	/// An attribute that tells Bumblebee to ignore this type/class when determining the file name to use when capturing the screen.
	/// </summary>
	/// <remarks>
	/// On screen capture, Bumblebee will use the name of the class and method outside of Bumblebee internal classes to name the image.  
	/// Apply this attribute to any type that you do not want Bumblebee to use for the naming.  
	/// For example, any third party element projects such as Bumblebee.KendoUI.
	/// </remarks>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class BumblebeeAttribute : Attribute
	{
	}
}
