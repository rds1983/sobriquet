﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobriquet {
	[Serializable]
	public class Generator {
		private int _seed = 0;
		private Markov.MarkovChain<char> _chain;

		private Dictionary<string, bool> _originalNames = new Dictionary<string, bool>();
		private Dictionary<string, bool> _seenNames = new Dictionary<string, bool>();

		public Generator(int order, IEnumerable<WeightedName> names) {
			_chain = new Markov.MarkovChain<char>(order);
			foreach (var wn in names) {
				_chain.Add(wn.Name, wn.Weight);
				_originalNames[wn.Name] = true;
			}
		}

		public string Next() {
			var name = new string(_chain.Chain(_seed).ToArray());
			_seed++;
			return name;
		}

		public string NextNew() {
			string name;

			while (true) {
				name = Next();
				if (!_originalNames.ContainsKey(name)) {
					break;
				}
			}
			return name;
		}

		public string NextUnique() {
			string name;

			while (true) {
				name = NextNew();
				if (!_seenNames.ContainsKey(name)) {
					_seenNames[name] = true;
					break;
				}
			}
			return name;
		}
	}
}