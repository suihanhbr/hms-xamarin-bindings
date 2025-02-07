﻿/*
       Copyright 2020-2021. Huawei Technologies Co., Ltd. All rights reserved.

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

using Android.Content;
using Android.Runtime;
using AndroidActivity = Android.App.Activity;
using Huawei.Hms.Support.Account.Result;
using Huawei.Hms.Support.Hwid.Result;
using System;
using System.Threading.Tasks;
using HuaweiTask = Huawei.Hmf.Tasks.Task;


namespace Huawei.Hms.Support.Account
{
    public partial class AccountAuthManager
    {
        //async Task<NAME> MyMethod(params) => await MyNativeMethod(params).CastTask<NAME>();
        public static async Task<AuthAccount> ParseAuthResultFromIntentAsync(Intent data) =>
            await ParseAuthResultFromIntent(data).CastTask<AuthAccount>();
    }
}

namespace Huawei.Hms.Support.Account.Service
{
    public partial interface IAccountAuthService
    {
        //async Task<NAME> MyMethod(params) => await MyNativeMethod(params).CastTask<NAME>();
        public async Task<AuthAccount> SilentSignInAsync() =>
                   await SilentSignIn().CastTask<AuthAccount>();

        //async Task<NAME> MyMethod(params) => await MyNativeMethod(params).CastTask<NAME>();
        public async Task SignOutAsync() =>
                   await SignOut().CastTask();

        //async Task<NAME> MyMethod(params) => await MyNativeMethod(params).CastTask<NAME>();
        public async Task CancelAuthorizationAsync() =>
                   await CancelAuthorization().CastTask();

        //async Task MyMethod(params) => await MyNativeMethod.CastTask<NAME>();
        public async Task<AccountIcon> GetChannelAsync() => await Channel.CastTask<AccountIcon>();
    }
}


namespace Huawei.Hms.Support.Hwid
{
    public partial class HuaweiIdAuthManager
    {
        //async Task<NAME> MyMethod(params) => await MyNativeMethod(params).CastTask<NAME>();
        public async Task<AuthHuaweiId> ParseAuthResultFromIntentAsync(Intent data) =>
            await ParseAuthResultFromIntent(data).CastTask<AuthHuaweiId>();
    }
}

namespace Huawei.Hms.Support.Hwid.Service
{
    public partial interface IHuaweiIdAuthService
    {
        //async Task<NAME> MyMethod(params) => await MyNativeMethod(params).CastTask<NAME>();
        public async Task<AuthHuaweiId> SilentSignInAsync() =>
                   await SilentSignIn().CastTask<AuthHuaweiId>();

        //async Task<NAME> MyMethod(params) => await MyNativeMethod(params).CastTask<NAME>();
        public async Task SignOutAsync() =>
                   await SignOut().CastTask();

        //async Task<NAME> MyMethod(params) => await MyNativeMethod(params).CastTask<NAME>();
        public async Task CancelAuthorizationAsync() =>
                   await CancelAuthorization().CastTask();
    }
}

namespace Huawei.Hms.Support.Sms
{
    public partial class ReadSmsManager
    {
        //async Task<NAME> MyMethod(params) => await MyNativeMethod(params).CastTask<NAME>();
        public static async Task StartAsync(AndroidActivity activity) =>
                   await Start(activity).CastTask();

        //async Task<NAME> MyMethod(params) => await MyNativeMethod(params).CastTask<NAME>();
        public static async Task StartAsync(Context context) =>
                   await Start(context).CastTask();

        //async Task<NAME> MyMethod(params) => await MyNativeMethod(params).CastTask<NAME>();
        public static async Task StartConsentAsync(AndroidActivity activity, string phoneNumber) =>
                   await StartConsent(activity, phoneNumber).CastTask();
    }
}


namespace Huawei.Hms.Support
{
    #region Task Extensions
    /// <summary>
    /// Task Extension Class for convert HuaweiTask to System.Threading.Task
    /// </summary>
    internal static class HuaweiTaskExtensions
    {
        /// <summary>
        /// Convert HuaweiTask to System.Threading.Task without return type
        /// </summary>
        /// <param name="HuaweiTask">Huawei.Hmf.Tasks.Task</param>
        /// <returns>System.Threading.Task</returns>
        public static Task CastTask(this HuaweiTask HuaweiTask)
        {
            var tcs = new TaskCompletionSource<bool>();

            HuaweiTask.AddOnCompleteListener(new HuaweiTaskCompleteListener(
                t =>
                {
                    if (t.Exception == null)
                        tcs.TrySetResult(false);
                    else
                        tcs.TrySetException(t.Exception);
                }
            ));

            return tcs.Task;
        }


        /// <summary>
        /// Convert HuaweiTask to System.Threading.Task with Generic return type
        /// </summary>
        /// <typeparam name="TResult">Return type,a Java object</typeparam>
        /// <param name="HuaweiTask">Huawei.Hmf.Tasks.Task class</param>
        /// <returns>System.Threading.Task with wrapped a generic type</returns>
        public static Task<TResult> CastTask<TResult>(this HuaweiTask HuaweiTask) where TResult : Java.Lang.Object
        {
            var tcs = new TaskCompletionSource<TResult>();

            HuaweiTask.AddOnCompleteListener(new HuaweiTaskCompleteListener(
                t =>
                {
                    if (t.Exception == null)
                        tcs.TrySetResult(t.Result.JavaCast<TResult>());
                    else
                        tcs.TrySetException(t.Exception);
                }));

            return tcs.Task;
        }


        /// <summary>
        /// Modified OnCompleteListener (from Huawei.Hmf.Tasks.Task)
        /// Invoke the given action
        /// </summary>
        class HuaweiTaskCompleteListener : Java.Lang.Object, Huawei.Hmf.Tasks.IOnCompleteListener
        {
            public HuaweiTaskCompleteListener(Action<HuaweiTask> onComplete)
                => OnCompleteHandler = onComplete;

            public Action<HuaweiTask> OnCompleteHandler { get; }

            public void OnComplete(HuaweiTask task)
                => OnCompleteHandler?.Invoke(task);
        }
    }
    #endregion
}