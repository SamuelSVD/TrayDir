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
		public override bool Equals(object b) {
			return Equals((T)b);
		}
		public abstract bool Equals(T b);
	}
}
