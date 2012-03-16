using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using Twitterizer;

namespace edu.syr.cse784.eskimodb.twitter
{
  public class twitter
  {

    OAuthTokens tokens = new OAuthTokens();
    public twitter()
    {
       tokens.AccessToken = "389134807-otoB6EnIHB12mRchWQSyLbvTxPzhXLkmdjWJyIV6";
       tokens.AccessTokenSecret = "38z9zh71UON1831IwWUxLvwaEf8Oxk4PHGXgt4zYg";
       tokens.ConsumerKey = "y3ZviWjwYLyfVAFomMOTA";
       tokens.ConsumerSecret = "yoyshFBh8PZ14tEPoOvotw7Af3lzT8qs1wv3NBooMgE";
    }
    public bool PostTweet(string tweet)
    {
      TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(tokens,tweet);

      if (tweetResponse.Result == RequestResult.Success)
      {
         return true;
      }
      else
      {
         return false;
      }
    }
  }
}
