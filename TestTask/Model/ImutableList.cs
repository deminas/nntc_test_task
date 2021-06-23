using System;
using System.Collections;
using System.Collections.Generic;

namespace TestTask.Data
{
    public class ImutableList<T> : IImutableList<T>
    {
        private class Node
        {
            public Node NextNode { get; set; }

            public int Index { get; set; }

            public T Value { get; set; }

            public Node(int index, T value)
            {
                Index = index;
                Value = value;
            }
        }

        private Node _firstNode;

        /// <summary>
        /// Добавление элемента в конец списка
        /// </summary>
        /// <param name="value">Значение</param>
        /// <returns>Новый список с учетом добавления</returns>
        public IImutableList<T> Add(T value)
        {
            var result = new ImutableList<T>();
            Node previousNode = null;

            foreach (var item in this)
            {
                var node = new Node(previousNode?.Index + 1 ?? 0, item);

                if (previousNode == null)
                {
                    result._firstNode = node;
                }
                else
                {
                    previousNode.NextNode = node;
                }

                previousNode = node;
            }

            var newNode = new Node(previousNode?.Index + 1 ?? 0, value);

            if (previousNode == null)
            {
                result._firstNode = newNode;
            }
            else
            {
                previousNode.NextNode = newNode;
            }

            return result;
        }

        /// <summary>
        /// Объединение списков
        /// </summary>
        /// <param name="other">Список для объединения</param>
        /// <returns>Объединенный список</returns>
        public IImutableList<T> Join(IImutableList<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other), "Missing list to combine");
            }

            var result = new ImutableList<T>();
            Node previousNode = null;

            foreach (var item in this)
            {
                var node = new Node(previousNode?.Index + 1 ?? 0, item);

                if (previousNode == null)
                {
                    result._firstNode = node;
                }
                else
                {
                    previousNode.NextNode = node;
                }

                previousNode = node;
            }

            foreach (var item in other)
            {
                var node = new Node(previousNode?.Index + 1 ?? 0, item);

                if (previousNode == null)
                {
                    result._firstNode = node;
                }
                else
                {
                    previousNode.NextNode = node;
                }

                previousNode = node;
            }

            return result;
        }

        /// <summary>
        /// Удаляет первый элемент
        /// </summary>
        /// <returns>Новый список с учетом удаления</returns>
        public IImutableList<T> Pop()
        {
            if (_firstNode == null)
            {
                throw new NullReferenceException("First item not found");
            }

            var result = new ImutableList<T>();
            Node previousNode = null;

            for (Node temp = _firstNode.NextNode; temp != null; temp = temp.NextNode)
            {
                var node = new Node(previousNode?.Index + 1 ?? 0, temp.Value);

                if (previousNode == null)
                {
                    result._firstNode = node;
                }
                else
                {
                    previousNode.NextNode = node;
                }

                previousNode = node;
            }

            return result;
        }

        /// <summary>
        /// Удаляет элемент по индексу
        /// </summary>
        /// <param name="index">Индекс элемента</param>
        /// <returns>Новый список с учетом удаления</returns>
        public IImutableList<T> Delete(int index)
        {
            var result = new ImutableList<T>();
            Node previousNode = null;

            for (Node temp = _firstNode; temp != null; temp = temp.NextNode)
            {
                if (temp.Index == index)
                {
                    continue;
                }

                var node = new Node(previousNode?.Index + 1 ?? 0, temp.Value);

                if (previousNode == null)
                {
                    result._firstNode = node;
                }
                else
                {
                    previousNode.NextNode = node;
                }

                previousNode = node;
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (Node temp = _firstNode; temp != null; temp = temp.NextNode)
            {
                yield return temp.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
