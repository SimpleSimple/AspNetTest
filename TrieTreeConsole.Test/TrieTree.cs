using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrieTreeConsole.Test
{
    public class TireTree
    {
        private TireNode root = new TireNode(' ');

        public TireTree()
        {

        }

        private void CreateTireTree(TireNode node, string word, int index)
        {
            if (word.Length == index) return;
            char key = word[index];
            TireNode newNode = null;
            if (node.NextNode.ContainsKey(key))
            {
                newNode = node.NextNode[key];
            }
            else
            {
                newNode = new TireNode(key);
                node.NextNode.Add(key, newNode);
            }
            if (word.Length - 1 == index)
            {
                newNode.Word = word;
            }
            CreateTireTree(node.NextNode[key], word, index + 1);
        }

        public void AddWords(string word)
        {
            CreateTireTree(root, word, 0);
        }

        public List<string> SearchWords(string content)
        {
            List<string> result = new List<string>();
            char[] charArr = content.ToCharArray();
            TireNode currentNode = root;
            for (int i = 0; i < charArr.Length; i++)
            {
                if (currentNode.NextNode.ContainsKey(charArr[i])) //如果下个节点找得到当前字，则继续往下找下个字符。
                {
                    currentNode = currentNode.NextNode[charArr[i]];
                }
                else if (root.NextNode.ContainsKey(charArr[i]))   //如果下个节点找不到当前字，则从根节点找。
                {
                    currentNode = root.NextNode[charArr[i]];
                }
                else                                              //否则下个字符，也从根节点找。
                {
                    currentNode = root;
                }
                if (currentNode.IsWord)
                {
                    if (!result.Contains(currentNode.Word))
                        result.Add(currentNode.Word);
                }
            }

            return result;
        }

        private class TireNode
        {
            public char Key { get; set; }
            public string Word { get; set; }
            public bool IsWord { get { return this.Word != null; } }
            private Dictionary<char, TireNode> nextNode = new Dictionary<char, TireNode>();
            public Dictionary<char, TireNode> NextNode
            {
                get { return nextNode; }
                set { nextNode = value; }
            }

            public TireNode(char key)
            {
                this.Key = key;
            }
        }
    }
}
