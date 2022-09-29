using System;
using System.Reflection;

namespace TrayDir {
	public class StringIndexable {
		public object this[string propertyName] {
			get {
				Type myType = GetType();
				FieldInfo myPropInfo = myType.GetField(propertyName);
				return myPropInfo.GetValue(this);
			}
			set {
				Type myType = GetType();
				FieldInfo myPropInfo = myType.GetField(propertyName);
				myPropInfo.SetValue(this, value);
			}
		}
	}
}
