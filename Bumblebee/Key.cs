using System;

using OpenQA.Selenium;

namespace Bumblebee
{
	/// <summary>
	/// Represents the key on the keyboard.
	/// </summary>
	public class Key : IEquatable<Key>
	{
		/// <summary>
		/// Represents the function keys found at the top of a standard keyboard.
		/// </summary>
		public static class Function
		{
			public static readonly Key F1 = new Key(Keys.F1, "F1");
			public static readonly Key F2 = new Key(Keys.F2, "F2");
			public static readonly Key F3 = new Key(Keys.F3, "F3");
			public static readonly Key F4 = new Key(Keys.F4, "F4");
			public static readonly Key F5 = new Key(Keys.F5, "F5");
			public static readonly Key F6 = new Key(Keys.F6, "F6");
			public static readonly Key F7 = new Key(Keys.F7, "F7");
			public static readonly Key F8 = new Key(Keys.F8, "F8");
			public static readonly Key F9 = new Key(Keys.F9, "F9");
			public static readonly Key F10 = new Key(Keys.F10, "F10");
			public static readonly Key F11 = new Key(Keys.F11, "F11");
			public static readonly Key F12 = new Key(Keys.F12, "F12");
		}

		/// <summary>
		/// Represents the arrow keys found to the right on a standard keyboard.
		/// </summary>
		public static class Arrows
		{
			public static readonly Key Up = new Key(Keys.Up, "Up");
			public static readonly Key Down = new Key(Keys.Down, "Down");
			public static readonly Key Left = new Key(Keys.Left, "Left");
			public static readonly Key Right = new Key(Keys.Right, "Right");
		}

		/// <summary>
		/// Represents the keys that are part of the standard 10-key on the far right of a standard keyboard.
		/// </summary>
		public static class Numpad
		{
			public static readonly Key NumberPad0 = new Key(Keys.NumberPad0, "NumberPad0");
			public static readonly Key NumberPad1 = new Key(Keys.NumberPad1, "NumberPad1");
			public static readonly Key NumberPad2 = new Key(Keys.NumberPad2, "NumberPad2");
			public static readonly Key NumberPad3 = new Key(Keys.NumberPad3, "NumberPad3");
			public static readonly Key NumberPad4 = new Key(Keys.NumberPad4, "NumberPad4");
			public static readonly Key NumberPad5 = new Key(Keys.NumberPad5, "NumberPad5");
			public static readonly Key NumberPad6 = new Key(Keys.NumberPad6, "NumberPad6");
			public static readonly Key NumberPad7 = new Key(Keys.NumberPad7, "NumberPad7");
			public static readonly Key NumberPad8 = new Key(Keys.NumberPad8, "NumberPad8");
			public static readonly Key NumberPad9 = new Key(Keys.NumberPad9, "NumberPad9");

			public static readonly Key Add = new Key(Keys.Add, "Add");
			public static readonly Key Subtract = new Key(Keys.Subtract, "Subtract");
			public static readonly Key Multiply = new Key(Keys.Multiply, "Multiply");
			public static readonly Key Divide = new Key(Keys.Divide, "Divide");

			public static readonly Key Decimal = new Key(Keys.Decimal, "Decimal");
		}

		/// <summary>
		/// Represents the keys not found in any of the other regions on the keyboard.
		/// </summary>
		public static class Other
		{
			public static readonly Key Insert = new Key(Keys.Insert, "Insert");
			public static readonly Key Delete = new Key(Keys.Delete, "Delete");
			public static readonly Key Home = new Key(Keys.Home, "Home");
			public static readonly Key End = new Key(Keys.End, "End");
			public static readonly Key PageUp = new Key(Keys.PageUp, "PageUp");
			public static readonly Key PageDown = new Key(Keys.PageDown, "PageDown");

			public static readonly Key Pause = new Key(Keys.Pause, "Pause");
		}

		public static readonly Key D0 = new Key("0", "0");
		public static readonly Key D1 = new Key("1", "1");
		public static readonly Key D2 = new Key("2", "2");
		public static readonly Key D3 = new Key("3", "3");
		public static readonly Key D4 = new Key("4", "4");
		public static readonly Key D5 = new Key("5", "5");
		public static readonly Key D6 = new Key("6", "6");
		public static readonly Key D7 = new Key("7", "7");
		public static readonly Key D8 = new Key("8", "8");
		public static readonly Key D9 = new Key("9", "9");

		public static readonly Key A = new Key("a", "A");
		public static readonly Key B = new Key("b", "B");
		public static readonly Key C = new Key("c", "C");
		public static readonly Key D = new Key("d", "D");
		public static readonly Key E = new Key("e", "E");
		public static readonly Key F = new Key("f", "F");
		public static readonly Key G = new Key("g", "G");
		public static readonly Key H = new Key("h", "H");
		public static readonly Key I = new Key("i", "I");
		public static readonly Key J = new Key("j", "J");
		public static readonly Key K = new Key("k", "K");
		public static readonly Key L = new Key("l", "L");
		public static readonly Key M = new Key("m", "M");
		public static readonly Key N = new Key("n", "N");
		public static readonly Key O = new Key("o", "O");
		public static readonly Key P = new Key("p", "P");
		public static readonly Key Q = new Key("q", "Q");
		public static readonly Key R = new Key("r", "R");
		public static readonly Key S = new Key("s", "S");
		public static readonly Key T = new Key("t", "T");
		public static readonly Key U = new Key("u", "U");
		public static readonly Key V = new Key("v", "V");
		public static readonly Key W = new Key("w", "W");
		public static readonly Key X = new Key("x", "X");
		public static readonly Key Y = new Key("y", "Y");
		public static readonly Key Z = new Key("z", "Z");

		public static readonly Key Alt = new Key(Keys.Alt, "Alt");
		public static readonly Key Apostrophe = new Key("'", "'");
		public static readonly Key Backslash = new Key(@"\", @"\");
		public static readonly Key Backspace = new Key(Keys.Backspace, "Backspace");
		public static readonly Key Comma = new Key(",", ",");
		public static readonly Key Command = new Key(Keys.Command, "Command");
		public static readonly Key Control = new Key(Keys.Control, "Control");
		public static readonly Key Enter = new Key(Keys.Enter, "Enter");
		public static readonly Key Equal = new Key(Keys.Equal, "Equal");
		public static readonly Key Escape = new Key(Keys.Escape, "Escape");
		public static readonly Key Grave = new Key("`", "`");
		public static readonly Key LeftBracket = new Key("[", "[");
		public static readonly Key Period = new Key(".", ".");
		public static readonly Key RightBracket = new Key("]", "]");
		public static readonly Key Semicolon = new Key(Keys.Semicolon, ";");
		public static readonly Key Shift = new Key(Keys.Shift, "Shift");
		public static readonly Key Slash = new Key("/", "/");
		public static readonly Key Space = new Key(Keys.Space, "Space");
		public static readonly Key Tab = new Key(Keys.Tab, "Tab");

		private readonly string _key;
		private readonly string _visualization;

		internal string Value { get { return _key; } }

		private Key(string key, string visualization)
		{
			_key = key;
			_visualization = visualization;
		}

		// TODO: provide a constructor (or implicit assignment operator?) for System.ConsoleKey and System.Windows.Forms.Keys???

		public static Key operator +(Key left, Key right)
		{
			return new Key(String.Format("{0}{1}", left.Value, right.Value), String.Format("{0}+{1}", left, right));
		}

		public static Key operator |(Key left, Key right)
		{
			return new Key(String.Format("{0}{1}", left.Value, right.Value), String.Format("{0}+{1}", left, right));
		}

		public bool Equals(Key other)
		{
			bool result;

			if (ReferenceEquals(null, other))
			{
				result = false;
			}
			else if (ReferenceEquals(this, other))
			{
				result = true;
			}
			else
			{
				result = String.Equals(_key, other._key);
			}

			return result;
		}

		public override bool Equals(object obj)
		{
			bool result;

			if (ReferenceEquals(null, obj))
			{
				result = false;
			}
			else if (ReferenceEquals(this, obj))
			{
				result = true;
			}
			else if (obj.GetType() != GetType())
			{
				result = false;
			}
			else
			{
				result = Equals((Key) obj);
			}

			return result;
		}

		public override int GetHashCode()
		{
			return (_key != null ? _key.GetHashCode() : 0);
		}

		public override string ToString()
		{
			return _visualization;
		}
	}
}
