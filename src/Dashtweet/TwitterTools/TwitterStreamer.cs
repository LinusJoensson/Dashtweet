using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Streaming;

namespace Dashtwett.TwitterTools
{
    public enum StreamingConditions
    {
        AllConditions = 1,
        AnyCondition = 2
    }

    //TODO : Multiton pattern
    public class TwitterStreamer
    {
        public static IFilteredStream stream;
        public static TwitterCredentials credentials;
        public static bool IsMining { get; private set; }
        public static bool IsBroadcasting { get; private set; }

        static TwitterStreamer()
        {
            if (credentials != null)
            {
                lock (stream)
                {
                    stream = Stream.CreateFilteredStream(credentials);
                }
            }
        }

        public static void AddTracks(string[] tracks)
        {
            foreach (var track in tracks)
                stream.AddTrack(track);
        }

        public static void RemoveAllTracks()
        {
            stream.ClearTracks();
        }

        public static void ClearStreamer()
        {
            stream.ClearCustomQueryParameters();
            stream.ClearFollows();
            stream.ClearLocations();
            stream.ClearTracks();
            stream.ClearTweetLanguageFilters();
        }

        public static void AddSocketBroadcast()
        {
            stream.MatchingTweetReceived += OnRecieve_BroadcastData;
            IsBroadcasting = true;
        }

        public static void RemoveSocketBroadcast()
        {
            stream.MatchingTweetReceived -= OnRecieve_BroadcastData;
            IsBroadcasting = false;
        }

        public static void AddDataMining()
        {
            stream.MatchingTweetReceived += OnRecieve_StoreData;
            IsMining = true;
        }

        public static void RemoveDataMining()
        {
            stream.MatchingTweetReceived -= OnRecieve_StoreData;
            IsMining = false;
        }

        public static void StartStream(StreamingConditions conditions = StreamingConditions.AllConditions)
        {
            if (conditions == StreamingConditions.AllConditions)
                stream.StartStreamMatchingAllConditions();

            else if (conditions == StreamingConditions.AnyCondition)
                stream.StartStreamMatchingAnyCondition();
        }

        public static void StopStream()
        {
            stream.StopStream();
        }

        // EVENTS BROADCASTERS //

        public static void OnRecieve_BroadcastData(object sender, object args)
        {

        }

        public static void OnRecieve_StoreData(object sender, object args)
        {

        }
    }
}
