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

using System;
using Huawei.Tts.Voicesynthesizer.Configuration;

namespace Huawei.Texttospeech.Frontend.Services.Verbalizers
{
    public abstract partial class AbstractTextVerbalizer
	{
		public Java.Lang.Object NumberMetaOf(string p0)
		{
			throw new NotImplementedException();
		}

		public string VerbalizeFloat(string p0, string p1, Java.Lang.Object p2)
		{
			throw new NotImplementedException();
		}
	}
}

namespace Huawei.Texttospeech.Frontend.Services.Verbalizers.Number2words
{
    public abstract partial class AbstractNumberToWords
	{
		public string Convert(long p0, Java.Lang.Object p1)
		{
			throw new NotImplementedException();
		}
	}
}

namespace Huawei.Tts.Voicesynthesizer.Factories.Configuration
{
    public partial class EnglishFrontendConfigurationFactory
	{
		public override TextPreprocessorConfiguration CreateConfiguration()
		{
			throw new NotImplementedException();
		}
	}
}