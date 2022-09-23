using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrayDir {
	public abstract class Model<T> {
		public object ObjectCopy() {
			return Copy();
		}
		public abstract T Copy();
		/*** Apply should be used to assign all values from the input model to this instance of the model ***/
		public abstract void Apply(T model);

		// Do not override base Equals(object b);
		public abstract bool Equals(T b);
	}
}
