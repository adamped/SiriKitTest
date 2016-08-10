using System;
using Foundation;
using Intents;
using ObjCRuntime;

namespace IntentTest
{
	public class IntentHandle: INExtension, IINSendMessageIntentHandling
	{
		public IntentHandle()
		{
		}

		public void HandleSendMessage(INSendMessageIntent intent, Action<INSendMessageIntentResponse> completion)
		{
			var userActivity = new NSUserActivity(activityType: "INSendMessageIntent");

			var response = new INSendMessageIntentResponse(code: .success, userActivity: userActivity);

			completion(response);
		}
		public override ResolveContent(INSendMessageIntent intent, Action<INStringResolutionResult> completion)
		{

			if (intent.Content != "")
			{
				completion(INStringResolutionResult.GetSuccess(intent.Content));
			}
			else {
				completion(INStringResolutionResult.NeedsValue);
			}
		}
	}
}
