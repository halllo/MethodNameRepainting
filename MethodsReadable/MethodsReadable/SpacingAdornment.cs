//***************************************************************************
//
//    Copyright (c) Microsoft Corporation. All rights reserved.
//    This code is licensed under the Visual Studio SDK license terms.
//    THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
//    ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
//    IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
//    PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//***************************************************************************

using System.Windows.Controls;
using System.Windows.Media;

namespace MethodsReadable
{
	internal sealed class SpacingAdornment : TextBlock
	{
		internal SpacingAdornment(SpacingTag spacingTag)
		{
			this.Width = 5;
			this.Height = 5;
			this.Text = string.Empty;
			this.Background = Brushes.Transparent;
		}

		internal void Update(SpacingTag spacingTag)
		{
		}
	}
}
