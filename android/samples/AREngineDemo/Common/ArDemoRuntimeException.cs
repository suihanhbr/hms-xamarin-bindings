﻿/*
*       Copyright 2020-2021 Huawei Technologies Co., Ltd. All rights reserved.

        Licensed under the Apache License, Version 2.0 (the "License");
        you may not use this file except in compliance with the License.
        You may obtain a copy of the License at

        http://www.apache.org/licenses/LICENSE-2.0

        Unless required by applicable law or agreed to in writing, software
        distributed under the License is distributed on an "AS IS" BASIS,
        WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
        See the License for the specific language governing permissions and
        limitations under the License.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace XamarinAREngineDemo.Common
{
    /// <summary>
    /// The exception class when the AR sample code runs. Sometimes,
    /// you need to capture exceptions to keep your program running.
    /// </summary>
    public class ArDemoRuntimeException : RuntimeException
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        public ArDemoRuntimeException() : base()
        {
           
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">message.</param>
        public ArDemoRuntimeException(string message) : base((string)message)
        {
            
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="cause">cause</param>
        public ArDemoRuntimeException(string message, Throwable cause) : base(message,cause)
        {

        }
    }
}