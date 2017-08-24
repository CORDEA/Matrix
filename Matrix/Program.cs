using System;
using System.Windows.Forms;

namespace Matrix
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var animator = new Animator();
            animator.Start();
            Application.Run();
        }
    }
}
