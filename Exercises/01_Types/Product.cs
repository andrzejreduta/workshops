using System.Collections;
using System.Collections.Generic;

namespace Exercises._01_Types
{
    public interface ISpecialProduct { }

    public class SpecialProduct : Product, ISpecialProduct { }


    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public IReadOnlyList<string> Strings { get; private set; }

        public void SetValues(int id, List<string> strings, bool b) { }

        public void SetValues(int id, params string[] strings)
        {
            Id = id;
            Strings = strings;
        }

        public void SetProduct(Product product) { }

        public void SetProduct(ISpecialProduct product) { }

        public void SetProduct(SpecialProduct product) { }

        public void Test()
        {
            SetValues(1);
            SetValues(1, "test");
            SetValues(1, "test", "test2", "test3");
            SetValues(1, new List<string> {"abc", "def"}, true);
            var list = new List<string>();
            list.Add("abd");
            list.Add("def");

            var myList = new MyList<int> {1, 3 /*, "abc", "def"*/};
            // myList.Add("a");
            myList.Add(1);
            // myList.Add(new object());

            foreach (var item in myList) { }

            SetProduct(new SpecialProduct());
        }

        public IEnumerable<int> GetIntEnumerable(bool b)
        {
            yield return 1;
            yield return 2;
            if (b)
                yield break;
            yield return 3;
            yield return 4;
        }
    }

    public class MyList<T> : IEnumerable<T>
        where T : struct
    {
        public void Add(T item) { }

        // public void Add(string item)
        // {
        //     
        // }
        //
        // public void Add(object item)
        // {
        //     
        // }

        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}