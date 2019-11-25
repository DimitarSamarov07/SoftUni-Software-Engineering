namespace _01._Prototype
{
    using System.Collections.Generic;

    public class SandwichMenu
    {
        private Dictionary<string, SandwichPrototype> _sandwiches =
            new Dictionary<string, SandwichPrototype>();

        public SandwichPrototype this[string name]
        {
            get => this._sandwiches[name];
            set => this._sandwiches.Add(name, value);
        }

    }
}
