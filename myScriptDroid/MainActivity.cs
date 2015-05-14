using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Android.OS;

using Myscript.Maw;
//using com.myscript.certificate.MyCertificate;
//using com.myscript.atk.maw.MathWidgetApi;
//using com.myscript.atk.maw.MathWidgetApi.RecognitionBeautification;


//MathWidgetApi.OnConfigureListener, MathWidgetApi.OnRecognitionListener,
//MathWidgetApi.OnGestureListener, MathWidgetApi.OnWritingListener,
//MathWidgetApi.OnTimeoutListener, MathWidgetApi.OnSolvingListener,
//MathWidgetApi.OnUndoRedoListener
using System.Text.RegularExpressions;

namespace myScriptDroid
{
	[Activity (Label = "myScriptDroid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity,
	IMathWidgetApiOnConfigureListener,IMathWidgetApiOnRecognitionListener,
	IMathWidgetApiOnGestureListener,IMathWidgetApiOnWritingListener,
	IMathWidgetApiOnTimeoutListener,IMathWidgetApiOnSolvingListener,
	IMathWidgetApiOnUndoRedoListener
	{
		private IMathWidgetApi mWidget;
		private static readonly String MathQuestionHtmlLocation = "file:///android_asset/MathQuestion.html";
		WebView objWebViewQuestion;
		private Button btnClickMe;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.activity_main);

			var webView = FindViewById<WebView> (Resource.Id.webViewQuestion);
			webView.Settings.JavaScriptEnabled = true;

		
		}


		private class HybridWebViewClient : WebViewClient
		{
			public override bool ShouldOverrideUrlLoading (WebView webView, string url)
			{

				// If the URL is not our own custom scheme, just let the webView load the URL as usual
				var scheme = "hybrid:";

				if (!url.StartsWith (scheme))
					return false;

				// This handler will treat everything between the protocol and "?"
				// as the method name.  The querystring has all of the parameters.
				var resources = url.Substring (scheme.Length).Split ('?');
				var method = resources [0];
				var parameters = System.Web.HttpUtility.ParseQueryString (resources [1]);

				if (method == "UpdateLabel") {
					var textbox = parameters ["textbox"];

					// Add some text to our string here so that we know something
					// happened on the native part of the round trip.
					var prepended = string.Format ("C# says: {0}", textbox);

					// Build some javascript using the C#-modified result
					var js = string.Format ("SetLabelText('{0}');", prepended);

					webView.LoadUrl ("javascript:" + js);
				}

				return true;
			}
		}

		public void OnConfigurationBegin ()
		{

		}

		public void OnConfigurationEnd (bool p0)
		{

		}

		public void OnEraseGesture (bool p0)
		{

		}

		public void OnWritingBegin ()
		{

		}

		public void OnWritingEnd ()
		{

		}

		public void OnRecognitionTimeout ()
		{

		}
		public void OnUsingAngleUnitChanged ()
		{

		}
		public void OnUndoRedoStateChanged ()
		{

		}
		public void OnRecognitionBegin ()
		{

		}
		public void OnRecognitionEnd ()
		{

		}
		public void OnUsingAngleUnitChanged (bool p0)
		{

		}
	}
}

