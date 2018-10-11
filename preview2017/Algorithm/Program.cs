using System;
using System.IO;
using System.Linq;

namespace Algorithm
{
    class Program
    {
        #region 顺递归
        //  static void Main(string[] args)
        //  {
        //      Console.WriteLine("Hello World!");
        //     // int xx = 2;
        //      Console.WriteLine(DayPeach(2)+"");
        //      Console.WriteLine(DayPeach(1) + "");
        //      Console.ReadKey();
        //  }
        //static  int DayPeach(int whichday)
        //  {
        //      if (whichday == 10)
        //          return 1;
        //      else
        //          if (whichday >= 1)
        //          return 2 * DayPeach(whichday +1) + 2;

        //      else
        //          throw new Exception("天数不正确");
        //  } 
        #endregion

        #region 生成连续和任意重复的字符串实例
        //static void Main(string[] args)
        //{
        //    Program p = new Program();//创建Program对象
        //    p.CreateSString();//调用自定义方法
        //    p.CreateTString();//调用自定义方法
        //    Console.Read();
        //}
        //private void CreateSString()
        //{
        //    //生成包含6个连续字符的字符串
        //    var dd = Enumerable.Range(9, 6).ToArray();
        //    string str = new string(Enumerable.Range(9, 6).Select(i => (char)(i + 65)).ToArray());
        //    Console.WriteLine("包含6个连续字符的字符串：" + str);
        //}
        //private void CreateTString()
        //{
        //    //生成包含3个重复字符串的字符串
        //    string str = string.Join(string.Empty, Enumerable.Repeat("MR", 3).ToArray());
        //    Console.WriteLine("包含3个重复字符串的字符串：" + str);
        //} 
        #endregion

        #region 获取文件扩展名
        //static void Main(string[] args)
        //{
        //    string fullPath = @"\WebSite1\Default.aspx";

        //    string filename = Path.GetFileName(fullPath);//文件名  “Default.aspx”
        //    string extension = Path.GetExtension(fullPath);//扩展名 “.aspx”
        //    Console.ReadKey();
        //} 
        #endregion

        static void Main(string[] args)
        {
            Mom mom = new Mom();
            Dad dad = new Dad();
            Child child = new Child();

            mom.Eat += dad.Eat;
            mom.Eat += child.Eat;

            mom.Cook();

            Console.WriteLine("Press any key to continue........");
            Console.ReadKey(true);
        }
        public class Mom
        {
            public event Action Eat;
            public void Cook()
            {
                Console.WriteLine("妈妈：饭好了");
                Eat?.Invoke();
            }
        }
        public class Dad
        {
            public void Eat()
            {
                Console.WriteLine("爸爸：吃饭了。");
            }
        }
        public class Child
        {
            public void Eat()
            {
                Console.WriteLine("孩子：打完这局再吃。");
            }
        }
    }
}
