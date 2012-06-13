// 
//  Copyright 2012
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using MonoTouch.UIKit;

namespace UICalendar
{
	public interface IEventsSource
	{
		CalendarEvent[] GetEvents(DateTime @from, DateTime to);
	}

	public class CalendarEvent
	{
		public string Title { get; set; }

		public string Description { get; set; }

		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		public bool AllDay { get; set; }

		public string Location { get; set; }

		public object CustomObject { get; set; }

		public Action<UITableViewCell> CustomAction { get; set; }

		public override string ToString()
		{
			return "starts " + StartDate.ToString("s");
		}
	}
}
