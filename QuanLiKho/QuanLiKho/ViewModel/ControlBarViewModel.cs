﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLiKho.ViewModel
{
    public class ControlBarViewModel : BaseViewModel
    {
        /// <summary>
        ///  To process some commands to use for ControlBarUC
        /// </summary>
        /// 
       
        #region commands
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MaximizeWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand MouseMoveWindowCommand { get; set; }

        #endregion

        public ControlBarViewModel()
        {
            // Command Closing Window
            CloseWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; },
                (p) =>
            {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                if (w != null)
                {
                    w.Close();
                }
            }
                );

            // Command Maximize Window
            MaximizeWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; },
                (p) =>
                {
                    FrameworkElement window = GetWindowParent(p);
                    var w = window as Window;
                    if (w != null)
                    {
                        if (w.WindowState != WindowState.Maximized)
                            w.WindowState = WindowState.Maximized;
                        else
                            w.WindowState = WindowState.Normal;  
                    }
                }
                );

            // Command Miximize Window
            MinimizeWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; },
                (p) =>
                {
                    FrameworkElement window = GetWindowParent(p);
                    var w = window as Window;
                    if (w != null)
                    {
                        if (w.WindowState != WindowState.Minimized)
                            w.WindowState = WindowState.Minimized;
                        else
                            w.WindowState = WindowState.Maximized;
                    }
                }
                );

            // Command Move Window
            MouseMoveWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; },
                (p) =>
                {
                    FrameworkElement window = GetWindowParent(p);
                    var w = window as Window;
                    if (w != null)
                    {
                        w.DragMove();
                    }
                }
                );

        }

        FrameworkElement GetWindowParent(UserControl p)
        {
            FrameworkElement parent = p;
            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }
            return parent;
        }
    }
}