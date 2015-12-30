using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HtmlAgilityPack;

namespace Top10ContentWordsWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        // Creating a hashset to save all the stop words so that we can use this hash set to filter out the stop words at the end.
        // CurrentCultureIgnoreCase is used to compare the words irrespective of their cases (especially the first character of each word).
        private HashSet<string> stopWords = new HashSet<string>(StringComparer.CurrentCultureIgnoreCase) {
        "a",
        "about",
        "above",
        "across",
        "after",
        "afterwards",
        "again",
        "against",
        "all",
        "almost",
        "alone",
        "along",
        "already",
        "also",
        "although",
        "always",
        "am",
        "among",
        "amongst",
        "amoungst",
        "amount",
        "an",
        "and",
        "another",
        "any",
        "anyhow",
        "anyone",
        "anything",
        "anyway",
        "anywhere",
        "are",
        "around",
        "as",
        "at",
        "back",
        "be",
        "became",
        "because",
        "become",
        "becomes",
        "becoming",
        "been",
        "before",
        "beforehand",
        "behind",
        "being",
        "below",
        "beside",
        "besides",
        "between",
        "beyond",
        "bill",
        "both",
        "bottom",
        "but",
        "by",
        "call",
        "can",
        "cannot",
        "cant",
        "co",
        "computer",
        "con",
        "could",
        "couldnt",
        "cry",
        "de",
        "describe",
        "detail",
        "do",
        "done",
        "down",
        "due",
        "during",
        "each",
        "eg",
        "eight",
        "either",
        "eleven",
        "else",
        "elsewhere",
        "empty",
        "enough",
        "etc",
        "even",
        "ever",
        "every",
        "everyone",
        "everything",
        "everywhere",
        "except",
        "few",
        "fifteen",
        "fify",
        "fill",
        "find",
        "fire",
        "first",
        "five",
        "for",
        "former",
        "formerly",
        "forty",
        "found",
        "four",
        "from",
        "front",
        "full",
        "further",
        "get",
        "give",
        "go",
        "had",
        "has",
        "hasnt",
        "have",
        "he",
        "hence",
        "her",
        "here",
        "hereafter",
        "hereby",
        "herein",
        "hereupon",
        "hers",
        "herse\"",
        "him",
        "himse\"",
        "his",
        "how",
        "however",
        "hundred",
        "i",
        "ie",
        "if",
        "in",
        "inc",
        "indeed",
        "interest",
        "into",
        "is",
        "it",
        "its",
        "itse\"",
        "keep",
        "last",
        "latter",
        "latterly",
        "least",
        "less",
        "ltd",
        "made",
        "many",
        "may",
        "me",
        "meanwhile",
        "might",
        "mill",
        "mine",
        "more",
        "moreover",
        "most",
        "mostly",
        "move",
        "much",
        "must",
        "my",
        "myse\"",
        "name",
        "namely",
        "neither",
        "never",
        "nevertheless",
        "next",
        "nine",
        "no",
        "nobody",
        "none",
        "noone",
        "nor",
        "not",
        "nothing",
        "now",
        "nowhere",
        "of",
        "off",
        "often",
        "on",
        "once",
        "one",
        "only",
        "onto",
        "or",
        "other",
        "others",
        "otherwise",
        "our",
        "ours",
        "ourselves",
        "out",
        "over",
        "own",
        "part",
        "per",
        "perhaps",
        "please",
        "put",
        "rather",
        "re",
        "same",
        "see",
        "seem",
        "seemed",
        "seeming",
        "seems",
        "serious",
        "several",
        "she",
        "should",
        "show",
        "side",
        "since",
        "sincere",
        "six",
        "sixty",
        "so",
        "some",
        "somehow",
        "someone",
        "something",
        "sometime",
        "sometimes",
        "somewhere",
        "still",
        "such",
        "system",
        "take",
        "ten",
        "than",
        "that",
        "the",
        "their",
        "them",
        "themselves",
        "then",
        "thence",
        "there",
        "thereafter",
        "thereby",
        "therefore",
        "therein",
        "thereupon",
        "these",
        "they",
        "thick",
        "thin",
        "third",
        "this",
        "those",
        "though",
        "three",
        "through",
        "throughout",
        "thru",
        "thus",
        "to",
        "together",
        "too",
        "top",
        "toward",
        "towards",
        "twelve",
        "twenty",
        "two",
        "vun",
        "under",
        "until",
        "up",
        "upon",
        "us",
        "very",
        "via",
        "was",
        "we",
        "well",
        "were",
        "what",
        "whatever",
        "when",
        "whence",
        "whenever",
        "where",
        "whereafter",
        "whereas",
        "whereby",
        "wherein",
        "whereupon",
        "wherever",
        "whether",
        "which",
        "while",
        "whither",
        "who",
        "whoever",
        "whole",
        "whom",
        "whose",
        "why",
        "will",
        "with",
        "within",
        "without",
        "would",
        "yet",
        "you",
        "your",
        "yours",
        "yourself",
        "yourselves"
    };

        public string[] Top10ContentWords(String url)
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

            // checking for any empty element in array and also removing all the stop words using the hashset developed at the beginning
            parsedWordsArray = parsedWordsArray.Where(x => !string.IsNullOrEmpty(x) && !stopWords.Contains(x)).ToArray();

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

            // returning the words as a string array
            return top10Words.ToArray();
        }
    }
}
