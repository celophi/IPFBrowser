﻿// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace IPFBrowser
{
	public static class ControlHelper
	{
		[DllImport("user32.dll", EntryPoint = "SendMessageA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
		private const int WM_SETREDRAW = 0xB;

		public static void SuspendDrawing(this Control target)
		{
			SendMessage(target.Handle, WM_SETREDRAW, 0, 0);
		}

		public static void ResumeDrawing(this Control target) { ResumeDrawing(target, true); }
		public static void ResumeDrawing(this Control target, bool redraw)
		{
			SendMessage(target.Handle, WM_SETREDRAW, 1, 0);

			if (redraw)
			{
				target.Refresh();
			}
		}
	}
}
