using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Person p = new Person();
            p.Name = "a";
            Console.WriteLine(p.Name);
            Console.ReadKey();
        }
    }

    internal class Person
    {
        public string Name //相当于public string Name；对取值和设置没有限制，但还是使用了属性
        {
            get;
            set;
        }

        public string Address //使用属性对字段进行封装，使用value内置值进行判断并赋值
        {
            get { return address; }
            set { if (value.Length < 10) { address = value; } }
        }

        private string address;
    }

    internal class DataType
    {
        public void execute()
        {
            Console.WriteLine("**************以下是连续分配内存******************");

            int[] numbers = new int[5];//一维数组
            int[] numbers1 = new int[5] { 1, 2, 3, 4, 5 };//指定大小和元素，使用条件是数组大小必须与元素个数相匹配。
            int[] numbers2 = new int[] { 1, 2, 3, 4, 5 };//不指定数组大小，因为编译器会自动统计元素的个数。
            int[] numbers3 = { 1, 2, 3, 4, 5 };//这是更简化的形式，直接使用花括号声明和初始化数组。
            string[,] names = new string[5, 4];//二维数组的声明方式
            string[,] names1 = { { "a", "b" }, { "c", "d" } };// 二维数组的初始化方式
            byte[][] scores = new byte[5][];  //数组的数组
            int[][] scores1 = { new int[] { 1, 2 }, new int[] { 1, 2, 3, 4 } };

            //Array：在内存上连续分配的，而且元素类型是一样的
            //可以坐标访问  读取快--增删慢，长度不变
            Console.WriteLine("***************Array******************");
            int[] intArray = new int[3];
            intArray[0] = 123;
            string[] strArray = new string[] { "123", "234" };//Array

            //ArrayList 在内存上连续分配的 是非泛型类型的集合，所以ArrayList既能存储相同类型的元素，也能存储不同类型的元素，
            //故ArrayList不能保证类型安全。
            Console.WriteLine("***************ArrayList******************");
            ArrayList arrayList = new ArrayList();
            ArrayList tempArrayList = new ArrayList();
            arrayList.Add("abc");//在集合结尾处添加单个元素
            arrayList.AddRange(tempArrayList);//在集合结尾处添加指定集合
            arrayList.Remove("abc");//移除指定元素（第一个匹配项）
            arrayList.RemoveAt(0);//移除指定索引处元素
            arrayList.Contains("cd");//判断指定元素是否存在集合中。
            arrayList.Insert(1, "kk");//将元素插入指定索引位置

            //List 在内存上连续分配的 是一种泛型集合，并保证类型安全。因此List在声明时就需要指定类型。
            Console.WriteLine("***************List<T>******************");
            List<string> address = new List<string>();//声明一个List
            List<string> tempAddress = new List<string>() { "北京", "沈阳" };
            address.Add("武汉");//在集合结尾处添加单个元素
            address.AddRange(tempAddress);//在集合结尾处添加指定集合
            address.Remove("沈阳");//移除集合中第一个匹配元素
            address.RemoveAt(0);//移除指定索引处元素
            address.Insert(1, "湖南");//将元素插入集合指定索引位置
            address.Clear();//移除集合中所有元素
            address.Contains("湖南");//判断某个元素是否存在集合中
            int number = address.Count;//获取集合中元素个数

            Console.WriteLine("**************以下是非连续分配内存******************");

            //LinkedList：泛型的特点;链表，元素不连续分配，每个元素都有记录前后节点
            //节点值可以重复
            //能不能下标访问？不能，找元素就只能遍历  查找不方便
            //增删 就比较方便
            Console.WriteLine("***************LinkedList<T>******************");
            LinkedList<int> linkedList = new LinkedList<int>();
            //linkedList[3]
            linkedList.AddFirst(123);//添加为第一个节点元素
            linkedList.AddLast(456);//添加为最后一个节点元素

            bool isContain = linkedList.Contains(123);
            LinkedListNode<int> node123 = linkedList.Find(123);  //元素123的位置  从头查找
            linkedList.AddBefore(node123, 123);//节点不存在，会报错
            linkedList.AddBefore(node123, 123);//在指定节点前新增元素
            linkedList.AddAfter(node123, 9);//在指定节点后新增元素

            linkedList.Remove(456);//删除指定值，不存在会报错
            linkedList.Remove(node123);//删除指定节点
            linkedList.RemoveFirst();//删除第一个元素
            linkedList.RemoveLast();//删除最后一个元素
            linkedList.Clear();

            //Queue 就是链表  先进先出  放任务延迟执行，A不断写入日志任务  B不断获取任务去执行
            Console.WriteLine("***************Queue<T>******************");
            Queue<string> numbersQ = new Queue<string>();
            numbersQ.Enqueue("one");//添加对象到队列末尾
            numbersQ.Enqueue("two");
            numbersQ.Enqueue("three");
            numbersQ.Enqueue("four");
            numbersQ.Enqueue("four");
            numbersQ.Enqueue("five");

            foreach (string num in numbersQ)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine($"Dequeuing '{numbersQ.Dequeue()}'");//Dequeue方法 移除并返回队列的第一个元素
            Console.WriteLine($"Peek at next item to dequeue: { numbersQ.Peek()}");//Peek方法 返回队列的第一个元素 但不移除元素
            Console.WriteLine($"Dequeuing '{numbersQ.Dequeue()}'");

            Queue<string> queueCopy = new Queue<string>(numbersQ.ToArray());
            foreach (string num in queueCopy)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine($"queueCopy.Contains(\"four\") = {queueCopy.Contains("four")}");
            queueCopy.Clear();
            Console.WriteLine($"queueCopy.Count = {queueCopy.Count}");

            //Stack 就是链表  先进后出  解析表达式目录树的时候，先产生的数据后使用
            //操作记录为命令，撤销的时候是倒序的
            Console.WriteLine("***************Stack<T>******************");
            Stack<string> numbersStack = new Stack<string>();
            numbersStack.Push("one");
            numbersStack.Push("two");
            numbersStack.Push("three");
            numbersStack.Push("four");
            numbersStack.Push("five");//放进去

            foreach (string num in numbersStack)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine($"Pop '{numbersStack.Pop()}'");//获取并移除
            Console.WriteLine($"Peek at next item to dequeue: { numbersStack.Peek()}");//获取不移除
            Console.WriteLine($"Pop '{numbersStack.Pop()}'");

            Stack<string> stackCopy = new Stack<string>(numbersStack.ToArray());
            foreach (string num in stackCopy)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine($"stackCopy.Contains(\"four\") = {stackCopy.Contains("four")}");
            stackCopy.Clear();
            Console.WriteLine($"stackCopy.Count = {stackCopy.Count}");

            Console.WriteLine("***************Set 纯粹的集合，容器，唯一性**************************");
            //集合：hash分布，元素间没关系,动态增加容量  去重
            //统计用户IP；IP投票   交叉并补--二次好友/间接关注/粉丝合集
            Console.WriteLine("***************HashSet<string>******************");
            HashSet<string> hashSet = new HashSet<string>();
            hashSet.Add("123");
            hashSet.Add("689");
            hashSet.Add("456");
            hashSet.Add("12435");
            hashSet.Add("12435");
            hashSet.Add("12435");
            //hashSet[0];
            foreach (var item in hashSet)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(hashSet.Count);
            Console.WriteLine(hashSet.Contains("12345"));

            {
                HashSet<string> hashSet1 = new HashSet<string>();
                hashSet1.Add("123");
                hashSet1.Add("689");
                hashSet1.Add("789");
                hashSet1.Add("12435");
                hashSet1.Add("12435");
                hashSet1.Add("12435");
                hashSet1.SymmetricExceptWith(hashSet);//补
                hashSet1.UnionWith(hashSet);//并
                hashSet1.ExceptWith(hashSet);//差
                hashSet1.IntersectWith(hashSet);//交
            }
            hashSet.ToList();
            hashSet.Clear();

            //排序的集合：去重  而且排序
            //统计排名--每统计一个就丢进去集合
            Console.WriteLine("***************SortedSet<string>******************");
            SortedSet<string> sortedSet = new SortedSet<string>();
            //IComparer<T> comparer  自定义对象要排序，就用这个指定
            sortedSet.Add("123");
            sortedSet.Add("689");
            sortedSet.Add("456");
            sortedSet.Add("12435");
            sortedSet.Add("12435");
            sortedSet.Add("12435");

            foreach (var item in sortedSet)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(sortedSet.Contains("12345"));
            {
                SortedSet<string> sortedSet1 = new SortedSet<string>();
                sortedSet1.Add("123");
                sortedSet1.Add("689");
                sortedSet1.Add("456");
                sortedSet1.Add("12435");
                sortedSet1.Add("12435");
                sortedSet1.Add("12435");
                sortedSet1.SymmetricExceptWith(sortedSet);//补
                sortedSet1.UnionWith(sortedSet);//并
                sortedSet1.ExceptWith(sortedSet);//差
                sortedSet1.IntersectWith(sortedSet);//交
            }

            sortedSet.ToList();
            sortedSet.Clear();

            Console.WriteLine("***************读取&增删都快？ 有 hash散列 字典******************");

            //Hashtable key-value  体积可以动态增加 拿着key计算一个地址，然后放入key - value
            //object-装箱拆箱  如果不同的key得到相同的地址，第二个在前面地址上 + 1
            //查找的时候，如果地址对应数据的key不对，那就 + 1查找。。
            //浪费了空间，Hashtable是基于数组实现
            //查找个数据  一次定位； 增删 一次定位；  增删查改 都很快
            //浪费空间，数据太多，重复定位定位，效率就下去了
            Console.WriteLine("***************Hashtable******************");
            Hashtable table = new Hashtable();
            table.Add("123", "456");
            table[234] = 456;
            table[234] = 567;
            table[32] = 4562;
            table[1] = 456;
            table["eleven"] = 456;
            foreach (DictionaryEntry objDE in table)
            {
                Console.WriteLine(objDE.Key.ToString());
                Console.WriteLine(objDE.Value.ToString());
            }
            //线程安全
            Hashtable.Synchronized(table);//只有一个线程写  多个线程读

            //哈希表未声明类型，会引发类型安全问题,哈希表默认是允许单线程写入，多线程读取，故是线程安全类型。
            Hashtable hashtable = new Hashtable();//声明一个哈希表
            hashtable.Add(0, "北京");//添加带有指定键和值的元素
            hashtable.Clear();//移除所有元素
            hashtable.ContainsKey(0);//判断哈希表中是否存在指定键
            hashtable.ContainsValue("北京");//判断哈希表中是否存在指定值
            hashtable.Remove(0);//移除指定键的键值对
            int hashtableCount = hashtable.Count;//获取哈希表中键值对个数

            //字典：泛型；key - value，增删查改 都很快；有序的
            //  字典不是线程安全 ConcurrentDictionary
            Console.WriteLine("***************Dictionary******************");
            //字典指定类型，故保证类型安全，但字典多线程时不是线程安全的类型，必须人为使用lock语句进行保护.
            //字典指定数据类型
            Dictionary<string, string> dictionary = new Dictionary<string, string>();//声明一个字典
            dictionary.Add("张三", "15823504311");//添加带有指定键和值的元素
            dictionary.Clear();//移除所有元素
            dictionary.ContainsKey("张三");//判断字典中是否存在指定键
            dictionary.ContainsValue("15823504311");//判断字典中是否存在指定值
            dictionary.Remove("张三");//移除指定键的键值对
            int dictionaryCount = dictionary.Count;//获取字典中键值对个数
            Dictionary<string, string>.KeyCollection keys = dictionary.Keys;//获取字典中键的集合
            Dictionary<string, string>.ValueCollection values = dictionary.Values;//获取字典中值的集合

            Console.WriteLine("***************SortedDictionary******************");
            SortedDictionary<int, string> dic = new SortedDictionary<int, string>();
            dic.Add(1, "HaHa");
            dic.Add(5, "HoHo");
            dic.Add(3, "HeHe");
            dic.Add(2, "HiHi");
            dic.Add(4, "HuHu1");
            dic[4] = "HuHu";//相同key替换原值
            dic.Add(4, "HuHu");//相同key,会报错
            foreach (var item in dic)
            {
                Console.WriteLine($"Key:{item.Key}, Value:{item.Value}");
            }

            Console.WriteLine("***************SortedList******************");
            SortedList sortedList = new SortedList();//IComparer
            sortedList.Add("First", "Hello");
            sortedList.Add("Second", "World");
            sortedList.Add("Third", "!");

            sortedList["Third"] = "~~";//相同key替换原值
            sortedList.Add("Fourth", "!");
            sortedList.Add("Fourth", "!");//重复的Key Add会错
            sortedList["Fourth"] = "!!!";
            var keyList = sortedList.GetKeyList();
            var valueList = sortedList.GetValueList();

            sortedList.TrimToSize();//用于最小化集合的内存开销

            sortedList.Remove("Third");
            sortedList.RemoveAt(0);
            sortedList.Clear();

            //ConcurrentQueue 线程安全版本的Queue
            //ConcurrentStack线程安全版本的Stack
            //ConcurrentBag线程安全的对象集合
            //ConcurrentDictionary线程安全的Dictionary
            //BlockingCollection
        }
    }
}