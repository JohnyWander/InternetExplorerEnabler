// This program will stop Microsoft edge from starting when you want to use 
// by revoking run access from all user object
// It must be run with admin rights
using System.Security.AccessControl;
using System.Security.Principal;

namespace IExplorerEnabler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("C:\\Program Files (x86)\\Microsoft\\Edge\\Application","*.*",SearchOption.AllDirectories);
            IEnumerable<string> ie_to_edge_files = files.Where(x => x.Contains("ie_to_edge"));

          // NTAccount acc = new NTAccount(Environment.UserDomainName,"Administrator");
       
            foreach(string ie_file_to_break in ie_to_edge_files)
            {
                Console.WriteLine($"Breaking {ie_file_to_break}...");
                FileInfo finfo = new FileInfo(ie_file_to_break);
                FileSecurity newSecurity = finfo.GetAccessControl();

               // newSecurity.SetOwner(new SecurityIdentifier(WellKnownSidType.WinSystemLabelSid,null));
               //   newSecurity.SetOwner(new NTAccount(WindowsIdentity.GetCurrent().Name));
                
                FileSystemAccessRule ForbidAll = new FileSystemAccessRule
                    (
                    new SecurityIdentifier(WellKnownSidType.WorldSid,null),
                    FileSystemRights.ExecuteFile,
                    AccessControlType.Deny
                    );             
                newSecurity.AddAccessRule(ForbidAll);         
                finfo.SetAccessControl(newSecurity);
            }

            Console.WriteLine("Completed... IExplorer should work normally now, press any key to close");
            Console.ReadKey();
        }
    }
}