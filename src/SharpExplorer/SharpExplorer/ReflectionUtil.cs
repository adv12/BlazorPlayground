using System;
using System.Collections.Generic;
using System.Reflection;

namespace SharpExplorer
{
    public class ReflectionUtil
    {
        private static SortedList<string, Type> _allTypes;
        public static SortedList<string, Type> AllTypes
        {
            get
            {
                if (_allTypes == null)
                {
                    _allTypes = new SortedList<string, Type>();
                    foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                    {
                        foreach (Type type in assembly.GetTypes())
                        {
                            if (type.IsPublic)
                            {
                                _allTypes[type.FullName] = type;
                            }
                        }
                    }
                }
                return _allTypes;
            }
        }

    }
}
