using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using MMFood.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace MMFood.Service
{
    public static class SheetService
    {
        
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private const string SpreadsheetId = "1tLagRZBycZmlKWDvOjfVtPkMReTDflpY6NMAL7yr_dM";
        private const string GoogleCredentialsFileName = "credentials.json";
       
        /*
           Sheet1 - tab name in a spreadsheet
           A:B     - range of values we want to receive
        */
        private const string ReadRange = "Sheet1!A:B";

        public static Post[] GetData(SheetResponse apiresponse)
        {
            List<Post> posts = new List<Post>();
            var nonEmpty = apiresponse.Values.Where(x => x.Any());
            var rowNumber = 2;
            foreach(var valueList in nonEmpty)
            {
                posts.Add(MapRow(valueList, rowNumber));
                rowNumber++;
            }
            posts.Reverse();
            return posts.ToArray();
        }

        private static Post MapRow(IList<string> values, int rowNumber)
        {
            var post = new Post
            {
                RowNumber = rowNumber,
                Title = values[0],
                TeaserImage = !string.IsNullOrEmpty(values[1]) ? values[1] : string.Empty,
                Teaser = !string.IsNullOrEmpty(values[2]) ? values[2] : string.Empty
            };
            if (values.Count > 3)
            {
                post.Published = !string.IsNullOrEmpty(values[3]) ? values[3] : string.Empty;
                post.ArticleImage = !string.IsNullOrEmpty(values[4]) ? values[4] : string.Empty;
                post.Ingress = !string.IsNullOrEmpty(values[5]) ? values[5] : string.Empty;
                post.ContentBlocks = new List<string>();
                post.ContentBlocks.Add(!string.IsNullOrEmpty(values[6]) && values[6] != "null" ? values[6] : string.Empty);
                post.ContentBlocks.Add(!string.IsNullOrEmpty(values[7]) && values[7] != "null" ? values[7] : string.Empty);
                post.ContentBlocks.Add(!string.IsNullOrEmpty(values[8]) && values[8] != "null" ? values[8] : string.Empty);
            } 

            return post;
        }
    }
}
