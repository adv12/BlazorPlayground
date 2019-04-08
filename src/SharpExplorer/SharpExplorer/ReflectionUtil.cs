using System;
using System.Collections.Generic;
using System.Reflection;

namespace SharpExplorer
{
    public class ReflectionUtil
    {
        private static SortedList<string, Type> _allPublicTypes;
        private static SortedList<string, Type> _allPublicClasses;
        private static SortedList<string, Type> _allPublicClassesWithPublicConstructors;
        private static SortedList<string, Type> _allPublicClassesWithPublicStaticMethods;
        private static SortedList<string, Type> _allPublicClassesWithPublicStaticProperties;

        public static SortedList<string, Type> AllPublicTypes
        {
            get
            {
                if (_allPublicTypes == null)
                {
                    _allPublicTypes = new SortedList<string, Type>();
                    foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                    {
                        foreach (Type type in assembly.GetTypes())
                        {
                            if (type.IsPublic)
                            {
                                _allPublicTypes[type.FullName] = type;
                            }
                        }
                    }
                }
                return _allPublicTypes;
            }
        }

        public static SortedList<string, Type> AllPublicClasses
        {
            get
            {
                if (_allPublicClasses == null)
                {
                    _allPublicClasses = new SortedList<string, Type>();
                    foreach (Type type in AllPublicTypes.Values)
                    {
                        if (type.IsClass)
                        {
                            _allPublicClasses[type.FullName] = type;
                        }
                    }
                }
                return _allPublicClasses;
            }
        }

        public static SortedList<string, Type> AllPublicClassesWithPublicConstructors
        {
            get
            {
                if (_allPublicClassesWithPublicConstructors == null)
                {
                    _allPublicClassesWithPublicConstructors = new SortedList<string, Type>();
                    foreach (Type type in AllPublicClasses.Values)
                    {
                        if (type.GetConstructors().Length > 0)
                        {
                            _allPublicClassesWithPublicConstructors[type.FullName] = type;
                        }
                    }
                }
                return _allPublicClassesWithPublicConstructors;
            }
        }

        public static SortedList<string, Type> AllPublicClassesWithPublicStaticMethods
        {
            get
            {
                if (_allPublicClassesWithPublicStaticMethods == null)
                {
                    _allPublicClassesWithPublicStaticMethods = new SortedList<string, Type>();
                    foreach (Type type in AllPublicClasses.Values)
                    {
                        if (type.GetMethods(BindingFlags.Public | BindingFlags.Static).Length > 0)
                        {
                            _allPublicClassesWithPublicStaticMethods[type.FullName] = type;
                        }
                    }
                }
                return _allPublicClassesWithPublicStaticMethods;
            }
        }

        public static SortedList<string, Type> AllPublicClassesWithPublicStaticProperties
        {
            get
            {
                if (_allPublicClassesWithPublicStaticProperties == null)
                {
                    _allPublicClassesWithPublicStaticProperties = new SortedList<string, Type>();
                    foreach (Type type in AllPublicClasses.Values)
                    {
                        if (type.GetProperties(BindingFlags.Public | BindingFlags.Static).Length > 0)
                        {
                            _allPublicClassesWithPublicStaticProperties[type.FullName] = type;
                        }
                    }
                }
                return _allPublicClassesWithPublicStaticProperties;
            }
        }

    }
}
