﻿/*
*       Copyright 2020-2021. Huawei. Technologies Co., Ltd. All rights reserved.

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
using Huawei.Hms.Analytics;

namespace HiAnalyticsXamarinAndroidDemo
{
    [Activity(Label = "OrderActivity")]
    public class OrderActivity : Activity
    {
        FrameLayout frameLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_order);

            frameLayout = FindViewById<FrameLayout>(Resource.Id.fragment_frame);


            Fragment fragment = new OrderFragment();
            FragmentManager.BeginTransaction().Replace(frameLayout.Id, fragment, fragment.Class.SimpleName).Commit();
        }
    }
}