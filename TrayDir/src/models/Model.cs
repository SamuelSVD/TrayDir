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

		// Do not override base Equals(object b);
		public abstract bool Equals(T b);
	}
}
