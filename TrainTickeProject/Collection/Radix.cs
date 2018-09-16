using System;
using System.Collections.Generic;
using System.Text;

namespace TrainTickeProject.Collection
{
    /// <summary>
    /// This class contains the implementation of Radix Tree data structure.
    /// </summary>
    public class Radix
    {

        /// <summary>
        /// The <see cref="StringBuilder"/> instance used for string manipulation.
        /// </summary>
        static readonly StringBuilder StringBuilder = new StringBuilder();


        /// <summary>
        /// This class represents the Radix node.
        /// </summary>
        class RadixNode
        {
            /// <summary>
            /// This field contains the Radix node childs and is used as a lookup table.
            /// </summary>
            private readonly Dictionary<char, RadixNode> radixNodes;

            /// <summary>
            /// Initializes a new instance of the <see cref="RadixNode"/> class.
            /// </summary>
            public RadixNode()
            {
                radixNodes = new Dictionary<char, RadixNode>();
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="RadixNode"/> class.
            /// </summary>
            /// <param name="c">The c.</param>
            public RadixNode(char c) : this()
            {
                Char = c;
            }

            /// <summary>
            /// Gets a value indicating whether this instance is a leaf radix node.
            /// </summary>
            /// <value>
            ///   <c>true</c> if this instance is leaf; otherwise, <c>false</c>.
            /// </value>
            private bool IsLeaf { get { return radixNodes.Count == 0; } }

            /// <summary>
            /// Gets or sets the radix node character.
            /// </summary>
            /// <value>
            /// The char.
            /// </value>
            private char Char { get; set; }

            /// <summary>
            /// Gets the child node with the indicated character.
            /// </summary>
            /// <param name="c">The character.</param>
            /// <returns></returns>
            public RadixNode GetChild(char c)
            {
                RadixNode node;
                radixNodes.TryGetValue(c, out node);
                return node;
            }

            /// <summary>
            /// Adds the child node into the current RadixNode lookup table.
            /// </summary>
            /// <param name="node">The node.</param>
            public void AddChild(RadixNode node)
            {
                radixNodes.Add(node.Char, node);
            }

            /// <summary>
            /// Gets the childs terms from the current radix node.
            /// </summary>
            /// <param name="term">The starting term.</param>
            /// <returns></returns>
            public IEnumerable<string> GetChildsTerms(string term)
            {
                if (IsLeaf)
                    return new List<string> { term };

                var terms = new List<string>();

                foreach (var pair in radixNodes)
                {
                    StringBuilder.Clear();
                    StringBuilder.Append(term);

                    terms.AddRange(pair.Value.GetChildTermsInternal(StringBuilder));
                }

                return terms;
            }

            private IEnumerable<string> GetChildTermsInternal(StringBuilder sb)
            {
                // Do not append the control char
                if (new char() != Char)
                    sb.Append(Char);

                if (IsLeaf)
                    return new[] { sb.ToString() };

                var terms = new List<string>();
                foreach (var radixNode in radixNodes)
                {
                    terms.AddRange(radixNode.Value.GetChildTermsInternal(new StringBuilder(sb.ToString())));

                }

                return terms;
            }
        }

        /// <summary>
        /// The radix head node.
        /// </summary>
        private readonly RadixNode head;

        /// <summary>
        /// Initializes a new instance of the <see cref="Radix"/> class.
        /// </summary>
        public Radix()
        {
            head = new RadixNode();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Radix"/> class populated with terms.
        /// </summary>
        /// <param name="terms">The terms.</param>
        public Radix(IEnumerable<string> terms)
            : this()
        {
            foreach (var term in terms)
            {
                Add(term);
            }
        }

        /// <summary>
        /// Finds the specified prefix.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <returns></returns>
        public IEnumerable<string> Find(string prefix)
        {
            if (prefix == null)
                throw new ArgumentNullException("prefix");

            StringBuilder.Clear();

            RadixNode node = head;
            foreach (char prefixChar in prefix)
            {
                var child = node.GetChild(prefixChar);
                node = child;

                if (child == null)
                    return new string[0];

                StringBuilder.Append(prefixChar);
            }

            return node.GetChildsTerms(StringBuilder.ToString());
        }

        /// <summary>
        /// Gets all terms existents in the Radix.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAllTerms()
        {
            return head.GetChildsTerms(string.Empty);
        }

        /// <summary>
        /// Adds the specified term into the Radix.
        /// </summary>
        /// <param name="term">The term.</param>
        public void Add(string term)
        {
            if (term == null)
                throw new ArgumentNullException("term");


            RadixNode node = head;

            // Adding control char
            var prefixChars = new List<char>(term) { new char() };
            foreach (char prefixChar in prefixChars)
            {
                var child = node.GetChild(prefixChar);

                if (child == null)
                {
                    child = new RadixNode(prefixChar);
                    node.AddChild(child);
                }

                node = child;
            }
        }

        /// <summary>
        /// Adds the specified terms into the radix.
        /// </summary>
        /// <param name="terms">The terms.</param>
        public void Add(IEnumerable<string> terms)
        {
            foreach (var term in terms)
            {
                Add(term);
            }
        }
    }
}
    
