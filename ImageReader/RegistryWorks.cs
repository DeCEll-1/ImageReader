using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageReader
{
    public class RegistryWorks
    {
        private static string MasterPath { get; set; } = @"SOFTWARE\Reader";
        public static void SetMasterPath(string path)
        {
            MasterPath = path;
        }

        /// <summary>
        /// Sets variable on registry
        /// </summary>
        /// <param name="loc"> The location to save the variable on</param>
        /// <param name="var"> The variable to save</param>
        public static void SetVariable(string loc, string var)
        {
            try
            {
                Registry.CurrentUser.CreateSubKey(MasterPath, RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue(loc, var);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened when saving the path to registry: \n" + ex.ToString());
            }
        }

        /// <summary>
        /// Gets variable from registry
        /// </summary>
        /// <param name="loc"> Location of the variable</param>
        /// <param name="varIfNull"> What to return if value doesnt exist</param>
        /// <returns></returns>
        public static string GetVariable(string loc, string varIfNull = "NULL")
        {
            try
            {
                return Registry.CurrentUser.CreateSubKey(MasterPath, RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue(loc, varIfNull).ToString();
            }
            catch (Exception ex)
            {
                return varIfNull;
            }
        }

        /// <summary>
        /// Gets variable from registry
        /// </summary>
        /// <param name="loc"> Location of the variable</param>
        /// <param name="varIfNull"> What to return if value doesnt exist</param>
        /// <returns></returns>
        public static int GetVariable(string loc, int varIfNull = -1)
        {
            try
            {
                return (int)Registry.CurrentUser.CreateSubKey(MasterPath, RegistryKeyPermissionCheck.ReadWriteSubTree).GetValue(loc, varIfNull);
            }
            catch (Exception ex)
            {
                return varIfNull;
            }
        }

    }
}
