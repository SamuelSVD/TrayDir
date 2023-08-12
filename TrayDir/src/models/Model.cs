namespace TrayDir {
	public abstract class Model {
		public object ObjectCopy() {
			return Copy();
		}
		public abstract object Copy();
		/*** Apply should be used to assign all values from the input model to this instance of the model ***/
		public abstract void Apply(object model);

		// Do not override base Equals(object b);
		public abstract bool Equals(object b);
	}
}
