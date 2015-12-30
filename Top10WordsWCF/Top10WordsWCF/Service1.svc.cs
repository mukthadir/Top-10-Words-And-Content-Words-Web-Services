using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HtmlAgilityPack;

namespace Top10WordsWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public string[] Top10Words(String url)
        {
            // Using the service at ASU repository to get the text out of the given web page
            ServiceReferenceWebContent.ServiceClient webClient = new ServiceReferenceWebContent.ServiceClient();
            String htmlString = webClient.GetWebContent(url);

            // Using HtmlAgilityPack to parse the obtained string from the above service.
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(htmlString);

            // tempArray would save all the parsed sentences and words after parsing them from the htmlString returned by above service.
            String[] tempArray = new String[100000];

            // parsedWordsArray contains all the words after splitting all the sentences to get individual words.
            String[] parsedWordsArray = new String[100000];
            int line = 0;
            int element = 0;

            // Using the enumerator to iterate through all the nodes and filter what is not required.
            // Here, we are using only those nodes which have texts and also we are removing the script and style nodes/tags
            // as they do not form the body of the document and we are only interested in real words appearing in the website
            IEnumerable<HtmlNode> nodes = htmlDocument.DocumentNode.Descendants().Where(node =>
                node.NodeType == HtmlNodeType.Text &&
                node.ParentNode.Name != "script" &&
                node.ParentNode.Name != "style");

            // saving each sentence obtained after parsing into tempArray
            foreach (var node in nodes)
            {
                if (!node.HasChildNodes)
                {
                    string text = node.InnerText;
                    tempArray[line++] = text.Trim();
                }
            }

            // checking/removing tempArray for any empty/null element 
            tempArray = tempArray.Where(eachLine => !string.IsNullOrEmpty(eachLine)).ToArray();

            // Finally saving all the individual words into a array after removing any comma, stop etc. from obtained sentences.
            for (int i = 0; i < tempArray.Length; i++)
            {
                // we are selecting only whitespaces, letters and digits from the whole sentences here and removing everything else
                tempArray[i] = new string((from characters in tempArray[i]
                                           where char.IsWhiteSpace(characters) || char.IsLetterOrDigit(characters)
                                           select characters).ToArray());

                // splitting the string to obtain all the words from the sentence.
                String[] splitter = tempArray[i].Split(' ');

                for (int k = 0; k < splitter.Length; k++)
                {
                    parsedWordsArray[element++] = splitter[k];
                }
            }

            // checking for any empty element in array and removing them
            parsedWordsArray = parsedWordsArray.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            // Finally, picking up only the 10 content words that appeared the most and arranging them w.r.t frequency of appearance
            var top10Words = (from words in parsedWordsArray
                              group words by words
                                  into grp
                                  let counter = grp.Count()
                                  orderby counter descending
                                  select grp.Key).Take(10);

            //        String[] topTenWords = top10Words.ToArray();
            //        for (int z = 0; z < topTenWords.Length; z++)
            //        {
            //            Console.WriteLine(topTenWords[z]);
            //        }

            return top10Words.ToArray();
        }

    }
}
