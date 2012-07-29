using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch;
// 
//  Copyright 2011  Clancey
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
using System.Drawing;


namespace UICalendar
{

	[Register("RotatingViewController")]
	public abstract partial class RotatingViewController : UIViewController
	{
		//public NSObject notificationObserver;

		public RotatingViewController(IntPtr handle)
			: base(handle)
		{
			initialize();
		}

		[Export("initWithCoder:")]
		public RotatingViewController(NSCoder coder)
			: base(coder)
		{
			initialize();
		}

		public RotatingViewController(string nibName, NSBundle bundle)
			: base(nibName, bundle)
		{
			initialize();
		}

		public RotatingViewController()
			: base()
		{
			initialize();
		}

		private void initialize()
		{
		}

		public UIViewController LandscapeLeftViewController { get; set; }
		public UIViewController LandscapeRightViewController { get; set; }
		public UIViewController PortraitViewController { get; set; }
		public UIView PortraitView { get; set; }
		public UIView LandscapeLeftView { get; set; }
		public UIView LandscapeRightView { get; set; }
		public bool viewControllerVisible { get; set; }

		public override void ViewDidLoad()
		{
			//  SetView();
		}

		public override void ViewWillAppear(bool animated)
		{
			viewControllerVisible = true;
			SetView(InterfaceOrientation, 0.3);
		}

		public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
		{
			return toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown;
		}

		public abstract void SetupNavBar(UIInterfaceOrientation orientation);

		private void SetView(UIInterfaceOrientation interfaceOrientation, double duration)
		{
			UIView.BeginAnimations("test");
			UIView.SetAnimationDuration(duration);
			_removeAllViews();
			UIView view;
			switch (interfaceOrientation)
			{
				case UIInterfaceOrientation.Portrait:
					view = PortraitView;
					break;

				case UIInterfaceOrientation.LandscapeLeft:
					view = LandscapeLeftView;
					break;
				case UIInterfaceOrientation.LandscapeRight:
					view = LandscapeRightView;
					break;
				default:
					throw new NotImplementedException();
			}
			view.Frame = interfaceOrientation == UIInterfaceOrientation.Portrait ? new RectangleF(0, 0, 320, 480) : new RectangleF(0, 0, 480, 320);
			View.AddSubview(view);
			UIView.CommitAnimations();
			SetupNavBar(interfaceOrientation);
		}

		public override void WillRotate(UIInterfaceOrientation toInterfaceOrientation, double duration)
		{
			SetView(toInterfaceOrientation, duration);
		}

		private void _removeAllViews()
		{
			PortraitView.RemoveFromSuperview();
			LandscapeLeftView.RemoveFromSuperview();
			LandscapeRightView.RemoveFromSuperview();
		}

		public override void ViewDidDisappear(bool animated)
		{
			viewControllerVisible = false;
			base.ViewWillDisappear(animated);
		}
	}
}
