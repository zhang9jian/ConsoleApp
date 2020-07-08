using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeature
{
    internal class GenericsWhere
    {
        //以下定义报错：因为要求MyListValue泛型参数为值类型
        //private MyListValue<Person> list1 = new MyListValue<Person>();
        //泛型参数要求是值类型
        private MyListValue<int> list2 = new MyListValue<int>();

        //泛型参数要求是引用类型
        private MyListRef<Person> list1 = new MyListRef<Person>();

        private MyListNullConstructor<Person> list3 = new MyListNullConstructor<Person>();
        private MyListDerive<SeniorPerson> list4 = new MyListDerive<SeniorPerson>();
    }

    internal class MyList<T>
    {
        private List<T> list = new List<T>();

        public T this[int i]
        {
            get { return list[i]; }
            set { this.list[i] = value; }
        }
    }

    internal class Person
    {
        public string Name { get; set; }

        public Person()
        {
            //do nothing
        }
    }

    // 指定泛型参数为值类型
    internal class MyListValue<T> where T : struct
    {
    }

    //泛型参数要求为引用类型
    internal class MyListRef<T> where T : class
    {
    }

    //泛型参数要求有空构造方法
    internal class MyListNullConstructor<T> where T : new()
    {
    }

    internal abstract class SeniorAnimal//高级动物
    {
        public abstract void Speak();//会说话

        public abstract void UseTool();//会使用工具
    }

    internal class MyListDerive<T> where T : SeniorAnimal
    {
    }

    internal class SeniorPerson : SeniorAnimal
    {
        public string Name { get; set; }

        public override void Speak()
        {
            Console.WriteLine("我会说脏话！");
        }

        public override void UseTool()
        {
            Console.WriteLine("我会用砍刀！");
        }
    }

    //指定泛型参数 必须实现指定接口
    //类似于指定继承类

    //指定泛型参数 必须派生于泛型类型U（裸类型约束）
    internal class MyListMethodDerive<U> where U : SeniorAnimal
    {
        private List<U> list = new List<U>();

        public void ShowInfo<T>() where T : U
        {
        }
    }
}