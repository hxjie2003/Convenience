using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Reflection;
using ETong.Controls;
using System.Runtime.Caching;
using System.ComponentModel;
using System.Windows.Navigation;

namespace ETong.Controls.WPF
{
    public static class NavigateHelper
    {
        private static ObjectCache _cache = MemoryCache.Default;
        public static ObjectCache Cache
        {
            get { return _cache; }
        }
        private static Frame _frame;
        public static Frame Frame
        {
            get
            {
                if (_frame == null)
                {
                    throw new NullReferenceException();
                }
                return _frame;
            }
            set
            {
                _frame = value;
            }
        }
        public static Page GetPage(string typename)
        {
            try
            {
                if (string.IsNullOrEmpty(typename))
                {
                    return null;
                }
                //var page = _cache[typename] as Page;
                Page page = null;
                if (page == null)
                {
                    var typestring = typename.Split(';');
                    string dllName = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\" + typestring[0] + ".dll";
                    string className = typestring[1].Trim();
                    AssemblyName assemblyName = AssemblyName.GetAssemblyName(dllName);
                    if (assemblyName == null)
                    {
                        var assembly = Assembly.LoadFile(dllName);
                        assemblyName = new AssemblyName(assembly.FullName);
                        assembly = AppDomain.CurrentDomain.Load(assemblyName);
                    }

                    var objHandle = AppDomain.CurrentDomain.CreateInstance(assemblyName.FullName, className);
                    if (objHandle != null)
                    {
                        page = objHandle.Unwrap() as Page;
                    }                    


                    //CacheItemPolicy policy = new CacheItemPolicy();
                    //policy.AbsoluteExpiration = DateTimeOffset.Now.AddHours(0.5);
                    //_cache.Add(typename, page, policy);
                }
                return page;
            }
            catch
            {
                return null;
            }
        }

        public static Window GetWindow(string typename)
        {
            try
            {
                if (string.IsNullOrEmpty(typename))
                {
                    return null;
                }

                Window wind = null;

                if (wind == null)
                {
                    var typestring = typename.Split(';');

                    string dllName = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\" + typestring[0] + ".dll";

                    string className = typestring[1].Trim();

                    AssemblyName assemblyName = AssemblyName.GetAssemblyName(dllName);

                    if (assemblyName == null)
                    {
                        var assembly = Assembly.LoadFile(dllName);

                        assemblyName = new AssemblyName(assembly.FullName);

                        assembly = AppDomain.CurrentDomain.Load(assemblyName);
                    }

                    var objHandle = AppDomain.CurrentDomain.CreateInstance(assemblyName.FullName, className);

                    if (objHandle != null)
                    {
                        wind = objHandle.Unwrap() as Window;
                    }
                }

                return wind;
            }
            catch
            {
                return null;
            }
        }

        //public static Window GetWindow(string typename)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(typename))
        //        {
        //            return null;
        //        }
        //        //var window = _cache[typename] as Window;
        //        Window window = null;
        //        if (window == null)
        //        {
        //            var typestring = typename.Split(';');
        //            var assembly = Assembly.LoadFile(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\" + typestring[0] + ".dll");
        //            window = assembly.CreateInstance(typestring[1]) as Window;
        //            //CacheItemPolicy policy = new CacheItemPolicy();
        //            //policy.AbsoluteExpiration = DateTimeOffset.Now.AddHours(0.5);
        //            //_cache.Add(typename, window, policy);
        //        }
        //        return window;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        public static void Show(string typeName, IDictionary<string, string> querypara, bool notAskLeave = false)
        {
            try
            {
                //var page = Cache[typeName] as Page;
                Page page = null;
                if (page == null)
                {
                    page = GetPage(typeName);
                }
                if (page != null)
                {
                    Navigate(page, querypara, notAskLeave);
                }
                else
                {
                    var window = Cache[typeName] as Window;
                    if (page == null)
                    {
                        window = GetWindow(typeName);
                    }
                    if (window != null)
                    {
                        window.Tag = querypara;
                        window.ShowDialog();
                    }
                }
            }
            catch { }
        }
        public static void Show(string typeName, object querypara, bool notAskLeave = false)
        {
            try
            {
                //var page = Cache[typeName] as Page;
                Page page = null;
                if (page == null)
                {
                    page = GetPage(typeName);
                }
                if (page != null)
                {
                    Navigate(page, querypara, notAskLeave);
                }
                else
                {
                    var window = Cache[typeName] as Window;
                    if (page == null)
                    {
                        window = GetWindow(typeName);
                    }
                    if (window != null)
                    {
                        window.Tag = querypara;
                        window.Show();
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// 缓存页面的导航
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="querypara"></param>
        /// <param name="notAskLeave"></param>
        public static void ShowCache(string typeName, object querypara, bool notAskLeave = false)
        {
            try
            {
                Page page = Cache[typeName] as Page;

                if (page == null)
                {
                    page = GetPage(typeName);

                    if (page != null)
                    {
                        CacheItemPolicy policy = new CacheItemPolicy();
                        policy.AbsoluteExpiration = DateTimeOffset.Now.AddHours(0.5);
                        _cache.Add(typeName, page, policy);
                    }
                }

                if (page != null)
                {
                    Navigate(page, querypara, notAskLeave);
                }
                else
                {
                    var window = Cache[typeName] as Window;

                    if (page == null)
                    {
                        window = GetWindow(typeName);

                        if (window != null)
                        {
                            CacheItemPolicy policy = new CacheItemPolicy();
                            policy.AbsoluteExpiration = DateTimeOffset.Now.AddHours(0.5);
                            _cache.Add(typeName, window, policy);
                        }
                    }

                    if (window != null)
                    {
                        window.Tag = querypara;
                        window.Show();
                    }
                }
            }
            catch { }
        }

        public static void Show(FrameworkElement content, IDictionary<string, string> querypara, bool notAskLeave = false)
        {
            try
            {
                if (content is Window)
                {
                    content.Tag = querypara;
                    (content as Window).Show();
                }
                Navigate(content, querypara, notAskLeave);
            }
            catch { }
        }
        public static void Show(FrameworkElement content, object querypara, bool notAskLeave = false)
        {
            try
            {
                if (content is Window)
                {
                    content.Tag = querypara;
                    (content as Window).Show();
                }
                Navigate(content, querypara, notAskLeave);
            }
            catch { }
        }
        internal static void Navigate(FrameworkElement content, object para, bool notAskLeave)
        {
            try
            {
                Page page = content as Page;
                if (page != null)
                {
                    INavigation p = Frame.Content as INavigation;
                    CancelEventArgs m = new CancelEventArgs(false);
                    if (p != null && !notAskLeave)
                    {
                        p.OnNavigateFrom(m);
                    }
                    if (!m.Cancel)
                    {
                        Frame.Navigate(content, para);
                    }
                }
            }
            catch { }
        }
        public static void GoBack(bool notAskLeave = false)
        {
            try
            {
                INavigation page = Frame.Content as INavigation;
                CancelEventArgs m = new CancelEventArgs();
                if (page != null && !notAskLeave)
                {
                    page.OnNavigateFrom(m);
                }
                if (!m.Cancel)
                {
                    Frame.GoBack();
                }
            }
            catch { }
        }
        public static void GoForward(bool notAskLeave = false)
        {
            try
            {
                INavigation page = Frame.Content as INavigation;
                CancelEventArgs m = new CancelEventArgs();
                if (page != null && !notAskLeave)
                {
                    page.OnNavigateFrom(m);
                }
                if (!m.Cancel)
                {
                    Frame.GoForward();
                }
            }
            catch { }
        }
        public static void GoBack(this NavigationService navigateService, bool notAskLeave = false)
        {
            try
            {
                INavigation page = navigateService.Content as INavigation;
                CancelEventArgs m = new CancelEventArgs();
                if (page != null && !notAskLeave)
                {
                    page.OnNavigateFrom(m);
                }
                if (!m.Cancel)
                {
                    navigateService.GoBack();
                }
            }
            catch { }
        }
        public static void GoForward(this NavigationService navigateService, bool notAskLeave = false)
        {
            try
            {
                INavigation page = navigateService.Content as INavigation;
                CancelEventArgs m = new CancelEventArgs();
                if (page != null && !notAskLeave)
                {
                    page.OnNavigateFrom(m);
                }
                if (!m.Cancel)
                {
                    navigateService.GoForward();
                }
            }
            catch { }
        }
    }
}
