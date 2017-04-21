using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace Dropshot.Patcher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Too lazy to make a config file, just gonna use the stdout/stdin for now.
            Console.Write("Host name: ");
            var hostName = Console.ReadLine();

            Console.Write("HTTPS (Y/N): ");
            var key = Console.ReadKey();
            var https = key.Key == ConsoleKey.Y ? true : false;

            Console.WriteLine();

            Console.WriteLine("Patching 'Assembly-CSharp.dll'...");
            PatchAssemblyCSharp("Assembly-CSharp.dll", hostName, https);

            Console.WriteLine("Patching 'Assembly-CSharp-firstpass.dll'...");
            PatchAssemblyCSharpFirstpass("Assembly-CSharp-firstpass.dll");
        }

        public static void PatchAssemblyCSharp(string path, string hostName, bool https)
        {
            var lib = ModuleDefMD.Load(path);
            var appDataMgr = lib.Find("ApplicationDataManager", true);
            var cctor = appDataMgr.FindStaticConstructor();

            var strCount = 0;
            foreach (var il in cctor.Body.Instructions)
            {
                if (il.OpCode == OpCodes.Ldstr)
                {
                    var str = (string)il.Operand;

                    if (strCount == 0)
                    {
                        var ws = https ? "https://" + hostName + "/2.0/" : "http://" + hostName + "/2.0/";
                        il.Operand = ws;
                    }
                    else if (strCount == 1)
                    {
                        var ws = https ? "https://" + hostName + "/images/" : "http://" + hostName + "/images/";
                        il.Operand = "http://localhost/images/";
                        break;
                    }

                    strCount++;
                }
            }

            lib.Write("Assembly-CSharp-patched.dll");
        }

        public static void PatchAssemblyCSharpFirstpass(string path)
        {
            var lib = ModuleDefMD.Load(path);
            var defs = lib.GetTypes();
            foreach (var def in defs)
            {
                // Could have done better and more strict searches but am
                // a lazy cunt, gonna do for now.
                if (def.Name.EndsWith("WebServiceClient"))
                {
                    foreach (var method in def.Methods)
                    {
                        foreach (var il in method.Body.Instructions)
                        {
                            if (il.OpCode == OpCodes.Ldstr)
                            {
                                var str = (string)il.Operand;
                                if (str.StartsWith("UberStrike.DataCenter.WebService.CWS.") && str.EndsWith("Contract.svc"))
                                {
                                    str = str.Replace("UberStrike.DataCenter.WebService.CWS.", string.Empty).Replace("Contract.svc", string.Empty);
                                    il.Operand = str;
                                }
                            }
                        }
                    }
                }
            }

            lib.Write("Assembly-CSharp-firstpass-patched.dll");
        }
    }
}
