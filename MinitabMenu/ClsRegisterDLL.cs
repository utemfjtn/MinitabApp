using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace MinitabMenu {
    public class ClsRegisterDLL {
        public static bool RegisterDll(string fileName) {
            bool result = true;
            try {
                string dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);//获得要注册的dll的物理路径
                if(!File.Exists(dllPath)) {
                    MessageBox.Show(string.Format("“{0}”目录下无“" + fileName + "”文件！", AppDomain.CurrentDomain.BaseDirectory));
                    return false;
                }
                //拼接命令参数
                string startArgs = string.Format("/s \"{0}\"", dllPath);

                Process p = new Process();//创建一个新进程，以执行注册动作
                p.StartInfo.FileName = "regsvr32";
                p.StartInfo.Arguments = startArgs;

                //以管理员权限注册dll文件
                WindowsIdentity winIdentity = WindowsIdentity.GetCurrent(); //引用命名空间 System.Security.Principal
                WindowsPrincipal winPrincipal = new WindowsPrincipal(winIdentity);
                if(!winPrincipal.IsInRole(WindowsBuiltInRole.Administrator)) {
                    p.StartInfo.Verb = "runas";//管理员权限运行
                }
                p.Start();
                p.WaitForExit();
                p.Close();
                p.Dispose();
            } catch(Exception ex) {
                MessageBox.Show(ex.ToString());
                result = false;　　　　　　　　  //记录日志，抛出异常
            }

            return result;
        }
    }
}
