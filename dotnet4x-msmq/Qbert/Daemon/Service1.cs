﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Daemon
{
    public partial class Service1 : ServiceBase
    {
        private static Thread serviceThread;
        private static ServiceRunner runner;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            runner = new ServiceRunner();
            serviceThread = new Thread(new ThreadStart(runner.Run));
            serviceThread.Start();
        }

        protected override void OnStop()
        {
            runner.Stop();
            serviceThread.Abort();
            serviceThread.Join();
        }
    }
}
