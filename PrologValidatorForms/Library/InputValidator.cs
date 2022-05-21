﻿using System;
using System.IO;
using System.Text.RegularExpressions;

namespace PrologValidatorForms
{
    static class InputValidator
    {
        private static Regex studentDirectoryPattern = new Regex("^K[1-9]_[0-9]{6}_[1-9]$");
        private static Regex taskNamePattern = new Regex("^[z|Z]ad[0-9]{1,2}$");
        private static Regex groupDirectoryPattern= new Regex("^G[1-9]_[0-9]{4}$");
        
        // GK_XXXX
        // K - numer grupy
        // XXXX - rocznik
        
        public static bool ValidateDirectory(string path)
        {
            if (path.Length < 11)
                return false;
            string[] dirs = path.Split(Path.DirectorySeparatorChar);
            return studentDirectoryPattern.IsMatch(dirs[dirs.Length - 1]);
        }

        // 
        // C:\directory\directory\K1_1111_1

        public static bool ValidateGroup(string path)
        {
            if (path.Length < 7)
                return false;
            string[] dirs = path.Split(Path.DirectorySeparatorChar);
            return groupDirectoryPattern.IsMatch(dirs[dirs.Length - 1]);
        }

        public static bool ValidateTaskName(string name)
        {
            return taskNamePattern.IsMatch(name);
        }
    }
}