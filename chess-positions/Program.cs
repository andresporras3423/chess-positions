using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace chess
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    string cypher = Console.ReadLine();
        //    char[] c = cypher.ToCharArray();
        //    Array.Reverse(c);
        //    List<char> c2 = c.ToList<char>().FindAll(e => Regex.Match(e.ToString(), @"[1-9]").Success == false);
        //    string c3 = String.Join("", c2);
        //    Console.WriteLine(c3.ToUpper());
        //}


        //find nth item of the aritmetic progression, a is first term, b is second, n is the nth term
        //static void Main(string[] args)
        //{
        //    int a = int.Parse(Console.ReadLine());
        //    int d = int.Parse(Console.ReadLine());
        //    int n = int.Parse(Console.ReadLine());
        //    Console.WriteLine(a + d * (n - 1));
        //}

        //static void Main(string[] args)
        //{
        //    string[] inputs = Console.ReadLine().Split(' ');
        //    string[] vals = { "mon", "di", "tri", "tetr", "pent", "hex", "hept", "oct", "non", "dec" };
        //    string[] vals2 = { "", "di", "tri", "tetra", "penta", "hexa", "hepta", "octa", "nona", "deca" };
        //    int nNum = int.Parse(inputs[0]);
        //    string n = inputs[1];
        //    int oNum = int.Parse(Console.ReadLine());
        //    char[] ns = n.ToCharArray();
        //    Boolean first = Regex.Match(ns[0].ToString(), @"[aeiou]").Success;
        //    Console.WriteLine((first ? vals[nNum-1] : vals2[nNum - 1]) +n+" "+vals[oNum-1]+"oxide");
        //}

        // having n, sum all the 2^m when m is each number from 0 till n-1
        // static void Main(string[] args)
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    int[] nums = Enumerable.Range(0, n).ToArray();
        //    Console.WriteLine(nums.Sum(e => Math.Pow(2, e)));
        //}

        //return last character of the string
        //static void Main(string[] args)
        //{
        //    string N = Console.ReadLine();
        //    char last = N.ToCharArray().LastOrDefault();
        //    Console.WriteLine(last);
        //}

        // convert every pair of characters to int, 00 is a blank space, 01 is a, 02 is b, 10 is j, etc.
        //static void Main(string[] args)
        //{
        //    char[] letters = " abcdefghijklmnopqrstuvwxyz".ToCharArray();
        //    char[] input = Console.ReadLine().ToCharArray();
        //    string sol = "";
        //    for (int i = 0; i < input.Length - 1; i += 2)
        //    {
        //        sol += letters[Convert.ToInt32(input[i] + "" + input[i + 1])];
        //    }
        //    Console.WriteLine(sol);
        //}

        //scramble string, each n characters the element is swapped by the previous one
        //static void Main(string[] args)
        //{
        //    char[] t = Console.ReadLine().ToCharArray();
        //    int n = int.Parse(Console.ReadLine());
        //    for (int i = 1; i < t.Length; i++)
        //    {
        //        if ((i + 1) % n == 0)
        //        {
        //            char temp = t[i];
        //            t[i] = t[i - 1];
        //            t[i - 1] = temp;
        //        }
        //    }
        //    Console.WriteLine(String.Join("", t));
        //}

        // convert from 12 hours system to 24 hours
        //static void Main(string[] args)
        //{
        //    char[] input = Console.ReadLine().ToCharArray();
        //    string sol = "";
        //    if (input[input.Length - 2] == 'P' && (input[0] + "" + input[1]!="12"))
        //    {
        //        string part1 = Convert.ToString(Convert.ToInt32(input[0] + "" + input[1]) + 12);
        //        sol = part1 + String.Join("", input).Substring(2, input.Length - 4);
        //    }
        //    else if(input[input.Length - 2] == 'A' && (input[0] + "" + input[1] == "12"))
        //    {
        //        sol = "00" + String.Join("", input).Substring(2, input.Length - 4);
        //    }
        //    else
        //    {
        //        sol = String.Join("", input);
        //    }
        //    Console.WriteLine(sol);
        //}


        // having an 8 x 8 matrix where lowercase letters represents black pieces, 
        // uppercase letters represents white pieces, and points represents squares with no pieces
        // find the difference between white and black score pieces
        // example: if black has king and pawn, and white has king and rook, then output is 4
        // if black has king, rook and pawn, and white has king and knight, then output is -3
        // output "equal" if both players have same score
        //static void Main(string[] args)
        //{
        //    Dictionary<string, Int32> wPieces =
        //new Dictionary<string, Int32>();
        //    Dictionary<string, Int32> bPieces =
        //    new Dictionary<string, Int32>();
        //    wPieces.Add("P", 1);
        //    wPieces.Add("N", 3);
        //    wPieces.Add("B", 3);
        //    wPieces.Add("R", 5);
        //    wPieces.Add("Q", 9);
        //    wPieces.Add("K", 5);
        //    bPieces.Add("p", 1);
        //    bPieces.Add("n", 3);
        //    bPieces.Add("b", 3);
        //    bPieces.Add("r", 5);
        //    bPieces.Add("q", 9);
        //    bPieces.Add("k", 5);
        //    int N = int.Parse(Console.ReadLine());
        //    int whiteScore = 0;
        //    int blackScore = 0;
        //    for (int i = 0; i < N; i++)
        //    {
        //        char[] S = Console.ReadLine().ToCharArray();
        //        for (int j = 0; j < S.Length; j++)
        //        {
        //            if (Regex.Match(S[j].ToString(), @"[A-Z]").Success)
        //            {
        //                whiteScore += wPieces[S[j].ToString()];
        //            }
        //            else if (Regex.Match(S[j].ToString(), @"[a-z]").Success)
        //            {
        //                blackScore += bPieces[S[j].ToString()];
        //            }
        //        }
        //    }
        //    int diff = whiteScore - blackScore;
        //    Console.WriteLine(diff == 0 ? "equal" : diff.ToString());
        //}


        //sum ascii codes of each character, sum two times the value if it is even
        //static void Main(string[] args)
        //{
        //    string s = Console.ReadLine();
        //    int[] asciis = s.Select(x => (int)x % 2 == 0 ? (int)x * 2 : (int)x).ToArray<Int32>();
        //    Console.WriteLine(asciis.Sum());
        //}

        // if 2:
        //01
        //10
        //if 3:
        //101
        //010
        //101
        //if 4:
        //0101
        //1010
        //0101
        //1010
        //if 5:
        //10101
        //01010
        //10101
        //01010
        //10101
        //static void Main(string[] args)
        //{
        //    int N = int.Parse(Console.ReadLine());
        //    int x = 0;
        //    if (N % 2 == 1) x = 1;
        //    for (int i = 0; i < N; i++)
        //    {
        //        string line = "";
        //        for (int j = 0; j < N; j++)
        //        {
        //            line += (i + j + x) % 2;
        //        }
        //        Console.WriteLine(line);
        //    }
        //}

        // divide number of numbers and number of alphabet characters in the given string
        // round to the nearest integer
        //static void Main(string[] args)
        //{
        //    char[] input = Console.ReadLine().ToCharArray();
        //    float nums = 0f;
        //    float lets = 0f;
        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        if (Regex.Match(input[i].ToString(), @"[0-9]").Success) nums++;
        //        else if (Regex.Match(input[i].ToString(), @"[A-Za-z]").Success) lets++;
        //    }
        //    Console.WriteLine(Math.Round(lets / nums));
        //}

        // follow the The Collatz conjecture (if even split by 2, otherwise multiple by 3 and then sum 1)
        // count how many steps until arrive 1
        //static void Main(string[] args)
        //{
        //    long N = long.Parse(Console.ReadLine());
        //    int s = 0;
        //    while (N > 1)
        //    {
        //        if ((N % 2) == 0) N = (N / 2);
        //        else N = (N * 3) + 1;
        //        s++;
        //    }
        //    Console.WriteLine(s);
        //}

        //input numbers X and Y
        //return the sum of the digits of X**Y
        //static void Main(string[] args)
        //{
        //    int X = int.Parse(Console.ReadLine());
        //    int Y = int.Parse(Console.ReadLine());
        //    char[] Z = Convert.ToString(Math.Pow(X, Y)).ToCharArray();
        //    Console.WriteLine(Z.Sum(a => Int32.Parse(a.ToString())));
        //}

        //input: Hello World
        //output: 2
        //input: LOL, what a funny guy
        //output: 3
        //input:Who is Jordan Peterson?
        //output: 3
        //static void Main(string[] args)
        //{
        //    char[] input = Console.ReadLine().ToCharArray();
        //    Console.WriteLine(input.Count(x => Regex.Match(x.ToString(), @"[A-Z]").Success));
        //}




        //input: 
        //2
        //B 4
        //output:
        //4 4
        //input:
        //3
        //B*C 4 6
        //output
        //24 4 6
        //note: always at most operation between two values. There is always a solution
        //static void Main(string[] args)
        //{
        //    char[] a = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        //    int n = int.Parse(Console.ReadLine());
        //    string[] inputs = Console.ReadLine().Split(' ');
        //    Dictionary<char, string> sols = new Dictionary<char, string>();
        //    for (int i = 0; i < n; i++)
        //    {
        //        sols[a[i]] = inputs[i];
        //    }
        //    bool follow = true;
        //    while (follow)
        //    {
        //        follow = false;
        //        for (int i = 0; i < n; i++)
        //        {
        //            String[] vals = sols[a[i]].Split("*");
        //            if (vals.Length > 1)
        //            {
        //                follow = true;
        //                string val1 = Regex.Match(vals[0], @"^[0-9]+$").Success ? vals[0] : (Regex.Match(sols[vals[0][0]], @"^[0-9]+$").Success ? sols[vals[0][0]]  :  vals[0]);
        //                string val2 = Regex.Match(vals[1], @"^[0-9]+$").Success ? vals[1] : (Regex.Match(sols[vals[1][0]], @"^[0-9]+$").Success ? sols[vals[1][0]] : vals[1]);
        //                if(Regex.Match(val1, @"^[0-9]+$").Success && Regex.Match(val2, @"^[0-9]+$").Success)
        //                {
        //                    sols[a[i]] = (Int32.Parse(val1) * Int32.Parse(val2)).ToString();
        //                }
        //            }
        //            else
        //            {
        //                if (Regex.Match(sols[a[i]], @"^[0-9]+$").Success) continue;
        //                else if (!Regex.Match(sols[a[i]], @"^[0-9]+$").Success && Regex.Match(sols[sols[a[i]][0]], @"^[0-9]+$").Success) sols[a[i]] = sols[sols[a[i]][0]];
        //                else follow = true;
        //            }
        //        }
        //    }
        //    Console.WriteLine(String.Join(" ", sols.Values));
        //}


        // Given two sentences, s_1 and s_2, return whether they are shadows of each other.This means that all of the word lengths are the same and words in corresponding positions don't share any common letters whatsoever.
        // If shadow sentences: print shadow
        // else print the reason that they are not shadows(check in the order provided):
        // not the same amount of words in both strings
        // some of the corresponding words not the same length
        // shared letters in corresponding words
        //static void Main(string[] args)
        //{
        //    string[] s1 = Console.ReadLine().Split(" ");
        //    string[] s2 = Console.ReadLine().Split(" ");
        //    if (s1.Length != s2.Length)
        //    {
        //        Console.WriteLine("not the same amount of words in both strings");
        //        return;
        //    }

        //    for (int i = 0; i < s1.Length; i++)
        //    {
        //        char[] s01 = s1[i].ToCharArray();
        //        char[] s02 = s2[i].ToCharArray();
        //        if (s01.Length != s02.Length)
        //        {
        //            Console.WriteLine("some of the corresponding words not the same length");
        //            return;
        //        }
        //    }
        //    for (int i = 0; i < s1.Length; i++)
        //    {
        //        char[] s01 = s1[i].ToCharArray();
        //        char[] s02 = s2[i].ToCharArray();
        //        for (int j = 0; j < s01.Length; j++)
        //        {
        //            if (s01[j] == s02[j])
        //            {
        //                Console.WriteLine("shared letters in corresponding words");
        //                return;
        //            }
        //        }
        //    }
        //    Console.WriteLine("shadow");
        //}


        // You are required to write a program that finds the number of vowels in each word of a sentence.
        //- Words are separated by a single space.
        //- The sentence may consist of letters, numbers and/or special characters.Specifically, it may contain any character in the range of characters having an ASCII value of 33 to 126 inclusive.
        //static void Main(string[] args)
        //{
        //    string[] sentence = Console.ReadLine().Split(" ");
        //    List<int> sols = new List<int>();
        //    for (int i = 0; i < sentence.Length; i++)
        //    {
        //        char[] word = sentence[i].ToCharArray();
        //        int total = 0;
        //        for (int j = 0; j < word.Length; j++)
        //        {
        //            if (Regex.Match(word[j].ToString(), @"[aeiouAEIOU]").Success)
        //            {
        //                total++;
        //            }
        //        }
        //        sols.Add(total);
        //    }
        //    Console.WriteLine(String.Join(" ", sols));
        //}


        // delete from string adjacent lower an uppercases from the same letter, repeat until no more can be deleted
        // input:
        // aBaAbbBc
        // output:
        // ac
        //static void Main(string[] args)
        //{
        //    char[] initial = Console.ReadLine().ToCharArray();
        //    bool keep = true;
        //    while (keep)
        //    {
        //        List<char> final = new List<char>();
        //        for (int i = 0; i < initial.Length; i++)
        //        {
        //            if (i== initial.Length-1)
        //            {
        //                final.Add(initial[i]);
        //            }
        //            else if (initial[i] == initial[i + 1] || (initial[i].ToString().ToLower() != initial[i + 1].ToString().ToLower()))
        //            {
        //                final.Add(initial[i]);
        //            }
        //            else
        //            {
        //                i++;
        //            }
        //        }
        //        if (String.Join("", initial) == String.Join("", final))
        //        {
        //            Console.WriteLine(String.Join("", final));
        //            return;
        //        }
        //        else
        //        {
        //            initial = final.ToArray();
        //        }
        //    }
        //}


        // from 1 to n, get all numbers who are palindrome in their binary version, then find the mean of those numbers
        // if the mean is also binary palindrome then write:
        // otherwise: 
        //static void Main(string[] args)
        //{
        //    int N = int.Parse(Console.ReadLine());
        //    if (N == 0)
        //    {
        //        Console.WriteLine("0 is a palindrome in binary");
        //        return;
        //    }
        //    else if (N == 1)
        //    {
        //        Console.WriteLine("1 is a palindrome in binary");
        //        return;
        //    }
        //    List<string> sols = new List<string>();
        //    sols.Add("0");
        //    sols.Add("1");
        //    List<string> list = new List<string>();
        //    list = sols.ToList();
        //    int j = 0;
        //    string current = "10";
        //    for (int i = 0; i <= N - 2; i++)
        //    {
        //        if (j == list.Count())
        //        {
        //            j = 0;
        //            list = sols.ToList();
        //            current = current + "0";
        //        }
        //        sols.Add(binary_sum(current, list[j]));
        //        j++;
        //    }
        //    int sum=0;
        //    int total = 0;
        //    for(int i=1; i<sols.Count(); i++)
        //    {
        //        string rev = String.Join("",sols[i].ToCharArray().Reverse());
        //        if (sols[i] == rev)
        //        {
        //            sum += i;
        //            total++;
        //        }
        //    }
        //    int solut = sum / total;
        //    string revSol = String.Join("", sols[solut].ToCharArray().Reverse());
        //    if (sols[solut]==revSol) Console.WriteLine($"{solut} is a palindrome in binary");
        //    else Console.WriteLine($"{solut} isn't a palindrome in binary");
        //}

        //static string binary_sum(string first, string second)
        //{
        //    char[] fArray = first.ToCharArray();
        //    char[] sArray = second.ToCharArray();
        //    Array.Reverse(fArray);
        //    Array.Reverse(sArray);
        //    string nSol = "";
        //    for(int i=0; i<first.Length || i<second.Length; i++)
        //    {
        //        nSol = (convert_to_zero(fArray, i) == '0' && convert_to_zero(sArray, i) == '0') ? "0" + nSol : "1" + nSol; 
        //    }
        //    return nSol;
        //}

        //static char convert_to_zero(char[] list, int i)
        //{
        //    try
        //    {
        //        return list[i];
        //    }
        //    catch
        //    {
        //        return '0';
        //    }
        //}

        // having a jigsaw puzzle of wxh size, where every figure has a bit in each side
        // except for outside figures, define how many bits are in total
        //static void Main(string[] args)
        //{
        //    string[] inputs = Console.ReadLine().Split(' ');
        //    int w = int.Parse(inputs[0]);
        //    int h = int.Parse(inputs[1]);
        //    Console.WriteLine((w + h + w + h - 8) * 1.5 + ((w - 2) * (h - 2) * 2) + 4);
        //}
    }
}
